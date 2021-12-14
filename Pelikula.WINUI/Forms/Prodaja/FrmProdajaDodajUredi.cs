using Pelikula.API.Model;
using Pelikula.API.Model.Artikal;
using Pelikula.API.Model.Helper;
using Pelikula.API.Model.Korisnik;
using Pelikula.API.Model.Prodaja;
using Pelikula.API.Model.Projekcija;
using Pelikula.API.Model.Rezervacija;
using Pelikula.CORE.Helper.Response;
using Pelikula.WINUI.Forms.Korisnik;
using Pelikula.WINUI.Forms.Projekcija;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Pelikula.WINUI.Forms.Prodaja
{
    public partial class FrmProdajaDodajUredi : Form
    {
        private readonly ApiService _service = new ApiService("Prodaja");

        private readonly ApiService _projekcijaService = new ApiService("Projekcija");
        private readonly ApiService _rezervacijaService = new ApiService("Rezervacija");
        private readonly ApiService _korisnikService = new ApiService("Korisnik");
        private readonly ApiService _salaService = new ApiService("Sala");
        private readonly ApiService _artikalService = new ApiService("Artikal");
        private readonly KorisnikResponse _prijavljeniKorisnik;

        private int _salaId = 0;

        private ProdajaInsertRequest _request = new ProdajaInsertRequest();
        private readonly RezervacijaUpsertRequest _rezervacijaRequest = new RezervacijaUpsertRequest();

        IEnumerable<LoV> projekcijaList = new List<LoV>();
        IEnumerable<RezervacijaSimpleResponse> rezervacijaList = new List<RezervacijaSimpleResponse>();
        IEnumerable<LoV> terminList = new List<LoV>();
        IEnumerable<LoV> korisnikList = new List<LoV>();
        IEnumerable<LoV> sjedistaList = new List<LoV>();
        IEnumerable<LoV> zauzetaSjedistaList = new List<LoV>();

        public FrmProdajaDodajUredi() {
            InitializeComponent();
            dgvArtikli.AutoGenerateColumns = false;
            _prijavljeniKorisnik = Properties.Settings.Default.PrijavljeniKorisnik;
        }

        private async void FrmProdajaDodajUredi_Load(object sender, EventArgs e) {
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            MinimizeBox = false;

            Text = "Dodaj kupovinu";
            txtCijenaArtikli.Text = 0.ToString("0.00");
            txtCijenaProjekcija.Text = 0.ToString("0.00");
            txtCijenaUkupno.Text = 0.ToString("0.00");

            List<FilterUtility.FilterParams> filters = new List<FilterUtility.FilterParams>
            {
                new FilterUtility.FilterParams("DatumProdano", null, FilterUtility.FilterOptions.isequalto.ToString()),
                new FilterUtility.FilterParams("DatumOtkazano", null, FilterUtility.FilterOptions.isequalto.ToString())
            };

            rezervacijaList = (await _rezervacijaService.GetSimple(null, filters, null)).Payload.OrderBy(o => o.Naziv).ToList();
            cbRezervacija.DataSource = rezervacijaList;
            cbRezervacija.DisplayMember = "Naziv";
            cbRezervacija.ValueMember = "Id";
            cbRezervacija.SelectedItem = rezervacijaList.FirstOrDefault();
            UpdateProjekcijaCijena(rezervacijaList.FirstOrDefault()?.Cijena);

            await GetGridData();

            cbTipProdaje.Items.AddRange(new object[] { TipProdaje.SA_REZERVACIJOM, TipProdaje.SA_PROJEKCIJOM, TipProdaje.PRODAJA_ARTIKLA });
            cbTipProdaje.DisplayMember = "Naziv";
            cbTipProdaje.ValueMember = "Id";
            cbTipProdaje.SelectedIndex = 0;

            gbRezervacija.Visible = true;
            gbInformacije.Visible = false;
            btnOdaberiSjedista.Visible = false;
            btnOdaberiSjedista.Enabled = false;
        }

        private async Task GetGridData() {
            Cursor = Cursors.WaitCursor;

            PagedPayloadResponse<ArtikalResponse> obj = await _artikalService.Get<PagedPayloadResponse<ArtikalResponse>>(null, null, null);

            dgvArtikli.DataSource = obj.Payload;
            dgvArtikli.Columns["Kolicina"].ValueType = typeof(int);

            dgvArtikli.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            Cursor = Cursors.Default;

        }

        private void SetValues() {
            cbTipProdaje.SelectedIndex = 0;

            cbProjekcija.SelectedItem = projekcijaList.FirstOrDefault();
            cbRezervacija.SelectedItem = rezervacijaList.FirstOrDefault();
            cbTermin.SelectedItem = terminList.FirstOrDefault();
            cbKorisnik.SelectedItem = korisnikList.FirstOrDefault();

        }

        private async void BtnSpremi_Click(object sender, EventArgs e) {
            var tipProdaje = cbTipProdaje.SelectedItem.ToString();
            _request = new ProdajaInsertRequest();

            switch (tipProdaje) {
                case TipProdaje.SA_REZERVACIJOM:
                    if (cbRezervacija.SelectedItem == null) {
                        err.SetError(cbRezervacija, "Obavezno polje!");
                        return;
                    }
                    else {
                        err.SetError(cbRezervacija, null);
                    }
                    _request.RezervacijaId = ((RezervacijaSimpleResponse)cbRezervacija.SelectedItem).Id;
                    break;
                case TipProdaje.SA_PROJEKCIJOM:
                    await KreirajRezervaciju();
                    if (!_request.RezervacijaId.HasValue)
                        return;

                    break;
                default:
                    break;

            }
            _request.KorisnikId = _prijavljeniKorisnik.Id;
            _request.ProdajaArtikal = GetArtikle();

            if (tipProdaje == TipProdaje.PRODAJA_ARTIKLA && (_request.ProdajaArtikal == null || _request.ProdajaArtikal.Count == 0)) {
                err.SetError(gbArtikli, "Obavezno polje!");
                return;
            }
            else {
                err.SetError(gbArtikli, null);
            }

            PayloadResponse<ProdajaResponse> response = await _service.Insert<PayloadResponse<ProdajaResponse>>(_request);

            if (response != null) {
                MessageBox.Show($"Prodaja {response.Payload.BrojRacuna} uspješno dodana!", "", MessageBoxButtons.OK, MessageBoxIcon.Information);

                DialogResult = DialogResult.OK;
                Close();
            }
        }

        private ICollection<ProdajaArtikalInsertRequest> GetArtikle() {
            var artikli = new List<ProdajaArtikalInsertRequest>();

            foreach (DataGridViewRow red in dgvArtikli.Rows) {
                bool odabrano = false;

                if (red.Cells["Izaberi"].Value != null)
                    odabrano = bool.Parse(red.Cells["Izaberi"].Value.ToString());

                if (odabrano && red.Cells["Kolicina"].Value != null && int.Parse(red.Cells["Kolicina"].Value.ToString()) > 0) {
                    int id = int.Parse(red.Cells["Id"].Value.ToString());
                    int kolicina = int.Parse(red.Cells["Kolicina"].Value.ToString());

                    artikli.Add(new ProdajaArtikalInsertRequest {
                        ArtikalId = id,
                        Kolicina = kolicina
                    });
                }
            }

            return artikli;
        }

        private async Task KreirajRezervaciju() {
            if (_rezervacijaRequest.SjedistaIds == null || _rezervacijaRequest.SjedistaIds.Count == 0) {
                err.SetError(btnOdaberiSjedista, "Obavezno odabrati bar jedno sjedište!");
                return;
            }
            else {
                err.SetError(btnOdaberiSjedista, null);
            }

            if (cbKorisnik.SelectedItem == null) {
                err.SetError(cbKorisnik, "Obavezno polje!");
                return;
            }
            else {
                err.SetError(cbKorisnik, null);
            }

            if (ValidateChildren()) {
                _rezervacijaRequest.ProjekcijaTerminId = ((LoV)cbTermin.SelectedItem).Id;
                _rezervacijaRequest.KorisnikId = ((LoV)cbKorisnik.SelectedItem).Id;
                _rezervacijaRequest.BrojSjedista = _rezervacijaRequest.SjedistaIds.Count;
                _rezervacijaRequest.Datum = DateTime.Now;

                PayloadResponse<RezervacijaResponse> response = await _rezervacijaService.Insert<PayloadResponse<RezervacijaResponse>>(_rezervacijaRequest);

                if (response != null) {
                    _request.RezervacijaId = response.Payload.Id;
                    _request.Datum = response.Payload.Datum;
                    UpdateProjekcijaCijena(response.Payload.Cijena);
                    UpdateUkupnaCijena();
                }
            }
        }

        private void BtnOcisti_Click(object sender, EventArgs e) {
            RemoveArtikli();
            if (_rezervacijaRequest.SjedistaIds != null)
                _rezervacijaRequest.SjedistaIds.Clear();

            SetValues();
        }

        private void RemoveArtikli() {
            foreach (DataGridViewRow red in dgvArtikli.Rows) {
                bool odabrano = false;

                if (red.Cells["Izaberi"].Value != null)
                    odabrano = bool.Parse(red.Cells["Izaberi"].Value.ToString());

                if (odabrano) {
                    red.Cells["Izaberi"].Value = false;
                    red.Cells["Kolicina"].ReadOnly = true;
                    red.Cells["Kolicina"].Value = null;
                }
            }

            txtCijenaArtikli.Text = 0.ToString("0.00");
            UpdateUkupnaCijena();
        }

        private async void CbProjekcija_SelectedValueChanged(object sender, EventArgs e) {
            var data = (LoV)cbProjekcija.SelectedItem;
            if (data != null) {
                var salaId = (await _projekcijaService.GetById<PayloadResponse<ProjekcijaResponse>>(data.Id)).Payload.Sala.Id;

                terminList = (await _projekcijaService.GetAktivniTermini(data.Id)).Payload.OrderBy(o => o.Naziv).ToList();

                cbTermin.Enabled = true;

                cbTermin.DataSource = terminList;
                cbTermin.DisplayMember = "Naziv";
                cbTermin.ValueMember = "Id";

                if (terminList.FirstOrDefault() == null) {
                    cbTermin.Enabled = false;
                    cbKorisnik.Enabled = false;
                    btnDodajKorisnika.Enabled = false;
                    dgvArtikli.Enabled = false;
                    btnSpremi.Enabled = false;

                    MessageBox.Show("Nema dostupnih termina za odabranu projekciju!", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                else {
                    cbTermin.Enabled = true;
                    dgvArtikli.Enabled = true;
                    btnSpremi.Enabled = true;
                }


                if (_salaId != salaId) {
                    _salaId = salaId;
                    sjedistaList = (await _salaService.GetSjedista(data.Id)).Payload;

                    if (_rezervacijaRequest.SjedistaIds != null)
                        _rezervacijaRequest.SjedistaIds.Clear();
                }
            }
        }

        private async void CbTermin_SelectedValueChanged(object sender, EventArgs e) {
            var data = (LoV)cbTermin.SelectedItem;

            if (data != null) {
                cbKorisnik.Enabled = true;
                korisnikList = (await _korisnikService.GetKlijentiForTermin(data.Id, true)).Payload.OrderBy(o => o.Naziv).ToList();

                zauzetaSjedistaList = (await _salaService.GetZauzetaSjedista(data.Id)).Payload;
                btnOdaberiSjedista.Enabled = true;
            }

            cbKorisnik.DataSource = korisnikList;
            cbKorisnik.DisplayMember = "Naziv";
            cbKorisnik.ValueMember = "Id";
            cbKorisnik.SelectedItem = korisnikList.FirstOrDefault();
        }

        private void BtnOdaberiSjedista_Click(object sender, EventArgs e) {
            FrmOdabirSjedista frm = new FrmOdabirSjedista(sjedistaList, zauzetaSjedistaList, _rezervacijaRequest.SjedistaIds?.ToList()) {
                StartPosition = FormStartPosition.CenterScreen
            };

            if (frm.ShowDialog() == DialogResult.OK) {
                var odabrano = frm.OdabranaSjedista;
                _rezervacijaRequest.SjedistaIds = odabrano;

                if (_rezervacijaRequest.SjedistaIds != null && _rezervacijaRequest.SjedistaIds.Count > 0) {
                    err.SetError(btnOdaberiSjedista, null);
                }
            }
        }

        private async void BtnDodajKorisnika_Click(object sender, EventArgs e) {
            FrmKorisnikDodajUredi frm = new FrmKorisnikDodajUredi {
                StartPosition = FormStartPosition.CenterParent
            };

            if (frm.ShowDialog() == DialogResult.OK) {
                var data = (LoV)cbTermin.SelectedItem;
                korisnikList = (await _korisnikService.GetKlijentiForTermin(data.Id, true)).Payload.OrderBy(o => o.Naziv).ToList();
                cbKorisnik.DataSource = korisnikList;
            }
        }

        private void BtnProjekcijaInfo_Click(object sender, EventArgs e) {
            FrmProjekcijaDodajUredi frm = new FrmProjekcijaDodajUredi(((LoV)cbProjekcija.SelectedItem).Id, true);
            frm.ShowDialog();
        }

        private void DgvArtikli_CellValueChanged(object sender, DataGridViewCellEventArgs e) {
            if (dgvArtikli.Columns[e.ColumnIndex].Name.Equals("Izaberi")) {
                UpdateArtikliKolicina();
                if (dgvArtikli.Rows[e.RowIndex].Cells["Izaberi"].Value != null && bool.Parse(dgvArtikli.Rows[e.RowIndex].Cells["Izaberi"].Value.ToString()))
                    dgvArtikli.CurrentCell = dgvArtikli.Rows[e.RowIndex].Cells["Kolicina"];
            }

            if (dgvArtikli.Columns[e.ColumnIndex].Name.Equals("Kolicina"))
                UpdateArtikliCijena();
        }

        private void UpdateArtikliCijena() {
            decimal artikliCijena = 0;

            foreach (DataGridViewRow red in dgvArtikli.Rows) {
                decimal cijena = 0;
                int kolicina = 0;


                if (red.Cells["Cijena"].Value != null)
                    cijena = decimal.Parse(red.Cells["Cijena"].Value.ToString());
                if (red.Cells["Kolicina"].Value != null)
                    kolicina = int.Parse(red.Cells["Kolicina"].Value.ToString());

                artikliCijena += cijena * kolicina;
            }

            txtCijenaArtikli.Text = artikliCijena.ToString("0.00");
            UpdateUkupnaCijena();
        }

        private void UpdateUkupnaCijena() {
            decimal artikliCijena = decimal.Parse(txtCijenaArtikli.Text);
            decimal projekcijaCijena = decimal.Parse(txtCijenaProjekcija.Text);

            txtCijenaUkupno.Text = (artikliCijena + projekcijaCijena).ToString("0.00");
        }

        private void UpdateProjekcijaCijena(decimal? cijena) {
            if (cijena.HasValue)
                txtCijenaProjekcija.Text = cijena.Value.ToString("0.00");
        }

        private void UpdateArtikliKolicina() {
            foreach (DataGridViewRow red in dgvArtikli.Rows) {
                bool odabrano = false;

                if (red.Cells["Izaberi"].Value != null)
                    odabrano = bool.Parse(red.Cells["Izaberi"].Value.ToString());

                if (odabrano) {
                    red.Cells["Kolicina"].ReadOnly = false;
                    if (red.Cells["Kolicina"].Value == null)
                        red.Cells["Kolicina"].Value = 1;
                }
                else {
                    red.Cells["Kolicina"].Value = null;
                    red.Cells["Kolicina"].ReadOnly = true;
                }
            }
        }

        private void DgvArtikli_CellContentClick(object sender, DataGridViewCellEventArgs e) {
            dgvArtikli.CommitEdit(DataGridViewDataErrorContexts.Commit);
        }

        private void CbRezervacija_SelectedValueChanged(object sender, EventArgs e) {
            var rezervacija = (RezervacijaSimpleResponse)cbRezervacija.SelectedItem;

            if (rezervacija != null) {
                UpdateProjekcijaCijena(rezervacija.Cijena);
                UpdateUkupnaCijena();
            }
        }

        private async void CbTipProdaje_SelectedIndexChanged(object sender, EventArgs e) {
            var data = cbTipProdaje.SelectedItem?.ToString();

            switch (data) {
                case TipProdaje.SA_REZERVACIJOM:
                    err.Clear();

                    gbRezervacija.Visible = true;
                    gbInformacije.Visible = false;
                    btnOdaberiSjedista.Visible = false;
                    cbProjekcija.SelectedItem = null;
                    txtCijenaProjekcija.Visible = true;
                    lblCijenaProjekcija.Visible = true;

                    if (rezervacijaList.FirstOrDefault() == null) {
                        cbRezervacija.Enabled = false;
                        dgvArtikli.Enabled = false;
                        btnSpremi.Enabled = false;
                        MessageBox.Show("Nema kreiranih rezervacija!", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else {
                        cbRezervacija.Enabled = true;
                        dgvArtikli.Enabled = true;
                        btnSpremi.Enabled = true;
                    }

                    break;
                case TipProdaje.SA_PROJEKCIJOM:
                    err.Clear();

                    txtCijenaProjekcija.Text = 0.ToString("0.00");
                    gbRezervacija.Visible = false;
                    gbInformacije.Visible = true;
                    btnOdaberiSjedista.Visible = true;
                    btnOdaberiSjedista.Enabled = false;

                    var filters = new List<FilterUtility.FilterParams>
                    {
                        new FilterUtility.FilterParams("VrijediOd", DateTime.Now.ToString(), FilterUtility.FilterOptions.islessthanorequalto.ToString()),
                        new FilterUtility.FilterParams("VrijediDo", DateTime.Now.ToString(), FilterUtility.FilterOptions.isgreaterthanorequalto.ToString())
                    };

                    projekcijaList = (await _projekcijaService.GetLoVs<PagedPayloadResponse<LoV>>(null, filters, null)).Payload.OrderBy(o => o.Naziv).ToList();
                    cbProjekcija.DataSource = projekcijaList;
                    cbProjekcija.DisplayMember = "Naziv";
                    cbProjekcija.ValueMember = "Id";

                    cbTermin.Enabled = false;
                    cbKorisnik.Enabled = false;

                    if (projekcijaList.FirstOrDefault() == null) {
                        cbProjekcija.Enabled = false;
                        btnDodajKorisnika.Enabled = false;
                        dgvArtikli.Enabled = false;
                        btnSpremi.Enabled = false;

                        MessageBox.Show("Nema dostupnih projekcija!", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else {
                        cbProjekcija.Enabled = true;
                        dgvArtikli.Enabled = true;
                        btnSpremi.Enabled = true;
                    }

                    txtCijenaProjekcija.Visible = true;
                    lblCijenaProjekcija.Visible = true;

                    dgvArtikli.Enabled = true;
                    btnSpremi.Enabled = true;
                    break;
                case TipProdaje.PRODAJA_ARTIKLA:
                    err.Clear();

                    gbRezervacija.Visible = false;
                    gbInformacije.Visible = false;
                    btnOdaberiSjedista.Visible = false;
                    cbProjekcija.SelectedItem = null;
                    txtCijenaProjekcija.Visible = false;
                    lblCijenaProjekcija.Visible = false;

                    dgvArtikli.Enabled = true;
                    btnSpremi.Enabled = true;
                    break;
                default:
                    break;
            }
        }


        //VALIDACIJA

        private void CbProjekcija_Validating(object sender, CancelEventArgs e) {
            if (cbProjekcija.SelectedItem == null) {
                e.Cancel = true;
                err.SetError(cbProjekcija, "Obavezno polje!");
            }
            else {
                err.SetError(cbProjekcija, null);
            }
        }

        private void CbTermin_Validating(object sender, CancelEventArgs e) {
            if (cbTermin.SelectedItem == null) {
                e.Cancel = true;
                err.SetError(cbTermin, "Obavezno polje!");
            }
            else {
                err.SetError(cbTermin, null);
            }
        }

        private void CbKorisnik_SelectedIndexChanged(object sender, EventArgs e) {
            var data = (LoV)cbKorisnik.SelectedItem;

            if (data != null) {
                btnOdaberiSjedista.Enabled = true;
            }
        }

    }

    static class TipProdaje
    {
        public const string SA_REZERVACIJOM = "Prodaja sa rezervacijom";
        public const string SA_PROJEKCIJOM = "Prodaja sa projekcijom";
        public const string PRODAJA_ARTIKLA = "Prodaja artikala";
    }
}
