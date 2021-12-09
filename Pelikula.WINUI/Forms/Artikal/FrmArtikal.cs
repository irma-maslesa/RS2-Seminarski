using Pelikula.API.Model;
using Pelikula.API.Model.Helper;
using Pelikula.API.Model.Artikal;
using Pelikula.CORE.Helper.Response;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Pelikula.WINUI.Forms.Artikal
{
    public partial class FrmArtikal : Form
    {
        private readonly ApiService _service = new ApiService("Artikal");
        private readonly ApiService _jedinicaMjereService = new ApiService("JedinicaMjere");

        List<LoV> jedinicaMjereList = new List<LoV>();

        public FrmArtikal()
        {
            InitializeComponent();
            dgvArtikli.AutoGenerateColumns = false;
        }
        private async void FrmArtikal_Load(object sender, EventArgs e)
        {
            DisableChildren();

            jedinicaMjereList = (await _jedinicaMjereService.GetLoVs<PagedPayloadResponse<LoV>>(null, null, null)).Payload.OrderBy(o => o.Naziv).ToList();
            jedinicaMjereList.Insert(0, new LoV { Id = -1, Naziv = "Svi" });

            cbJedinicaMjere.DataSource = jedinicaMjereList;
            cbJedinicaMjere.SelectedItem = jedinicaMjereList.FirstOrDefault(o => o.Id == -1);
            cbJedinicaMjere.DisplayMember = "Naziv";
            cbJedinicaMjere.ValueMember = "Id";

            await GetGridData();
        }

        private async void BtnPretrazi_Click(object sender, EventArgs e)
        {
            await GetGridData();
        }

        private async Task GetGridData(bool adding = false)
        {
            DisableChildren();

            int _currentIndex = dgvArtikli.FirstDisplayedScrollingRowIndex;
            int? _selectedRowIndex = dgvArtikli.CurrentRow?.Index;

            List<FilterUtility.FilterParams> filters = new List<FilterUtility.FilterParams>();
            CreateFilters(filters, txNaziv, "Naziv");
            CreateFilters(filters, txtSifra, "Sifra");
            CreateCbFilters(filters, cbJedinicaMjere, "JedinicaMjereId");

            Cursor = Cursors.WaitCursor;

            PagedPayloadResponse<ArtikalResponse> obj = await _service.Get<PagedPayloadResponse<ArtikalResponse>>(null, filters, null);

            dgvArtikli.DataSource = obj.Payload;

            dgvArtikli.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            //dgvArtikli.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            if (filters.Count == 0 && _selectedRowIndex.HasValue)
                dgvArtikli.ClearSelection();

            Cursor = Cursors.Default;

            EnableChildren();

            if (dgvArtikli.RowCount == 0)
            {
                btnUredi.Enabled = false;
                btnObrisi.Enabled = false;
            }

            if (adding)
            {
                dgvArtikli.FirstDisplayedScrollingRowIndex = dgvArtikli.RowCount - 1;
            }
            else if (!adding && _currentIndex >= 0 && _currentIndex < dgvArtikli.RowCount)
            {
                dgvArtikli.FirstDisplayedScrollingRowIndex = _currentIndex;
            }
            else if (!adding && _currentIndex < 0 && dgvArtikli.RowCount > 0)
            {
                dgvArtikli.FirstDisplayedScrollingRowIndex = 0;
            }

            if (adding)
            {
                dgvArtikli.CurrentCell = dgvArtikli.Rows[dgvArtikli.RowCount - 1].Cells[1];
                dgvArtikli.Rows[dgvArtikli.RowCount - 1].Selected = true;
            }
            else if (!adding && filters.Count == 0 && _selectedRowIndex.HasValue && _selectedRowIndex.Value >= dgvArtikli.RowCount)
            {
                dgvArtikli.CurrentCell = dgvArtikli.Rows[_selectedRowIndex.Value - 1].Cells[1];
                dgvArtikli.Rows[_selectedRowIndex.Value - 1].Selected = true;
            }
            else if (!adding && filters.Count == 0 && _selectedRowIndex.HasValue)
            {
                dgvArtikli.CurrentCell = dgvArtikli.Rows[_selectedRowIndex.Value].Cells[1];
                dgvArtikli.Rows[_selectedRowIndex.Value].Selected = true;
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
            txNaziv.Enabled = true;
            txtSifra.Enabled = true;

            cbJedinicaMjere.Enabled = true;

            btnPretrazi.Enabled = true;
            btnDodaj.Enabled = true;
            btnUredi.Enabled = true;
            btnObrisi.Enabled = true;

            dgvArtikli.Enabled = true;
        }

        private void DisableChildren()
        {
            txNaziv.Enabled = false;
            txtSifra.Enabled = false;

            cbJedinicaMjere.Enabled = false;

            btnPretrazi.Enabled = false;
            btnDodaj.Enabled = false;
            btnUredi.Enabled = false;
            btnObrisi.Enabled = false;

            dgvArtikli.Enabled = false;
        }

        private async void BtnDodaj_Click(object sender, EventArgs e)
        {
            FrmArtikalDodajUredi frm = new FrmArtikalDodajUredi
            {
                StartPosition = FormStartPosition.CenterParent
            };

            if (frm.ShowDialog() == DialogResult.OK)
                await GetGridData(adding: true);
        }

        private async void BtnUredi_Click(object sender, EventArgs e)
        {
            FrmArtikalDodajUredi frm = new FrmArtikalDodajUredi(((ArtikalResponse)dgvArtikli.CurrentRow.DataBoundItem).Id)
            {
                StartPosition = FormStartPosition.CenterParent
            };

            if (frm.ShowDialog() == DialogResult.OK)
                await GetGridData();
        }

        private async void BtnObrisi_Click(object sender, EventArgs e)
        {
            ArtikalResponse data = (ArtikalResponse)dgvArtikli.CurrentRow.DataBoundItem;

            if (MessageBox.Show($"Jeste li sigurni da želite obrisati artikal {data.Naziv} ({data.Sifra})?", "Upozorenje", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                await _service.Delete(data.Id);
                await GetGridData();
            }
        }

        private async void CbJedinicaMjere_SelectedValueChanged(object sender, EventArgs e)
        {
            await GetGridData();
        }
    }
}
