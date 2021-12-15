using Pelikula.API.Model.Helper;
using Pelikula.API.Model.JedinicaMjere;
using Pelikula.CORE.Helper.Response;
using Pelikula.WINUI.Helpers;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Pelikula.WINUI.Forms.JedinicaMjere
{
    public partial class FrmJedinicaMjere : Form
    {
        private readonly ApiService _service = new ApiService("JedinicaMjere");

        public FrmJedinicaMjere() {
            InitializeComponent();
        }
        private async void FrmJedinicaMjere_Load(object sender, EventArgs e) {
            await GetGridData();
        }

        private async void BtnPretrazi_Click(object sender, EventArgs e) {
            await GetGridData();
        }

        private async Task GetGridData(bool adding = false) {
            DisableChildren();

            int _currentIndex = dgvJediniceMjere.FirstDisplayedScrollingRowIndex;
            int? _selectedRowIndex = null;

            if (dgvJediniceMjere.SelectedRows.Count > 0)
                _selectedRowIndex = dgvJediniceMjere.SelectedRows[0]?.Index;

            List<FilterUtility.FilterParams> filters = new List<FilterUtility.FilterParams>();
            FormHelper.CreateFilters(filters, txtNaziv, "Naziv");

            Cursor = Cursors.WaitCursor;

            PagedPayloadResponse<JedinicaMjereResponse> obj = await _service.Get<PagedPayloadResponse<JedinicaMjereResponse>>(null, filters, null);

            dgvJediniceMjere.DataSource = obj.Payload;
            dgvJediniceMjere.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvJediniceMjere.Columns[0].Visible = false;
            if (string.IsNullOrEmpty(txtNaziv.Text) && _selectedRowIndex.HasValue)
                dgvJediniceMjere.ClearSelection();

            Cursor = Cursors.Default;

            EnableChildren();

            if (dgvJediniceMjere.RowCount == 0) {
                btnUredi.Enabled = false;
                btnObrisi.Enabled = false;
            }
            else {
                btnUredi.Enabled = true;
                btnObrisi.Enabled = true;
            }

            FormHelper.SelectAndShowDgvRow(dgvJediniceMjere, adding, _currentIndex, _selectedRowIndex, filters);
        }
        private void EnableChildren() {
            txtNaziv.Enabled = true;
            btnPretrazi.Enabled = true;
            btnDodaj.Enabled = true;
            btnUredi.Enabled = true;
            btnObrisi.Enabled = true;
            dgvJediniceMjere.Enabled = true;
        }

        private void DisableChildren() {
            txtNaziv.Enabled = false;
            btnPretrazi.Enabled = false;
            btnDodaj.Enabled = false;
            btnUredi.Enabled = false;
            btnObrisi.Enabled = false;
            dgvJediniceMjere.Enabled = false;
        }

        private async void BtnDodaj_Click(object sender, EventArgs e) {
            FrmJedinicaMjereDodajUredi frm = new FrmJedinicaMjereDodajUredi {
                StartPosition = FormStartPosition.CenterParent
            };

            if (frm.ShowDialog() == DialogResult.OK)
                await GetGridData(adding: true);
        }

        private async void BtnUredi_Click(object sender, EventArgs e) {
            FrmJedinicaMjereDodajUredi frm = new FrmJedinicaMjereDodajUredi(((JedinicaMjereResponse)dgvJediniceMjere.SelectedRows[0].DataBoundItem).Id) {
                StartPosition = FormStartPosition.CenterParent
            };

            if (frm.ShowDialog() == DialogResult.OK)
                await GetGridData();
        }

        private async void BtnObrisi_Click(object sender, EventArgs e) {
            JedinicaMjereResponse data = (JedinicaMjereResponse)dgvJediniceMjere.SelectedRows[0].DataBoundItem;

            if (MessageBox.Show($"Jeste li sigurni da želite obrisati jedinicu mjere {data.Naziv}?", "Upozorenje", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes) {
                await _service.Delete(data.Id);
                await GetGridData();
            }
        }
    }
}
