using Pelikula.API.Model.Helper;
using Pelikula.API.Model.Korisnik;
using Pelikula.API.Model.Prodaja;
using Pelikula.CORE.Helper.Response;
using Pelikula.WINUI.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Pelikula.WINUI.Forms.Prodaja
{
    public partial class FrmProdaja : Form
    {
        private readonly ApiService _service = new ApiService("Prodaja");
        private readonly KorisnikResponse _prijavljeniKorisnik;

        public FrmProdaja() {
            InitializeComponent();
            _prijavljeniKorisnik = Properties.Settings.Default.PrijavljeniKorisnik;
            dgvProdaje.AutoGenerateColumns = false;
        }

        private async void FrmProdaja_Load(object sender, EventArgs e) {
            DisableChildren();

            await GetGridData();

            EnableChildren();
        }

        private async Task GetGridData(bool adding = false) {
            int _currentIndex = dgvProdaje.FirstDisplayedScrollingRowIndex;
            int? _selectedRowIndex = null;

            if (dgvProdaje.SelectedRows.Count > 0)
                _selectedRowIndex = dgvProdaje.SelectedRows[0]?.Index;

            List<FilterUtility.FilterParams> filters = new List<FilterUtility.FilterParams>();

            if (txtBrojRacuna.TextLength > 2)
                FormHelper.CreateFilters(filters, txtBrojRacuna, "BrojRacuna");

            Cursor = Cursors.WaitCursor;

            PagedPayloadResponse<ProdajaResponse> obj = await _service.Get<PagedPayloadResponse<ProdajaResponse>>(null, null, null);

            if (obj != null)
                dgvProdaje.DataSource = obj.Payload.Where(e => e.Korisnik == null || e.Korisnik.Id == _prijavljeniKorisnik?.Id).ToList();

            dgvProdaje.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            if (filters.Count == 0 && _selectedRowIndex.HasValue)
                dgvProdaje.ClearSelection();

            Cursor = Cursors.Default;

            if (dgvProdaje.RowCount == 0) {
                btnObrisi.Enabled = false;
            }
            else {
                btnObrisi.Enabled = true;
            }

            FormHelper.SelectAndShowDgvRow(dgvProdaje, adding, _currentIndex, _selectedRowIndex, filters);
        }

        private void EnableChildren() {
            btnDodaj.Enabled = true;

            dgvProdaje.Enabled = true;
        }

        private void DisableChildren() {
            btnDodaj.Enabled = false;
            btnObrisi.Enabled = false;

            dgvProdaje.Enabled = false;
        }

        private async void BtnDodaj_Click(object sender, EventArgs e) {
            FrmProdajaDodajUredi frm = new FrmProdajaDodajUredi {
                StartPosition = FormStartPosition.CenterParent
            };

            if (frm.ShowDialog() == DialogResult.OK)
                await GetGridData(adding: true);
        }

        private async void BtnObrisi_Click(object sender, EventArgs e) {
            ProdajaResponse data = (ProdajaResponse)dgvProdaje.SelectedRows[0].DataBoundItem;

            if (MessageBox.Show($"Jeste li sigurni da želite obrisati prodaju {data.BrojRacuna}?", "Upozorenje", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes) {
                await _service.Delete(data.Id);
                await GetGridData();
            }
        }

        private async void TxtBrojRacuna_TextChanged(object sender, EventArgs e) {
            await GetGridData();
        }

        private void DgvProdaje_SelectionChanged(object sender, EventArgs e) {
            ProdajaResponse data = null;

            if (dgvProdaje.SelectedRows.Count > 0)
                data = (ProdajaResponse)dgvProdaje.SelectedRows[0].DataBoundItem;

            if (data != null && data.Korisnik == null) {
                btnObrisi.Enabled = false;
            }
            else {
                btnObrisi.Enabled = true;
            }
        }
    }
}
