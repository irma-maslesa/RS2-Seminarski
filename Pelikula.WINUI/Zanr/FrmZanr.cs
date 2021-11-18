using Flurl.Http;
using Pelikula.API.Model;
using Pelikula.API.Model.Helper;
using Pelikula.API.Model.Zanr;
using Pelikula.CORE.Helper.Response;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Pelikula.WINUI.Zanr
{
    public partial class FrmZanr : Form
    {
        private readonly ApiService _zanrService = new ApiService("Zanr");

        public FrmZanr()
        {
            InitializeComponent();
        }
        private async void FrmZanr_Load(object sender, EventArgs e)
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

            int _currentIndex = dgvZanrovi.FirstDisplayedScrollingRowIndex;
            int? _selectedRowIndex = dgvZanrovi.CurrentRow?.Index;
            string _text = Text;
            Text += " (Loading ...)";

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

            PagedPayloadResponse<ZanrResponse> obj = await _zanrService.Get<PagedPayloadResponse<ZanrResponse>>(null, filters, null);

            dgvZanrovi.DataSource = obj.Payload;
            dgvZanrovi.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvZanrovi.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            if (string.IsNullOrEmpty(txtNaziv.Text) && _selectedRowIndex.HasValue)
                dgvZanrovi.ClearSelection();

            Cursor = Cursors.Default;

            EnableChildren();

            if (dgvZanrovi.RowCount == 0)
            {
                btnUredi.Enabled = false;
                btnObrisi.Enabled = false;
            }

            Text = _text;

            if (adding)
            {
                dgvZanrovi.FirstDisplayedScrollingRowIndex = dgvZanrovi.RowCount - 1;
            }
            else if (!adding && _currentIndex >= 0 && _currentIndex < dgvZanrovi.RowCount)
            {
                dgvZanrovi.FirstDisplayedScrollingRowIndex = _currentIndex;
            }
            else if (!adding && _currentIndex < 0 && dgvZanrovi.RowCount > 0)
            {
                dgvZanrovi.FirstDisplayedScrollingRowIndex = 0;
            }

            if (adding)
            {
                dgvZanrovi.CurrentCell = dgvZanrovi.Rows[dgvZanrovi.RowCount - 1].Cells[0];
                dgvZanrovi.Rows[dgvZanrovi.RowCount - 1].Selected = true;
            }
            else if (!adding && string.IsNullOrEmpty(txtNaziv.Text) && _selectedRowIndex.HasValue && _selectedRowIndex.Value >= dgvZanrovi.RowCount)
            {
                dgvZanrovi.CurrentCell = dgvZanrovi.Rows[_selectedRowIndex.Value - 1].Cells[0];
                dgvZanrovi.Rows[_selectedRowIndex.Value - 1].Selected = true;
            }
            else if (!adding && string.IsNullOrEmpty(txtNaziv.Text) && _selectedRowIndex.HasValue)
            {
                dgvZanrovi.CurrentCell = dgvZanrovi.Rows[_selectedRowIndex.Value].Cells[0];
                dgvZanrovi.Rows[_selectedRowIndex.Value].Selected = true;
            }
        }
        private void EnableChildren()
        {
            txtNaziv.Enabled = true;
            btnPretrazi.Enabled = true;
            btnDodaj.Enabled = true;
            btnUredi.Enabled = true;
            btnObrisi.Enabled = true;
            dgvZanrovi.Enabled = true;
        }

        private void DisableChildren()
        {
            txtNaziv.Enabled = false;
            btnPretrazi.Enabled = false;
            btnDodaj.Enabled = false;
            btnUredi.Enabled = false;
            btnObrisi.Enabled = false;
            dgvZanrovi.Enabled = false;
        }

        private async void BtnDodaj_Click(object sender, EventArgs e)
        {
            FrmZanrDodajUredi frm = new FrmZanrDodajUredi
            {
                StartPosition = FormStartPosition.CenterParent
            };

            if (frm.ShowDialog() == DialogResult.OK)
                await GetGridData(adding: true);
        }

        private async void BtnUredi_Click(object sender, EventArgs e)
        {
            FrmZanrDodajUredi frm = new FrmZanrDodajUredi(((ZanrResponse)dgvZanrovi.CurrentRow.DataBoundItem).Id)
            {
                StartPosition = FormStartPosition.CenterParent
            };

            if (frm.ShowDialog() == DialogResult.OK)
                await GetGridData();
        }

        private async void BtnObrisi_Click(object sender, EventArgs e)
        {
            ZanrResponse zanr = (ZanrResponse)dgvZanrovi.CurrentRow.DataBoundItem;

            if (MessageBox.Show($"Jeste li sigurni da želite obrisati žanr {zanr.Naziv}?", "Upozorenje", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                await _zanrService.Delete(zanr.Id);
                await GetGridData();
            }
        }
    }
}
