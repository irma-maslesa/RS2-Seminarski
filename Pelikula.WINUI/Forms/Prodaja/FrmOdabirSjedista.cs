using Pelikula.API.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace Pelikula.WINUI.Forms.Prodaja
{
    public partial class FrmOdabirSjedista : Form
    {
        public List<int> OdabranaSjedista { get; set; }

        private readonly IEnumerable<LoV> _sjedistaList;
        private readonly IEnumerable<LoV> _zauzetaSjedistaList;
        private readonly List<int> _rezervisanaSjedista;

        public FrmOdabirSjedista(IEnumerable<LoV> sjedistaList, IEnumerable<LoV> zauzetaSjedistaList, List<int> rezervisanaSjedista) {
            _sjedistaList = sjedistaList;
            _zauzetaSjedistaList = zauzetaSjedistaList;
            _rezervisanaSjedista = rezervisanaSjedista;

            InitializeComponent();
        }

        private void FrmOdabirSjedista_Load(object sender, EventArgs e) {
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            MinimizeBox = false;

            Text = "Odberi sjedišta";

            GenerateSjedistaView();
            SetValues();
        }

        private void SetValues() {
            OdabranaSjedista = new List<int>(_rezervisanaSjedista);
            DisableAndSelectZauzetaSjedista();
        }

        private void BtnSpremi_Click(object sender, EventArgs e) {
            if (OdabranaSjedista == null || OdabranaSjedista.Count == 0) {
                err.SetError(flpSjedista, "Obavezno odabrati bar jedno sjediste!");
                return;
            }
            else {
                err.SetError(flpSjedista, null);
            }

            DialogResult = DialogResult.OK;
            Close();
        }

        private void BtnOcisti_Click(object sender, EventArgs e) {
            if (OdabranaSjedista != null)
                OdabranaSjedista.Clear();

            var buttons = flpSjedista.Controls.OfType<Button>().Where(o => o.Name != "btnEkran").ToList();
            buttons.ForEach(o => { o.Enabled = true;  o.BackColor = DefaultBackColor; o.UseVisualStyleBackColor = true; });

            SetValues();
            DisableAndSelectZauzetaSjedista();
        }

        private void GenerateSjedistaView() {
            var groupedSjedista = _sjedistaList.GroupBy(e => e.Naziv.Substring(0, 1));
            var keys = groupedSjedista.Select(e => e.Key).ToList();

            flpSjedista.Controls.Clear();

            foreach (var redKey in keys) {
                var red = _sjedistaList.Where(e => e.Naziv.Substring(0, 1).Equals(redKey));
                Button lastButton = null;
                foreach (var sjediste in red) {
                    Button btn = new Button {
                        Name = sjediste.Id.ToString(),
                        Text = sjediste.Naziv,
                        Size = new Size(35, 35),
                        Margin = new Padding(3)
                    };

                    btn.Click += new EventHandler(Button_Click);

                    lastButton = btn;
                    flpSjedista.Controls.Add(btn);
                }

                flpSjedista.SetFlowBreak(lastButton, true);
            }

            Button ekranBtn = new Button {
                Name = "btnEkran",
                Text = "E     K     R     A     N",
                Enabled = false,
                Width = flpSjedista.Width - 3
            };

            flpSjedista.Controls.Add(ekranBtn);

            flpSjedista.Left = (Width - 12 - flpSjedista.Width) / 2;

            Top = 50;
        }

        private void Button_Click(object sender, EventArgs e) {
            var btn = (Button)sender;
            if (OdabranaSjedista == null)
                OdabranaSjedista = new List<int>();

            if (OdabranaSjedista.Contains(int.Parse(btn.Name))) {
                OdabranaSjedista.Remove(int.Parse(btn.Name));
                btn.BackColor = DefaultBackColor;
                btn.UseVisualStyleBackColor = true;
            }
            else {
                OdabranaSjedista.Add(int.Parse(btn.Name));
                btn.BackColor = SystemColors.ActiveCaption;
            }
        }

        private void DisableAndSelectZauzetaSjedista() {
            var buttons = flpSjedista.Controls.OfType<Button>().Where(e => e.Name != "btnEkran").ToList();
            buttons.ForEach(e => e.Enabled = true);

            var zauzetaSjedistaIds = _zauzetaSjedistaList.Select(e => e.Id).ToList();

            if (OdabranaSjedista == null || OdabranaSjedista.Count == 0)
                buttons.Where(e => zauzetaSjedistaIds.Contains(int.Parse(e.Name))).ToList().ForEach(e => e.Enabled = false);
            else {
                buttons.Where(e => zauzetaSjedistaIds.Contains(int.Parse(e.Name)) && !OdabranaSjedista.Contains(int.Parse(e.Name)) && !_rezervisanaSjedista.Contains(int.Parse(e.Name))).ToList().ForEach(e => e.Enabled = false);
                buttons.Where(e => OdabranaSjedista.Contains(int.Parse(e.Name))).ToList().ForEach(e => e.BackColor = SystemColors.ActiveCaption);
            }

        }
    }
}
