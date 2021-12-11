using Pelikula.API.Model;
using Pelikula.API.Model.Film;
using Pelikula.API.Model.Helper;
using Pelikula.CORE.Helper.Response;
using Pelikula.WINUI.Helpers;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Pelikula.WINUI.Forms.Film
{
    public partial class FrmFilm : Form
    {
        private readonly ApiService _service = new ApiService("Film");
        private readonly ApiService _zanrService = new ApiService("Zanr");

        List<LoV> zanrList = new List<LoV>();

        public FrmFilm() {
            InitializeComponent();
            dgvFilmovi.AutoGenerateColumns = false;
        }
        private async void FrmFilm_Load(object sender, EventArgs e) {
            DisableChildren();

            zanrList = (await _zanrService.GetLoVs<PagedPayloadResponse<LoV>>(null, null, null)).Payload.OrderBy(o => o.Naziv).ToList();
            zanrList.Insert(0, new LoV { Id = -1, Naziv = "Svi" });

            cbZanr.DataSource = zanrList;
            cbZanr.SelectedItem = zanrList.FirstOrDefault(o => o.Id == -1);
            cbZanr.DisplayMember = "Naziv";
            cbZanr.ValueMember = "Id";

            await GetGridData();
        }

        private async void BtnPretrazi_Click(object sender, EventArgs e) {
            await GetGridData();
        }

        private async Task GetGridData(bool adding = false) {
            DisableChildren();

            int _currentIndex = dgvFilmovi.FirstDisplayedScrollingRowIndex;
            int? _selectedRowIndex = dgvFilmovi.CurrentRow?.Index;

            List<FilterUtility.FilterParams> filters = new List<FilterUtility.FilterParams>();
            FormHelper.CreateFilters(filters, txtNaslov, "Naslov");
            FormHelper.CreateCbFilters(filters, cbZanr, "ZanrId");

            CreateTrajanjeFilter(filters, txtMinTrajanje, FilterUtility.FilterOptions.isgreaterthanorequalto);
            CreateTrajanjeFilter(filters, txtMaxTrajanje, FilterUtility.FilterOptions.islessthanorequalto);

            Cursor = Cursors.WaitCursor;

            PagedPayloadResponse<FilmResponse> obj = await _service.Get<PagedPayloadResponse<FilmResponse>>(null, filters, null);

            dgvFilmovi.DataSource = obj.Payload;

            dgvFilmovi.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            if (filters.Count == 0 && _selectedRowIndex.HasValue)
                dgvFilmovi.ClearSelection();

            Cursor = Cursors.Default;

            EnableChildren();

            if (dgvFilmovi.RowCount == 0) {
                btnUredi.Enabled = false;
                btnObrisi.Enabled = false;
            }
            else {
                btnUredi.Enabled = true;
                btnObrisi.Enabled = true;
            }

            FormHelper.SelectAndShowDgvRow(dgvFilmovi, adding, _currentIndex, _selectedRowIndex, filters);
        }

        private void CreateTrajanjeFilter(List<FilterUtility.FilterParams> filters, MaskedTextBox txt, FilterUtility.FilterOptions option) {
            if (!string.IsNullOrEmpty(txt.Text))
                filters.Add(new FilterUtility.FilterParams("Trajanje", int.Parse(txt.Text).ToString(), option.ToString()));

        }

        private void EnableChildren() {
            txtNaslov.Enabled = true;
            txtMinTrajanje.Enabled = true;
            txtMaxTrajanje.Enabled = true;

            cbZanr.Enabled = true;

            btnPretrazi.Enabled = true;
            btnDodaj.Enabled = true;
            btnUredi.Enabled = true;
            btnObrisi.Enabled = true;

            dgvFilmovi.Enabled = true;
        }

        private void DisableChildren() {
            txtNaslov.Enabled = false;
            txtMinTrajanje.Enabled = false;
            txtMaxTrajanje.Enabled = false;

            cbZanr.Enabled = false;

            btnPretrazi.Enabled = false;
            btnDodaj.Enabled = false;
            btnUredi.Enabled = false;
            btnObrisi.Enabled = false;

            dgvFilmovi.Enabled = false;
        }

        private async void BtnDodaj_Click(object sender, EventArgs e) {
            FrmFilmDodajUredi frm = new FrmFilmDodajUredi {
                StartPosition = FormStartPosition.CenterParent
            };

            if (frm.ShowDialog() == DialogResult.OK)
                await GetGridData(adding: true);
        }

        private async void BtnUredi_Click(object sender, EventArgs e) {
            FrmFilmDodajUredi frm = new FrmFilmDodajUredi(((FilmResponse)dgvFilmovi.CurrentRow.DataBoundItem).Id) {
                StartPosition = FormStartPosition.CenterParent
            };

            if (frm.ShowDialog() == DialogResult.OK)
                await GetGridData();
        }

        private async void BtnObrisi_Click(object sender, EventArgs e) {
            FilmResponse data = (FilmResponse)dgvFilmovi.CurrentRow.DataBoundItem;

            if (MessageBox.Show($"Jeste li sigurni da želite obrisati film {data.Naslov}?", "Upozorenje", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes) {
                await _service.Delete(data.Id);
                await GetGridData();
            }
        }

        private async void CbZanr_SelectedValueChanged(object sender, EventArgs e) {
            await GetGridData();
        }
    }
}
