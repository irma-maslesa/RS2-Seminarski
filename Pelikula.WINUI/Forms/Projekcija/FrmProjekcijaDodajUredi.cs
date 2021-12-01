using Pelikula.API.Model;
using Pelikula.API.Model.Projekcija;
using Pelikula.CORE.Helper.Response;
using Pelikula.WINUI.Forms.Film;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Windows.Forms;

namespace Pelikula.WINUI.Forms.Projekcija
{
    public partial class FrmProjekcijaDodajUredi : Form
    {
        private readonly ApiService _service = new ApiService("Projekcija");
        private readonly ApiService _filmService = new ApiService("Film");
        private readonly ApiService _salaService = new ApiService("Sala");

        private readonly int? _id;

        private ProjekcijaResponse _initial = new ProjekcijaResponse();
        private readonly ProjekcijaUpsertRequest _request = new ProjekcijaUpsertRequest();

        List<LoV> filmList = new List<LoV>();
        List<LoV> salaList = new List<LoV>();

        public FrmProjekcijaDodajUredi(int? id = null)
        {
            _id = id;

            InitializeComponent();
        }

        private async void FrmProjekcijaDodajUredi_Load(object sender, EventArgs e)
        {
            EnableTerminiCb(false, true, false, false, false, false);
            CheckTerminiCb();
            EnableDp(true, false, false, false, false, false);

            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            MinimizeBox = false;

            Text = "Dodaj projekciju";

            filmList = (await _filmService.GetLoVs<PagedPayloadResponse<LoV>>(null, null, null)).Payload.OrderBy(o => o.Naziv).ToList();
            cbFilm.DataSource = filmList;
            cbFilm.DisplayMember = "Naziv";
            cbFilm.ValueMember = "Id";

            salaList = (await _salaService.GetLoVs<PagedPayloadResponse<LoV>>(null, null, null)).Payload.OrderBy(o => o.Naziv).ToList();
            cbSala.DataSource = salaList;
            cbSala.DisplayMember = "Naziv";
            cbSala.ValueMember = "Id";

            if (_id.HasValue)
            {
                DisableControls();

                Text = "Uredi projekciju";

                PayloadResponse<ProjekcijaResponse> response = await _service.GetById<PayloadResponse<ProjekcijaResponse>>(_id.Value);
                _initial = response.Payload;

                SetValues();
            }
        }

        private void EnableDp(bool v1, bool v2, bool v3, bool v4, bool v5, bool v6)
        {
            dtpTermin1.Enabled = v1;
            dtpTermin2.Enabled = v2;
            dtpTermin3.Enabled = v3;
            dtpTermin4.Enabled = v4;
            dtpTermin5.Enabled = v5;
            dtpTermin6.Enabled = v6;
        }

        private void CheckTerminiCb()
        {
            cbTermin1.Checked = true;
            cbTermin2.Checked = false;
            cbTermin3.Checked = false;
            cbTermin4.Checked = false;
            cbTermin5.Checked = false;
            cbTermin6.Checked = false;
        }

        private void DisableControls()
        {
            dtpVrijediDo.Enabled = false;
            dtpVrijediOd.Enabled = false;
        }

        private void SetValues()
        {
            cbFilm.SelectedItem = filmList.FirstOrDefault(e => e.Id == _initial.Film?.Id);
            cbSala.SelectedItem = salaList.FirstOrDefault(e => e.Id == _initial.Sala?.Id);
            txtCijena.Text = _initial.Cijena.ToString("0000.00");
            dtpVrijediOd.Value = _initial.VrijediOd.Date;
            dtpVrijediDo.Value = _initial.VrijediOd.Date;

            SetTermine();
        }

        private void SetTermine()
        {
            var termini = _initial.Termini.Select(e => DateTime.ParseExact(e.Naziv, "dd/MM/yyyy, HH:mm", null).TimeOfDay).ToList();
            var distinctTermini = termini.Distinct().ToList();

            int i = 0;
            foreach (var t in distinctTermini)
            {
                i++;

                switch (i)
                {
                    case 1:
                        cbTermin1.Checked = true;
                        EnableTerminiCb(true, true, false, false, false, false);
                        EnableDp(true, false, false, false, false, false);
                        dtpTermin1.Value = DateTime.Now.Date + t;
                        break;
                    case 2:
                        cbTermin2.Checked = true;
                        EnableTerminiCb(true, true, true, false, false, false);
                        EnableDp(true, true, false, false, false, false);
                        dtpTermin2.Value = DateTime.Now.Date + t;
                        break;
                    case 3:
                        cbTermin3.Checked = true;
                        EnableTerminiCb(true, true, true, true, false, false);
                        EnableDp(true, true, true, false, false, false);
                        dtpTermin3.Value = DateTime.Now.Date + t;
                        break;
                    case 4:
                        cbTermin4.Checked = true;
                        EnableTerminiCb(true, true, true, true, true, false);
                        EnableDp(true, true, true, true, false, false);
                        dtpTermin4.Value = DateTime.Now.Date + t;
                        break;
                    case 5:
                        cbTermin5.Checked = true;
                        EnableTerminiCb(true, true, true, true, true, true);
                        EnableDp(true, true, true, true, true, false);
                        dtpTermin5.Value = DateTime.Now.Date + t;
                        break;
                    case 6:
                        cbTermin6.Checked = true;
                        EnableTerminiCb(true, true, true, true, true, true);
                        EnableDp(true, true, true, true, true, true);
                        dtpTermin6.Value = DateTime.Now.Date + t;
                        break;
                    default:
                        break;
                }
            }
        }

        private void EnableTerminiCb(bool v1, bool v2, bool v3, bool v4, bool v5, bool v6)
        {
            cbTermin1.Enabled = v1;
            cbTermin2.Enabled = v2;
            cbTermin3.Enabled = v3;
            cbTermin4.Enabled = v4;
            cbTermin5.Enabled = v5;
            cbTermin6.Enabled = v6;
        }

        private async void BtnSpremi_Click(object sender, EventArgs e)
        {
            if (ValidateChildren())
            {
                _request.FilmId = ((LoV)cbFilm.SelectedItem).Id;
                _request.SalaId = ((LoV)cbSala.SelectedItem).Id;

                _request.Cijena = decimal.Parse(txtCijena.Text);
                _request.VrijediOd = dtpVrijediOd.Value;
                _request.VrijediDo = dtpVrijediDo.Value;
                _request.Datum = DateTime.Now;

                _request.ProjekcijaTermin = GetTermini();

                if (_id.HasValue)
                {
                    PayloadResponse<ProjekcijaResponse> response = await _service.Update<PayloadResponse<ProjekcijaResponse>>(_id.Value, _request);

                    if (response != null)
                    {
                        MessageBox.Show($"Projekcija {((LoV)cbFilm.SelectedItem).Naziv} - {((LoV)cbSala.SelectedItem).Naziv} ({_request.VrijediOd:dd/MM/yyyy} - {_request.VrijediDo:dd/MM/yyyy}) uspješno uređena!", "", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        DialogResult = DialogResult.OK;
                        Close();
                    }
                }
                else
                {
                    PayloadResponse<ProjekcijaResponse> response = await _service.Insert<PayloadResponse<ProjekcijaResponse>>(_request);

                    if (response != null)
                    {
                        MessageBox.Show($"Projekcija {((LoV)cbFilm.SelectedItem).Naziv} - {((LoV)cbSala.SelectedItem).Naziv} ({_request.VrijediOd:dd/MM/yyyy} - {_request.VrijediDo:dd/MM/yyyy}) uspješno uređena!", "", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        DialogResult = DialogResult.OK;
                        MessageBox.Show($"Projekcija  {response.Payload.Film.Naziv} - {response.Payload.Sala.Naziv} ({response.Payload.VrijediOd:dd/MM/yyyy} - {response.Payload.VrijediDo:dd/MM/yyyy}) uspješno dodana!", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }


            }
        }

        private List<ProjekcijaTerminUpsertRequest> GetTermini()
        {
            var termini = new List<ProjekcijaTerminUpsertRequest>();
            var datum = DateTime.Now.Date;
            termini.Add(new ProjekcijaTerminUpsertRequest { Termin = datum + new TimeSpan(dtpTermin1.Value.Hour, dtpTermin1.Value.Minute, 0) });
            if (cbTermin2.Checked)
            {
                termini.Add(new ProjekcijaTerminUpsertRequest { Termin = datum + new TimeSpan(dtpTermin2.Value.Hour, dtpTermin2.Value.Minute, 0) });
            }
            if (cbTermin3.Checked)
            {
                termini.Add(new ProjekcijaTerminUpsertRequest { Termin = datum + new TimeSpan(dtpTermin3.Value.Hour, dtpTermin3.Value.Minute, 0) });
            }
            if (cbTermin4.Checked)
            {
                termini.Add(new ProjekcijaTerminUpsertRequest { Termin = datum + new TimeSpan(dtpTermin4.Value.Hour, dtpTermin4.Value.Minute, 0) });
            }
            if (cbTermin5.Checked)
            {
                termini.Add(new ProjekcijaTerminUpsertRequest { Termin = datum + new TimeSpan(dtpTermin5.Value.Hour, dtpTermin5.Value.Minute, 0) });
            }
            if (cbTermin6.Checked)
            {
                termini.Add(new ProjekcijaTerminUpsertRequest { Termin = datum + new TimeSpan(dtpTermin6.Value.Hour, dtpTermin6.Value.Minute, 0) });
            }

            return termini;
        }

        private void BtnOcisti_Click(object sender, EventArgs e)
        {
            SetValues();

        }

        private void CbTermin2_CheckedChanged(object sender, EventArgs e)
        {
            dtpTermin2.Enabled = cbTermin2.Checked;
            cbTermin3.Enabled = cbTermin2.Checked;
        }
        private void CbTermin3_CheckedChanged(object sender, EventArgs e)
        {
            dtpTermin3.Enabled = cbTermin3.Checked;
            cbTermin4.Enabled = cbTermin3.Checked;
        }
        private void CbTermin4_CheckedChanged(object sender, EventArgs e)
        {
            dtpTermin4.Enabled = cbTermin4.Checked;
            cbTermin5.Enabled = cbTermin4.Checked;
        }
        private void CbTermin5_CheckedChanged(object sender, EventArgs e)
        {
            dtpTermin5.Enabled = cbTermin5.Checked;
            cbTermin6.Enabled = cbTermin5.Checked;
        }
        private void CbTermin6_CheckedChanged(object sender, EventArgs e)
        {
            dtpTermin6.Enabled = cbTermin6.Checked;
        }

        //VALIDACIJA
        private void TxtCijena_Validating(object sender, CancelEventArgs e)
        {
            var cijenaText = txtCijena.Text.Trim().Replace(",", "");
            if (string.IsNullOrEmpty(cijenaText))
            {
                e.Cancel = true;
                err.SetError(txtCijena, "Obavezno polje!");
            }
            else
            {
                try
                {
                    decimal.Parse(txtCijena.Text);
                    err.SetError(txtCijena, null);
                }
                catch
                {
                    e.Cancel = true;
                    err.SetError(txtCijena, "Neispravan format!");
                }
            }
        }

        private void Dtp_Validating(object sender, CancelEventArgs e)
        {
            if (dtpVrijediOd.Value.Date > dtpVrijediDo.Value.Date)
            {
                e.Cancel = true;
                err.SetError(dtpVrijediOd, "Neispravna vrijednost");
                err.SetError(dtpVrijediDo, "Neispravna vrijednost");
            }
            else
            {
                err.SetError(dtpVrijediOd, null);
                err.SetError(dtpVrijediDo, null);
            }
        }

        private void DtpVrijediOd_ValueChanged(object sender, EventArgs e)
        {
            dtpVrijediDo.MinDate = dtpVrijediOd.Value.Date;
        }

        private void DtpVrijediDo_ValueChanged(object sender, EventArgs e)
        {
            dtpVrijediOd.MaxDate = dtpVrijediDo.Value.Date;
        }

        private void BtnFilmInfo_Click(object sender, EventArgs e)
        {
            FrmFilmDodajUredi frm = new FrmFilmDodajUredi(((LoV)cbFilm.SelectedItem).Id, true);
            frm.ShowDialog();
        }
    }
}
