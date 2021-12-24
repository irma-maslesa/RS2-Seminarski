using Microsoft.Reporting.WinForms;
using System;
using System.Linq;
using System.Windows.Forms;

namespace Pelikula.WINUI.Forms.Izvjestaiji
{
    public partial class FrmProdajaPoDatumu : Form
    {
        private readonly ApiService _service = new ApiService("Izvjestaj");

        private DateTime? _datumOd = null;
        private DateTime? _datumDo = null;

        public FrmProdajaPoDatumu() {
            InitializeComponent();
        }

        private void FrmProdajaPoDatumu_Load(object sender, EventArgs e) {
            dtpOd.Value = DateTime.Today;
            dtpDo.Value = DateTime.Today;
        }


        private async void BtnPrikazi_Click(object sender, EventArgs e) {

            var datumOd = new DateTime(dtpOd.Value.Year, dtpOd.Value.Month, dtpOd.Value.Day, 0, 0, 0);
            var datumDo = new DateTime(dtpDo.Value.Year, dtpDo.Value.Month, dtpDo.Value.Day, 23, 59, 59);

            if (datumOd <= datumDo && (!_datumOd.HasValue || _datumOd.Value != datumOd || !_datumDo.HasValue || _datumDo.Value != datumDo)) {
                _datumOd = datumOd;
                _datumDo = datumDo;

                ReportParameterCollection parameters = new ReportParameterCollection {
                    new ReportParameter("DatumOd", _datumOd.ToString()),
                    new ReportParameter("DatumDo", _datumDo.ToString())
                };

                var response = await _service.GetProdajaPoDatumu(datumOd, datumDo);
                if (response != null && response.Payload != null && response.Payload.Any()) {
                    ReportDataSource dataSource = new ReportDataSource("dsProdajaPoDatumu", response.Payload);

                    rvProdajaPoDatumu.Reset();
                    rvProdajaPoDatumu.LocalReport.DataSources.Clear();
                    rvProdajaPoDatumu.LocalReport.DataSources.Add(dataSource);

                    parameters.Add(new ReportParameter("Korisnik", $"{Properties.Settings.Default.PrijavljeniKorisnik.Ime} {Properties.Settings.Default.PrijavljeniKorisnik.Prezime} ({Properties.Settings.Default.PrijavljeniKorisnik.KorisnickoIme})"));

                    rvProdajaPoDatumu.LocalReport.ReportEmbeddedResource = "Pelikula.WINUI.Forms.Izvjestaiji.RptProdajaPoDatumu.rdlc";

                    rvProdajaPoDatumu.LocalReport.SetParameters(parameters);

                    rvProdajaPoDatumu.RefreshReport();
                }
                else {
                    MessageBox.Show("Nema podataka za prikaz!", "Greška", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    rvProdajaPoDatumu.Reset();
                    rvProdajaPoDatumu.LocalReport.DataSources.Clear();
                }

            }
            else if (datumOd > datumDo) {
                err.SetError(dtpOd, "Neispravna vrijednost");
                err.SetError(dtpDo, "Neispravna vrijednost");
            }
        }

        private void DtpOd_ValueChanged(object sender, EventArgs e) {
            dtpDo.MinDate = dtpOd.Value;
        }

        private void DtpDo_ValueChanged(object sender, EventArgs e) {
            dtpOd.MaxDate = dtpDo.Value;
        }
    }
}
