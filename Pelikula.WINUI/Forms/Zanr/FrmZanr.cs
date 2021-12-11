using Pelikula.API.Model.Helper;
using Pelikula.API.Model.Zanr;
using Pelikula.CORE.Helper.Response;
using Pelikula.WINUI.Helpers;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Pelikula.WINUI.Forms.Zanr
{
    public partial class FrmZanr : Form
    {
        private readonly ApiService _ZanrService = new ApiService("Zanr");

        public FrmZanr() {
            InitializeComponent();
        }
        private async void FrmZanr_Load(object sender, EventArgs e) {
            await GetGridData();
        }

        private async void BtnPretrazi_Click(object sender, EventArgs e) {
            await GetGridData();
        }

        private async Task GetGridData(bool adding = false) {
            DisableChildren();

            int _currentIndex = dgvZanrovi.FirstDisplayedScrollingRowIndex;
            int? _selectedRowIndex = dgvZanrovi.CurrentRow?.Index;

            List<FilterUtility.FilterParams> filters = new List<FilterUtility.FilterParams>();
            FormHelper.CreateFilters(filters, txtNaziv, "Naziv");

            Cursor = Cursors.WaitCursor;

            PagedPayloadResponse<ZanrResponse> obj = await _ZanrService.Get<PagedPayloadResponse<ZanrResponse>>(null, filters, null);

            dgvZanrovi.DataSource = obj.Payload;
            dgvZanrovi.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvZanrovi.Columns[0].Visible = false;
            if (string.IsNullOrEmpty(txtNaziv.Text) && _selectedRowIndex.HasValue)
                dgvZanrovi.ClearSelection();

            Cursor = Cursors.Default;

            EnableChildren();

            if (dgvZanrovi.RowCount == 0) {
                btnUredi.Enabled = false;
                btnObrisi.Enabled = false;
            }
            else {
                btnUredi.Enabled = true;
                btnObrisi.Enabled = true;
            }

            FormHelper.SelectAndShowDgvRow(dgvZanrovi, adding, _currentIndex, _selectedRowIndex, filters);
        }
        private void EnableChildren() {
            txtNaziv.Enabled = true;
            btnPretrazi.Enabled = true;
            btnDodaj.Enabled = true;
            btnUredi.Enabled = true;
            btnObrisi.Enabled = true;
            dgvZanrovi.Enabled = true;
        }

        private void DisableChildren() {
            txtNaziv.Enabled = false;
            btnPretrazi.Enabled = false;
            btnDodaj.Enabled = false;
            btnUredi.Enabled = false;
            btnObrisi.Enabled = false;
            dgvZanrovi.Enabled = false;
        }

        private async void BtnDodaj_Click(object sender, EventArgs e) {
            FrmZanrDodajUredi frm = new FrmZanrDodajUredi {
                StartPosition = FormStartPosition.CenterParent
            };

            if (frm.ShowDialog() == DialogResult.OK)
                await GetGridData(adding: true);
        }

        private async void BtnUredi_Click(object sender, EventArgs e) {
            FrmZanrDodajUredi frm = new FrmZanrDodajUredi(((ZanrResponse)dgvZanrovi.CurrentRow.DataBoundItem).Id) {
                StartPosition = FormStartPosition.CenterParent
            };

            if (frm.ShowDialog() == DialogResult.OK)
                await GetGridData();
        }

        private async void BtnObrisi_Click(object sender, EventArgs e) {
            ZanrResponse Zanr = (ZanrResponse)dgvZanrovi.CurrentRow.DataBoundItem;

            if (MessageBox.Show($"Jeste li sigurni da želite obrisati žanr {Zanr.Naziv}?", "Upozorenje", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes) {
                await _ZanrService.Delete(Zanr.Id);
                await GetGridData();
            }
        }
    }
}
