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
            btnUredi.Enabled = false;
            btnObrisi.Enabled = false;

            await GetGridData();
        }

        private async void BtnPretrazi_Click(object sender, EventArgs e)
        {
            await GetGridData(txtNaziv.Text);
        }

        private async Task GetGridData(string searchValue = null)
        {
            List<FilterUtility.FilterParams> filters = new List<FilterUtility.FilterParams>();

            if (!string.IsNullOrEmpty(searchValue))
            {
                FilterUtility.FilterParams filter = new FilterUtility.FilterParams
                {
                    ColumnName = "Naziv",
                    FilterOption = FilterUtility.FilterOptions.startswith.ToString(),
                    FilterValue = searchValue
                };

                filters.Add(filter);
            }

            Cursor = Cursors.WaitCursor;

            PagedPayloadResponse<ZanrResponse> obj = await _zanrService.Get<PagedPayloadResponse<ZanrResponse>>(null, filters, null);

            dgvZanrovi.DataSource = obj.Payload;

            btnUredi.Enabled = true;
            btnObrisi.Enabled = true;

            Cursor = Cursors.Default;
        }

        private async void BtnDodaj_Click(object sender, EventArgs e)
        {
            FrmZanrDodajUredi frm = new FrmZanrDodajUredi();
            frm.ShowDialog();

            int currentIndex = dgvZanrovi.FirstDisplayedScrollingRowIndex; 
            await GetGridData();
            dgvZanrovi.FirstDisplayedScrollingRowIndex = currentIndex;
        }

        private async void BtnUredi_Click(object sender, EventArgs e)
        {
            FrmZanrDodajUredi frm = new FrmZanrDodajUredi(((ZanrResponse)dgvZanrovi.CurrentRow.DataBoundItem).Id);
            frm.ShowDialog();

            int currentIndex = dgvZanrovi.FirstDisplayedScrollingRowIndex;
            await GetGridData();
            dgvZanrovi.FirstDisplayedScrollingRowIndex = currentIndex;
        }

        private async void BtnObrisi_Click(object sender, EventArgs e)
        {
            PayloadResponse<string> response = await _zanrService.Delete(((ZanrResponse)dgvZanrovi.CurrentRow.DataBoundItem).Id);

            MessageBox.Show(response.Payload, "", MessageBoxButtons.OK, MessageBoxIcon.Information);

            int currentIndex = dgvZanrovi.FirstDisplayedScrollingRowIndex;
            await GetGridData();
            dgvZanrovi.FirstDisplayedScrollingRowIndex = currentIndex;
        }
    }
}
