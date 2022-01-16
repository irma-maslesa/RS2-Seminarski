using Microsoft.Reporting.WinForms;
using Pelikula.API.Model;
using Pelikula.CORE.Helper.Response;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace Pelikula.WINUI.Forms.Izvjestaiji
{
    public partial class FrmPrometUGodini : Form
    {
        private readonly ApiService _service = new ApiService("Izvjestaj");
        private readonly ApiService _zanrService = new ApiService("Zanr");

        List<LoV> zanrList = new List<LoV>();
        private int? _zanrId = null;

        public FrmPrometUGodini() {
            InitializeComponent();
        }

        private async void FrmPrometUGodini_Load(object sender, EventArgs e) {
            zanrList = (await _zanrService.GetLoVs<PagedPayloadResponse<LoV>>(null, null, null)).Payload.OrderBy(o => o.Naziv).ToList();
            zanrList.Insert(0, new LoV { Id = -1, Naziv = "Svi" });

            cbZanr.DataSource = zanrList;
            cbZanr.SelectedItem = zanrList.FirstOrDefault(o => o.Id == -1);
            cbZanr.DisplayMember = "Naziv";
            cbZanr.ValueMember = "Id";
        }

        private async void BtnPrikazi_Click(object sender, EventArgs e) {
            var datum = DateTime.Now;
            int? zanrId = null;
            if (cbZanr.SelectedItem != null && ((LoV)cbZanr.SelectedItem).Id != -1)
                zanrId = ((LoV)cbZanr.SelectedItem).Id;

            if (!_zanrId.HasValue || _zanrId.Value != zanrId) {
                _zanrId = zanrId;

                ReportParameterCollection parameters = new ReportParameterCollection {
                    new ReportParameter("DatumOd", new DateTime(datum.AddYears(-1).AddMonths(1).Year, datum.AddYears(-1).AddMonths(1).Month, 1).ToString()),
                    new ReportParameter("DatumDo",  new DateTime(datum.Year, datum.Month, DateTime.DaysInMonth(datum.Year, datum.Month)).ToString())
                };

                var response = await _service.GetPrometUGodini(_zanrId);
                if (response != null && response.Payload != null && response.Payload.Any()) {
                    ReportDataSource dataSource = new ReportDataSource("dsPrometUGodini", response.Payload);

                    rvPrometUGodini.Reset();
                    rvPrometUGodini.LocalReport.DataSources.Clear();
                    rvPrometUGodini.LocalReport.DataSources.Add(dataSource);

                    parameters.Add(new ReportParameter("Korisnik", $"{Properties.Settings.Default.PrijavljeniKorisnik.Ime} {Properties.Settings.Default.PrijavljeniKorisnik.Prezime} ({Properties.Settings.Default.PrijavljeniKorisnik.KorisnickoIme})"));

                    if (_zanrId.HasValue)
                        parameters.Add(new ReportParameter("Zanr", ((LoV)cbZanr.SelectedItem).Naziv));
                    else
                        parameters.Add(new ReportParameter("Zanr", "Svi"));

                    rvPrometUGodini.LocalReport.ReportEmbeddedResource = "Pelikula.WINUI.Forms.Izvjestaiji.RptPrometUGodini.rdlc";

                    rvPrometUGodini.LocalReport.SetParameters(parameters);

                    rvPrometUGodini.RefreshReport();
                }
                else {
                    MessageBox.Show("Nema podataka za prikaz!", "Greška", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    rvPrometUGodini.Reset();
                    rvPrometUGodini.LocalReport.DataSources.Clear();
                }

            }


        }
    }
}
