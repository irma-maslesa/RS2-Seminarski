using Pelikula.API.Model;
using Pelikula.API.Model.Helper;
using Pelikula.API.Model.Dojam;
using Pelikula.CORE.Helper.Response;
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

        public FrmDojam()
        {
            InitializeComponent();
            dgvDojmovi.AutoGenerateColumns = false;
        }
        private async void FrmDojam_Load(object sender, EventArgs e)
        {
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

        private async void BtnPretrazi_Click(object sender, EventArgs e)
        {
            await GetGridData();
        }

        private async Task GetGridData(bool adding = false)
        {
            DisableChildren();

            int _currentIndex = dgvDojmovi.FirstDisplayedScrollingRowIndex;
            int? _selectedRowIndex = dgvDojmovi.CurrentRow?.Index;

            List<FilterUtility.FilterParams> filters = new List<FilterUtility.FilterParams>();

            CreateCbFilters(filters, cbProjekcija, "ProjekcijaId");
            CreateCbFilters(filters, cbKorisnik, "KorisnikId");

            Cursor = Cursors.WaitCursor;

            PagedPayloadResponse<DojamResponse> obj = await _service.Get<PagedPayloadResponse<DojamResponse>>(null, filters, null);

            dgvDojmovi.DataSource = obj.Payload;

            dgvDojmovi.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvDojmovi.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            if (filters.Count == 0 && _selectedRowIndex.HasValue)
                dgvDojmovi.ClearSelection();

            Cursor = Cursors.Default;

            EnableChildren();

            if (adding)
            {
                dgvDojmovi.FirstDisplayedScrollingRowIndex = dgvDojmovi.RowCount - 1;
            }
            else if (!adding && _currentIndex >= 0 && _currentIndex < dgvDojmovi.RowCount)
            {
                dgvDojmovi.FirstDisplayedScrollingRowIndex = _currentIndex;
            }
            else if (!adding && _currentIndex < 0 && dgvDojmovi.RowCount > 0)
            {
                dgvDojmovi.FirstDisplayedScrollingRowIndex = 0;
            }

            if (adding)
            {
                dgvDojmovi.CurrentCell = dgvDojmovi.Rows[dgvDojmovi.RowCount - 1].Cells[0];
                dgvDojmovi.Rows[dgvDojmovi.RowCount - 1].Selected = true;
            }
            else if (!adding && filters.Count == 0 && _selectedRowIndex.HasValue && _selectedRowIndex.Value >= dgvDojmovi.RowCount)
            {
                dgvDojmovi.CurrentCell = dgvDojmovi.Rows[_selectedRowIndex.Value - 1].Cells[0];
                dgvDojmovi.Rows[_selectedRowIndex.Value - 1].Selected = true;
            }
            else if (!adding && filters.Count == 0 && _selectedRowIndex.HasValue)
            {
                dgvDojmovi.CurrentCell = dgvDojmovi.Rows[_selectedRowIndex.Value].Cells[0];
                dgvDojmovi.Rows[_selectedRowIndex.Value].Selected = true;
            }
        }

        private void CreateCbFilters(List<FilterUtility.FilterParams> filters, ComboBox cb, string columnName)
        {
            if (cb.SelectedItem != null && ((LoV)cb.SelectedItem).Id != -1)
            {
                FilterUtility.FilterParams filter = new FilterUtility.FilterParams
                {
                    ColumnName = columnName,
                    FilterOption = FilterUtility.FilterOptions.startswith.ToString(),
                    FilterValue = ((LoV)cb.SelectedItem).Id.ToString()
                };


                filters.Add(filter);
            }
        }


        private void EnableChildren()
        {
            cbKorisnik.Enabled = true;
            cbProjekcija.Enabled = true;

            dgvDojmovi.Enabled = true;
        }

        private void DisableChildren()
        {
            cbKorisnik.Enabled = false;
            cbProjekcija.Enabled = false;

            dgvDojmovi.Enabled = false;
        }

        private async void CbKorisnik_SelectedValueChanged(object sender, EventArgs e)
        {
            await GetGridData();
        }

        private async void CbProjekcija_SelectedValueChanged(object sender, EventArgs e)
        {
            await GetGridData();
        }
    }
}
