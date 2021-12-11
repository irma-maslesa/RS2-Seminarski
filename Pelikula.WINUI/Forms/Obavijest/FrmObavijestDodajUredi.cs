using Pelikula.API.Model.Obavijest;
using Pelikula.CORE.Helper.Response;
using System;
using System.ComponentModel;
using System.Windows.Forms;

namespace Pelikula.WINUI.Forms.Obavijest
{
    public partial class FrmObavijestDodajUredi : Form
    {
        private readonly ApiService _service = new ApiService("Obavijest");

        private readonly int? _id;

        private ObavijestResponse _initial = new ObavijestResponse();
        private readonly ObavijestUpsertRequest _request = new ObavijestUpsertRequest();

        public FrmObavijestDodajUredi(int? id = null) {
            _id = id;

            InitializeComponent();
        }

        private async void FrmObavijestDodajUredi_Load(object sender, EventArgs e) {
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            MinimizeBox = false;

            txtTekst.AutoSize = false;
            txtTekst.WordWrap = true;
            txtTekst.Multiline = true;
            txtTekst.ScrollBars = ScrollBars.Vertical;

            Text = "Dodaj artikal";

            if (_id.HasValue) {
                Text = "Uredi artikal";

                PayloadResponse<ObavijestResponse> response = await _service.GetById<PayloadResponse<ObavijestResponse>>(_id.Value);
                _initial = response.Payload;

                SetValues();
            }
        }

        private void SetValues() {
            txtNaslov.Text = _initial.Naslov;
            txtTekst.Text = _initial.Tekst;
        }

        private async void BtnSpremi_Click(object sender, EventArgs e) {
            if (ValidateChildren()) {
                _request.Naslov = txtNaslov.Text;
                _request.Tekst = txtTekst.Text;
                _request.Datum = _initial.Datum;

                if (_initial.Korisnik != null)
                    _request.KorisnikId = _initial.Korisnik.Id;

                if (_id.HasValue) {
                    var response = await _service.Update<PayloadResponse<ObavijestResponse>>(_id.Value, _request);

                    if (response != null) {
                        MessageBox.Show($"Obavijest {txtNaslov.Text} uspješno uređena!", "", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        DialogResult = DialogResult.OK;
                        Close();
                    }
                }
                else {
                    _request.Datum = DateTime.Now;
                    _request.KorisnikId = Properties.Settings.Default.PrijavljeniKorisnik.Id;

                    PayloadResponse<ObavijestResponse> response = await _service.Insert<PayloadResponse<ObavijestResponse>>(_request);

                    if (response != null) {
                        MessageBox.Show($"Obavijest {response.Payload.Naslov} uspješno dodana!", "", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        DialogResult = DialogResult.OK;
                        Close();
                    }
                }
            }
        }

        private void BtnOcisti_Click(object sender, EventArgs e) {
            SetValues();
        }

        //VALIDACIJA
        private void TxtNaslov_Validating(object sender, CancelEventArgs e) {
            if (string.IsNullOrEmpty(txtNaslov.Text.Trim())) {
                e.Cancel = true;
                err.SetError(txtNaslov, "Obavezno polje!");
            }
            else {
                err.SetError(txtNaslov, null);
            }
        }

        private void TxtTekst_Validating(object sender, CancelEventArgs e) {
            if (string.IsNullOrEmpty(txtTekst.Text.Trim())) {
                e.Cancel = true;
                err.SetError(txtTekst, "Obavezno polje!");
            }
            else {
                err.SetError(txtTekst, null);
            }
        }
    }
}
