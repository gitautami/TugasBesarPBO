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
using iTextSharp.text;
using iTextSharp.text.pdf;
using System.IO;

namespace tbpbo2
{
    public partial class Laporan : Form
    {
        private IMongoCollection<BsonDocument> collection;

        public Laporan()
        {
            InitializeComponent();
            InitializeMongoDB();
        }

        private void InitializeMongoDB()
        {
            // Koneksi ke MongoDB
            var connectionString = "mongodb://localhost:27017/";
            var client = new MongoClient(connectionString);

            // Pilih database dan koleksi
            var database = client.GetDatabase("tbpbo");
            collection = database.GetCollection<BsonDocument>("pasien");
        }

        private void Grafik_Load(object sender, EventArgs e)
        {

            // 1. Query data pasien
            var pasienData = collection.Find(new BsonDocument()).ToList();

            // 2. Siapkan data untuk grafik
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
                try
                {
                    // Parsing data tanggal
                    DateTime tanggal = doc.Contains("Tanggal Pencatatan") ? doc["Tanggal Pencatatan"].ToUniversalTime() : DateTime.MinValue;

                    // Parsing Tekanan Darah (Validasi ditambahkan)
                    if (doc.Contains("Tekanan Darah") && !string.IsNullOrWhiteSpace(doc["Tekanan Darah"].AsString))
                    {
                        string tekananDarah = doc["Tekanan Darah"].AsString.Trim();
                        var tekananParts = tekananDarah.Split('/');

                        // Pastikan array memiliki dua elemen sebelum parsing
                        if (tekananParts.Length == 2 &&
                            double.TryParse(tekananParts[0], out double sistolik) &&
                            double.TryParse(tekananParts[1], out double diastolik))
                        {
                            // Parsing Denyut Jantung (Validasi)
                            double denyutJantung = doc.Contains("Denyut Jantung") && doc["Denyut Jantung"].IsNumeric ? doc["Denyut Jantung"].ToDouble() : 0;

                            // Tambahkan data ke masing-masing seri
                            sistolikSeries.Points.AddXY(tanggal, sistolik);
                            diastolikSeries.Points.AddXY(tanggal, diastolik);
                            denyutJantungSeries.Points.AddXY(tanggal, denyutJantung);
                        }
                        else
                        {
                            Console.WriteLine($"Format tekanan darah tidak valid: {tekananDarah}");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Data tekanan darah tidak ditemukan atau kosong.");
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error saat memproses data: {ex.Message}");
                }
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

        private void buttonEkspor_Click(object sender, EventArgs e)
        {
            string connectionString = "mongodb://localhost:27017"; // Ganti sesuai koneksi MongoDB-mu
            string databaseName = "tbpbo";
            string pasienCollectionName = "pasien";
            string monitoringCollectionName = "monitoring";
            string jadwalkunjunganCollectionName = "jadwalkunjungan";

            DataTable dtPasien = new DataTable();
            DataTable dtMonitoring = new DataTable();
            DataTable dtJadwal = new DataTable();

            try
            {
                // Koneksi ke MongoDB
                var client = new MongoClient(connectionString);
                var database = client.GetDatabase(databaseName);

                // Ambil data dari collection pasien
                var pasienCollection = database.GetCollection<BsonDocument>(pasienCollectionName);
                var pasienDocuments = pasienCollection.Find(new BsonDocument()).ToList();

                // Ambil data dari collection monitoring
                var monitoringCollection = database.GetCollection<BsonDocument>(monitoringCollectionName);
                var monitoringDocuments = monitoringCollection.Find(new BsonDocument()).ToList();

                // Ambil data dari collection jadwal kunjungan
                var jadwalCollection = database.GetCollection<BsonDocument>(jadwalkunjunganCollectionName);
                var jadwalDocuments = jadwalCollection.Find(new BsonDocument()).ToList();

                // Tambahkan kolom ke DataTable pasien
                dtPasien.Columns.Add("Nama Pasien");
                dtPasien.Columns.Add("Tekanan Darah");
                dtPasien.Columns.Add("Denyut Jantung");
                dtPasien.Columns.Add("Suhu Tubuh");
                dtPasien.Columns.Add("Berat Badan");
                dtPasien.Columns.Add("Tanggal Pencatatan");
                dtPasien.Columns.Add("Catatan Tambahan");

                // Tambahkan kolom ke DataTable monitoring
                dtMonitoring.Columns.Add("Nama Pasien");
                dtMonitoring.Columns.Add("Tanggal Lahir");
                dtMonitoring.Columns.Add("Jenis Kelamin");
                dtMonitoring.Columns.Add("Nomor Telepon");
                dtMonitoring.Columns.Add("Alamat");
                dtMonitoring.Columns.Add("Golongan Darah");
                dtMonitoring.Columns.Add("Riwayat Penyakit");
                dtMonitoring.Columns.Add("Alergi");
                dtMonitoring.Columns.Add("Kontak Darurat (Nama)");
                dtMonitoring.Columns.Add("Kontak Darurat (Nomor Telepon)");
                dtMonitoring.Columns.Add("Kontak Darurat (Hubungan)");

                // Tambahkan kolom ke DataTable jadwal kunjungan 
                dtJadwal.Columns.Add("Nama Pasien");
                dtJadwal.Columns.Add("Nama Dokter");
                dtJadwal.Columns.Add("Tanggal Kunjungan");
                dtJadwal.Columns.Add("Waktu Kunjungan");
                dtJadwal.Columns.Add("Keperluan");
                dtJadwal.Columns.Add("Catatan");

                // Isi DataTable pasien
                foreach (var document in pasienDocuments)
                {
                    DataRow row = dtPasien.NewRow();
                    row["Nama Pasien"] = document.Contains("Nama Pasien") ? document["Nama Pasien"].ToString() : "";
                    row["Tekanan Darah"] = document.Contains("Tekanan Darah") ? document["Tekanan Darah"].ToString() : "";
                    row["Denyut Jantung"] = document.Contains("Denyut Jantung") ? document["Denyut Jantung"].ToString() : "";
                    row["Suhu Tubuh"] = document.Contains("Suhu Tubuh") ? document["Suhu Tubuh"].ToString() : "";
                    row["Berat Badan"] = document.Contains("Berat Badan") ? document["Berat Badan"].ToString() : "";
                    row["Tanggal Pencatatan"] = document.Contains("Tanggal Pencatatan") ? document["Tanggal Pencatatan"].ToString() : "";
                    row["Catatan Tambahan"] = document.Contains("Catatan Tambahan") ? document["Catatan Tambahan"].ToString() : "";
                    dtPasien.Rows.Add(row);
                }

                // Isi DataTable monitoring
                foreach (var document in monitoringDocuments)
                {
                    DataRow row = dtMonitoring.NewRow();
                    row["Nama Pasien"] = document.Contains("NamaPasien") ? document["NamaPasien"].ToString() : "";
                    row["Tanggal Lahir"] = document.Contains("TanggalLahir") ? document["TanggalLahir"].ToUniversalTime().ToString("yyyy-MM-dd") : "";
                    row["Jenis Kelamin"] = document.Contains("JenisKelamin") ? document["JenisKelamin"].ToString() : "";
                    row["Nomor Telepon"] = document.Contains("NomorTelepon") ? document["NomorTelepon"].ToString() : "";
                    row["Alamat"] = document.Contains("Alamat") ? document["Alamat"].ToString() : "";
                    row["Golongan Darah"] = document.Contains("GolonganDarah") ? document["GolonganDarah"].ToString() : "";
                    row["Riwayat Penyakit"] = document.Contains("RiwayatPenyakit") ? document["RiwayatPenyakit"].ToString() : "";
                    row["Alergi"] = document.Contains("Alergi") ? document["Alergi"].ToString() : "";
                    if (document.Contains("KontakDarurat"))
                    {
                        var emergencyContact = document["KontakDarurat"].AsBsonDocument;
                        row["Kontak Darurat (Nama)"] = emergencyContact.Contains("Nama") ? emergencyContact["Nama"].ToString() : "";
                        row["Kontak Darurat (Nomor Telepon)"] = emergencyContact.Contains("NomorTelepon") ? emergencyContact["NomorTelepon"].ToString() : "";
                        row["Kontak Darurat (Hubungan)"] = emergencyContact.Contains("Hubungan") ? emergencyContact["Hubungan"].ToString() : "";
                    }
                    dtMonitoring.Rows.Add(row);
                }

                // Isi DataTable jadwal kunjungan
                foreach (var document in jadwalDocuments)
                {
                    DataRow row = dtJadwal.NewRow();
                    row["Nama Pasien"] = document.Contains("NamaPasien") ? document["NamaPasien"].ToString() : "";
                    row["Nama Dokter"] = document.Contains("NamaDokter") ? document["NamaDokter"].ToString() : "";
                    row["Tanggal Kunjungan"] = document.Contains("TanggalKunjungan") ? document["TanggalKunjungan"].ToString() : "";
                    row["Waktu Kunjungan"] = document.Contains("WaktuKunjungan") ? document["WaktuKunjungan"].ToString() : "";
                    row["Keperluan"] = document.Contains("Keperluan") ? document["Keperluan"].ToString() : "";
                    row["Catatan"] = document.Contains("Catatan") ? document["Catatan"].ToString() : "";
                    dtJadwal.Rows.Add(row);
                }

                string outputPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), "ExportData.pdf");

                Document pdfDoc = new Document();
                PdfWriter.GetInstance(pdfDoc, new FileStream(outputPath, FileMode.Create));
                pdfDoc.Open();

                ExportDataTableToPdf(pdfDoc, dtPasien, "Data Pasien");
                pdfDoc.Add(new Paragraph("\n\n"));
                ExportDataTableToPdf(pdfDoc, dtMonitoring, "Data Monitoring");
                pdfDoc.Add(new Paragraph("\n\n"));
                ExportDataTableToPdf(pdfDoc, dtJadwal, "Data Jadwal Kunjungan");
                pdfDoc.Close();

                MessageBox.Show($"Export PDF berhasil di: {outputPath}", "Sukses", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Terjadi kesalahan: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ExportDataTableToPdf(Document pdfDoc, DataTable dt, string title)
        {
            iTextSharp.text.Font titleFont = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 14);
            pdfDoc.Add(new Paragraph(title, titleFont));
            pdfDoc.Add(new Paragraph("\n"));

            PdfPTable table = new PdfPTable(dt.Columns.Count);

            foreach (DataColumn column in dt.Columns)
            {
                PdfPCell header = new PdfPCell(new Phrase(column.ColumnName));
                header.BackgroundColor = BaseColor.LIGHT_GRAY;
                header.HorizontalAlignment = Element.ALIGN_CENTER;
                table.AddCell(header);
            }

            foreach (DataRow row in dt.Rows)
            {
                foreach (var item in row.ItemArray)
                {
                    table.AddCell(item.ToString());
                }
            }

            pdfDoc.Add(table);
        }

        private void buttonInput_Click(object sender, EventArgs e)
        {
            InputData formInputData = new InputData();
            formInputData.Show();
            this.Hide();
        }

        private void buttonJadwal_Click(object sender, EventArgs e)
        {
            Jadwal formJadwal = new Jadwal();
            formJadwal.Show();
            this.Hide();
        }

        private void buttonInputManual_Click(object sender, EventArgs e)
        {
            InputManual formInputManual = new InputManual();
            formInputManual.Show();
            this.Hide();
        }

        private void buttonLogout_Click(object sender, EventArgs e)
        {
            login loginForm = new login();
            loginForm.Show();
            this.Hide();
        }
    }
}
