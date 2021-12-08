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
            nudBrojSjedistaRed.Enabled = false;
            nudBrojRedova.Enabled = false;
            btnOcisti.Enabled = false;
            btnSpremi.Enabled = false;
        }

        private void SetValues()
        {
            txtNaziv.Text = _initial.Naziv;

            nudBrojSjedistaRed.Value = _initial.BrojSjedistaSirina;
            nudBrojRedova.Value = _initial.BrojSjedistaDuzina;
        }

        private async void BtnSpremi_Click(object sender, EventArgs e)
        {
            int errCount = 0;

            if (string.IsNullOrWhiteSpace(txtNaziv.Text))
            {
                errNaziv.SetError(txtNaziv, "Obavezno polje!");
                errCount++;
            }

            if (errCount != 0)
                return;

            SalaUpsertRequest request = new SalaUpsertRequest() { Naziv = txtNaziv.Text, BrojSjedistaSirina = (int)nudBrojSjedistaRed.Value, BrojSjedistaDuzina = (int)nudBrojRedova.Value };

            if (_id.HasValue)
            {
                var response = await _service.Update<PayloadResponse<SalaResponse>>(_id.Value, request);

                if (response != null)
                {
                    MessageBox.Show($"Sala {txtNaziv.Text} uspješno uređena!", "", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    DialogResult = DialogResult.OK;
                    Close();
                }
            }
            else
            {
                PayloadResponse<SalaResponse> response = await _service.Insert<PayloadResponse<SalaResponse>>(request);

                if (response != null)
                {
                    MessageBox.Show($"Sala {response.Payload.Naziv} uspješno dodana!", "", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    DialogResult = DialogResult.OK;
                    Close();
                }
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
