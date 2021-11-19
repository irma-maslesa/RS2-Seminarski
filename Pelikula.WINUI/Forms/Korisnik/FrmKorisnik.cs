using Pelikula.API.Model;
using Pelikula.API.Model.Helper;
using Pelikula.API.Model.Korisnik;
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

namespace Pelikula.WINUI.Forms.Korisnik
{
    public partial class FrmKorisnik : Form
    {
        private readonly ApiService _service = new ApiService("Korisnik");
        private readonly ApiService _tipKorisnikaService = new ApiService("TipKorisnika");

        List<LoV> tipKorisnikaList = new List<LoV>();

        public FrmKorisnik()
        {
            InitializeComponent();
            dgvKorisnici.AutoGenerateColumns = false;
        }
        private async void FrmKorisnik_Load(object sender, EventArgs e)
        {
            DisableChildren();

            tipKorisnikaList = (await _tipKorisnikaService.GetLoVs<PagedPayloadResponse<LoV>>(null, null, null)).Payload.OrderBy(o => o.Naziv).ToList();
            tipKorisnikaList.Insert(0, new LoV { Id = -1, Naziv = "Svi" });

            cbTipKorisnika.DataSource = tipKorisnikaList;
            cbTipKorisnika.SelectedItem = tipKorisnikaList.FirstOrDefault(o => o.Id == -1);
            cbTipKorisnika.DisplayMember = "Naziv";
            cbTipKorisnika.ValueMember = "Id";

            await GetGridData();
        }

        private async void BtnPretrazi_Click(object sender, EventArgs e)
        {
            await GetGridData();
        }

        private async Task GetGridData(bool adding = false)
        {
            DisableChildren();

            int _currentIndex = dgvKorisnici.FirstDisplayedScrollingRowIndex;
            int? _selectedRowIndex = dgvKorisnici.CurrentRow?.Index;
            string _text = Text;
            Text += " (Loading ...)";

            List<FilterUtility.FilterParams> filters = new List<FilterUtility.FilterParams>();
            CreateFilters(filters, txtIme, "Ime");
            CreateFilters(filters, txtPrezime, "Prezime");
            CreateFilters(filters, txtKorisnickoIme, "KorisnickoIme");
            CreateFilters(filters, txtEmail, "Email");
            CreateCbFilters(filters, cbTipKorisnika, "TipKorisnikaId");

            Cursor = Cursors.WaitCursor;

            PagedPayloadResponse<KorisnikResponse> obj = await _service.Get<PagedPayloadResponse<KorisnikResponse>>(null, filters, null);

            dgvKorisnici.DataSource = obj.Payload;

            dgvKorisnici.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvKorisnici.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            if (filters.Count == 0 && _selectedRowIndex.HasValue)
                dgvKorisnici.ClearSelection();

            Cursor = Cursors.Default;

            EnableChildren();

            if (dgvKorisnici.RowCount == 0)
            {
                btnUredi.Enabled = false;
                btnObrisi.Enabled = false;
            }

            Text = _text;

            if (adding)
            {
                dgvKorisnici.FirstDisplayedScrollingRowIndex = dgvKorisnici.RowCount - 1;
            }
            else if (!adding && _currentIndex >= 0 && _currentIndex < dgvKorisnici.RowCount)
            {
                dgvKorisnici.FirstDisplayedScrollingRowIndex = _currentIndex;
            }
            else if (!adding && _currentIndex < 0 && dgvKorisnici.RowCount > 0)
            {
                dgvKorisnici.FirstDisplayedScrollingRowIndex = 0;
            }

            if (adding)
            {
                dgvKorisnici.CurrentCell = dgvKorisnici.Rows[dgvKorisnici.RowCount - 1].Cells[0];
                dgvKorisnici.Rows[dgvKorisnici.RowCount - 1].Selected = true;
            }
            else if (!adding && filters.Count == 0 && _selectedRowIndex.HasValue && _selectedRowIndex.Value >= dgvKorisnici.RowCount)
            {
                dgvKorisnici.CurrentCell = dgvKorisnici.Rows[_selectedRowIndex.Value - 1].Cells[0];
                dgvKorisnici.Rows[_selectedRowIndex.Value - 1].Selected = true;
            }
            else if (!adding && filters.Count == 0 && _selectedRowIndex.HasValue)
            {
                dgvKorisnici.CurrentCell = dgvKorisnici.Rows[_selectedRowIndex.Value].Cells[0];
                dgvKorisnici.Rows[_selectedRowIndex.Value].Selected = true;
            }
        }

        private void CreateFilters(List<FilterUtility.FilterParams> filters, TextBox txt, string columnName)
        {
            if (!string.IsNullOrEmpty(txt.Text))
            {
                FilterUtility.FilterParams filter = new FilterUtility.FilterParams
                {
                    ColumnName = columnName,
                    FilterOption = FilterUtility.FilterOptions.startswith.ToString(),
                    FilterValue = txt.Text
                };

                filters.Add(filter);
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

        private void EnableChildren()
        {
            txtIme.Enabled = true;
            txtPrezime.Enabled = true;
            txtKorisnickoIme.Enabled = true;
            txtEmail.Enabled = true;

            cbTipKorisnika.Enabled = true;

            btnPretrazi.Enabled = true;
            btnDodaj.Enabled = true;
            btnUredi.Enabled = true;
            btnObrisi.Enabled = true;
            dgvKorisnici.Enabled = true;
        }

        private void DisableChildren()
        {
            txtIme.Enabled = false;
            txtPrezime.Enabled = false;
            txtKorisnickoIme.Enabled = false;
            txtEmail.Enabled = false;

            cbTipKorisnika.Enabled = false;

            btnPretrazi.Enabled = false;
            btnDodaj.Enabled = false;
            btnUredi.Enabled = false;
            btnObrisi.Enabled = false;
            dgvKorisnici.Enabled = false;
        }

        private async void BtnDodaj_Click(object sender, EventArgs e)
        {
            FrmKorisnikDodajUredi frm = new FrmKorisnikDodajUredi
            {
                StartPosition = FormStartPosition.CenterParent
            };

            if (frm.ShowDialog() == DialogResult.OK)
                await GetGridData(adding: true);
        }

        private async void BtnUredi_Click(object sender, EventArgs e)
        {
            FrmKorisnikDodajUredi frm = new FrmKorisnikDodajUredi(((KorisnikResponse)dgvKorisnici.CurrentRow.DataBoundItem).Id)
            {
                StartPosition = FormStartPosition.CenterParent
            };

            if (frm.ShowDialog() == DialogResult.OK)
                await GetGridData();
        }

        private async void BtnObrisi_Click(object sender, EventArgs e)
        {
            KorisnikResponse korisnik = (KorisnikResponse)dgvKorisnici.CurrentRow.DataBoundItem;

            if (MessageBox.Show($"Jeste li sigurni da želite obrisati korisnika {korisnik.Ime} {korisnik.Prezime} ({korisnik.KorisnickoIme})?", "Upozorenje", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                await _service.Delete(korisnik.Id);
                await GetGridData();
            }
        }

        private async void CbTipKorisnika_SelectedValueChanged(object sender, EventArgs e)
        {
            await GetGridData();
        }
    }
}
