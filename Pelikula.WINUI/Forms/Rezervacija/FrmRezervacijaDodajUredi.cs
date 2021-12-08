using Pelikula.API;
using Pelikula.API.Model;
using Pelikula.API.Model.Helper;
using Pelikula.API.Model.Projekcija;
using Pelikula.API.Model.Rezervacija;
using Pelikula.CORE.Helper.Response;
using Pelikula.WINUI.Forms.Korisnik;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace Pelikula.WINUI.Forms.Rezervacija
{
    public partial class FrmRezervacijaDodajUredi : Form
    {
        private readonly ApiService _service = new ApiService("Rezervacija");

        private readonly ApiService _projekcijaService = new ApiService("Projekcija");
        private readonly ApiService _korisnikService = new ApiService("Korisnik");
        private readonly ApiService _salaService = new ApiService("Sala");
        private readonly int? _id;
        private int _salaId = 0;

        private RezervacijaResponse _initial = new RezervacijaResponse();
        private readonly RezervacijaUpsertRequest _request = new RezervacijaUpsertRequest();

        IEnumerable<LoV> projekcijaList = new List<LoV>();
        IEnumerable<LoV> terminList = new List<LoV>();
        IEnumerable<LoV> korisnikList = new List<LoV>();
        IEnumerable<LoV> sjedistaList = new List<LoV>();
        IEnumerable<LoV> zauzetaSjedistaList = new List<LoV>();

        public FrmRezervacijaDodajUredi(int? id = null)
        {
            _id = id;

            InitializeComponent();
        }

        private async void FrmRezervacijaDodajUredi_Load(object sender, EventArgs e)
        {
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            MinimizeBox = false;

            Text = "Dodaj rezervaciju";

            var filters = new List<FilterUtility.FilterParams>();
            CreateFilter(filters);

            projekcijaList = (await _projekcijaService.GetLoVs<PagedPayloadResponse<LoV>>(null, filters, null)).Payload.OrderBy(o => o.Naziv).ToList();
            cbProjekcija.DataSource = projekcijaList;
            cbProjekcija.DisplayMember = "Naziv";
            cbProjekcija.ValueMember = "Id";

            cbTermin.Enabled = false;
            cbKorisnik.Enabled = false;

            if (_id.HasValue)
            {
                cbProjekcija.Enabled = false;

                btnDodajKorisnika.Enabled = false;

                Text = "Uredi rezervaciju";

                PayloadResponse<RezervacijaResponse> response = await _service.GetById<PayloadResponse<RezervacijaResponse>>(_id.Value);
                _initial = response.Payload;

                SetValues();
            }
        }

        private static void CreateFilter(List<FilterUtility.FilterParams> filters)
        {
            var filter = new FilterUtility.FilterParams();

            filter.ColumnName = "VrijediOd";
            filter.FilterOption = FilterUtility.FilterOptions.islessthanorequalto.ToString();
            filter.FilterValue = DateTime.Now.ToString();
            filters.Add(filter);

            filter.ColumnName = "VrijediDo";
            filter.FilterOption = FilterUtility.FilterOptions.isgreaterthanorequalto.ToString();
            filter.FilterValue = DateTime.Now.ToString();
            filters.Add(filter);
        }

        private void SetValues()
        {
            cbProjekcija.SelectedItem = projekcijaList.FirstOrDefault(e => e.Id == _initial.ProjekcijaTermin?.Projekcija?.Id);

            var rezervisanaSjedistaIds = _initial.Sjedista.Select(e => e.Sjediste.Id).ToList();
            _request.SjedistaIds = rezervisanaSjedistaIds;
        }

        private async void BtnSpremi_Click(object sender, EventArgs e)
        {
            if (_request.SjedistaIds == null || _request.SjedistaIds.Count == 0)
            {
                err.SetError(flpSjedista, "Obavezno odabrati bar jedno sjediste!");
                return;
            }
            else
            {
                err.SetError(flpSjedista, null);
            }

            if (cbKorisnik.SelectedItem == null)
            {
                err.SetError(cbKorisnik, "Obavezno polje!");
                return;
            }
            else
            {
                err.SetError(cbKorisnik, null);
            }

            if (ValidateChildren())
            {
                _request.ProjekcijaTerminId = ((LoV)cbTermin.SelectedItem).Id;
                _request.KorisnikId = ((LoV)cbKorisnik.SelectedItem).Id;
                _request.BrojSjedista = _request.SjedistaIds.Count;
                _request.Datum = DateTime.Now;

                if (_id.HasValue)
                {
                    var response = await _service.Update<PayloadResponse<RezervacijaResponse>>(_id.Value, _request);

                    if (response != null)
                    {
                        MessageBox.Show($"Rezervacija {response.Payload.ProjekcijaTermin.Projekcija} - {response.Payload.Korisnik} - {response.Payload.BrojSjedista} uspješno uređena!", "", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        DialogResult = DialogResult.OK;
                        Close();
                    }
                }
                else
                {
                    PayloadResponse<RezervacijaResponse> response = await _service.Insert<PayloadResponse<RezervacijaResponse>>(_request);

                    if (response != null)
                    {
                        MessageBox.Show($"Rezervacija {response.Payload.ProjekcijaTermin.Projekcija} - {response.Payload.Korisnik} - {response.Payload.BrojSjedista} uspješno dodana!", "", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        DialogResult = DialogResult.OK;
                        Close();
                    }
                }
            }
        }

        private void BtnOcisti_Click(object sender, EventArgs e)
        {
            if (_request.SjedistaIds != null)
                _request.SjedistaIds.Clear();
            var buttons = flpSjedista.Controls.OfType<Button>().Where(o => o.Name != "btnEkran").ToList();
            buttons.ForEach(o => { o.BackColor = DefaultBackColor; o.UseVisualStyleBackColor = true; });

            SetValues();
            DisableAndSelectZauzetaSjedista();
        }

        private async void CbProjekcija_SelectedValueChanged(object sender, EventArgs e)
        {
            var data = (LoV)cbProjekcija.SelectedItem;
            var salaId = (await _projekcijaService.GetById<PayloadResponse<ProjekcijaResponse>>(data.Id)).Payload.Sala.Id;

            terminList = (await _projekcijaService.GetAktivniTermini(data.Id)).Payload.OrderBy(o => o.Naziv).ToList();

            if (!_id.HasValue)
                cbTermin.Enabled = true;
            else
                cbTermin.Enabled = false;

            cbTermin.DataSource = terminList;
            cbTermin.DisplayMember = "Naziv";
            cbTermin.ValueMember = "Id";
            cbTermin.SelectedItem = terminList.FirstOrDefault(o => o.Id == _initial.ProjekcijaTermin?.Id);

            if (cbTermin.SelectedItem == null)
                cbTermin.SelectedItem = terminList.FirstOrDefault();


            if (_salaId != salaId)
            {
                _salaId = salaId;
                sjedistaList = (await _salaService.GetSjedista(data.Id)).Payload;
                GenerateSjedistaView();
            }

        }

        private void GenerateSjedistaView()
        {
            var groupedSjedista = sjedistaList.GroupBy(e => e.Naziv.Substring(0, 1));
            var keys = groupedSjedista.Select(e => e.Key).ToList();

            flpSjedista.Controls.Clear();

            foreach (var redKey in keys)
            {
                var red = sjedistaList.Where(e => e.Naziv.Substring(0, 1).Equals(redKey));
                Button lastButton = null;
                foreach (var sjediste in red)
                {
                    Button btn = new Button();

                    btn.Name = sjediste.Id.ToString();
                    btn.Text = sjediste.Naziv;
                    btn.Size = new Size(35, 35);
                    btn.Margin = new Padding(3);
                    btn.Click += new EventHandler(Button_Click);

                    lastButton = btn;
                    flpSjedista.Controls.Add(btn);
                }

                flpSjedista.SetFlowBreak(lastButton, true);
            }

            Button ekranBtn = new Button();

            ekranBtn.Name = "btnEkran";
            ekranBtn.Text = "E     K     R     A     N";
            ekranBtn.Enabled = false;
            ekranBtn.Width = flpSjedista.Width - 3;
            flpSjedista.Controls.Add(ekranBtn);

            flpSjedista.Left = (Width - 12 - flpSjedista.Width) / 2;

            Top = 30;
        }

        private void Button_Click(object sender, EventArgs e)
        {
            var btn = (Button)sender;
            if (_request.SjedistaIds == null)
                _request.SjedistaIds = new List<int>();

            if (_request.SjedistaIds.Contains(int.Parse(btn.Name)))
            {
                _request.SjedistaIds.Remove(int.Parse(btn.Name));
                btn.BackColor = DefaultBackColor;
                btn.UseVisualStyleBackColor = true;
            }
            else
            {
                _request.SjedistaIds.Add(int.Parse(btn.Name));
                btn.BackColor = SystemColors.ActiveCaption;
            }
        }

        private async void CbTermin_SelectedValueChanged(object sender, EventArgs e)
        {
            var data = (LoV)cbTermin.SelectedItem;

            if (data != null)
            {
                if (!_id.HasValue)
                {
                    cbKorisnik.Enabled = true;
                    korisnikList = (await _korisnikService.GetKlijentiForTermin(data.Id, true)).Payload.OrderBy(o => o.Naziv).ToList();
                }
                else
                {
                    cbKorisnik.Enabled = false;
                    korisnikList = (await _korisnikService.GetKlijentiForTermin(data.Id, false)).Payload.OrderBy(o => o.Naziv).ToList();
                }

                zauzetaSjedistaList = (await _salaService.GetZauzetaSjedista(data.Id)).Payload;
                DisableAndSelectZauzetaSjedista();
            }

            cbKorisnik.DataSource = korisnikList;
            cbKorisnik.DisplayMember = "Naziv";
            cbKorisnik.ValueMember = "Id";
            cbKorisnik.SelectedItem = korisnikList.FirstOrDefault(o => o.Id == _initial.Korisnik?.Id);

            if (cbKorisnik.SelectedItem == null)
                cbKorisnik.SelectedItem = korisnikList.FirstOrDefault();

        }

        private void DisableAndSelectZauzetaSjedista()
        {
            var buttons = flpSjedista.Controls.OfType<Button>().Where(e => e.Name != "btnEkran").ToList();
            buttons.ForEach(e => e.Enabled = true);

            var zauzetaSjedistaIds = zauzetaSjedistaList.Select(e => e.Id).ToList();

            if (_request.SjedistaIds == null || _request.SjedistaIds.Count == 0)
                buttons.Where(e => zauzetaSjedistaIds.Contains(int.Parse(e.Name))).ToList().ForEach(e => e.Enabled = false);
            else
            {
                buttons.Where(e => zauzetaSjedistaIds.Contains(int.Parse(e.Name)) && !_request.SjedistaIds.Contains(int.Parse(e.Name))).ToList().ForEach(e => e.Enabled = false);
                buttons.Where(e => _request.SjedistaIds.Contains(int.Parse(e.Name))).ToList().ForEach(e => e.BackColor = SystemColors.ActiveCaption);
            }

        }

        //VALIDACIJA

        private void CbProjekcija_Validating(object sender, CancelEventArgs e)
        {
            if (cbProjekcija.SelectedItem == null)
            {
                e.Cancel = true;
                err.SetError(cbProjekcija, "Obavezno polje!");
            }
            else
            {
                err.SetError(cbProjekcija, null);
            }
        }

        private void CbTermin_Validating(object sender, CancelEventArgs e)
        {
            if (cbTermin.SelectedItem == null)
            {
                e.Cancel = true;
                err.SetError(cbTermin, "Obavezno polje!");
            }
            else
            {
                err.SetError(cbTermin, null);
            }
        }

        private async void BtnDodajKorisnika_Click(object sender, EventArgs e)
        {
            FrmKorisnikDodajUredi frm = new FrmKorisnikDodajUredi
            {
                StartPosition = FormStartPosition.CenterParent
            };

            if (frm.ShowDialog() == DialogResult.OK)
            {
                var data = (LoV)cbTermin.SelectedItem;
                korisnikList = (await _korisnikService.GetKlijentiForTermin(data.Id, true)).Payload.OrderBy(o => o.Naziv).ToList();
                cbKorisnik.DataSource = korisnikList;
            }
        }
    }
}
