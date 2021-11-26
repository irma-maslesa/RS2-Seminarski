using Pelikula.API.Model.Anketa;
using Pelikula.CORE.Helper.Response;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Windows.Forms;

namespace Pelikula.WINUI.Forms.Anketa
{
    public partial class FrmAnketaDodajUredi : Form
    {
        private readonly ApiService _service = new ApiService("Anketa");

        private readonly int? _id;

        private AnketaResponse _initial = new AnketaResponse();
        private AnketaInsertRequest _insertRequest = new AnketaInsertRequest();
        private AnketaUpdateRequest _updateRequest = new AnketaUpdateRequest();

        public FrmAnketaDodajUredi(int? id = null)
        {
            _id = id;

            InitializeComponent();
        }

        private async void FrmAnketaDodajUredi_Load(object sender, EventArgs e)
        {
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            MinimizeBox = false;

            Text = "Dodaj anketu";

            if (_id.HasValue)
            {
                Text = "Uredi anketu";

                PayloadResponse<AnketaResponse> response = await _service.GetById<PayloadResponse<AnketaResponse>>(_id.Value);
                _initial = response.Payload;

                SetValues();
            }
        }

        private void SetValues()
        {
            txtNaslov.Text = _initial.Naslov;

            foreach (var odgovor in _initial.Odgovori)
            {
                if (odgovor.RedniBroj == 1)
                {
                    cbOdgovor1.Checked = true;
                    cbOdgovor1.Enabled = false;
                    txtOdgovor1.Text = odgovor.Odgovor;
                }
                if (odgovor.RedniBroj == 2)
                {
                    cbOdgovor2.Checked = true;
                    cbOdgovor2.Enabled = false;
                    txtOdgovor2.Text = odgovor.Odgovor;
                }
                if (odgovor.RedniBroj == 3)
                {
                    cbOdgovor3.Checked = true;
                    cbOdgovor3.Enabled = false;
                    txtOdgovor3.Text = odgovor.Odgovor;
                }
                if (odgovor.RedniBroj == 4)
                {
                    cbOdgovor4.Checked = true;
                    cbOdgovor4.Enabled = false;
                    txtOdgovor4.Text = odgovor.Odgovor;
                }
                if (odgovor.RedniBroj == 5)
                {
                    cbOdgovor5.Checked = true;
                    cbOdgovor5.Enabled = false;
                    txtOdgovor5.Text = odgovor.Odgovor;
                }
            }
        }

        private async void BtnSpremi_Click(object sender, EventArgs e)
        {
            if (ValidateChildren())
            {


                if (_id.HasValue)
                {
                    _updateRequest.Naslov = txtNaslov.Text;
                    _updateRequest.Datum = DateTime.Now;
                    _updateRequest.KorisnikId = _initial.Korisnik.Id;

                    _updateRequest.Odgovori = new List<AnketaOdgovorUpdateRequest>();

                    foreach (var odgovor in _initial.Odgovori)
                    {
                        var updateOdg = new AnketaOdgovorUpdateRequest();
                        updateOdg.AnketaId = _id.Value;
                        updateOdg.Id = odgovor.Id;
                        updateOdg.Odgovor = odgovor.Odgovor;
                        updateOdg.RedniBroj = odgovor.RedniBroj;

                        _updateRequest.Odgovori.Add(updateOdg);
                    }

                    if (cbOdgovor1.Checked)
                    {
                        var odgovor1 = _updateRequest.Odgovori.FirstOrDefault(x => x.RedniBroj == 1);
                        if (odgovor1 != null)
                        {
                            odgovor1.Odgovor = txtOdgovor1.Text;
                        }
                        else
                        {
                            _updateRequest.Odgovori.Add(new AnketaOdgovorUpdateRequest { AnketaId = _id.Value, Odgovor = txtOdgovor1.Text, RedniBroj = 1 });
                        }
                    }
                    if (cbOdgovor2.Checked)
                    {
                        var odgovor2 = _updateRequest.Odgovori.FirstOrDefault(x => x.RedniBroj == 2);
                        if (odgovor2 != null)
                        {
                            odgovor2.Odgovor = txtOdgovor2.Text;
                        }
                        else
                        {
                            _updateRequest.Odgovori.Add(new AnketaOdgovorUpdateRequest { AnketaId = _id.Value, Odgovor = txtOdgovor2.Text, RedniBroj = 2 });
                        }
                    }
                    if (cbOdgovor3.Checked)
                    {
                        var odgovor3 = _updateRequest.Odgovori.FirstOrDefault(x => x.RedniBroj == 3);
                        if (odgovor3 != null)
                        {
                            odgovor3.Odgovor = txtOdgovor3.Text;
                        }
                        else
                        {
                            _updateRequest.Odgovori.Add(new AnketaOdgovorUpdateRequest { AnketaId = _id.Value, Odgovor = txtOdgovor3.Text, RedniBroj = 3 });
                        }
                    }
                    if (cbOdgovor4.Checked)
                    {
                        var odgovor4 = _updateRequest.Odgovori.FirstOrDefault(x => x.RedniBroj == 4);
                        if (odgovor4 != null)
                        {
                            odgovor4.Odgovor = txtOdgovor4.Text;
                        }
                        else
                        {
                            _updateRequest.Odgovori.Add(new AnketaOdgovorUpdateRequest { AnketaId = _id.Value, Odgovor = txtOdgovor4.Text, RedniBroj = 4 });
                        }
                    }
                    if (cbOdgovor5.Checked)
                    {
                        var odgovor5 = _updateRequest.Odgovori.FirstOrDefault(x => x.RedniBroj == 5);
                        if (odgovor5 != null)
                        {
                            odgovor5.Odgovor = txtOdgovor5.Text;
                        }
                        else
                        {
                            _updateRequest.Odgovori.Add(new AnketaOdgovorUpdateRequest { AnketaId = _id.Value, Odgovor = txtOdgovor4.Text, RedniBroj = 5 });
                        }
                    }

                    await _service.Update<PayloadResponse<AnketaResponse>>(_id.Value, _updateRequest);
                    MessageBox.Show($"Anketa {txtNaslov.Text} uspješno uređena!", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    _insertRequest.Naslov = txtNaslov.Text;
                    _insertRequest.Datum = DateTime.Now;
                    _insertRequest.KorisnikId = Properties.Settings.Default.PrijavljeniKorisnik.Id;

                    var odgovori = new List<AnketaOdgovorInsertRequest>();
                    if (cbOdgovor1.Checked)
                    {
                        odgovori.Add(new AnketaOdgovorInsertRequest { Odgovor = txtOdgovor1.Text, RedniBroj = 1 });
                    }
                    if (cbOdgovor2.Checked)
                    {
                        odgovori.Add(new AnketaOdgovorInsertRequest { Odgovor = txtOdgovor2.Text, RedniBroj = 2 });
                    }
                    if (cbOdgovor3.Checked)
                    {
                        odgovori.Add(new AnketaOdgovorInsertRequest { Odgovor = txtOdgovor3.Text, RedniBroj = 3 });
                    }
                    if (cbOdgovor4.Checked)
                    {
                        odgovori.Add(new AnketaOdgovorInsertRequest { Odgovor = txtOdgovor4.Text, RedniBroj = 4 });
                    }
                    if (cbOdgovor5.Checked)
                    {
                        odgovori.Add(new AnketaOdgovorInsertRequest { Odgovor = txtOdgovor5.Text, RedniBroj = 5 });
                    }

                    _insertRequest.Odgovori = odgovori;

                    PayloadResponse<AnketaResponse> response = await _service.Insert<PayloadResponse<AnketaResponse>>(_insertRequest);
                    MessageBox.Show($"Anketa {response.Payload.Naslov} uspješno dodana!", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                DialogResult = DialogResult.OK;
                Close();
            }
        }

        private void BtnOcisti_Click(object sender, EventArgs e)
        {
            SetValues();
        }

        //VALIDACIJA
        private void txtNaslov_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(txtNaslov.Text.Trim()))
            {
                e.Cancel = true;
                err.SetError(txtNaslov, "Obavezno polje!");
            }
            else
            {
                err.SetError(txtNaslov, null);
            }
        }

        private void cbOdgovor2_CheckedChanged(object sender, EventArgs e)
        {
            if (cbOdgovor2.Checked)
            {
                txtOdgovor2.ReadOnly = false;
            }
            else
            {
                txtOdgovor2.Text = string.Empty;
                txtOdgovor2.ReadOnly = true;
            }
        }

        private void cbOdgovor1_CheckedChanged(object sender, EventArgs e)
        {
            if (cbOdgovor1.Checked)
            {
                txtOdgovor1.ReadOnly = false;
            }
            else
            {
                txtOdgovor1.Text = string.Empty;
                txtOdgovor1.ReadOnly = true;
            }
        }

        private void cbOdgovor3_CheckedChanged(object sender, EventArgs e)
        {
            if (cbOdgovor3.Checked)
            {
                txtOdgovor3.ReadOnly = false;
            }
            else
            {
                txtOdgovor3.Text = string.Empty;
                txtOdgovor3.ReadOnly = true;
            }
        }

        private void cbOdgovor4_CheckedChanged(object sender, EventArgs e)
        {
            if (cbOdgovor4.Checked)
            {
                txtOdgovor4.ReadOnly = false;
            }
            else
            {
                txtOdgovor4.Text = string.Empty;
                txtOdgovor4.ReadOnly = true;
            }
        }

        private void cbOdgovor5_CheckedChanged(object sender, EventArgs e)
        {
            if (cbOdgovor5.Checked)
            {
                txtOdgovor5.ReadOnly = false;
            }
            else
            {
                txtOdgovor5.Text = string.Empty;
                txtOdgovor5.ReadOnly = true;
            }
        }
    }
}
