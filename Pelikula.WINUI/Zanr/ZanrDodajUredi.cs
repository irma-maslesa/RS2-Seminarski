﻿using Pelikula.API.Model.Zanr;
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

namespace Pelikula.WINUI.Zanr
{
    public partial class FrmZanrDodajUredi : Form
    {
        private readonly ApiService _service = new ApiService("Zanr");
        private readonly int? _id;
        private ZanrResponse _initial = new ZanrResponse();

        public FrmZanrDodajUredi( int? id = null)
        {
            _id = id;

            InitializeComponent();
        }

        private async void FrmZanrDodajUredi_Load(object sender, EventArgs e)
        {
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            MinimizeBox = false;

            txtOpis.AutoSize = false;
            txtOpis.WordWrap = true;
            txtOpis.Multiline = true;
            txtOpis.ScrollBars = ScrollBars.Vertical;


            Text = "Dodaj žanr";

            if (_id.HasValue)
            {
                DisableChildren();
                string _text = Text;
                Text += " (Loading ...)";

                Text = "Uredi žanr";

                PayloadResponse<ZanrResponse> response = await _service.GetById<PayloadResponse<ZanrResponse>>(_id.Value);
                _initial = response.Payload;

                SetValues();

                EnableChildren();
                Text = _text;
            }
        }

        private void EnableChildren()
        {
            txtNaziv.Enabled = true;
            txtOpis.Enabled = true;
            btnOcisti.Enabled = true;
            btnSpremi.Enabled = true;
        }

        private void DisableChildren()
        {
            txtNaziv.Enabled = false;
            txtOpis.Enabled = false;
            btnOcisti.Enabled = false;
            btnSpremi.Enabled = false;
        }

        private void SetValues()
        {
            txtNaziv.Text = _initial.Naziv;
            txtOpis.Text =_initial.Opis;
        }

        private async void BtnSpremi_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtNaziv.Text))
            {
                errNaziv.SetError(txtNaziv, "Obavezno polje!");
                return;
            }

            ZanrUpsertRequest request = new ZanrUpsertRequest() { Naziv = txtNaziv.Text, Opis = string.IsNullOrWhiteSpace(txtOpis.Text)? null: txtOpis.Text };

            if (_id.HasValue)
            {

                PayloadResponse<ZanrResponse> response = await _service.Update<PayloadResponse<ZanrResponse>>(_id.Value, request);
                MessageBox.Show($"Žanr {txtNaziv.Text} uspješno uređen!", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                PayloadResponse<ZanrResponse> response = await _service.Insert<PayloadResponse<ZanrResponse>>(request);
                MessageBox.Show($"Žanr {response.Payload.Naziv} uspješno dodan!", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
