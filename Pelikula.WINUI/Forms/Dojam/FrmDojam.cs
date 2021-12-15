using Pelikula.API.Model;
using Pelikula.API.Model.Dojam;
using Pelikula.API.Model.Helper;
using Pelikula.CORE.Helper.Response;
using Pelikula.WINUI.Helpers;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Pelikula.WINUI.Forms.Dojam
{
    public partial class FrmDojam : Form
    {
        private readonly ApiService _service = new ApiService("Dojam");
        private readonly ApiService _korisnikService = new ApiService("Korisnik");
        private readonly ApiService _projekcijaService = new ApiService("Projekcija");

        List<LoV> korisnikList = new List<LoV>();
        List<LoV> projekcijaList = new List<LoV>();

        public FrmDojam() {
            InitializeComponent();
            dgvDojmovi.AutoGenerateColumns = false;
        }
        private async void FrmDojam_Load(object sender, EventArgs e) {
            DisableChildren();

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

            await GetGridData();
        }

        private async void BtnPretrazi_Click(object sender, EventArgs e) {
            await GetGridData();
        }

        private async Task GetGridData(bool adding = false) {
            DisableChildren();

            int _currentIndex = dgvDojmovi.FirstDisplayedScrollingRowIndex;

            int? _selectedRowIndex = null;
            if (dgvDojmovi.SelectedRows.Count > 0)
                _selectedRowIndex = dgvDojmovi.SelectedRows[0].Index;

            List<FilterUtility.FilterParams> filters = new List<FilterUtility.FilterParams>();

            FormHelper.CreateCbFilters(filters, cbProjekcija, "ProjekcijaId");
            FormHelper.CreateCbFilters(filters, cbKorisnik, "KorisnikId");

            Cursor = Cursors.WaitCursor;

            PagedPayloadResponse<DojamResponse> obj = await _service.Get<PagedPayloadResponse<DojamResponse>>(null, filters, null);

            dgvDojmovi.DataSource = obj.Payload;

            dgvDojmovi.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            if (filters.Count == 0 && _selectedRowIndex.HasValue)
                dgvDojmovi.ClearSelection();

            Cursor = Cursors.Default;

            EnableChildren();

            FormHelper.SelectAndShowDgvRow(dgvDojmovi, adding, _currentIndex, _selectedRowIndex, filters);
        }

        private void EnableChildren() {
            cbKorisnik.Enabled = true;
            cbProjekcija.Enabled = true;

            dgvDojmovi.Enabled = true;
        }

        private void DisableChildren() {
            cbKorisnik.Enabled = false;
            cbProjekcija.Enabled = false;

            dgvDojmovi.Enabled = false;
        }

        private async void CbKorisnik_SelectedValueChanged(object sender, EventArgs e) {
            await GetGridData();
        }

        private async void CbProjekcija_SelectedValueChanged(object sender, EventArgs e) {
            await GetGridData();
        }
    }
}
