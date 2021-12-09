using Pelikula.API.Model;
using Pelikula.API.Model.Helper;
using Pelikula.API.Model.Obavijest;
using Pelikula.CORE.Helper.Response;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Pelikula.WINUI.Forms.Obavijest
{
    public partial class FrmObavijest : Form
    {
        private readonly ApiService _service = new ApiService("Obavijest");
        private readonly ApiService _korisnikService = new ApiService("Korisnik");

        List<LoV> korisnikList = new List<LoV>();

        public FrmObavijest()
        {
            InitializeComponent();
            dgvObavijesti.AutoGenerateColumns = false;
        }
        private async void FrmObavijest_Load(object sender, EventArgs e)
        {
            DisableChildren();

            korisnikList = (await _korisnikService.GetLoVs<PagedPayloadResponse<LoV>>(null, null, null)).Payload.OrderBy(o => o.Naziv).ToList();
            korisnikList.Insert(0, new LoV { Id = -1, Naziv = "Svi" });

            cbKorisnik.DataSource = korisnikList;
            cbKorisnik.SelectedItem = korisnikList.FirstOrDefault(o => o.Id == -1);
            cbKorisnik.DisplayMember = "Naziv";
            cbKorisnik.ValueMember = "Id";

            await GetGridData();
        }

        private async void BtnPretrazi_Click(object sender, EventArgs e)
        {
            await GetGridData();
        }

        private async Task GetGridData(bool adding = false)
        {
            DisableChildren();

            int _currentIndex = dgvObavijesti.FirstDisplayedScrollingRowIndex;
            int? _selectedRowIndex = dgvObavijesti.CurrentRow?.Index;

            List<FilterUtility.FilterParams> filters = new List<FilterUtility.FilterParams>();
            CreateFilters(filters, txNaslov, "Naslov");
            CreateCbFilters(filters, cbKorisnik, "KorisnikId");

            Cursor = Cursors.WaitCursor;

            PagedPayloadResponse<ObavijestResponse> obj = await _service.Get<PagedPayloadResponse<ObavijestResponse>>(null, filters, null);

            dgvObavijesti.DataSource = obj.Payload;

            dgvObavijesti.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            if (filters.Count == 0 && _selectedRowIndex.HasValue)
                dgvObavijesti.ClearSelection();

            Cursor = Cursors.Default;

            EnableChildren();

            if (dgvObavijesti.RowCount == 0)
            {
                btnUredi.Enabled = false;
                btnObrisi.Enabled = false;
            }

            if (adding)
            {
                dgvObavijesti.FirstDisplayedScrollingRowIndex = dgvObavijesti.RowCount - 1;
            }
            else if (!adding && _currentIndex >= 0 && _currentIndex < dgvObavijesti.RowCount)
            {
                dgvObavijesti.FirstDisplayedScrollingRowIndex = _currentIndex;
            }
            else if (!adding && _currentIndex < 0 && dgvObavijesti.RowCount > 0)
            {
                dgvObavijesti.FirstDisplayedScrollingRowIndex = 0;
            }

            if (adding)
            {
                dgvObavijesti.CurrentCell = dgvObavijesti.Rows[dgvObavijesti.RowCount - 1].Cells[1];
                dgvObavijesti.Rows[dgvObavijesti.RowCount - 1].Selected = true;
            }
            else if (!adding && filters.Count == 0 && _selectedRowIndex.HasValue && _selectedRowIndex.Value >= dgvObavijesti.RowCount)
            {
                dgvObavijesti.CurrentCell = dgvObavijesti.Rows[_selectedRowIndex.Value - 1].Cells[1];
                dgvObavijesti.Rows[_selectedRowIndex.Value - 1].Selected = true;
            }
            else if (!adding && filters.Count == 0 && _selectedRowIndex.HasValue)
            {
                dgvObavijesti.CurrentCell = dgvObavijesti.Rows[_selectedRowIndex.Value].Cells[1];
                dgvObavijesti.Rows[_selectedRowIndex.Value].Selected = true;
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
            txNaslov.Enabled = true;

            cbKorisnik.Enabled = true;

            btnPretrazi.Enabled = true;
            btnDodaj.Enabled = true;
            btnUredi.Enabled = true;
            btnObrisi.Enabled = true;

            dgvObavijesti.Enabled = true;
        }

        private void DisableChildren()
        {
            txNaslov.Enabled = false;

            cbKorisnik.Enabled = false;

            btnPretrazi.Enabled = false;
            btnDodaj.Enabled = false;
            btnUredi.Enabled = false;
            btnObrisi.Enabled = false;

            dgvObavijesti.Enabled = false;
        }

        private async void BtnDodaj_Click(object sender, EventArgs e)
        {
            FrmObavijestDodajUredi frm = new FrmObavijestDodajUredi
            {
                StartPosition = FormStartPosition.CenterParent
            };

            if (frm.ShowDialog() == DialogResult.OK)
                await GetGridData(adding: true);
        }

        private async void BtnUredi_Click(object sender, EventArgs e)
        {
            FrmObavijestDodajUredi frm = new FrmObavijestDodajUredi(((ObavijestResponse)dgvObavijesti.CurrentRow.DataBoundItem).Id)
            {
                StartPosition = FormStartPosition.CenterParent
            };

            if (frm.ShowDialog() == DialogResult.OK)
                await GetGridData();
        }

        private async void BtnObrisi_Click(object sender, EventArgs e)
        {
            ObavijestResponse data = (ObavijestResponse)dgvObavijesti.CurrentRow.DataBoundItem;

            if (MessageBox.Show($"Jeste li sigurni da želite obrisati obavijest {data.Naslov} ({data.Datum})?", "Upozorenje", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                await _service.Delete(data.Id);
                await GetGridData();
            }
        }

        private async void CbKorisnik_SelectedValueChanged(object sender, EventArgs e)
        {
            await GetGridData();
        }
    }
}
