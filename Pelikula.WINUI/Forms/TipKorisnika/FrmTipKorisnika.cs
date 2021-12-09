using Pelikula.API.Model.Helper;
using Pelikula.API.Model.TipKorisnika;
using Pelikula.CORE.Helper.Response;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Pelikula.WINUI.Forms.TipKorisnika
{
    public partial class FrmTipKorisnika : Form
    {
        private readonly ApiService _service = new ApiService("TipKorisnika");

        public FrmTipKorisnika()
        {
            InitializeComponent();
        }

        private async void FrmTipKorisnika_Load(object sender, EventArgs e)
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

            int _currentIndex = dgvTipoviKorisnika.FirstDisplayedScrollingRowIndex;
            int? _selectedRowIndex = dgvTipoviKorisnika.CurrentRow?.Index;

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

            PagedPayloadResponse<TipKorisnikaResponse> obj = await _service.Get<PagedPayloadResponse<TipKorisnikaResponse>>(null, filters, null);

            dgvTipoviKorisnika.DataSource = obj.Payload;
            dgvTipoviKorisnika.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvTipoviKorisnika.Columns[0].Visible = false;
            if (string.IsNullOrEmpty(txtNaziv.Text) && _selectedRowIndex.HasValue)
                dgvTipoviKorisnika.ClearSelection();

            Cursor = Cursors.Default;

            EnableChildren();

            if (dgvTipoviKorisnika.RowCount == 0)
            {
                btnUredi.Enabled = false;
                btnObrisi.Enabled = false;
            }

            if (adding)
            {
                dgvTipoviKorisnika.FirstDisplayedScrollingRowIndex = dgvTipoviKorisnika.RowCount - 1;
            }
            else if (!adding && _currentIndex >= 0 && _currentIndex < dgvTipoviKorisnika.RowCount)
            {
                dgvTipoviKorisnika.FirstDisplayedScrollingRowIndex = _currentIndex;
            }
            else if (!adding && _currentIndex < 0 && dgvTipoviKorisnika.RowCount > 0)
            {
                dgvTipoviKorisnika.FirstDisplayedScrollingRowIndex = 0;
            }

            if (adding)
            {
                dgvTipoviKorisnika.CurrentCell = dgvTipoviKorisnika.Rows[dgvTipoviKorisnika.RowCount - 1].Cells[1];
                dgvTipoviKorisnika.Rows[dgvTipoviKorisnika.RowCount - 1].Selected = true;
            }
            else if (!adding && string.IsNullOrEmpty(txtNaziv.Text) && _selectedRowIndex.HasValue && _selectedRowIndex.Value >= dgvTipoviKorisnika.RowCount)
            {
                dgvTipoviKorisnika.CurrentCell = dgvTipoviKorisnika.Rows[_selectedRowIndex.Value - 1].Cells[1];
                dgvTipoviKorisnika.Rows[_selectedRowIndex.Value - 1].Selected = true;
            }
            else if (!adding && string.IsNullOrEmpty(txtNaziv.Text) && _selectedRowIndex.HasValue)
            {
                dgvTipoviKorisnika.CurrentCell = dgvTipoviKorisnika.Rows[_selectedRowIndex.Value].Cells[1];
                dgvTipoviKorisnika.Rows[_selectedRowIndex.Value].Selected = true;
            }
        }
        private void EnableChildren()
        {
            txtNaziv.Enabled = true;
            btnPretrazi.Enabled = true;
            btnDodaj.Enabled = true;
            btnUredi.Enabled = true;
            btnObrisi.Enabled = true;
            dgvTipoviKorisnika.Enabled = true;
        }

        private void DisableChildren()
        {
            txtNaziv.Enabled = false;
            btnPretrazi.Enabled = false;
            btnDodaj.Enabled = false;
            btnUredi.Enabled = false;
            btnObrisi.Enabled = false;
            dgvTipoviKorisnika.Enabled = false;
        }

        private async void BtnDodaj_Click(object sender, EventArgs e)
        {
            FrmTipKorisnikaDodajUredi frm = new FrmTipKorisnikaDodajUredi();
            frm.StartPosition = FormStartPosition.CenterParent;

            if (frm.ShowDialog() == DialogResult.OK)
                await GetGridData(adding: true);
        }

        private async void BtnUredi_Click(object sender, EventArgs e)
        {
            FrmTipKorisnikaDodajUredi frm = new FrmTipKorisnikaDodajUredi(((TipKorisnikaResponse)dgvTipoviKorisnika.CurrentRow.DataBoundItem).Id);
            frm.StartPosition = FormStartPosition.CenterParent;

            if (frm.ShowDialog() == DialogResult.OK)
                await GetGridData();
        }

        private async void BtnObrisi_Click(object sender, EventArgs e)
        {
            TipKorisnikaResponse tipKorisnika = (TipKorisnikaResponse)dgvTipoviKorisnika.CurrentRow.DataBoundItem;

            if (MessageBox.Show($"Jeste li sigurni da želite obrisati tip korisnika {tipKorisnika.Naziv}?", "Upozorenje", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                await _service.Delete(tipKorisnika.Id);
                await GetGridData();
            }
        }
    }
}
