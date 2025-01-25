using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace tbpbo2
{
    public partial class InputData : Form
    {
        // Deklarasi koleksi MongoDB
        private IMongoCollection<BsonDocument> collection;
        public InputData()
        {
            InitializeComponent();
            InitializeMongoDB();
            LoadDataToGridView();
        }
        private void InitializeMongoDB()
        {
            // Koneksi ke MongoDB
            var connectionString = "mongodb://localhost:27017/";
            var client = new MongoClient(connectionString);

            // Pilih database dan koleksi
            var database = client.GetDatabase("tbpbo");
            collection = database.GetCollection<BsonDocument>("monitoring");
        }

        private void InputData_Load(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void buttonSimpan_Click(object sender, EventArgs e)
        {
            try
            {
                var data = new BsonDocument
        {
            { "NamaPasien", textBoxNama.Text },
            { "TanggalLahir", dateTimePickerTTL.Value },
            { "JenisKelamin", comboBoxJenis.Text },
            { "NomorTelepon", textBoxNomorTLP.Text },
            { "Alamat", textBoxAlamat.Text },
            { "GolonganDarah", comboBoxGolongan.Text },
            { "RiwayatPenyakit", textBoxRiwayat.Text },
            { "Alergi", textBoxAlergi.Text },
            { "KontakDarurat", new BsonDocument
                {
                    { "Nama", textBoxNamaDarurat.Text },
                    { "NomorTelepon", textBoxNomorDarurat.Text },
                    { "Hubungan", textBoxHubunganDarurat.Text }
            }
                    }
        };
                collection.InsertOne(data);
                MessageBox.Show("Data pasien berhasil disimpan!", "Informasi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ResetForm();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Terjadi kesalahan: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void ResetForm()
        {
            textBoxNama.Clear();
            dateTimePickerTTL.Value = DateTime.Now;
            comboBoxJenis.SelectedIndex = -1;
            textBoxNomorTLP.Clear();
            textBoxAlamat.Clear();
            comboBoxGolongan.SelectedIndex = -1;
            textBoxRiwayat.Clear();
            textBoxAlergi.Clear();
            textBoxNamaDarurat.Clear();
            textBoxNomorDarurat.Clear();
            textBoxHubunganDarurat.Clear();
        }
        private void textBoxNomorTLP_TextChanged(object sender, EventArgs e)
        {

        }

        private void buttonEdit_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBoxNama.Text) || comboBoxJenis.SelectedIndex == -1 || string.IsNullOrEmpty(textBoxNomorTLP.Text))
            {
                MessageBox.Show("Nama Pasien, Jenis Kelamin, dan Nomor Telepon wajib diisi.", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            try
            {
                // Filter berdasarkan Nama Pasien (atau gunakan ID jika tersedia)
                var filter = Builders<BsonDocument>.Filter.Eq("NamaPasien", textBoxNama.Text);

                // Perbarui data berdasarkan input pengguna
                var update = Builders<BsonDocument>.Update
                    .Set("NamaPasien", textBoxNama.Text)
                    .Set("TanggalLahir", dateTimePickerTTL.Value)
                    .Set("JenisKelamin", comboBoxJenis.Text)
                    .Set("NomorTelepon", textBoxNomorTLP.Text)
                    .Set("Alamat", textBoxAlamat.Text)
                    .Set("GolonganDarah", comboBoxGolongan.Text)
                    .Set("RiwayatPenyakit", textBoxRiwayat.Text)
                    .Set("Alergi", textBoxAlergi.Text)
                    .Set("KontakDarurat", new BsonDocument
                    {
                { "Nama", textBoxNamaDarurat.Text },
                { "NomorTelepon", textBoxNomorDarurat.Text },
                { "Hubungan", textBoxHubunganDarurat.Text }
                    });

                // Perbarui data di MongoDB
                var result = collection.UpdateOne(filter, update);

                // Periksa apakah data berhasil diperbarui
                if (result.ModifiedCount > 0)
                {
                    MessageBox.Show("Data pasien berhasil diperbarui!", "Informasi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ResetForm();
                }
                else
                {
                    MessageBox.Show("Data pasien tidak ditemukan atau tidak ada perubahan.", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Terjadi kesalahan saat mengedit data: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void LoadDataToGridView()
        {
            try
            {
                // Ambil semua dokumen dari koleksi MongoDB
                var documents = collection.Find(new BsonDocument()).ToList();

                // Buat DataTable untuk menyimpan data yang akan ditampilkan
                var dataTable = new DataTable();

                // Tambahkan kolom ke DataTable sesuai field di dokumen MongoDB
                dataTable.Columns.Add("Nama Pasien");
                dataTable.Columns.Add("Tanggal Lahir");
                dataTable.Columns.Add("Jenis Kelamin");
                dataTable.Columns.Add("Nomor Telepon");
                dataTable.Columns.Add("Alamat");
                dataTable.Columns.Add("Golongan Darah");
                dataTable.Columns.Add("Riwayat Penyakit");
                dataTable.Columns.Add("Alergi");
                dataTable.Columns.Add("Kontak Darurat (Nama)");
                dataTable.Columns.Add("Kontak Darurat (Nomor)");
                dataTable.Columns.Add("Kontak Darurat (Hubungan)");

                // Iterasi setiap dokumen untuk mengisi data ke dalam DataTable
                foreach (var doc in documents)
                {
                    var kontakDarurat = doc["KontakDarurat"].AsBsonDocument; // Ambil subdokumen Kontak Darurat
                    dataTable.Rows.Add(
                        doc["NamaPasien"].ToString(),
                        doc["TanggalLahir"].ToUniversalTime().ToString("yyyy-MM-dd"),
                        doc["JenisKelamin"].ToString(),
                        doc["NomorTelepon"].ToString(),
                        doc["Alamat"].ToString(),
                        doc["GolonganDarah"].ToString(),
                        doc["RiwayatPenyakit"].ToString(),
                        doc["Alergi"].ToString(),
                        kontakDarurat["Nama"].ToString(),
                        kontakDarurat["NomorTelepon"].ToString(),
                        kontakDarurat["Hubungan"].ToString()
                    );
                }

                // Tampilkan DataTable ke DataGridView
                dataGridView1.DataSource = dataTable;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Terjadi kesalahan saat memuat data: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

    }
}
