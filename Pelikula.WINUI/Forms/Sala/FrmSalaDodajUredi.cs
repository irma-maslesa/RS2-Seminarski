using Pelikula.API.Model.Sala;
using Pelikula.CORE.Helper.Response;
using System;
using System.Windows.Forms;

namespace Pelikula.WINUI.Forms.Sala
{
    public partial class FrmSalaDodajUredi : Form
    {
        private readonly ApiService _service = new ApiService("Sala");
        private readonly int? _id;
        private SalaResponse _initial = new SalaResponse();

        public FrmSalaDodajUredi(int? id = null)
        {
            _id = id;

            InitializeComponent();
        }

        private async void FrmSalaDodajUredi_Load(object sender, EventArgs e)
        {
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            MinimizeBox = false;

            Text = "Dodaj salu";

            if (_id.HasValue)
            {
                DisableChildren();

                Text = "Uredi salu";

                PayloadResponse<SalaResponse> response = await _service.GetById<PayloadResponse<SalaResponse>>(_id.Value);
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
            txtBrojSjedistaRed.Enabled = false;
            txtBrojRedova.Enabled = false;
            btnOcisti.Enabled = false;
            btnSpremi.Enabled = false;
        }

        private void SetValues()
        {
            txtNaziv.Text = _initial.Naziv;

            txtBrojSjedistaRed.Text = _initial.BrojSjedistaSirina.ToString();
            txtBrojRedova.Text = _initial.BrojSjedistaDuzina.ToString();
        }

        private async void BtnSpremi_Click(object sender, EventArgs e)
        {
            int errCount = 0;

            if (string.IsNullOrWhiteSpace(txtNaziv.Text))
            {
                errNaziv.SetError(txtNaziv, "Obavezno polje!");
                errCount++;
            }

            if (string.IsNullOrWhiteSpace(txtBrojSjedistaRed.Text))
            {
                errNaziv.SetError(txtBrojSjedistaRed, "Obavezno polje!");
                errCount++;
            }

            if (string.IsNullOrWhiteSpace(txtBrojRedova.Text))
            {
                errNaziv.SetError(txtBrojRedova, "Obavezno polje!");
                errCount++;
            }

            if (errCount != 0)
                return;

            SalaUpsertRequest request = new SalaUpsertRequest() { Naziv = txtNaziv.Text, BrojSjedistaSirina = int.Parse(txtBrojSjedistaRed.Text), BrojSjedistaDuzina = int.Parse(txtBrojRedova.Text) };

            if (_id.HasValue)
            {

                await _service.Update<PayloadResponse<SalaResponse>>(_id.Value, request);
                MessageBox.Show($"Sala {txtNaziv.Text} uspješno uređena!", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                PayloadResponse<SalaResponse> response = await _service.Insert<PayloadResponse<SalaResponse>>(request);
                MessageBox.Show($"Sala {response.Payload.Naziv} uspješno dodana!", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
