using Pelikula.API.Model;
using Pelikula.API.Model.Artikal;
using Pelikula.CORE.Helper.Response;
using Pelikula.WINUI.Helpers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace Pelikula.WINUI.Forms.Artikal
{
    public partial class FrmArtikalDodajUredi : Form
    {
        private readonly ApiService _service = new ApiService("Artikal");

        private readonly ApiService _jedinicaMjereService = new ApiService("JedinicaMjere");
        private readonly int? _id;

        private ArtikalResponse _initial = new ArtikalResponse();
        private readonly ArtikalUpsertRequest _request = new ArtikalUpsertRequest();

        IEnumerable<LoV> jedinicaMjereList = new List<LoV>();

        public FrmArtikalDodajUredi(int? id = null) {
            _id = id;

            InitializeComponent();
        }

        private async void FrmArtikalDodajUredi_Load(object sender, EventArgs e) {
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            MinimizeBox = false;

            Text = "Dodaj artikal";

            jedinicaMjereList = (await _jedinicaMjereService.GetLoVs<PagedPayloadResponse<LoV>>(null, null, null)).Payload.OrderBy(o => o.Naziv).ToList();
            cbJedinicaMjere.DataSource = jedinicaMjereList;
            cbJedinicaMjere.DisplayMember = "Naziv";
            cbJedinicaMjere.ValueMember = "Id";

            if (_id.HasValue) {
                Text = "Uredi artikal";

                PayloadResponse<ArtikalResponse> response = await _service.GetById<PayloadResponse<ArtikalResponse>>(_id.Value);
                if (response != null)
                    _initial = response.Payload;

                SetValues();
            }
        }

        private void SetValues() {
            txtNaziv.Text = _initial.Naziv;
            txtCijena.Text = _initial.Cijena.ToString("0000.00");

            if (_initial.SlikaThumb != null && _initial.SlikaThumb.Length > 0)
                pbSlika.Image = (Bitmap)((new ImageConverter()).ConvertFrom(_initial.SlikaThumb));
            else
                pbSlika.Image = null;

            cbJedinicaMjere.SelectedItem = jedinicaMjereList.FirstOrDefault(e => e.Id == _initial.JedinicaMjere?.Id);

        }

        private async void BtnSpremi_Click(object sender, EventArgs e) {
            if (ValidateChildren()) {
                _request.Naziv = txtNaziv.Text;
                _request.Cijena = decimal.Parse(txtCijena.Text);
                _request.JedinicaMjereId = ((LoV)cbJedinicaMjere.SelectedItem).Id;

                if (_request.Slika == null && _request.SlikaThumb == null) {
                    _request.Slika = _initial.Slika;
                    _request.SlikaThumb = _initial.SlikaThumb;
                }


                if (_id.HasValue) {

                    var response = await _service.Update<PayloadResponse<ArtikalResponse>>(_id.Value, _request);

                    if (response != null) {
                        MessageBox.Show($"Artikal {txtNaziv.Text} uspješno uređen!", "", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        DialogResult = DialogResult.OK;
                        Close();
                    }
                }
                else {
                    PayloadResponse<ArtikalResponse> response = await _service.Insert<PayloadResponse<ArtikalResponse>>(_request);

                    if (response != null) {
                        MessageBox.Show($"Artikal {response.Payload.Naziv} uspješno dodan!", "", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        DialogResult = DialogResult.OK;
                        Close();
                    }
                }
            }
        }

        private void BtnOcisti_Click(object sender, EventArgs e) {
            SetValues();
        }

        private void PictureBox1_Click(object sender, EventArgs e) {
            if (txtCijena.PasswordChar == '*')
                txtCijena.PasswordChar = new char();
            else
                txtCijena.PasswordChar = '*';
        }

        private void BtnDodajSliku_Click(object sender, EventArgs e) {
            ofdSlika.ShowDialog();

            var slikaData = SaveImageHelper.PrepareSaveImage(ofdSlika.FileName);

            if (slikaData != null) {
                _request.Slika = slikaData.OriginalImageBytes;
                _request.SlikaThumb = slikaData.CroppedImageBytes;
                pbSlika.Image = (Bitmap)((new ImageConverter()).ConvertFrom(slikaData.CroppedImageBytes));
            }

        }


        //VALIDACIJA
        private void TxtNaziv_Validating(object sender, CancelEventArgs e) {
            if (string.IsNullOrEmpty(txtNaziv.Text.Trim())) {
                e.Cancel = true;
                err.SetError(txtNaziv, "Obavezno polje!");
            }
            else {
                err.SetError(txtNaziv, null);
            }
        }


        private void CbJedinicaMjere_Validating(object sender, CancelEventArgs e) {
            if (cbJedinicaMjere.SelectedItem == null) {
                e.Cancel = true;
                err.SetError(cbJedinicaMjere, "Obavezno polje!");
            }
            else {
                err.SetError(cbJedinicaMjere, null);
            }
        }

        private void TxtCijena_Validating(object sender, CancelEventArgs e) {
            var cijenaText = txtCijena.Text.Trim().Replace(",", "");
            if (string.IsNullOrEmpty(cijenaText)) {
                e.Cancel = true;
                err.SetError(txtCijena, "Obavezno polje!");
            }
            else {
                try {
                    decimal.Parse(txtCijena.Text);
                    err.SetError(txtCijena, null);
                }
                catch {
                    e.Cancel = true;
                    err.SetError(txtCijena, "Neispravan format!");
                }
            }
        }
    }
}
