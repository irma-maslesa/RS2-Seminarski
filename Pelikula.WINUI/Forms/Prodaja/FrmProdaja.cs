using Pelikula.API.Model;
using Pelikula.API.Model.Helper;
using Pelikula.API.Model.Korisnik;
using Pelikula.API.Model.Prodaja;
using Pelikula.CORE.Helper.Response;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Pelikula.WINUI.Forms.Prodaja
{
    public partial class FrmProdaja : Form
    {
        private readonly ApiService _service = new ApiService("Prodaja");
        private readonly KorisnikResponse _prijavljeniKorisnik;

        public FrmProdaja()
        {
            InitializeComponent();
            _prijavljeniKorisnik = Properties.Settings.Default.PrijavljeniKorisnik;
            dgvProdaje.AutoGenerateColumns = false;
        }

        private async void FrmProdaja_Load(object sender, EventArgs e)
        {
            DisableChildren();

            await GetGridData();

            EnableChildren();
        }

        private async Task GetGridData(bool adding = false)
        {
            int _currentIndex = dgvProdaje.FirstDisplayedScrollingRowIndex;
            int? _selectedRowIndex = dgvProdaje.CurrentRow?.Index;

            List<FilterUtility.FilterParams> filters = new List<FilterUtility.FilterParams>();
            CreateKorisnikFilter(filters);

            if (txtBrojRacuna.TextLength > 2)
            {
                FilterUtility.FilterParams filter = new FilterUtility.FilterParams()
                {
                    ColumnName = "BrojRacuna",
                    FilterOption = FilterUtility.FilterOptions.startswith.ToString(),
                    FilterValue = txtBrojRacuna.Text
                };

                filters.Add(filter);
            }

            Cursor = Cursors.WaitCursor;

            PagedPayloadResponse<ProdajaResponse> obj = await _service.Get<PagedPayloadResponse<ProdajaResponse>>(null, filters, null);

            dgvProdaje.DataSource = obj.Payload;

            dgvProdaje.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            if (filters.Count == 0 && _selectedRowIndex.HasValue)
                dgvProdaje.ClearSelection();

            Cursor = Cursors.Default;

            if (dgvProdaje.RowCount == 0)
            {
                btnObrisi.Enabled = false;
            }

            if (adding)
            {
                dgvProdaje.FirstDisplayedScrollingRowIndex = dgvProdaje.RowCount - 1;
            }
            else if (!adding && _currentIndex >= 0 && _currentIndex < dgvProdaje.RowCount)
            {
                dgvProdaje.FirstDisplayedScrollingRowIndex = _currentIndex;
            }
            else if (!adding && _currentIndex < 0 && dgvProdaje.RowCount > 0)
            {
                dgvProdaje.FirstDisplayedScrollingRowIndex = 0;
            }

            if (adding)
            {
                dgvProdaje.CurrentCell = dgvProdaje.Rows[dgvProdaje.RowCount - 1].Cells[1];
                dgvProdaje.Rows[dgvProdaje.RowCount - 1].Selected = true;
            }
            else if (!adding && filters.Count == 0 && _selectedRowIndex.HasValue && _selectedRowIndex.Value >= dgvProdaje.RowCount)
            {
                dgvProdaje.CurrentCell = dgvProdaje.Rows[_selectedRowIndex.Value - 1].Cells[1];
                dgvProdaje.Rows[_selectedRowIndex.Value - 1].Selected = true;
            }
            else if (!adding && filters.Count == 0 && _selectedRowIndex.HasValue)
            {
                dgvProdaje.CurrentCell = dgvProdaje.Rows[_selectedRowIndex.Value].Cells[1];
                dgvProdaje.Rows[_selectedRowIndex.Value].Selected = true;
            }
        }

        private void CreateKorisnikFilter(List<FilterUtility.FilterParams> filters)
        {
            FilterUtility.FilterParams filter = new FilterUtility.FilterParams()
            {
                ColumnName = "KorisnikId",
                FilterOption = FilterUtility.FilterOptions.isequalto.ToString(),
                FilterValue = _prijavljeniKorisnik?.Id.ToString()
            };

            filters.Add(filter);
        }

        private void EnableChildren()
        {
            btnDodaj.Enabled = true;
            btnObrisi.Enabled = true;

            dgvProdaje.Enabled = true;
        }

        private void DisableChildren()
        {
            btnDodaj.Enabled = false;
            btnObrisi.Enabled = false;

            dgvProdaje.Enabled = false;
        }

        private async void BtnDodaj_Click(object sender, EventArgs e)
        {
            FrmProdajaDodajUredi frm = new FrmProdajaDodajUredi
            {
                StartPosition = FormStartPosition.CenterParent
            };

            if (frm.ShowDialog() == DialogResult.OK)
                await GetGridData(adding: true);
        }

        private async void BtnObrisi_Click(object sender, EventArgs e)
        {
            ProdajaResponse data = (ProdajaResponse)dgvProdaje.CurrentRow.DataBoundItem;

            if (MessageBox.Show($"Jeste li sigurni da želite obrisati prodaju {data.BrojRacuna}?", "Upozorenje", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                await _service.Delete(data.Id);
                await GetGridData();
            }
        }

        private async void TxtBrojRacuna_TextChanged(object sender, EventArgs e)
        {
            await GetGridData();
        }
    }
}
