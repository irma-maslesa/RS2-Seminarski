using Pelikula.API.Model.FilmskaLicnost;
using Pelikula.API.Model.Helper;
using Pelikula.CORE.Helper.Response;
using Pelikula.WINUI.Helpers;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Pelikula.WINUI.Forms.FilmskaLicnost
{
    public partial class FrmFilmskaLicnost : Form
    {
        private readonly ApiService _service = new ApiService("FilmskaLicnost");


        public FrmFilmskaLicnost() {
            InitializeComponent();
        }

        private async void FrmFilmskaLicnost_Load(object sender, EventArgs e) {
            DisableChildren();

            cbVrsta.Items.AddRange(new object[] { "Svi", "Glumac", "Režiser" });
            cbVrsta.DisplayMember = "Naziv";
            cbVrsta.ValueMember = "Id";
            cbVrsta.SelectedIndex = 0;

            await GetGridData();
        }

        private async void BtnPretrazi_Click(object sender, EventArgs e) {
            await GetGridData();
        }

        private async Task GetGridData(bool adding = false) {
            DisableChildren();

            int _currentIndex = dgvFilmskeLicnosti.FirstDisplayedScrollingRowIndex;
            int? _selectedRowIndex = null;

            if (dgvFilmskeLicnosti.SelectedRows.Count > 0)
                _selectedRowIndex = dgvFilmskeLicnosti.SelectedRows[0]?.Index;

            List<FilterUtility.FilterParams> filters = new List<FilterUtility.FilterParams>();
            FormHelper.CreateFilters(filters, txtIme, "Ime");
            FormHelper.CreateFilters(filters, txtPrezime, "Prezime");
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

            if (dgvFilmskeLicnosti.RowCount == 0) {
                btnUredi.Enabled = false;
                btnObrisi.Enabled = false;
            }
            else {
                btnUredi.Enabled = true;
                btnObrisi.Enabled = true;
            }

            FormHelper.SelectAndShowDgvRow(dgvFilmskeLicnosti, adding, _currentIndex, _selectedRowIndex, filters);
        }

        private void CreateCbVrstaFilter(List<FilterUtility.FilterParams> filters) {
            var selectedItem = cbVrsta.SelectedItem?.ToString();

            switch (selectedItem) {
                case "Glumac":
                    filters.Add(new FilterUtility.FilterParams("IsGlumac", true.ToString(), FilterUtility.FilterOptions.isequalto.ToString()));
                    break;
                case "Režiser":
                    filters.Add(new FilterUtility.FilterParams("IsReziser", true.ToString(), FilterUtility.FilterOptions.isequalto.ToString()));
                    break;
                default:
                    break;
            }

        }

        private void EnableChildren() {
            txtIme.Enabled = true;
            txtPrezime.Enabled = true;

            cbVrsta.Enabled = true;

            btnPretrazi.Enabled = true;
            btnDodaj.Enabled = true;
            btnUredi.Enabled = true;
            btnObrisi.Enabled = true;

            dgvFilmskeLicnosti.Enabled = true;
        }

        private void DisableChildren() {
            txtIme.Enabled = false;
            txtPrezime.Enabled = false;

            cbVrsta.Enabled = false;

            btnPretrazi.Enabled = false;
            btnDodaj.Enabled = false;
            btnUredi.Enabled = false;
            btnObrisi.Enabled = false;

            dgvFilmskeLicnosti.Enabled = false;
        }

        private async void BtnDodaj_Click(object sender, EventArgs e) {
            FrmFilmskaLicnostDodajUredi frm = new FrmFilmskaLicnostDodajUredi {
                StartPosition = FormStartPosition.CenterParent
            };

            if (frm.ShowDialog() == DialogResult.OK)
                await GetGridData(adding: true);
        }

        private async void BtnUredi_Click(object sender, EventArgs e) {
            FrmFilmskaLicnostDodajUredi frm = new FrmFilmskaLicnostDodajUredi(((FilmskaLicnostResponse)dgvFilmskeLicnosti.SelectedRows[0].DataBoundItem).Id) {
                StartPosition = FormStartPosition.CenterParent
            };

            if (frm.ShowDialog() == DialogResult.OK)
                await GetGridData();
        }

        private async void BtnObrisi_Click(object sender, EventArgs e) {
            FilmskaLicnostResponse data = (FilmskaLicnostResponse)dgvFilmskeLicnosti.SelectedRows[0].DataBoundItem;

            if (MessageBox.Show($"Jeste li sigurni da želite obrisati ličnost {data.Ime} {data.Prezime}?", "Upozorenje", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes) {
                await _service.Delete(data.Id);
                await GetGridData();
            }
        }

        private async void CbVrsta_SelectedValueChanged(object sender, EventArgs e) {
            await GetGridData();
        }
    }
}
