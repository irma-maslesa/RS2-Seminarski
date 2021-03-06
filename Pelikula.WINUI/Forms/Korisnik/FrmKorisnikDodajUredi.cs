using Pelikula.API.Model;
using Pelikula.API.Model.Korisnik;
using Pelikula.CORE.Helper.Response;
using Pelikula.DAO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Net.Mail;
using System.Windows.Forms;

namespace Pelikula.WINUI.Forms.Korisnik
{
    public partial class FrmKorisnikDodajUredi : Form
    {
        private readonly ApiService _service = new ApiService("Korisnik");

        private readonly ApiService _tipKorisnikaService = new ApiService("TipKorisnika");
        private readonly int? _id;

        private KorisnikResponse _initial = new KorisnikResponse();
        private readonly KorisnikUpsertRequest _request = new KorisnikUpsertRequest();

        private readonly KorisnikResponse _prijavljeniKorisnik;

        IEnumerable<LoV> tipKorisnikaList = new List<LoV>();

        public FrmKorisnikDodajUredi(int? id = null) {
            _id = id;
            _prijavljeniKorisnik = Properties.Settings.Default.PrijavljeniKorisnik;

            InitializeComponent();
        }

        private async void FrmKorisnikDodajUredi_Load(object sender, EventArgs e) {
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            MinimizeBox = false;

            Text = "Dodaj korisnika";

            cbSpol.Items.AddRange(new object[] { "Muški", "Ženski" });
            cbSpol.DisplayMember = "Naziv";
            cbSpol.ValueMember = "Id";

            tipKorisnikaList = (await _tipKorisnikaService.GetLoVs<PagedPayloadResponse<LoV>>(null, null, null)).Payload.OrderBy(o => o.Naziv).ToList();
            cbTipKorisnika.DataSource = tipKorisnikaList;
            cbTipKorisnika.DisplayMember = "Naziv";
            cbTipKorisnika.ValueMember = "Id";

            if (_prijavljeniKorisnik.TipKorisnika.Naziv.Equals(KorisnikTip.Radnik.ToString())) {
                cbTipKorisnika.SelectedItem = tipKorisnikaList.FirstOrDefault(o => o.Naziv.ToLower().Equals(KorisnikTip.Klijent.ToString().ToLower()));
                cbTipKorisnika.Enabled = false;
            }

            if (_id.HasValue) {
                Text = "Uredi korisnika";

                PayloadResponse<KorisnikResponse> response = await _service.GetById<PayloadResponse<KorisnikResponse>>(_id.Value);
                if (response != null)
                    _initial = response.Payload;

                SetValues();
            }
        }

        private void SetValues() {
            txtIme.Text = _initial.Ime;
            txtPrezime.Text = _initial.Prezime;
            txtEmail.Text = _initial.Email;

            txtKorisnickoIme.Text = _initial.KorisnickoIme;
            txtLozinka.Text = null;

            if (_initial.DatumRodjenja != null)
                dtpDatumRodjenja.Value = _initial.DatumRodjenja.Value;

            if (!_prijavljeniKorisnik.TipKorisnika.Naziv.Equals(KorisnikTip.Radnik.ToString()))
                cbTipKorisnika.SelectedItem = tipKorisnikaList.FirstOrDefault(e => e.Id == _initial.TipKorisnika?.Id);
            else
                cbTipKorisnika.SelectedItem = tipKorisnikaList.FirstOrDefault(o => o.Naziv.ToLower().Equals(KorisnikTip.Klijent.ToString().ToLower()));

            cbSpol.SelectedIndex = _initial.Spol == "M" ? cbSpol.FindStringExact("Muški") : cbSpol.FindStringExact("Ženski");
        }

        private async void BtnSpremi_Click(object sender, EventArgs e) {
            if (ValidateChildren()) {
                _request.Ime = txtIme.Text;
                _request.Prezime = txtPrezime.Text;
                _request.Email = txtEmail.Text;
                _request.Spol = cbSpol.SelectedItem?.ToString().Substring(0, 1);
                _request.DatumRodjenja = dtpDatumRodjenja?.Value;
                _request.KorisnickoIme = txtKorisnickoIme.Text.ToLower();

                if (!string.IsNullOrEmpty(txtLozinka.Text.Trim())) {
                    _request.LozinkaSalt = PasswordHelper.GenerateSalt();
                    _request.LozinkaHash = PasswordHelper.GenerateHash(_request.LozinkaSalt, txtLozinka.Text);
                }

                if (_id.HasValue && string.IsNullOrEmpty(txtLozinka.Text.Trim())) {
                    _request.LozinkaSalt = _initial.LozinkaSalt;
                    _request.LozinkaHash = _initial.LozinkaHash;
                }

                _request.TipKorisnikaId = ((LoV)cbTipKorisnika.SelectedItem).Id;

                if (_id.HasValue) {
                    var response = await _service.Update<PayloadResponse<KorisnikResponse>>(_id.Value, _request);

                    if (response != null) {
                        MessageBox.Show($"Korisnik {txtIme.Text} uspješno uređen!", "", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        DialogResult = DialogResult.OK;
                        Close();
                    }
                }
                else {
                    PayloadResponse<KorisnikResponse> response = await _service.Insert<PayloadResponse<KorisnikResponse>>(_request);

                    if (response != null) {
                        MessageBox.Show($"Korisnik {response.Payload.Ime} uspješno dodan!", "", MessageBoxButtons.OK, MessageBoxIcon.Information);

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
        private void TxtIme_Validating(object sender, CancelEventArgs e) {
            if (string.IsNullOrEmpty(txtIme.Text.Trim())) {
                e.Cancel = true;
                err.SetError(txtIme, "Obavezno polje!");
            }
            else {
                err.SetError(txtIme, null);
            }
        }

        private void TxtPrezime_Validating(object sender, CancelEventArgs e) {
            if (string.IsNullOrEmpty(txtPrezime.Text.Trim())) {
                e.Cancel = true;
                err.SetError(txtPrezime, "Obavezno polje!");
            }
            else {
                err.SetError(txtPrezime, null);
            }
        }

        private void TxtEmail_Validating(object sender, CancelEventArgs e) {
            if (string.IsNullOrEmpty(txtEmail.Text.Trim())) {
                e.Cancel = true;
                err.SetError(txtEmail, "Obavezno polje!");
            }
            else {
                try {
                    new MailAddress(txtEmail.Text);
                    err.SetError(txtEmail, null);
                }
                catch (FormatException) {
                    e.Cancel = true;
                    err.SetError(txtEmail, "Neispravan format!");
                }
            }
        }

        private void TxtKorisnickoIme_Validating(object sender, CancelEventArgs e) {
            if (string.IsNullOrEmpty(txtKorisnickoIme.Text.Trim())) {
                e.Cancel = true;
                err.SetError(txtKorisnickoIme, "Obavezno polje!");
            }
            else if (txtKorisnickoIme.TextLength < 3) {
                e.Cancel = true;
                err.SetError(txtKorisnickoIme, "Minimalna duzina je 3!");
            }
            else {
                err.SetError(txtKorisnickoIme, null);
            }
        }

        private void TxtLozinka_Validating(object sender, CancelEventArgs e) {
            if (!_id.HasValue) {
                if (string.IsNullOrEmpty(txtLozinka.Text.Trim())) {
                    e.Cancel = true;
                    err.SetError(txtLozinka, "Obavezno polje!");
                }
                else if (txtLozinka.TextLength < 6) {
                    e.Cancel = true;
                    err.SetError(txtLozinka, "Minimalna dužina je 6!");
                }
                else if (!txtLozinka.Text.Any(char.IsDigit) || !txtLozinka.Text.Any(char.IsLetter)) {
                    e.Cancel = true;
                    err.SetError(txtLozinka, "Mora sadržavati minimalno jedno slovo i broj!");
                }
                else {
                    err.SetError(txtLozinka, null);
                }
            }
        }

        private void CbTipKorisnika_Validating(object sender, CancelEventArgs e) {
            if (cbTipKorisnika.SelectedItem == null) {
                e.Cancel = true;
                err.SetError(cbTipKorisnika, "Obavezno polje!");
            }
            else {
                err.SetError(cbTipKorisnika, null);
            }
        }

        private void CbSpol_Validating(object sender, CancelEventArgs e) {
            if (cbSpol.SelectedItem == null) {
                e.Cancel = true;
                err.SetError(cbSpol, "Obavezno polje!");
            }
            else {
                err.SetError(cbSpol, null);
            }
        }
    }
}
