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
    public partial class FrmTopKorisnici : Form
    {
        private readonly ApiService _service = new ApiService("Izvjestaj");
        private readonly ApiService _zanrService = new ApiService("Zanr");

        List<LoV> zanrList = new List<LoV>();
        private int? _zanrId = null;

        public FrmTopKorisnici() {
            InitializeComponent();
        }

        private async void FrmTopKorisnici_Load(object sender, EventArgs e) {
            zanrList = (await _zanrService.GetLoVs<PagedPayloadResponse<LoV>>(null, null, null)).Payload.OrderBy(o => o.Naziv).ToList();
            zanrList.Insert(0, new LoV { Id = -1, Naziv = "Svi" });

            cbZanr.DataSource = zanrList;
            cbZanr.SelectedItem = zanrList.FirstOrDefault(o => o.Id == -1);
            cbZanr.DisplayMember = "Naziv";
            cbZanr.ValueMember = "Id";

            nudBrojKorisnika.Value = 5;
        }

        private async void BtnPrikazi_Click(object sender, EventArgs e) {
            var datum = DateTime.Now;
            int? zanrId = null;
            if (cbZanr.SelectedItem != null && ((LoV)cbZanr.SelectedItem).Id != -1)
                zanrId = ((LoV)cbZanr.SelectedItem).Id;

            if (!_zanrId.HasValue || _zanrId.Value != zanrId) {
                _zanrId = zanrId;

                var response = await _service.GetTopKorisnici((int)nudBrojKorisnika.Value, _zanrId);
                if (response.Payload.Any()) {
                    ReportDataSource dataSource = new ReportDataSource("dsTopKorisnici", response.Payload);

                    rvTopKorisnici.Reset();
                    rvTopKorisnici.LocalReport.DataSources.Clear(); 
                    rvTopKorisnici.LocalReport.DataSources.Add(dataSource);

                    ReportParameterCollection parameters = new ReportParameterCollection {
                        new ReportParameter("Datum", datum.ToString()),
                        new ReportParameter("Korisnik", $"{Properties.Settings.Default.PrijavljeniKorisnik.Ime} {Properties.Settings.Default.PrijavljeniKorisnik.Prezime} ({Properties.Settings.Default.PrijavljeniKorisnik.KorisnickoIme})")
                    };

                    if (_zanrId.HasValue)
                        parameters.Add(new ReportParameter("Zanr", ((LoV)cbZanr.SelectedItem).Naziv));
                    else
                        parameters.Add(new ReportParameter("Zanr", "Svi"));

                    rvTopKorisnici.LocalReport.ReportEmbeddedResource = "Pelikula.WINUI.Forms.Izvjestaiji.RptTopKorisnici.rdlc";

                    rvTopKorisnici.LocalReport.SetParameters(parameters);

                    rvTopKorisnici.RefreshReport();

                    if (response.Payload.Count() < nudBrojKorisnika.Value) {
                        MessageBox.Show("Traženi broj korisnika je prevelik, prikazan je maksimalni mogući broj korisnika!", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                else {
                    MessageBox.Show("Nema podataka za prikaz!", "Greška", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    rvTopKorisnici.Reset();
                    rvTopKorisnici.LocalReport.DataSources.Clear();
                }

            }


        }
    }
}
