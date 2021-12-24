
using Pelikula.API.Model.Anketa;
using Pelikula.CORE.Helper.Response;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace Pelikula.WINUI.Forms.Anketa
{
    public partial class FrmAnketaRezultati : Form
    {
        private readonly ApiService _service = new ApiService("Anketa");

        private readonly int _id;

        private Chart pieChart;
        private AnketaResponse anketa;

        public FrmAnketaRezultati(int id) {
            InitializeComponent();

            _id = id;
            anketa = null;

            InitializeChart();
        }
        private void InitializeChart() {
            components = new Container();
            ChartArea chartArea1 = new ChartArea();
            Legend legend1 = new Legend() {
                BackColor = Color.Transparent,
                ForeColor = Color.Black,
                Title = "Ponuđeni odgovori:"
            };

            pieChart = new Chart();

            ((ISupportInitialize)(pieChart)).BeginInit();

            SuspendLayout();

            //===Pie chart
            chartArea1.Name = "PieChartArea";
            pieChart.ChartAreas.Add(chartArea1);
            pieChart.Dock = DockStyle.Fill;
            legend1.Name = "Legend1";
            pieChart.Legends.Add(legend1);
            pieChart.Location = new Point(0, 50);

            AutoScaleDimensions = new SizeF(6F, 13F);
            AutoScaleMode = AutoScaleMode.Font;

            ((ISupportInitialize)(pieChart)).EndInit();

            ResumeLayout(false);
        }

        void LoadPieChart() {
            pieChart.Series.Clear();
            pieChart.Palette = ChartColorPalette.EarthTones;
            pieChart.BackColor = Color.White;
            pieChart.ChartAreas[0].BackColor = Color.Transparent;

            Series series1 = new Series {
                Name = "series1",
                IsVisibleInLegend = true,
                Color = Color.Green,
                ChartType = SeriesChartType.Pie
            };

            pieChart.Series.Add(series1);

            for (int i = 0; i < anketa.Odgovori.Count; i++) {
                var odgovor = anketa.Odgovori[i];

                series1.Points.Add(odgovor.UkupnoIzabrano);
                var p = series1.Points[i];
                p.AxisLabel = odgovor.UkupnoIzabrano.ToString();
                p.LegendText = odgovor.Odgovor;
            }

            pieChart.Invalidate();
            pnlPie.Controls.Add(pieChart);
        }

        private async void FrmAnketaRezultati_Load(object sender, System.EventArgs e) {
            var response = await _service.GetById<PayloadResponse<AnketaResponse>>(_id);

            if (response != null) {
                anketa = response.Payload;
                lblNaslov.Text = anketa.Naslov;

                LoadPieChart();
            }
        }
    }
}
