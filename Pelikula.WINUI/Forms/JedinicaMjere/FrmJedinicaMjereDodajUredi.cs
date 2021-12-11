using Pelikula.API.Model.JedinicaMjere;
using Pelikula.CORE.Helper.Response;
using System;
using System.Windows.Forms;

namespace Pelikula.WINUI.Forms.JedinicaMjere
{
    public partial class FrmJedinicaMjereDodajUredi : Form
    {
        private readonly ApiService _service = new ApiService("JedinicaMjere");
        private readonly int? _id;
        private JedinicaMjereResponse _initial = new JedinicaMjereResponse();

        public FrmJedinicaMjereDodajUredi(int? id = null) {
            _id = id;

            InitializeComponent();
        }

        private async void FrmJedinicaMjereDodajUredi_Load(object sender, EventArgs e) {
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            MinimizeBox = false;

            Text = "Dodaj jedinicu mjere";

            if (_id.HasValue) {
                DisableChildren();

                Text = "Uredi jedinicu mjere";

                PayloadResponse<JedinicaMjereResponse> response = await _service.GetById<PayloadResponse<JedinicaMjereResponse>>(_id.Value);
                _initial = response.Payload;

                SetValues();

                EnableChildren();
            }
        }

        private void EnableChildren() {
            txtNaziv.Enabled = true;
            txtKratkiNaziv.Enabled = true;
            btnOcisti.Enabled = true;
            btnSpremi.Enabled = true;
        }

        private void DisableChildren() {
            txtNaziv.Enabled = false;
            txtKratkiNaziv.Enabled = false;
            btnOcisti.Enabled = false;
            btnSpremi.Enabled = false;
        }

        private void SetValues() {
            txtNaziv.Text = _initial.Naziv;
            txtKratkiNaziv.Text = _initial.KratkiNaziv;
        }

        private async void BtnSpremi_Click(object sender, EventArgs e) {
            int errCount = 0;

            if (string.IsNullOrWhiteSpace(txtNaziv.Text)) {
                errNaziv.SetError(txtNaziv, "Obavezno polje!");
                errCount++;
            }

            if (string.IsNullOrWhiteSpace(txtKratkiNaziv.Text)) {
                errNaziv.SetError(txtKratkiNaziv, "Obavezno polje!");
                errCount++;
            }

            if (errCount != 0)
                return;

            JedinicaMjereUpsertRequest request = new JedinicaMjereUpsertRequest() { Naziv = txtNaziv.Text, KratkiNaziv = txtKratkiNaziv.Text };

            if (_id.HasValue) {
                var response = await _service.Update<PayloadResponse<JedinicaMjereResponse>>(_id.Value, request);

                if (response != null) {
                    MessageBox.Show($"Jedinica mjere {txtNaziv.Text} uspješno uređena!", "", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    DialogResult = DialogResult.OK;
                    Close();
                }
            }
            else {
                PayloadResponse<JedinicaMjereResponse> response = await _service.Insert<PayloadResponse<JedinicaMjereResponse>>(request);

                if (response != null) {
                    MessageBox.Show($"Jedinica mjere {response.Payload.Naziv} uspješno dodana!", "", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    DialogResult = DialogResult.OK;
                    Close();
                }
            }
        }

        private void BtnOcisti_Click(object sender, EventArgs e) {
            SetValues();
        }

    }
}
