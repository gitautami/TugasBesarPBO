using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace tbpbo2
{
    public partial class Laporan : Form
    {
        public Laporan()
        {
            InitializeComponent();
        }

        private void Grafik_Load(object sender, EventArgs e)
        {
            // 1. Koneksi ke MongoDB
            var client = new MongoClient("mongodb://localhost:27017");
            var database = client.GetDatabase("tbpbo");
            var collection = database.GetCollection<BsonDocument>("pasien");

            // 2. Query data pasien
            var pasienData = collection.Find(new BsonDocument()).ToList();

            // 3. Siapkan data untuk grafik
            chart1.Series.Clear(); // Hapus seri sebelumnya (jika ada)

            // Tambahkan seri untuk Sistolik
            var sistolikSeries = new Series("Sistolik")
            {
                ChartType = SeriesChartType.Line,
                BorderWidth = 2
            };

            // Tambahkan seri untuk Diastolik
            var diastolikSeries = new Series("Diastolik")
            {
                ChartType = SeriesChartType.Line,
                BorderWidth = 2
            };

            // Tambahkan seri untuk Denyut Jantung
            var denyutJantungSeries = new Series("Denyut Jantung")
            {
                ChartType = SeriesChartType.Line,
                BorderWidth = 2
            };

            foreach (var doc in pasienData)
            {
                // Parsing data
                DateTime tanggal = doc["Tanggal Pencatatan"].ToUniversalTime();

                // Parsing Tekanan Darah
                string tekananDarah = doc["Tekanan Darah"].AsString; // Ambil string "120/80"
                var tekananParts = tekananDarah.Split('/'); // Pisahkan menjadi ["120", "80"]
                double sistolik = double.Parse(tekananParts[0]);
                double diastolik = double.Parse(tekananParts[1]);

                // Parsing Denyut Jantung
                double denyutJantung = doc["Denyut Jantung"].ToDouble();

                // Tambahkan data ke masing-masing seri
                sistolikSeries.Points.AddXY(tanggal, sistolik);
                diastolikSeries.Points.AddXY(tanggal, diastolik);
                denyutJantungSeries.Points.AddXY(tanggal, denyutJantung);
            }

            // 4. Tambahkan seri ke chart
            chart1.Series.Add(sistolikSeries);
            chart1.Series.Add(diastolikSeries);
            chart1.Series.Add(denyutJantungSeries);

            // 5. Konfigurasi sumbu X dan Y
            chart1.ChartAreas[0].AxisX.Title = "Tanggal";
            chart1.ChartAreas[0].AxisX.LabelStyle.Format = "dd-MM-yyyy";
            chart1.ChartAreas[0].AxisX.IntervalAutoMode = IntervalAutoMode.VariableCount;
            chart1.ChartAreas[0].AxisY.Title = "Nilai";

            chart1.ChartAreas[0].RecalculateAxesScale();
        }

        private void chart1_Click(object sender, EventArgs e)
        {

        }
    }
}
