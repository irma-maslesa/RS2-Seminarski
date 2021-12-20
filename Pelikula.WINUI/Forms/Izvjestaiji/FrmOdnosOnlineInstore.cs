using Microsoft.Reporting.WinForms;
using System;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Pelikula.WINUI.Forms.Izvjestaiji
{
    public partial class FrmOdnosOnlineInstore : Form
    {
        private readonly ApiService _service = new ApiService("Izvjestaj");

        private DateTime? _datumOd = null;
        private DateTime? _datumDo = null;

        public FrmOdnosOnlineInstore() {
            InitializeComponent();
        }

        private async void FrmOdnosOnlineInstore_Load(object sender, EventArgs e) {
            cbPeriod.Checked = false;
            dtpOd.Enabled = false;
            dtpOd.Value = DateTime.Today;
            dtpDo.Enabled = false;
            dtpDo.Value = DateTime.Today;

            cbPeriod.Enabled = false;
            btnPrikazi.Enabled = false;

            Cursor = Cursors.WaitCursor;

            await GetDataWithoutDates();

            Cursor = Cursors.Default;
            cbPeriod.Enabled = true;
            btnPrikazi.Enabled = true;
        }

        private async Task GetDataWithoutDates(bool showNoData = false) {
            var response = await _service.GetOdnosOnlineInstore(null, null);
            if (response.Payload != null && response.Payload.Any() && response.Payload.Any(o => o.Count > 0)) {
                ReportDataSource dataSource = new ReportDataSource("dsOdnosOnlineInstore", response.Payload);

                rvOdnosOnlineInstore.Reset();
                rvOdnosOnlineInstore.LocalReport.DataSources.Clear();
                rvOdnosOnlineInstore.LocalReport.DataSources.Add(dataSource);


                ReportParameterCollection parameters = new ReportParameterCollection {
                        new ReportParameter("DatumOd", response.Payload.Select(o => o.DatumOd).First().ToString()),
                        new ReportParameter("DatumDo", response.Payload.Select(o => o.DatumDo).First().ToString()),
                        new ReportParameter("Korisnik", $"{Properties.Settings.Default.PrijavljeniKorisnik.Ime} {Properties.Settings.Default.PrijavljeniKorisnik.Prezime} ({Properties.Settings.Default.PrijavljeniKorisnik.KorisnickoIme})")
                    };

                rvOdnosOnlineInstore.LocalReport.ReportEmbeddedResource = "Pelikula.WINUI.Forms.Izvjestaiji.RptOdnosOnlineInstore.rdlc";

                rvOdnosOnlineInstore.LocalReport.SetParameters(parameters);

                rvOdnosOnlineInstore.RefreshReport();
            }
            else if (showNoData) {
                MessageBox.Show("Nema podataka za prikaz!", "Greška", MessageBoxButtons.OK, MessageBoxIcon.Information);

                rvOdnosOnlineInstore.Reset();
                rvOdnosOnlineInstore.LocalReport.DataSources.Clear();
            }
        }

        private async void BtnPrikazi_Click(object sender, EventArgs e) {
            if (cbPeriod.Checked) {
                var datumOd = new DateTime(dtpOd.Value.Year, dtpOd.Value.Month, dtpOd.Value.Day, 0, 0, 0);
                var datumDo = new DateTime(dtpDo.Value.Year, dtpDo.Value.Month, dtpDo.Value.Day, 23, 59, 59);

                if (datumOd.Date <= datumDo.Date && (!_datumOd.HasValue || _datumOd.Value != datumOd || !_datumDo.HasValue || _datumDo.Value != datumDo)) {
                    _datumOd = datumOd;
                    _datumDo = datumDo;

                    ReportParameterCollection parameters = new ReportParameterCollection {
                    new ReportParameter("DatumOd", _datumOd.ToString()),
                    new ReportParameter("DatumDo", _datumDo.ToString())
                    };

                    var response = await _service.GetOdnosOnlineInstore(datumOd, datumDo);
                    if (response.Payload != null && response.Payload.Any() && response.Payload.Any(o => o.Count > 0)) {
                        ReportDataSource dataSource = new ReportDataSource("dsOdnosOnlineInstore", response.Payload);

                        rvOdnosOnlineInstore.Reset();
                        rvOdnosOnlineInstore.LocalReport.DataSources.Clear();
                        rvOdnosOnlineInstore.LocalReport.DataSources.Add(dataSource);

                        parameters.Add(new ReportParameter("Korisnik", $"{Properties.Settings.Default.PrijavljeniKorisnik.Ime} {Properties.Settings.Default.PrijavljeniKorisnik.Prezime} ({Properties.Settings.Default.PrijavljeniKorisnik.KorisnickoIme})"));

                        rvOdnosOnlineInstore.LocalReport.ReportEmbeddedResource = "Pelikula.WINUI.Forms.Izvjestaiji.RptOdnosOnlineInstore.rdlc";

                        rvOdnosOnlineInstore.LocalReport.SetParameters(parameters);

                        rvOdnosOnlineInstore.RefreshReport();
                    }
                    else {
                        MessageBox.Show("Nema podataka za prikaz!", "Greška", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        rvOdnosOnlineInstore.Reset();
                        rvOdnosOnlineInstore.LocalReport.DataSources.Clear();
                    }
                }
                else if (datumOd.Date > datumDo.Date) {
                    err.SetError(dtpOd, "Neispravna vrijednost");
                    err.SetError(dtpDo, "Neispravna vrijednost");
                }
            }
            else {
                _datumOd = null;
                _datumDo = null;
                await GetDataWithoutDates(true);
            }
        }

        private void DtpOd_ValueChanged(object sender, EventArgs e) {
            dtpDo.MinDate = dtpOd.Value;
        }

        private void DtpDo_ValueChanged(object sender, EventArgs e) {
            dtpOd.MaxDate = dtpDo.Value;
        }

        private void CbPeriod_CheckedChanged(object sender, EventArgs e) {
            if (cbPeriod.Checked) {
                dtpDo.Enabled = true;
                dtpOd.Enabled = true;
            }
            else {
                dtpDo.Enabled = false;
                dtpOd.Enabled = false;
            }
        }
    }
}
