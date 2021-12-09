using Pelikula.API.Model.Helper;
using Pelikula.API.Model.FilmskaLicnost;
using Pelikula.CORE.Helper.Response;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Pelikula.WINUI.Forms.FilmskaLicnost
{
    public partial class FrmFilmskaLicnost : Form
    {
        private readonly ApiService _service = new ApiService("FilmskaLicnost");


        public FrmFilmskaLicnost()
        {
            InitializeComponent();
        }

        private async void FrmFilmskaLicnost_Load(object sender, EventArgs e)
        {
            DisableChildren();

            cbVrsta.Items.AddRange(new object[] { "Svi", "Glumac", "Režiser" });
            cbVrsta.DisplayMember = "Naziv";
            cbVrsta.ValueMember = "Id";
            cbVrsta.SelectedIndex = 0;

            await GetGridData();
        }

        private async void BtnPretrazi_Click(object sender, EventArgs e)
        {
            await GetGridData();
        }

        private async Task GetGridData(bool adding = false)
        {
            DisableChildren();

            int _currentIndex = dgvFilmskeLicnosti.FirstDisplayedScrollingRowIndex;
            int? _selectedRowIndex = dgvFilmskeLicnosti.CurrentRow?.Index;

            List<FilterUtility.FilterParams> filters = new List<FilterUtility.FilterParams>();
            CreateFilters(filters, txtIme, "Ime");
            CreateFilters(filters, txtPrezime, "Prezime");
            CreateCbVrstaFilter(filters);
            Cursor = Cursors.WaitCursor;

            PagedPayloadResponse<FilmskaLicnostResponse> obj = await _service.Get<PagedPayloadResponse<FilmskaLicnostResponse>>(null, filters, null);

            dgvFilmskeLicnosti.DataSource = obj.Payload;

            dgvFilmskeLicnosti.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvFilmskeLicnosti.Columns[0].Visible = false;
            if (filters.Count == 0 && _selectedRowIndex.HasValue)
                dgvFilmskeLicnosti.ClearSelection();

            Cursor = Cursors.Default;

            EnableChildren();

            if (dgvFilmskeLicnosti.RowCount == 0)
            {
                btnUredi.Enabled = false;
                btnObrisi.Enabled = false;
            }

            if (adding)
            {
                dgvFilmskeLicnosti.FirstDisplayedScrollingRowIndex = dgvFilmskeLicnosti.RowCount - 1;
            }
            else if (!adding && _currentIndex >= 0 && _currentIndex < dgvFilmskeLicnosti.RowCount)
            {
                dgvFilmskeLicnosti.FirstDisplayedScrollingRowIndex = _currentIndex;
            }
            else if (!adding && _currentIndex < 0 && dgvFilmskeLicnosti.RowCount > 0)
            {
                dgvFilmskeLicnosti.FirstDisplayedScrollingRowIndex = 0;
            }

            if (adding)
            {
                dgvFilmskeLicnosti.CurrentCell = dgvFilmskeLicnosti.Rows[dgvFilmskeLicnosti.RowCount - 1].Cells[1];
                dgvFilmskeLicnosti.Rows[dgvFilmskeLicnosti.RowCount - 1].Selected = true;
            }
            else if (!adding && filters.Count == 0 && _selectedRowIndex.HasValue && _selectedRowIndex.Value >= dgvFilmskeLicnosti.RowCount)
            {
                dgvFilmskeLicnosti.CurrentCell = dgvFilmskeLicnosti.Rows[_selectedRowIndex.Value - 1].Cells[1];
                dgvFilmskeLicnosti.Rows[_selectedRowIndex.Value - 1].Selected = true;
            }
            else if (!adding && filters.Count == 0 && _selectedRowIndex.HasValue)
            {
                dgvFilmskeLicnosti.CurrentCell = dgvFilmskeLicnosti.Rows[_selectedRowIndex.Value].Cells[1];
                dgvFilmskeLicnosti.Rows[_selectedRowIndex.Value].Selected = true;
            }
        }

        private void CreateFilters(List<FilterUtility.FilterParams> filters, TextBox txt, string columnName)
        {
            if (!string.IsNullOrEmpty(txt.Text))
            {
                FilterUtility.FilterParams filter = new FilterUtility.FilterParams
                {
                    ColumnName = columnName,
                    FilterOption = FilterUtility.FilterOptions.startswith.ToString(),
                    FilterValue = txt.Text
                };

                filters.Add(filter);
            }
        }

        private void CreateCbVrstaFilter(List<FilterUtility.FilterParams> filters)
        {
            var selectedItem = cbVrsta.SelectedItem?.ToString();

            var filter = new FilterUtility.FilterParams();

            switch (selectedItem)
            {
                case "Glumac":
                    filter.ColumnName = "IsGlumac";
                    filter.FilterOption = FilterUtility.FilterOptions.isequalto.ToString();
                    filter.FilterValue = true.ToString();
                    filters.Add(filter);
                    break;
                case "Režiser":
                    filter.ColumnName = "IsReziser";
                    filter.FilterOption = FilterUtility.FilterOptions.isequalto.ToString();
                    filter.FilterValue = true.ToString();
                    filters.Add(filter);
                    break;
                default:
                    break;
            }

        }

        private void EnableChildren()
        {
            txtIme.Enabled = true;
            txtPrezime.Enabled = true;

            cbVrsta.Enabled = true;

            btnPretrazi.Enabled = true;
            btnDodaj.Enabled = true;
            btnUredi.Enabled = true;
            btnObrisi.Enabled = true;

            dgvFilmskeLicnosti.Enabled = true;
        }

        private void DisableChildren()
        {
            txtIme.Enabled = false;
            txtPrezime.Enabled = false;

            cbVrsta.Enabled = false;

            btnPretrazi.Enabled = false;
            btnDodaj.Enabled = false;
            btnUredi.Enabled = false;
            btnObrisi.Enabled = false;

            dgvFilmskeLicnosti.Enabled = false;
        }

        private async void BtnDodaj_Click(object sender, EventArgs e)
        {
            FrmFilmskaLicnostDodajUredi frm = new FrmFilmskaLicnostDodajUredi
            {
                StartPosition = FormStartPosition.CenterParent
            };

            if (frm.ShowDialog() == DialogResult.OK)
                await GetGridData(adding: true);
        }

        private async void BtnUredi_Click(object sender, EventArgs e)
        {
            FrmFilmskaLicnostDodajUredi frm = new FrmFilmskaLicnostDodajUredi(((FilmskaLicnostResponse)dgvFilmskeLicnosti.CurrentRow.DataBoundItem).Id)
            {
                StartPosition = FormStartPosition.CenterParent
            };

            if (frm.ShowDialog() == DialogResult.OK)
                await GetGridData();
        }

        private async void BtnObrisi_Click(object sender, EventArgs e)
        {
            FilmskaLicnostResponse data = (FilmskaLicnostResponse)dgvFilmskeLicnosti.CurrentRow.DataBoundItem;

            if (MessageBox.Show($"Jeste li sigurni da želite obrisati ličnost {data.Ime} {data.Prezime}?", "Upozorenje", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                await _service.Delete(data.Id);
                await GetGridData();
            }
        }

        private async void CbVrsta_SelectedValueChanged(object sender, EventArgs e)
        {
            await GetGridData();
        }
    }
}
