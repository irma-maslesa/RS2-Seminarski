using Pelikula.API.Model;
using Pelikula.API.Model.Helper;
using Pelikula.API.Model.Projekcija;
using Pelikula.CORE.Helper.Response;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Pelikula.WINUI.Forms.Projekcija
{
    public partial class FrmProjekcija : Form
    {
        private readonly ApiService _service = new ApiService("Projekcija");
        private readonly ApiService _filmService = new ApiService("Film");
        private readonly ApiService _salaService = new ApiService("Sala");

        List<LoV> filmList = new List<LoV>();
        List<LoV> salaList = new List<LoV>();

        public FrmProjekcija()
        {
            InitializeComponent();
            dgvProjekcije.AutoGenerateColumns = false;
        }
        private async void FrmProjekcija_Load(object sender, EventArgs e)
        {
            DisableChildren();

            filmList = (await _filmService.GetLoVs<PagedPayloadResponse<LoV>>(null, null, null)).Payload.OrderBy(o => o.Naziv).ToList();
            filmList.Insert(0, new LoV { Id = -1, Naziv = "Sve" });

            cbFilm.DataSource = filmList;
            cbFilm.SelectedItem = filmList.FirstOrDefault(o => o.Id == -1);
            cbFilm.DisplayMember = "Naziv";
            cbFilm.ValueMember = "Id";

            salaList = (await _salaService.GetLoVs<PagedPayloadResponse<LoV>>(null, null, null)).Payload.OrderBy(o => o.Naziv).ToList();
            salaList.Insert(0, new LoV { Id = -1, Naziv = "Sve" });

            cbSala.DataSource = salaList;
            cbSala.SelectedItem = salaList.FirstOrDefault(o => o.Id == -1);
            cbSala.DisplayMember = "Naziv";
            cbSala.ValueMember = "Id";

            cbAktivno.Items.AddRange(new object[] { "Sve", "Prethodne", "Trenutne", "Najavljene" });
            cbAktivno.DisplayMember = "Naziv";
            cbAktivno.ValueMember = "Id";
            cbAktivno.SelectedIndex = 0;

            await GetGridData();
        }

        private async void BtnPretrazi_Click(object sender, EventArgs e)
        {
            await GetGridData();
        }

        private async Task GetGridData(bool adding = false)
        {
            DisableChildren();

            int _currentIndex = dgvProjekcije.FirstDisplayedScrollingRowIndex;
            int? _selectedRowIndex = dgvProjekcije.CurrentRow?.Index;

            List<FilterUtility.FilterParams> filters = new List<FilterUtility.FilterParams>();

            CreateCbFilters(filters, cbSala, "SalaId");
            CreateCbFilters(filters, cbFilm, "FilmId");
            CreateCbAktivnoFilter(filters);

            Cursor = Cursors.WaitCursor;

            PagedPayloadResponse<ProjekcijaResponse> obj = await _service.Get<PagedPayloadResponse<ProjekcijaResponse>>(null, filters, null);

            dgvProjekcije.DataSource = obj.Payload;

            dgvProjekcije.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            if (filters.Count == 0 && _selectedRowIndex.HasValue)
                dgvProjekcije.ClearSelection();

            Cursor = Cursors.Default;

            EnableChildren();

            if (dgvProjekcije.RowCount == 0)
            {
                btnUredi.Enabled = false;
                btnObrisi.Enabled = false;
            }

            if (adding)
            {
                dgvProjekcije.FirstDisplayedScrollingRowIndex = dgvProjekcije.RowCount - 1;
            }
            else if (!adding && _currentIndex >= 0 && _currentIndex < dgvProjekcije.RowCount)
            {
                dgvProjekcije.FirstDisplayedScrollingRowIndex = _currentIndex;
            }
            else if (!adding && _currentIndex < 0 && dgvProjekcije.RowCount > 0)
            {
                dgvProjekcije.FirstDisplayedScrollingRowIndex = 0;
            }

            if (adding)
            {
                dgvProjekcije.CurrentCell = dgvProjekcije.Rows[dgvProjekcije.RowCount - 1].Cells[1];
                dgvProjekcije.Rows[dgvProjekcije.RowCount - 1].Selected = true;
            }
            else if (!adding && filters.Count == 0 && _selectedRowIndex.HasValue && _selectedRowIndex.Value >= dgvProjekcije.RowCount)
            {
                dgvProjekcije.CurrentCell = dgvProjekcije.Rows[_selectedRowIndex.Value - 1].Cells[1];
                dgvProjekcije.Rows[_selectedRowIndex.Value - 1].Selected = true;
            }
            else if (!adding && filters.Count == 0 && _selectedRowIndex.HasValue)
            {
                dgvProjekcije.CurrentCell = dgvProjekcije.Rows[_selectedRowIndex.Value].Cells[1];
                dgvProjekcije.Rows[_selectedRowIndex.Value].Selected = true;
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

        private void CreateCbAktivnoFilter(List<FilterUtility.FilterParams> filters)
        {
            var selectedItem = cbAktivno.SelectedItem?.ToString();

            var filter = new FilterUtility.FilterParams();
            var datum = DateTime.Now;

            switch (selectedItem)
            {
                case "Trenutne":
                    filter.ColumnName = "VrijediOd";
                    filter.FilterOption = FilterUtility.FilterOptions.islessthanorequalto.ToString();
                    filter.FilterValue = datum.ToString();
                    filters.Add(filter);

                    filter.ColumnName = "VrijediDo";
                    filter.FilterOption = FilterUtility.FilterOptions.isgreaterthanorequalto.ToString();
                    filter.FilterValue = datum.ToString();
                    filters.Add(filter);
                    break;
                case "Prethodne":
                    filter.ColumnName = "VrijediDo";
                    filter.FilterOption = FilterUtility.FilterOptions.islessthan.ToString();
                    filter.FilterValue = datum.ToString();
                    filters.Add(filter);
                    break;
                case "Najavljene":
                    filter.ColumnName = "VrijediOd";
                    filter.FilterOption = FilterUtility.FilterOptions.isgreaterthan.ToString();
                    filter.FilterValue = datum.ToString();
                    filters.Add(filter);
                    break;
                default:
                    break;
            }

        }

        private void EnableChildren()
        {
            cbFilm.Enabled = true;
            cbSala.Enabled = true;
            cbAktivno.Enabled = true;

            btnDodaj.Enabled = true;
            btnUredi.Enabled = true;
            btnObrisi.Enabled = true;

            dgvProjekcije.Enabled = true;
        }

        private void DisableChildren()
        {
            cbFilm.Enabled = false;
            cbSala.Enabled = false;
            cbAktivno.Enabled = false;

            btnDodaj.Enabled = false;
            btnUredi.Enabled = false;
            btnObrisi.Enabled = false;

            dgvProjekcije.Enabled = false;
        }

        private async void BtnDodaj_Click(object sender, EventArgs e)
        {
            FrmProjekcijaDodajUredi frm = new FrmProjekcijaDodajUredi
            {
                StartPosition = FormStartPosition.CenterParent
            };

            if (frm.ShowDialog() == DialogResult.OK)
                await GetGridData(adding: true);
        }

        private async void BtnUredi_Click(object sender, EventArgs e)
        {
            FrmProjekcijaDodajUredi frm = new FrmProjekcijaDodajUredi(((ProjekcijaResponse)dgvProjekcije.CurrentRow.DataBoundItem).Id)
            {
                StartPosition = FormStartPosition.CenterParent
            };

            if (frm.ShowDialog() == DialogResult.OK)
                await GetGridData();
        }

        private async void BtnObrisi_Click(object sender, EventArgs e)
        {
            ProjekcijaResponse data = (ProjekcijaResponse)dgvProjekcije.CurrentRow.DataBoundItem;

            if (MessageBox.Show($"Jeste li sigurni da želite obrisati projekciju {data.Film.Naziv} - {data.Sala.Naziv} ({data.VrijediOd:dd/MM/yyyy} - {data.VrijediDo:dd/MM/yyyy})?", "Upozorenje", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                await _service.Delete(data.Id);
                await GetGridData();
            }
        }

        private async void CbFilm_SelectedValueChanged(object sender, EventArgs e)
        {
            await GetGridData();
        }

        private async void CbSala_SelectedValueChanged(object sender, EventArgs e)
        {
            await GetGridData();
        }
        private async void CbAktivno_SelectedValueChanged(object sender, EventArgs e)
        {
            await GetGridData();
        }
    }
}
