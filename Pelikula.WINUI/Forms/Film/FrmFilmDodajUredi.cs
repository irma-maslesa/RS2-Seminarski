using Pelikula.API.Model.Film;
using Pelikula.CORE.Helper.Response;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Windows.Forms;

namespace Pelikula.WINUI.Forms.Film
{
    public partial class FrmFilmDodajUredi : Form
    {
        private readonly ApiService _service = new ApiService("Film");

        private readonly int? _id;

        private FilmResponse _initial = new FilmResponse();
        private FilmUpsertRequest _upsertRequest = new FilmUpsertRequest();

        public FrmFilmDodajUredi(int? id = null)
        {
            _id = id;

            InitializeComponent();
        }

        private async void FrmFilmDodajUredi_Load(object sender, EventArgs e)
        {
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            MinimizeBox = false;

            Text = "Dodaj anketu";

            if (_id.HasValue)
            {
                Text = "Uredi anketu";

                PayloadResponse<FilmResponse> response = await _service.GetById<PayloadResponse<FilmResponse>>(_id.Value);
                _initial = response.Payload;

                SetValues();
            }
        }

        private void SetValues()
        {
            txtNaslov.Text = _initial.Naslov;

        }

        private async void BtnSpremi_Click(object sender, EventArgs e)
        {
            if (ValidateChildren())
            {


                if (_id.HasValue)
                {
                    _upsertRequest.Naslov = txtNaslov.Text;


                    await _service.Update<PayloadResponse<FilmResponse>>(_id.Value, _upsertRequest);
                    MessageBox.Show($"Film {txtNaslov.Text} uspješno uređena!", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    _upsertRequest.Naslov = txtNaslov.Text;
                   
                    PayloadResponse<FilmResponse> response = await _service.Insert<PayloadResponse<FilmResponse>>(_upsertRequest);
                    MessageBox.Show($"Film {response.Payload.Naslov} uspješno dodana!", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                DialogResult = DialogResult.OK;
                Close();
            }
        }

        private void BtnOcisti_Click(object sender, EventArgs e)
        {
            SetValues();
        }

        //VALIDACIJA
        private void txtNaslov_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(txtNaslov.Text.Trim()))
            {
                e.Cancel = true;
                err.SetError(txtNaslov, "Obavezno polje!");
            }
            else
            {
                err.SetError(txtNaslov, null);
            }
        }
    }
}
