using Pelikula.API.Model;
using Pelikula.API.Model.Film;
using Pelikula.API.Model.Helper;
using Pelikula.CORE.Helper.Response;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace Pelikula.WINUI.Forms.Film
{
    public partial class FrmFilmDodajUredi : Form
    {
        private readonly ApiService _service = new ApiService("Film");

        private readonly ApiService _zanrService = new ApiService("Zanr");
        private readonly ApiService _filmskaLicnostService = new ApiService("FilmskaLicnost");
        private readonly int? _id;

        private FilmResponse _initial = new FilmResponse();
        private FilmUpsertRequest _request = new FilmUpsertRequest();

        IEnumerable<LoV> zanrList = new List<LoV>();
        IEnumerable<LoV> rediteljList = new List<LoV>();
        IEnumerable<LoV> glumacList = new List<LoV>();

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

            Text = "Dodaj film";

            zanrList = (await _zanrService.GetLoVs<PagedPayloadResponse<LoV>>(null, null, null)).Payload.OrderBy(o => o.Naziv).ToList();
            cbZanr.DataSource = zanrList;
            cbZanr.DisplayMember = "Naziv";
            cbZanr.ValueMember = "Id";

            var rediteljFilter = new FilterUtility.FilterParams()
            {
                ColumnName = "IsReziser",
                FilterOption = FilterUtility.FilterOptions.isequalto.ToString(),
                FilterValue = true.ToString()
            };

            rediteljList = (await _filmskaLicnostService.GetLoVs<PagedPayloadResponse<LoV>>(null, new List<FilterUtility.FilterParams>() { rediteljFilter }, null)).Payload.OrderBy(o => o.Naziv).ToList();
            cbReditelj.DataSource = rediteljList;
            cbReditelj.DisplayMember = "Naziv";
            cbReditelj.ValueMember = "Id";

            var glumacFilter = new FilterUtility.FilterParams()
            {
                ColumnName = "IsGlumac",
                FilterOption = FilterUtility.FilterOptions.isequalto.ToString(),
                FilterValue = true.ToString()
            };
            glumacList = (await _filmskaLicnostService.GetLoVs<PagedPayloadResponse<LoV>>(null, new List<FilterUtility.FilterParams>() { glumacFilter }, null)).Payload.OrderBy(o => o.Naziv).ToList();
            clbGlumci.CheckOnClick = true;
            clbGlumci.DataSource = glumacList;
            clbGlumci.DisplayMember = "Naziv";
            clbGlumci.ValueMember = "Id";

            if (_id.HasValue)
            {
                Text = "Uredi film";

                PayloadResponse<FilmResponse> response = await _service.GetById<PayloadResponse<FilmResponse>>(_id.Value);
                _initial = response.Payload;

                SetValues();
            }
        }

        private void SetValues()
        {
            txtNaslov.Text = _initial.Naslov;
            txtTrajanje.Text = _initial.Trajanje.ToString();
            txtGodinaSnimanja.Text = _initial.GodinaSnimanja.ToString();
            txtVideoLink.Text = _initial.VideoLink;
            txtImdbLink.Text = _initial.ImdbLink;
            txtSadrzaj.Text = _initial.Sadrzaj;

            if (_initial.PlakatThumb != null && _initial.PlakatThumb.Length > 0)
                pbPlakat.Image = (Bitmap)((new ImageConverter()).ConvertFrom(_initial.PlakatThumb));
            else
                pbPlakat.Image = null;

            cbZanr.SelectedItem = zanrList.FirstOrDefault(e => e.Id == _initial.Zanr?.Id);
            cbReditelj.SelectedItem = rediteljList.FirstOrDefault(e => e.Id == _initial.Reditelj?.Id);

            var izabraniGlumci = _initial.Glumci
                .Select(e => e.FilmskaLicnost)
                .ToList();

            if (clbGlumci.CheckedItems.Count > 0)
                for (int i=0; i <clbGlumci.Items.Count; i++)
                    clbGlumci.SetItemChecked(clbGlumci.Items.IndexOf(clbGlumci.Items[i]), false);

            izabraniGlumci.ForEach(e => clbGlumci.SetItemChecked(clbGlumci.Items.IndexOf(e), true));
        }

        private async void BtnSpremi_Click(object sender, EventArgs e)
        {
            if (ValidateChildren())
            {
                _request.Naslov = txtNaslov.Text;
                _request.Trajanje = int.Parse(txtTrajanje.Text);
                _request.GodinaSnimanja = int.Parse(txtGodinaSnimanja.Text);
                _request.VideoLink = txtVideoLink.Text;
                _request.ImdbLink = txtImdbLink.Text;
                _request.Sadrzaj = txtSadrzaj.Text;

                if (_request.Plakat == null && _request.PlakatThumb == null)
                {
                    _request.Plakat = _initial.Plakat;
                    _request.PlakatThumb = _initial.PlakatThumb;
                }

                _request.ZanrId = ((LoV)cbZanr.SelectedItem).Id;
                _request.RediteljId = ((LoV)cbReditelj.SelectedItem).Id;
                _request.FilmGlumacIds = (clbGlumci.CheckedItems.Cast<LoV>()).Select(o => o.Id).ToList();

                if (_id.HasValue)
                {

                    await _service.Update<PayloadResponse<FilmResponse>>(_id.Value, _request);
                    MessageBox.Show($"Film {txtNaslov.Text} uspješno uređen!", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    PayloadResponse<FilmResponse> response = await _service.Insert<PayloadResponse<FilmResponse>>(_request);
                    MessageBox.Show($"Film {response.Payload.Naslov} uspješno dodan!", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }


                DialogResult = DialogResult.OK;
                Close();
            }
        }

        private void BtnOcisti_Click(object sender, EventArgs e)
        {
            SetValues();
        }

        private void BtnDodajPlakat_Click(object sender, EventArgs e)
        {
            ofdPlakat.ShowDialog();

            var slikaData = SaveImageHelper.PrepareSaveImage(ofdPlakat.FileName);

            if (slikaData != null)
            {
                _request.Plakat = slikaData.OriginalImageBytes;
                _request.PlakatThumb = slikaData.CroppedImageBytes;
                pbPlakat.Image = (Bitmap)((new ImageConverter()).ConvertFrom(slikaData.CroppedImageBytes));
            }

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

        private void txtTrajanje_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(txtTrajanje.Text.Trim()))
            {
                e.Cancel = true;
                err.SetError(txtTrajanje, "Obavezno polje!");
            }
            else
            {
                err.SetError(txtTrajanje, null);
            }
        }

        private void txtGodinaSnimanja_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(txtGodinaSnimanja.Text.Trim()))
            {
                e.Cancel = true;
                err.SetError(txtGodinaSnimanja, "Obavezno polje!");
            }
            else
            {
                err.SetError(txtGodinaSnimanja, null);
            }
        }

        private void txtImdbLink_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(txtImdbLink.Text.Trim()))
            {
                e.Cancel = true;
                err.SetError(txtImdbLink, "Obavezno polje!");
            }
            else
            {
                err.SetError(txtImdbLink, null);
            }
        }

        private void txtVideoLink_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(txtVideoLink.Text.Trim()))
            {
                e.Cancel = true;
                err.SetError(txtVideoLink, "Obavezno polje!");
            }
            else
            {
                err.SetError(txtVideoLink, null);
            }
        }

        private void cbReditelj_Validating(object sender, CancelEventArgs e)
        {
            if (cbReditelj.SelectedItem == null)
            {
                e.Cancel = true;
                err.SetError(cbReditelj, "Obavezno polje!");
            }
            else
            {
                err.SetError(cbReditelj, null);
            }
        }

        private void cbZanr_Validating(object sender, CancelEventArgs e)
        {
            if (cbZanr.SelectedItem == null)
            {
                e.Cancel = true;
                err.SetError(cbZanr, "Obavezno polje!");
            }
            else
            {
                err.SetError(cbZanr, null);
            }
        }

        private void txtSadrzaj_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(txtSadrzaj.Text.Trim()))
            {
                e.Cancel = true;
                err.SetError(txtSadrzaj, "Obavezno polje!");
            }
            else
            {
                err.SetError(txtSadrzaj, null);
            }
        }

        private void clbGlumci_Validating(object sender, CancelEventArgs e)
        {
            if (clbGlumci.CheckedItems.Count <= 0)
            {
                e.Cancel = true;
                err.SetError(clbGlumci, "Obavezno polje!");
            }
            else
            {
                err.SetError(clbGlumci, null);
            }
        }
    }

}
