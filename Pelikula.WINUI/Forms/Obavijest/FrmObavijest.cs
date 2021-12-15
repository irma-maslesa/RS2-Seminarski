using Pelikula.API.Model;
using Pelikula.API.Model.Helper;
using Pelikula.API.Model.Obavijest;
using Pelikula.CORE.Helper.Response;
using Pelikula.WINUI.Helpers;
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

        public FrmObavijest() {
            InitializeComponent();
            dgvObavijesti.AutoGenerateColumns = false;
        }
        private async void FrmObavijest_Load(object sender, EventArgs e) {
            DisableChildren();

            korisnikList = (await _korisnikService.GetLoVs<PagedPayloadResponse<LoV>>(null, null, null)).Payload.OrderBy(o => o.Naziv).ToList();
            korisnikList.Insert(0, new LoV { Id = -1, Naziv = "Svi" });

            cbKorisnik.DataSource = korisnikList;
            cbKorisnik.SelectedItem = korisnikList.FirstOrDefault(o => o.Id == -1);
            cbKorisnik.DisplayMember = "Naziv";
            cbKorisnik.ValueMember = "Id";

            await GetGridData();
        }

        private async void BtnPretrazi_Click(object sender, EventArgs e) {
            await GetGridData();
        }

        private async Task GetGridData(bool adding = false) {
            DisableChildren();

            int _currentIndex = dgvObavijesti.FirstDisplayedScrollingRowIndex;
            int? _selectedRowIndex = null;

            if (dgvObavijesti.SelectedRows.Count > 0)
                _selectedRowIndex = dgvObavijesti.SelectedRows[0]?.Index;

            List<FilterUtility.FilterParams> filters = new List<FilterUtility.FilterParams>();
            FormHelper.CreateFilters(filters, txNaslov, "Naslov");
            FormHelper.CreateCbFilters(filters, cbKorisnik, "KorisnikId");

            Cursor = Cursors.WaitCursor;

            PagedPayloadResponse<ObavijestResponse> obj = await _service.Get<PagedPayloadResponse<ObavijestResponse>>(null, filters, null);

            dgvObavijesti.DataSource = obj.Payload;

            dgvObavijesti.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            if (filters.Count == 0 && _selectedRowIndex.HasValue)
                dgvObavijesti.ClearSelection();

            Cursor = Cursors.Default;

            EnableChildren();

            if (dgvObavijesti.RowCount == 0) {
                btnUredi.Enabled = false;
                btnObrisi.Enabled = false;
            }
            else {
                btnUredi.Enabled = true;
                btnObrisi.Enabled = true;
            }

            FormHelper.SelectAndShowDgvRow(dgvObavijesti, adding, _currentIndex, _selectedRowIndex, filters);
        }

        private void EnableChildren() {
            txNaslov.Enabled = true;

            cbKorisnik.Enabled = true;

            btnPretrazi.Enabled = true;
            btnDodaj.Enabled = true;
            btnUredi.Enabled = true;
            btnObrisi.Enabled = true;

            dgvObavijesti.Enabled = true;
        }

        private void DisableChildren() {
            txNaslov.Enabled = false;

            cbKorisnik.Enabled = false;

            btnPretrazi.Enabled = false;
            btnDodaj.Enabled = false;
            btnUredi.Enabled = false;
            btnObrisi.Enabled = false;

            dgvObavijesti.Enabled = false;
        }

        private async void BtnDodaj_Click(object sender, EventArgs e) {
            FrmObavijestDodajUredi frm = new FrmObavijestDodajUredi {
                StartPosition = FormStartPosition.CenterParent
            };

            if (frm.ShowDialog() == DialogResult.OK)
                await GetGridData(adding: true);
        }

        private async void BtnUredi_Click(object sender, EventArgs e) {
            FrmObavijestDodajUredi frm = new FrmObavijestDodajUredi(((ObavijestResponse)dgvObavijesti.SelectedRows[0].DataBoundItem).Id) {
                StartPosition = FormStartPosition.CenterParent
            };

            if (frm.ShowDialog() == DialogResult.OK)
                await GetGridData();
        }

        private async void BtnObrisi_Click(object sender, EventArgs e) {
            ObavijestResponse data = (ObavijestResponse)dgvObavijesti.SelectedRows[0].DataBoundItem;

            if (MessageBox.Show($"Jeste li sigurni da želite obrisati obavijest {data.Naslov} ({data.Datum})?", "Upozorenje", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes) {
                await _service.Delete(data.Id);
                await GetGridData();
            }
        }

        private async void CbKorisnik_SelectedValueChanged(object sender, EventArgs e) {
            await GetGridData();
        }
    }
}
