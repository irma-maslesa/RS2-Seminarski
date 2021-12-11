using Pelikula.API.Model.FilmskaLicnost;
using Pelikula.CORE.Helper.Response;
using System;
using System.Windows.Forms;

namespace Pelikula.WINUI.Forms.FilmskaLicnost
{
    public partial class FrmFilmskaLicnostDodajUredi : Form
    {
        private readonly ApiService _service = new ApiService("FilmskaLicnost");
        private readonly int? _id;
        private FilmskaLicnostResponse _initial = new FilmskaLicnostResponse();

        public FrmFilmskaLicnostDodajUredi(int? id = null) {
            _id = id;

            InitializeComponent();
        }

        private async void FrmFilmskaLicnostDodajUredi_Load(object sender, EventArgs e) {
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            MinimizeBox = false;

            clbVrsta.Items.AddRange(new object[] { "Glumac", "Režiser" });
            clbVrsta.DisplayMember = "Naziv";
            clbVrsta.ValueMember = "Id";
            clbVrsta.CheckOnClick = true;

            Text = "Dodaj filmsku ličnost";

            if (_id.HasValue) {
                DisableChildren();

                Text = "Uredi filmsku ličnost";

                PayloadResponse<FilmskaLicnostResponse> response = await _service.GetById<PayloadResponse<FilmskaLicnostResponse>>(_id.Value);
                _initial = response.Payload;

                SetValues();

                EnableChildren();
            }
        }

        private void EnableChildren() {
            txtIme.Enabled = true;
            txtPrezime.Enabled = true;
            btnOcisti.Enabled = true;
            btnSpremi.Enabled = true;
        }

        private void DisableChildren() {
            txtIme.Enabled = false;
            txtPrezime.Enabled = false;
            btnOcisti.Enabled = false;
            btnSpremi.Enabled = false;
        }

        private void SetValues() {
            txtIme.Text = _initial.Ime;
            txtPrezime.Text = _initial.Prezime;

            clbVrsta.SetItemChecked(clbVrsta.Items.IndexOf("Glumac"), _initial.IsGlumac);
            clbVrsta.SetItemChecked(clbVrsta.Items.IndexOf("Režiser"), _initial.IsReziser);
        }

        private async void BtnSpremi_Click(object sender, EventArgs e) {
            int errCount = 0;

            if (string.IsNullOrWhiteSpace(txtIme.Text)) {
                errIme.SetError(txtIme, "Obavezno polje!");
                errCount++;
            }

            if (string.IsNullOrWhiteSpace(txtPrezime.Text)) {
                errIme.SetError(txtPrezime, "Obavezno polje!");
                errCount++;
            }

            if (clbVrsta.CheckedItems.Count == 0) {
                errIme.SetError(clbVrsta, "Obavezno polje!");
                errCount++;
            }

            if (errCount != 0)
                return;


            FilmskaLicnostUpsertRequest request = new FilmskaLicnostUpsertRequest() {
                Ime = txtIme.Text,
                Prezime = txtPrezime.Text,
                IsGlumac = clbVrsta.CheckedItems.Contains("Glumac"),
                IsReziser = clbVrsta.CheckedItems.Contains("Režiser")
            };

            if (_id.HasValue) {

                var response = await _service.Update<PayloadResponse<FilmskaLicnostResponse>>(_id.Value, request);

                if (response != null) {
                    MessageBox.Show($"Filmska ličnost {txtIme.Text} {txtPrezime.Text} uspješno uređena!", "", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    DialogResult = DialogResult.OK;
                    Close();
                }
            }
            else {
                PayloadResponse<FilmskaLicnostResponse> response = await _service.Insert<PayloadResponse<FilmskaLicnostResponse>>(request);

                if (response != null) {
                    MessageBox.Show($"Filmska ličnost {response.Payload.Ime} {response.Payload.Prezime} uspješno dodana!", "", MessageBoxButtons.OK, MessageBoxIcon.Information);

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
