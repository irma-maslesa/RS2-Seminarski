using Pelikula.API.Model.Helper;
using Pelikula.API.Model.Sala;
using Pelikula.CORE.Helper.Response;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Pelikula.WINUI.Forms.Sala
{
    public partial class FrmSala : Form
    {
        private readonly ApiService _service = new ApiService("Sala");

        public FrmSala()
        {
            InitializeComponent();
        }
        private async void FrmSala_Load(object sender, EventArgs e)
        {
            await GetGridData();
        }

        private async void BtnPretrazi_Click(object sender, EventArgs e)
        {
            await GetGridData();
        }

        private async Task GetGridData(bool adding = false)
        {
            DisableChildren();

            int _currentIndex = dgvSala.FirstDisplayedScrollingRowIndex;
            int? _selectedRowIndex = dgvSala.CurrentRow?.Index;

            List<FilterUtility.FilterParams> filters = new List<FilterUtility.FilterParams>();

            if (!string.IsNullOrEmpty(txtNaziv.Text))
            {
                FilterUtility.FilterParams filter = new FilterUtility.FilterParams
                {
                    ColumnName = "Naziv",
                    FilterOption = FilterUtility.FilterOptions.contains.ToString(),
                    FilterValue = txtNaziv.Text
                };

                filters.Add(filter);
            }

            CreateBrojSjedistaFilter(filters, txtMinMjesta, FilterUtility.FilterOptions.isgreaterthanorequalto);
            CreateBrojSjedistaFilter(filters, txtMaxMjesta, FilterUtility.FilterOptions.islessthanorequalto);

            Cursor = Cursors.WaitCursor;

            PagedPayloadResponse<SalaResponse> obj = await _service.Get<PagedPayloadResponse<SalaResponse>>(null, filters, null);

            dgvSala.DataSource = obj.Payload;
            dgvSala.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvSala.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            if (string.IsNullOrEmpty(txtNaziv.Text) && _selectedRowIndex.HasValue)
                dgvSala.ClearSelection();

            Cursor = Cursors.Default;

            EnableChildren();

            if (dgvSala.RowCount == 0)
            {
                btnUredi.Enabled = false;
                btnObrisi.Enabled = false;
            }

            if (adding)
            {
                dgvSala.FirstDisplayedScrollingRowIndex = dgvSala.RowCount - 1;
            }
            else if (!adding && _currentIndex >= 0 && _currentIndex < dgvSala.RowCount)
            {
                dgvSala.FirstDisplayedScrollingRowIndex = _currentIndex;
            }
            else if (!adding && _currentIndex < 0 && dgvSala.RowCount > 0)
            {
                dgvSala.FirstDisplayedScrollingRowIndex = 0;
            }

            if (adding)
            {
                dgvSala.CurrentCell = dgvSala.Rows[dgvSala.RowCount - 1].Cells[0];
                dgvSala.Rows[dgvSala.RowCount - 1].Selected = true;
            }
            else if (!adding && string.IsNullOrEmpty(txtNaziv.Text) && _selectedRowIndex.HasValue && _selectedRowIndex.Value >= dgvSala.RowCount)
            {
                dgvSala.CurrentCell = dgvSala.Rows[_selectedRowIndex.Value - 1].Cells[0];
                dgvSala.Rows[_selectedRowIndex.Value - 1].Selected = true;
            }
            else if (!adding && string.IsNullOrEmpty(txtNaziv.Text) && _selectedRowIndex.HasValue)
            {
                dgvSala.CurrentCell = dgvSala.Rows[_selectedRowIndex.Value].Cells[0];
                dgvSala.Rows[_selectedRowIndex.Value].Selected = true;
            }
        }

        private void CreateBrojSjedistaFilter(List<FilterUtility.FilterParams> filters, MaskedTextBox txt, FilterUtility.FilterOptions option)
        {
            if (!string.IsNullOrEmpty(txt.Text))
            {
                FilterUtility.FilterParams filter = new FilterUtility.FilterParams
                {
                    ColumnName = "BrojSjedista",
                    FilterOption = option.ToString(),
                    FilterValue = int.Parse(txt.Text).ToString()
                };

                filters.Add(filter);
            }
        }

        private void EnableChildren()
        {
            txtNaziv.Enabled = true;
            txtMinMjesta.Enabled = true;
            txtMaxMjesta.Enabled = true;
            btnPretrazi.Enabled = true;
            btnDodaj.Enabled = true;
            btnUredi.Enabled = true;
            btnObrisi.Enabled = true;
            dgvSala.Enabled = true;
        }

        private void DisableChildren()
        {
            txtNaziv.Enabled = false;
            txtMinMjesta.Enabled = false;
            txtMaxMjesta.Enabled = false;
            btnPretrazi.Enabled = false;
            btnDodaj.Enabled = false;
            btnUredi.Enabled = false;
            btnObrisi.Enabled = false;
            dgvSala.Enabled = false;
        }

        private async void BtnDodaj_Click(object sender, EventArgs e)
        {
            FrmSalaDodajUredi frm = new FrmSalaDodajUredi
            {
                StartPosition = FormStartPosition.CenterParent
            };

            if (frm.ShowDialog() == DialogResult.OK)
                await GetGridData(adding: true);
        }

        private async void BtnUredi_Click(object sender, EventArgs e)
        {
            FrmSalaDodajUredi frm = new FrmSalaDodajUredi(((SalaResponse)dgvSala.CurrentRow.DataBoundItem).Id)
            {
                StartPosition = FormStartPosition.CenterParent
            };

            if (frm.ShowDialog() == DialogResult.OK)
                await GetGridData();
        }

        private async void BtnObrisi_Click(object sender, EventArgs e)
        {
            SalaResponse data = (SalaResponse)dgvSala.CurrentRow.DataBoundItem;

            if (MessageBox.Show($"Jeste li sigurni da želite obrisati salu {data.Naziv}?", "Upozorenje", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                await _service.Delete(data.Id);
                await GetGridData();
            }
        }
    }
}
