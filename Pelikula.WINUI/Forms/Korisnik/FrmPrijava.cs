using Pelikula.API.Model.Helper;
using Pelikula.API.Model.Korisnik;
using Pelikula.CORE.Helper.Response;
using Pelikula.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using Pelikula.API.Model;

namespace Pelikula.WINUI.Forms.Korisnik
{

    public partial class FrmPrijava : Form
    {

        private readonly ApiService _service = new ApiService("Korisnik");

        public FrmPrijava() {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterScreen;
        }

        private async void BtnPrijava_Click(object sender, EventArgs e) {
            txtKorisnickoIme.Enabled = false;
            txtLozinka.Enabled = false;
            btnPrijava.Enabled = false;

            Cursor = Cursors.WaitCursor;

            PayloadResponse<KorisnikResponse> obj = await _service.Prijava(txtKorisnickoIme.Text, txtLozinka.Text);

            if (obj != null && obj.Payload != null) {
                var korisnik = obj.Payload;

                if (korisnik.TipKorisnika.Naziv == KorisnikTip.Klijent.ToString()) {
                    MessageBox.Show("Nemate pristup aplikaciji! ", "Greška", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtKorisnickoIme.Text = string.Empty;
                    txtLozinka.Text = string.Empty;
                    txtLozinka.PasswordChar = '*';
                }
                else {
                    korisnik.Lozinka = txtLozinka.Text;
                    Properties.Settings.Default.PrijavljeniKorisnik = korisnik;
                    DialogResult = DialogResult.OK;
                    Close();
                }
            }
            else {
                txtLozinka.Text = string.Empty;
                txtLozinka.PasswordChar = '*';
            }

            txtKorisnickoIme.Enabled = true;
            txtLozinka.Enabled = true;
            btnPrijava.Enabled = true;

            Cursor = Cursors.Default;
        }

        private void PbLozinka_Click(object sender, EventArgs e) {
            if (txtLozinka.PasswordChar == '*')
                txtLozinka.PasswordChar = new char();
            else
                txtLozinka.PasswordChar = '*';
        }
    }
}
