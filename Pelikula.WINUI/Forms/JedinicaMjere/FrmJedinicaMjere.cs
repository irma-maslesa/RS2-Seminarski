using Pelikula.API.Model.Helper;
using Pelikula.API.Model.JedinicaMjere;
using Pelikula.CORE.Helper.Response;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Pelikula.WINUI.Forms.JedinicaMjere
{
    public partial class FrmJedinicaMjere : Form
    {
        private readonly ApiService _service = new ApiService("JedinicaMjere");

        public FrmJedinicaMjere()
        {
            InitializeComponent();
        }
        private async void FrmJedinicaMjere_Load(object sender, EventArgs e)
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

            int _currentIndex = dgvJediniceMjere.FirstDisplayedScrollingRowIndex;
            int? _selectedRowIndex = dgvJediniceMjere.CurrentRow?.Index;

            List<FilterUtility.FilterParams> filters = new List<FilterUtility.FilterParams>();

            if (!string.IsNullOrEmpty(txtNaziv.Text))
            {
                FilterUtility.FilterParams filter = new FilterUtility.FilterParams
                {
                    ColumnName = "Naziv",
                    FilterOption = FilterUtility.FilterOptions.startswith.ToString(),
                    FilterValue = txtNaziv.Text
                };

                filters.Add(filter);
            }

            Cursor = Cursors.WaitCursor;

            PagedPayloadResponse<JedinicaMjereResponse> obj = await _service.Get<PagedPayloadResponse<JedinicaMjereResponse>>(null, filters, null);

            dgvJediniceMjere.DataSource = obj.Payload;
            dgvJediniceMjere.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvJediniceMjere.Columns[0].Visible = false;
            if (string.IsNullOrEmpty(txtNaziv.Text) && _selectedRowIndex.HasValue)
                dgvJediniceMjere.ClearSelection();

            Cursor = Cursors.Default;

            EnableChildren();

            if (dgvJediniceMjere.RowCount == 0)
            {
                btnUredi.Enabled = false;
                btnObrisi.Enabled = false;
            }

            if (adding)
            {
                dgvJediniceMjere.FirstDisplayedScrollingRowIndex = dgvJediniceMjere.RowCount - 1;
            }
            else if (!adding && _currentIndex >= 0 && _currentIndex < dgvJediniceMjere.RowCount)
            {
                dgvJediniceMjere.FirstDisplayedScrollingRowIndex = _currentIndex;
            }
            else if (!adding && _currentIndex < 0 && dgvJediniceMjere.RowCount > 0)
            {
                dgvJediniceMjere.FirstDisplayedScrollingRowIndex = 0;
            }

            if (adding)
            {
                dgvJediniceMjere.CurrentCell = dgvJediniceMjere.Rows[dgvJediniceMjere.RowCount - 1].Cells[1];
                dgvJediniceMjere.Rows[dgvJediniceMjere.RowCount - 1].Selected = true;
            }
            else if (!adding && string.IsNullOrEmpty(txtNaziv.Text) && _selectedRowIndex.HasValue && _selectedRowIndex.Value >= dgvJediniceMjere.RowCount)
            {
                dgvJediniceMjere.CurrentCell = dgvJediniceMjere.Rows[_selectedRowIndex.Value - 1].Cells[1];
                dgvJediniceMjere.Rows[_selectedRowIndex.Value - 1].Selected = true;
            }
            else if (!adding && string.IsNullOrEmpty(txtNaziv.Text) && _selectedRowIndex.HasValue)
            {
                dgvJediniceMjere.CurrentCell = dgvJediniceMjere.Rows[_selectedRowIndex.Value].Cells[1];
                dgvJediniceMjere.Rows[_selectedRowIndex.Value].Selected = true;
            }
        }
        private void EnableChildren()
        {
            txtNaziv.Enabled = true;
            btnPretrazi.Enabled = true;
            btnDodaj.Enabled = true;
            btnUredi.Enabled = true;
            btnObrisi.Enabled = true;
            dgvJediniceMjere.Enabled = true;
        }

        private void DisableChildren()
        {
            txtNaziv.Enabled = false;
            btnPretrazi.Enabled = false;
            btnDodaj.Enabled = false;
            btnUredi.Enabled = false;
            btnObrisi.Enabled = false;
            dgvJediniceMjere.Enabled = false;
        }

        private async void BtnDodaj_Click(object sender, EventArgs e)
        {
            FrmJedinicaMjereDodajUredi frm = new FrmJedinicaMjereDodajUredi
            {
                StartPosition = FormStartPosition.CenterParent
            };

            if (frm.ShowDialog() == DialogResult.OK)
                await GetGridData(adding: true);
        }

        private async void BtnUredi_Click(object sender, EventArgs e)
        {
            FrmJedinicaMjereDodajUredi frm = new FrmJedinicaMjereDodajUredi(((JedinicaMjereResponse)dgvJediniceMjere.CurrentRow.DataBoundItem).Id)
            {
                StartPosition = FormStartPosition.CenterParent
            };

            if (frm.ShowDialog() == DialogResult.OK)
                await GetGridData();
        }

        private async void BtnObrisi_Click(object sender, EventArgs e)
        {
            JedinicaMjereResponse data = (JedinicaMjereResponse)dgvJediniceMjere.CurrentRow.DataBoundItem;

            if (MessageBox.Show($"Jeste li sigurni da želite obrisati jedinicu mjere {data.Naziv}?", "Upozorenje", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                await _service.Delete(data.Id);
                await GetGridData();
            }
        }
    }
}
