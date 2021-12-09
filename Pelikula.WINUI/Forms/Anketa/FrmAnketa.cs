using Pelikula.API.Model;
using Pelikula.API.Model.Helper;
using Pelikula.API.Model.Anketa;
using Pelikula.CORE.Helper.Response;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Pelikula.WINUI.Forms.Anketa
{
    public partial class FrmAnketa : Form
    {
        private readonly ApiService _service = new ApiService("Anketa");
        private readonly ApiService _korisnikService = new ApiService("Korisnik");

        List<LoV> korisnikList = new List<LoV>();

        public FrmAnketa()
        {
            InitializeComponent();
            dgvAnkete.AutoGenerateColumns = false;
        }
        private async void FrmAnketa_Load(object sender, EventArgs e)
        {
            DisableChildren();

            korisnikList = (await _korisnikService.GetLoVs<PagedPayloadResponse<LoV>>(null, null, null)).Payload.OrderBy(o => o.Naziv).ToList();
            korisnikList.Insert(0, new LoV { Id = -1, Naziv = "Svi" });

            cbKorisnik.DataSource = korisnikList;
            cbKorisnik.SelectedItem = korisnikList.FirstOrDefault(o => o.Id == -1);
            cbKorisnik.DisplayMember = "Naziv";
            cbKorisnik.ValueMember = "Id";

            cbAktivno.Items.AddRange(new object[] { "Svi", "Da", "Ne" });
            cbAktivno.DisplayMember = "Naziv";
            cbAktivno.ValueMember = "Id";
            cbAktivno.SelectedIndex = 0;

            await GetGridData();
        }

        private async void BtnPretrazi_Click(object sender, EventArgs e)
        {
            await GetGridData();
        }

        private async Task GetGridData(bool adding = false)
        {
            DisableChildren();

            int _currentIndex = dgvAnkete.FirstDisplayedScrollingRowIndex;
            int? _selectedRowIndex = dgvAnkete.CurrentRow?.Index;

            List<FilterUtility.FilterParams> filters = new List<FilterUtility.FilterParams>();
            CreateFilters(filters, txNaslov, "Naslov");
            CreateCbFilters(filters, cbKorisnik, "KorisnikId");
            CreateCbAktivnoFilter(filters);
            Cursor = Cursors.WaitCursor;

            PagedPayloadResponse<AnketaResponse> obj = await _service.Get<PagedPayloadResponse<AnketaResponse>>(null, filters, null);

            dgvAnkete.DataSource = obj.Payload;

            dgvAnkete.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            if (filters.Count == 0 && _selectedRowIndex.HasValue)
                dgvAnkete.ClearSelection();

            Cursor = Cursors.Default;

            EnableChildren();

            if (dgvAnkete.RowCount == 0)
            {
                btnUredi.Enabled = false;
                btnObrisi.Enabled = false;
            }

            if (adding)
            {
                dgvAnkete.FirstDisplayedScrollingRowIndex = dgvAnkete.RowCount - 1;
            }
            else if (!adding && _currentIndex >= 0 && _currentIndex < dgvAnkete.RowCount)
            {
                dgvAnkete.FirstDisplayedScrollingRowIndex = _currentIndex;
            }
            else if (!adding && _currentIndex < 0 && dgvAnkete.RowCount > 0)
            {
                dgvAnkete.FirstDisplayedScrollingRowIndex = 0;
            }

            if (adding)
            {
                dgvAnkete.CurrentCell = dgvAnkete.Rows[dgvAnkete.RowCount - 1].Cells[1];
                dgvAnkete.Rows[dgvAnkete.RowCount - 1].Selected = true;
            }
            else if (!adding && filters.Count == 0 && _selectedRowIndex.HasValue && _selectedRowIndex.Value >= dgvAnkete.RowCount)
            {
                dgvAnkete.CurrentCell = dgvAnkete.Rows[_selectedRowIndex.Value - 1].Cells[1];
                dgvAnkete.Rows[_selectedRowIndex.Value - 1].Selected = true;
            }
            else if (!adding && filters.Count == 0 && _selectedRowIndex.HasValue)
            {
                dgvAnkete.CurrentCell = dgvAnkete.Rows[_selectedRowIndex.Value].Cells[1];
                dgvAnkete.Rows[_selectedRowIndex.Value].Selected = true;
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

        private void CreateCbAktivnoFilter(List<FilterUtility.FilterParams> filters)
        {
            var selectedItem = cbAktivno.SelectedItem?.ToString();

            var filter = new FilterUtility.FilterParams();

            switch (selectedItem)
            {
                case "Ne":
                    filter.ColumnName = "ZakljucenoDatum";
                    filter.FilterOption = FilterUtility.FilterOptions.isnotequalto.ToString();
                    filter.FilterValue = null;
                    filters.Add(filter);
                    break;
                case "Da":
                    filter.ColumnName = "ZakljucenoDatum";
                    filter.FilterOption = FilterUtility.FilterOptions.isequalto.ToString();
                    filter.FilterValue = null;
                    filters.Add(filter);
                    break;
                default:
                    break;
            }

        }

        private void EnableChildren()
        {
            txNaslov.Enabled = true;

            cbKorisnik.Enabled = true;
            cbAktivno.Enabled = true;

            btnPretrazi.Enabled = true;
            btnDodaj.Enabled = true;
            btnUredi.Enabled = true;
            btnObrisi.Enabled = true;
            btnPrikazi.Enabled = true;

            dgvAnkete.Enabled = true;
        }

        private void DisableChildren()
        {
            txNaslov.Enabled = false;

            cbKorisnik.Enabled = false;
            cbAktivno.Enabled = false;

            btnPretrazi.Enabled = false;
            btnDodaj.Enabled = false;
            btnUredi.Enabled = false;
            btnObrisi.Enabled = false;
            btnPrikazi.Enabled = false;
            btnZakljucaj.Enabled = false;

            dgvAnkete.Enabled = false;
        }

        private async void BtnDodaj_Click(object sender, EventArgs e)
        {
            FrmAnketaDodajUredi frm = new FrmAnketaDodajUredi
            {
                StartPosition = FormStartPosition.CenterParent
            };

            if (frm.ShowDialog() == DialogResult.OK)
                await GetGridData(adding: true);
        }

        private async void BtnUredi_Click(object sender, EventArgs e)
        {
            FrmAnketaDodajUredi frm = new FrmAnketaDodajUredi(((AnketaResponse)dgvAnkete.CurrentRow.DataBoundItem).Id)
            {
                StartPosition = FormStartPosition.CenterParent
            };

            if (frm.ShowDialog() == DialogResult.OK)
                await GetGridData();
        }

        private async void BtnObrisi_Click(object sender, EventArgs e)
        {
            AnketaResponse data = (AnketaResponse)dgvAnkete.CurrentRow.DataBoundItem;

            if (MessageBox.Show($"Jeste li sigurni da želite obrisati anketu {data.Naslov} ({data.Datum})?", "Upozorenje", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                await _service.Delete(data.Id);
                await GetGridData();
            }
        }

        private async void CbKorisnik_SelectedValueChanged(object sender, EventArgs e)
        {
            await GetGridData();
        }

        private void BtnPrikazi_Click(object sender, EventArgs e)
        {
            var frm = new FrmAnketaRezultati(((AnketaResponse)dgvAnkete.CurrentRow.DataBoundItem).Id)
            {
                StartPosition = FormStartPosition.CenterParent
            };
            frm.ShowDialog();
        }

        private async void BtnZakljucaj_Click(object sender, EventArgs e)
        {
            var data = (AnketaResponse)dgvAnkete.CurrentRow.DataBoundItem;

            if (MessageBox.Show($"Jeste li sigurni da želite zaključati anketu {data.Naslov} ({data.Datum})?", "Upozorenje", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                await _service.ZatvoriAnketu(data.Id);
                await GetGridData();
            }
        }

        private async void CbAktivno_SelectedValueChanged(object sender, EventArgs e)
        {
            await GetGridData();
        }

        private void DgvAnkete_SelectionChanged(object sender, EventArgs e)
        {
            AnketaResponse data = null;

            if (dgvAnkete.CurrentRow != null)
                data = (AnketaResponse)dgvAnkete.CurrentRow.DataBoundItem;

            if (data != null && data.ZakljucenoDatum != null)
                btnZakljucaj.Enabled = false;
            else
                btnZakljucaj.Enabled = true;
        }
    }
}
