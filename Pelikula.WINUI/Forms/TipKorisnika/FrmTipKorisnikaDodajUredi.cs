using Pelikula.API.Model.TipKorisnika;
using Pelikula.CORE.Helper.Response;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Pelikula.WINUI.Forms.TipKorisnika
{
    public partial class FrmTipKorisnikaDodajUredi : Form
    {
        private readonly ApiService _service = new ApiService("TipKorisnika");
        private readonly int? _id;
        private TipKorisnikaResponse _initial = new TipKorisnikaResponse();

        public FrmTipKorisnikaDodajUredi(int? id = null)
        {
            _id = id;

            InitializeComponent();
        }

        private async void FrmTipKorisnikaDodajUredi_Load(object sender, EventArgs e)
        {
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            MinimizeBox = false;

            Text = "Dodaj tip korisnika";

            if (_id.HasValue)
            {
                DisableChildren();

                Text = "Uredi tip korisnika";

                PayloadResponse<TipKorisnikaResponse> response = await _service.GetById<PayloadResponse<TipKorisnikaResponse>>(_id.Value);
                _initial = response.Payload;

                SetValues();

                EnableChildren();
            }
        }

        private void EnableChildren()
        {
            txtNaziv.Enabled = true;
            btnOcisti.Enabled = true;
            btnSpremi.Enabled = true;
        }

        private void DisableChildren()
        {
            txtNaziv.Enabled = false;
            btnOcisti.Enabled = false;
            btnSpremi.Enabled = false;
        }

        private void SetValues()
        {
            txtNaziv.Text = _initial.Naziv;
        }

        private async void BtnSpremi_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtNaziv.Text))
            {
                errNaziv.SetError(txtNaziv, "Obavezno polje!");
                return;
            }

            TipKorisnikaUpsertRequest request = new TipKorisnikaUpsertRequest() { Naziv = txtNaziv.Text};

            if (_id.HasValue)
            {

                await _service.Update<PayloadResponse<TipKorisnikaResponse>>(_id.Value, request);
                MessageBox.Show($"TipKorisnika {txtNaziv.Text} uspješno uređen!", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                PayloadResponse<TipKorisnikaResponse> response = await _service.Insert<PayloadResponse<TipKorisnikaResponse>>(request);
                MessageBox.Show($"TipKorisnika {response.Payload.Naziv} uspješno dodan!", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }


            DialogResult = DialogResult.OK;
            Close();
        }

        private void BtnOcisti_Click(object sender, EventArgs e)
        {
            SetValues();
        }
    }
}
