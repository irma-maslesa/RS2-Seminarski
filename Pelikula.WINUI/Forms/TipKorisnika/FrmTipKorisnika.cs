using Pelikula.API.Model.Helper;
using Pelikula.API.Model.TipKorisnika;
using Pelikula.CORE.Helper.Response;
using Pelikula.WINUI.Helpers;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Pelikula.WINUI.Forms.TipKorisnika
{
    public partial class FrmTipKorisnika : Form
    {
        private readonly ApiService _service = new ApiService("TipKorisnika");

        public FrmTipKorisnika() {
            InitializeComponent();
        }

        private async void FrmTipKorisnika_Load(object sender, EventArgs e) {
            await GetGridData();
        }

        private async void BtnPretrazi_Click(object sender, EventArgs e) {
            await GetGridData();
        }

        private async Task GetGridData(bool adding = false) {
            DisableChildren();

            int _currentIndex = dgvTipoviKorisnika.FirstDisplayedScrollingRowIndex;
            int? _selectedRowIndex = null;

            if (dgvTipoviKorisnika.SelectedRows.Count > 0)
                _selectedRowIndex = dgvTipoviKorisnika.SelectedRows[0]?.Index;

            List<FilterUtility.FilterParams> filters = new List<FilterUtility.FilterParams>();
            FormHelper.CreateFilters(filters, txtNaziv, "Naziv");

            Cursor = Cursors.WaitCursor;

            PagedPayloadResponse<TipKorisnikaResponse> obj = await _service.Get<PagedPayloadResponse<TipKorisnikaResponse>>(null, filters, null);

            if (obj != null)
                dgvTipoviKorisnika.DataSource = obj.Payload;

            dgvTipoviKorisnika.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvTipoviKorisnika.Columns[0].Visible = false;

            if (string.IsNullOrEmpty(txtNaziv.Text) && _selectedRowIndex.HasValue)
                dgvTipoviKorisnika.ClearSelection();

            Cursor = Cursors.Default;

            EnableChildren();

            FormHelper.SelectAndShowDgvRow(dgvTipoviKorisnika, adding, _currentIndex, _selectedRowIndex, filters);
        }
        private void EnableChildren() {
            txtNaziv.Enabled = true;
            btnPretrazi.Enabled = true;
            dgvTipoviKorisnika.Enabled = true;
        }

        private void DisableChildren() {
            txtNaziv.Enabled = false;
            btnPretrazi.Enabled = false;
            dgvTipoviKorisnika.Enabled = false;
        }
    }
}
