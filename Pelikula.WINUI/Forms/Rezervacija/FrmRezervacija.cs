using Pelikula.API.Model;
using Pelikula.API.Model.Helper;
using Pelikula.API.Model.Rezervacija;
using Pelikula.CORE.Helper.Response;
using Pelikula.WINUI.Helpers;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Pelikula.WINUI.Forms.Rezervacija
{
    public partial class FrmRezervacija : Form
    {
        private readonly ApiService _service = new ApiService("Rezervacija");
        private readonly ApiService _korisnikService = new ApiService("Korisnik");
        private readonly ApiService _projekcijaService = new ApiService("Projekcija");

        List<LoV> korisnikList = new List<LoV>();
        List<LoV> projekcijaList = new List<LoV>();
        List<LoV> terminList = new List<LoV>();

        public FrmRezervacija() {
            InitializeComponent();
            dgvRezervacije.AutoGenerateColumns = false;
        }
        private async void FrmRezervacija_Load(object sender, EventArgs e) {
            DisableChildren();
            cbTermin.Enabled = false;

            korisnikList = (await _korisnikService.GetLoVs<PagedPayloadResponse<LoV>>(null, null, null)).Payload.OrderBy(o => o.Naziv).ToList();
            korisnikList.Insert(0, new LoV { Id = -1, Naziv = "Sve" });

            cbKorisnik.DataSource = korisnikList;
            cbKorisnik.SelectedItem = korisnikList.FirstOrDefault(o => o.Id == -1);
            cbKorisnik.DisplayMember = "Naziv";
            cbKorisnik.ValueMember = "Id";

            projekcijaList = (await _projekcijaService.GetLoVs<PagedPayloadResponse<LoV>>(null, null, null)).Payload.OrderBy(o => o.Naziv).ToList();
            projekcijaList.Insert(0, new LoV { Id = -1, Naziv = "Sve" });

            cbProjekcija.DataSource = projekcijaList;
            cbProjekcija.SelectedItem = projekcijaList.FirstOrDefault(o => o.Id == -1);
            cbProjekcija.DisplayMember = "Naziv";
            cbProjekcija.ValueMember = "Id";

            cbStatus.Items.AddRange(new object[] { "Sve", "Na čekanju", "Prodane", "Otkazane" });
            cbStatus.DisplayMember = "Naziv";
            cbStatus.ValueMember = "Id";
            cbStatus.SelectedIndex = 0;

            await GetGridData();
        }

        private async Task GetGridData(bool adding = false) {
            DisableChildren();

            int _currentIndex = dgvRezervacije.FirstDisplayedScrollingRowIndex;
            int? _selectedRowIndex = null;

            if (dgvRezervacije.SelectedRows.Count > 0)
                _selectedRowIndex = dgvRezervacije.SelectedRows[0]?.Index;

            List<FilterUtility.FilterParams> filters = new List<FilterUtility.FilterParams>();

            if (cbTermin.Enabled)
                FormHelper.CreateCbFilters(filters, cbTermin, "ProjekcijaTerminId");

            FormHelper.CreateCbFilters(filters, cbKorisnik, "KorisnikId");
            CreateCbStatusFilter(filters);

            Cursor = Cursors.WaitCursor;

            PagedPayloadResponse<RezervacijaResponse> obj = await _service.GetRezervacijaNotProdaja(null, filters, null);

            if (obj != null)
                dgvRezervacije.DataSource = obj.Payload;

            dgvRezervacije.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            if (filters.Count == 0 && _selectedRowIndex.HasValue)
                dgvRezervacije.ClearSelection();

            Cursor = Cursors.Default;

            EnableChildren();

            if (dgvRezervacije.RowCount == 0) {
                btnUredi.Enabled = false;
                btnObrisi.Enabled = false;
                btnOtkazi.Enabled = false;
            }
            else {
                btnUredi.Enabled = true;
                btnObrisi.Enabled = true;
                btnOtkazi.Enabled = true;
            }

            FormHelper.SelectAndShowDgvRow(dgvRezervacije, adding, _currentIndex, _selectedRowIndex, filters);
            DgvRezervacije_SelectionChanged(null, null);
        }

        private void CreateCbStatusFilter(List<FilterUtility.FilterParams> filters) {
            var selectedItem = cbStatus.SelectedItem?.ToString();

            switch (selectedItem) {
                case "Na čekanju":
                    filters.Add(new FilterUtility.FilterParams("DatumProdano", null, FilterUtility.FilterOptions.isequalto.ToString()));
                    filters.Add(new FilterUtility.FilterParams("DatumOtkazano", null, FilterUtility.FilterOptions.isequalto.ToString()));
                    break;
                case "Prodane":
                    filters.Add(new FilterUtility.FilterParams("DatumProdano", null, FilterUtility.FilterOptions.isnotequalto.ToString()));
                    break;
                case "Otkazane":
                    filters.Add(new FilterUtility.FilterParams("DatumOtkazano", null, FilterUtility.FilterOptions.isnotequalto.ToString()));
                    break;
                default:
                    break;
            }
        }

        private void EnableChildren() {
            cbKorisnik.Enabled = true;
            cbProjekcija.Enabled = true;
            cbStatus.Enabled = true;

            btnDodaj.Enabled = true;
            btnUredi.Enabled = true;
            btnOtkazi.Enabled = true;
            btnObrisi.Enabled = true;

            dgvRezervacije.Enabled = true;
        }

        private void DisableChildren() {
            cbKorisnik.Enabled = false;
            cbProjekcija.Enabled = false;
            cbStatus.Enabled = false;

            btnDodaj.Enabled = false;
            btnUredi.Enabled = false;
            btnOtkazi.Enabled = false;
            btnObrisi.Enabled = false;

            dgvRezervacije.Enabled = false;
        }

        private async void CbKorisnik_SelectedValueChanged(object sender, EventArgs e) {
            await GetGridData();
        }

        private async void CbTermin_SelectedValueChanged(object sender, EventArgs e) {
            await GetGridData();
        }

        private async void CbProjekcija_SelectedValueChanged(object sender, EventArgs e) {
            if (cbProjekcija.SelectedItem != null && ((LoV)cbProjekcija.SelectedItem).Id != -1) {
                terminList = (await _projekcijaService.GetTermini(((LoV)cbProjekcija.SelectedItem).Id)).Payload.OrderBy(o => o.Naziv).ToList();

                cbTermin.Enabled = true;
                cbTermin.DataSource = terminList;
                cbTermin.DisplayMember = "Naziv";
                cbTermin.ValueMember = "Id";
            }
            else {
                cbTermin.Enabled = false;
                await GetGridData();
            }
        }

        private async void CbStatus_SelectedValueChanged(object sender, EventArgs e) {
            await GetGridData();
        }

        private void DgvRezervacije_SelectionChanged(object sender, EventArgs e) {
            RezervacijaResponse data = null;

            if (dgvRezervacije.SelectedRows.Count > 0)
                data = (RezervacijaResponse)dgvRezervacije.SelectedRows[0].DataBoundItem;

            if(data != null && data.ProjekcijaTermin.Termin < DateTime.Now) {
                btnUredi.Enabled = false;
                btnOtkazi.Enabled = true;
            }
            else if (data != null && (data.DatumOtkazano != null || data.DatumProdano != null)) {
                btnOtkazi.Enabled = false;
                btnUredi.Enabled = false;
            }
            else {
                btnOtkazi.Enabled = true;
                btnUredi.Enabled = true;
            }
        }

        private async void BtnOtkazi_Click(object sender, EventArgs e) {
            var data = (RezervacijaResponse)dgvRezervacije.SelectedRows[0].DataBoundItem;

            if (MessageBox.Show($"Jeste li sigurni da želite otkazati rezervaciju {data.ProjekcijaTermin.Projekcija} - {data.Korisnik} - {data.BrojSjedista}? ", "Upozorenje", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes) {
                await _service.OtkaziRezervaciju(data.Id);
                await GetGridData();
            }
        }

        private async void BtnDodaj_Click(object sender, EventArgs e) {
            FrmRezervacijaDodajUredi frm = new FrmRezervacijaDodajUredi {
                StartPosition = FormStartPosition.CenterParent
            };

            if (frm.ShowDialog() == DialogResult.OK)
                await GetGridData(adding: true);
        }

        private async void BtnUredi_Click(object sender, EventArgs e) {
            FrmRezervacijaDodajUredi frm = new FrmRezervacijaDodajUredi(((RezervacijaResponse)dgvRezervacije.SelectedRows[0].DataBoundItem).Id) {
                StartPosition = FormStartPosition.CenterParent
            };

            if (frm.ShowDialog() == DialogResult.OK)
                await GetGridData();
        }
        private async void BtnObrisi_Click(object sender, EventArgs e) {
            RezervacijaResponse data = (RezervacijaResponse)dgvRezervacije.SelectedRows[0].DataBoundItem;

            if (MessageBox.Show($"Jeste li sigurni da želite obrisati rezervaciju {data.ProjekcijaTermin.Projekcija} - {data.Korisnik} - {data.BrojSjedista}?", "Upozorenje", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes) {
                await _service.Delete(data.Id);
                await GetGridData();
            }
        }
    }
}
