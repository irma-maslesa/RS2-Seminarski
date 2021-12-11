using Pelikula.API;
using Pelikula.API.Model;
using Pelikula.API.Model.Helper;
using Pelikula.API.Model.Projekcija;
using Pelikula.API.Model.Rezervacija;
using Pelikula.CORE.Helper.Response;
using Pelikula.WINUI.Forms.Korisnik;
using Pelikula.WINUI.Forms.Prodaja;
using Pelikula.WINUI.Forms.Projekcija;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace Pelikula.WINUI.Forms.Rezervacija
{
    public partial class FrmRezervacijaDodajUredi : Form
    {
        private readonly ApiService _service = new ApiService("Rezervacija");

        private readonly ApiService _projekcijaService = new ApiService("Projekcija");
        private readonly ApiService _korisnikService = new ApiService("Korisnik");
        private readonly ApiService _salaService = new ApiService("Sala");
        private readonly int? _id;
        private int _salaId = 0;

        private RezervacijaResponse _initial = new RezervacijaResponse();
        private readonly RezervacijaUpsertRequest _request = new RezervacijaUpsertRequest();

        IEnumerable<LoV> projekcijaList = new List<LoV>();
        IEnumerable<LoV> terminList = new List<LoV>();
        IEnumerable<LoV> korisnikList = new List<LoV>();
        IEnumerable<LoV> sjedistaList = new List<LoV>();
        IEnumerable<LoV> zauzetaSjedistaList = new List<LoV>();

        public FrmRezervacijaDodajUredi(int? id = null)
        {
            _id = id;

            InitializeComponent();
        }

        private async void FrmRezervacijaDodajUredi_Load(object sender, EventArgs e)
        {
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            MinimizeBox = false;

            Text = "Dodaj rezervaciju";

            var filters = new List<FilterUtility.FilterParams>();
            CreateFilter(filters);

            projekcijaList = (await _projekcijaService.GetLoVs<PagedPayloadResponse<LoV>>(null, filters, null)).Payload.OrderBy(o => o.Naziv).ToList();
            cbProjekcija.DataSource = projekcijaList;
            cbProjekcija.DisplayMember = "Naziv";
            cbProjekcija.ValueMember = "Id";

            cbTermin.Enabled = false;
            cbKorisnik.Enabled = false;

            if (_id.HasValue)
            {
                cbProjekcija.Enabled = false;

                btnDodajKorisnika.Enabled = false;

                Text = "Uredi rezervaciju";

                PayloadResponse<RezervacijaResponse> response = await _service.GetById<PayloadResponse<RezervacijaResponse>>(_id.Value);
                _initial = response.Payload;

                SetValues();
            }
        }

        private static void CreateFilter(List<FilterUtility.FilterParams> filters)
        {
            var filter1 = new FilterUtility.FilterParams
            {
                ColumnName = "VrijediOd",
                FilterOption = FilterUtility.FilterOptions.islessthanorequalto.ToString(),
                FilterValue = DateTime.Now.ToString()
            };
            filters.Add(filter1);


            var filter2 = new FilterUtility.FilterParams
            {
                ColumnName = "VrijediDo",
                FilterOption = FilterUtility.FilterOptions.isgreaterthanorequalto.ToString(),
                FilterValue = DateTime.Now.ToString()
            };
            filters.Add(filter2);
        }

        private void SetValues()
        {
            cbProjekcija.SelectedItem = projekcijaList.FirstOrDefault(e => e.Id == _initial.ProjekcijaTermin?.Projekcija?.Id);

            var rezervisanaSjedistaIds = _initial.Sjedista.Select(e => e.Sjediste.Id).ToList();
            _request.SjedistaIds = rezervisanaSjedistaIds;
        }

        private async void BtnSpremi_Click(object sender, EventArgs e)
        {
            if (_request.SjedistaIds == null || _request.SjedistaIds.Count == 0)
            {
                err.SetError(btnOdaberiSjedista, "Obavezno odabrati bar jedno sjediste!");
                return;
            }
            else
            {
                err.SetError(btnOdaberiSjedista, null);
            }

            if (cbKorisnik.SelectedItem == null)
            {
                err.SetError(cbKorisnik, "Obavezno polje!");
                return;
            }
            else
            {
                err.SetError(cbKorisnik, null);
            }

            if (ValidateChildren())
            {
                _request.ProjekcijaTerminId = ((LoV)cbTermin.SelectedItem).Id;
                _request.KorisnikId = ((LoV)cbKorisnik.SelectedItem).Id;
                _request.BrojSjedista = _request.SjedistaIds.Count;
                _request.Datum = DateTime.Now;

                if (_id.HasValue)
                {
                    var response = await _service.Update<PayloadResponse<RezervacijaResponse>>(_id.Value, _request);

                    if (response != null)
                    {
                        MessageBox.Show($"Rezervacija {response.Payload.ProjekcijaTermin.Projekcija} - {response.Payload.Korisnik} - {response.Payload.BrojSjedista} uspješno uređena!", "", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        DialogResult = DialogResult.OK;
                        Close();
                    }
                }
                else
                {
                    PayloadResponse<RezervacijaResponse> response = await _service.Insert<PayloadResponse<RezervacijaResponse>>(_request);

                    if (response != null)
                    {
                        MessageBox.Show($"Rezervacija {response.Payload.ProjekcijaTermin.Projekcija} - {response.Payload.Korisnik} - {response.Payload.BrojSjedista} uspješno dodana!", "", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        DialogResult = DialogResult.OK;
                        Close();
                    }
                }
            }
        }

        private void BtnOcisti_Click(object sender, EventArgs e)
        {
            if (_request.SjedistaIds != null)
                _request.SjedistaIds.Clear();

            SetValues();
        }

        private async void CbProjekcija_SelectedValueChanged(object sender, EventArgs e)
        {
            var data = (LoV)cbProjekcija.SelectedItem;
            var salaId = (await _projekcijaService.GetById<PayloadResponse<ProjekcijaResponse>>(data.Id)).Payload.Sala.Id;

            terminList = (await _projekcijaService.GetAktivniTermini(data.Id)).Payload.OrderBy(o => o.Naziv).ToList();

            if (!_id.HasValue)
                cbTermin.Enabled = true;
            else
                cbTermin.Enabled = false;

            cbTermin.DataSource = terminList;
            cbTermin.DisplayMember = "Naziv";
            cbTermin.ValueMember = "Id";
            cbTermin.SelectedItem = terminList.FirstOrDefault(o => o.Id == _initial.ProjekcijaTermin?.Id);

            if (cbTermin.SelectedItem == null)
                cbTermin.SelectedItem = terminList.FirstOrDefault();


            if (_salaId != salaId)
            {
                _salaId = salaId;
                sjedistaList = (await _salaService.GetSjedista(data.Id)).Payload;
            }

        }

        private async void CbTermin_SelectedValueChanged(object sender, EventArgs e)
        {
            var data = (LoV)cbTermin.SelectedItem;

            if (data != null)
            {
                if (!_id.HasValue)
                {
                    cbKorisnik.Enabled = true;
                    korisnikList = (await _korisnikService.GetKlijentiForTermin(data.Id, true)).Payload.OrderBy(o => o.Naziv).ToList();
                }
                else
                {
                    cbKorisnik.Enabled = false;
                    korisnikList = (await _korisnikService.GetKlijentiForTermin(data.Id, false)).Payload.OrderBy(o => o.Naziv).ToList();
                }

                zauzetaSjedistaList = (await _salaService.GetZauzetaSjedista(data.Id)).Payload;
            }

            cbKorisnik.DataSource = korisnikList;
            cbKorisnik.DisplayMember = "Naziv";
            cbKorisnik.ValueMember = "Id";
            cbKorisnik.SelectedItem = korisnikList.FirstOrDefault(o => o.Id == _initial.Korisnik?.Id);

            if (cbKorisnik.SelectedItem == null)
                cbKorisnik.SelectedItem = korisnikList.FirstOrDefault();

        }

        private void BtnOdaberiSjedista_Click(object sender, EventArgs e)
        {
            FrmOdabirSjedista frm = new FrmOdabirSjedista(sjedistaList, zauzetaSjedistaList, _request.SjedistaIds?.ToList())
            {
                StartPosition = FormStartPosition.CenterScreen
            };

            if (frm.ShowDialog() == DialogResult.OK)
            {
                var odabrano = frm.OdabranaSjedista;
                _request.SjedistaIds = odabrano;

                if (_request.SjedistaIds != null && _request.SjedistaIds.Count > 0)
                {
                    err.SetError(btnOdaberiSjedista, null);
                }
            }
        }

        //VALIDACIJA

        private void CbProjekcija_Validating(object sender, CancelEventArgs e)
        {
            if (cbProjekcija.SelectedItem == null)
            {
                e.Cancel = true;
                err.SetError(cbProjekcija, "Obavezno polje!");
            }
            else
            {
                err.SetError(cbProjekcija, null);
            }
        }

        private void CbTermin_Validating(object sender, CancelEventArgs e)
        {
            if (cbTermin.SelectedItem == null)
            {
                e.Cancel = true;
                err.SetError(cbTermin, "Obavezno polje!");
            }
            else
            {
                err.SetError(cbTermin, null);
            }
        }

        private async void BtnDodajKorisnika_Click(object sender, EventArgs e)
        {
            FrmKorisnikDodajUredi frm = new FrmKorisnikDodajUredi
            {
                StartPosition = FormStartPosition.CenterParent
            };

            if (frm.ShowDialog() == DialogResult.OK)
            {
                var data = (LoV)cbTermin.SelectedItem;
                korisnikList = (await _korisnikService.GetKlijentiForTermin(data.Id, true)).Payload.OrderBy(o => o.Naziv).ToList();
                cbKorisnik.DataSource = korisnikList;
            }
        }

        private void BtnProjekcijaInfo_Click(object sender, EventArgs e)
        {
            FrmProjekcijaDodajUredi frm = new FrmProjekcijaDodajUredi(((LoV)cbProjekcija.SelectedItem).Id, true);
            frm.ShowDialog();
        }
    }
}
