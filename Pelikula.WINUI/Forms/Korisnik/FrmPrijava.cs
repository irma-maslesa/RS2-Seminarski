using Pelikula.API;
using Pelikula.API.Model.Helper;
using Pelikula.API.Model.Korisnik;
using Pelikula.CORE.Helper.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

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

            List<FilterUtility.FilterParams> filters = new List<FilterUtility.FilterParams>
            {
                new FilterUtility.FilterParams("KorisnickoIme", txtKorisnickoIme.Text, FilterUtility.FilterOptions.isequalto.ToString())
            };

            PagedPayloadResponse<KorisnikResponse> obj = await _service.Get<PagedPayloadResponse<KorisnikResponse>>(null, filters, null);

            if (obj.Payload.Any()) {
                var korisnik = obj.Payload.First();
                if (PasswordHelper.GenerateHash(korisnik.LozinkaSalt, txtLozinka.Text) == korisnik.LozinkaHash) {
                    korisnik.Lozinka = txtLozinka.Text;
                    Properties.Settings.Default.PrijavljeniKorisnik = korisnik;

                    DialogResult = DialogResult.OK;
                    Close();
                }

                else {
                    MessageBox.Show("Neispravno korisčko ime ili lozinka.", "Greška", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtLozinka.Text = string.Empty;
                    txtLozinka.PasswordChar = '*';

                }
            }
            else {
                MessageBox.Show("Neispravno korisčko ime ili lozinka.", "Greška", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
