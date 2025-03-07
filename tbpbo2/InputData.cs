﻿using MongoDB.Bson;
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
using static System.Windows.Forms.DataFormats;

namespace tbpbo2
{
    public partial class InputData : Form //inheritance(pewarisan)
    {
        // Deklarasi koleksi MongoDB
        private IMongoCollection<BsonDocument> collection; // Encapsulation
        public InputData()
        {
            InitializeComponent();  //class
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

        private void buttonSimpan_Click(object sender, EventArgs e)
        {
            try
            {
                if (dataGridView1.SelectedRows.Count > 0) // Jika ada data yang dipilih, lakukan update
                {
                    var selectedRow = dataGridView1.SelectedRows[0];
                    var id = selectedRow.Cells["_id"].Value.ToString();
                    var filter = Builders<BsonDocument>.Filter.Eq("_id", ObjectId.Parse(id));

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

                    var result = collection.UpdateOne(filter, update);

                    if (result.ModifiedCount > 0)
                    {
                        MessageBox.Show("Data pasien berhasil diperbarui!", "Informasi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Data pasien tidak ditemukan atau tidak ada perubahan.", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
                else // Jika tidak ada data yang dipilih, lakukan insert baru
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
                }

                ResetForm();
                LoadDataToGridView();
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
            try
            {
                // Pastikan baris dipilih di DataGridView
                if (dataGridView1.SelectedRows.Count == 0)
                {
                    MessageBox.Show("Pilih data yang ingin diedit.", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Ambil baris yang dipilih
                var selectedRow = dataGridView1.SelectedRows[0];

                // Isi form dengan data dari DataGridView
                textBoxNama.Text = selectedRow.Cells["Nama Pasien"].Value.ToString();
                dateTimePickerTTL.Value = DateTime.Parse(selectedRow.Cells["Tanggal Lahir"].Value.ToString());
                comboBoxJenis.Text = selectedRow.Cells["Jenis Kelamin"].Value.ToString();
                textBoxNomorTLP.Text = selectedRow.Cells["Nomor Telepon"].Value.ToString();
                textBoxAlamat.Text = selectedRow.Cells["Alamat"].Value.ToString();
                comboBoxGolongan.Text = selectedRow.Cells["Golongan Darah"].Value.ToString();
                textBoxRiwayat.Text = selectedRow.Cells["Riwayat Penyakit"].Value.ToString();
                textBoxAlergi.Text = selectedRow.Cells["Alergi"].Value.ToString();
                textBoxNamaDarurat.Text = selectedRow.Cells["Kontak Darurat (Nama)"].Value.ToString();
                textBoxNomorDarurat.Text = selectedRow.Cells["Kontak Darurat (Nomor)"].Value.ToString();
                textBoxHubunganDarurat.Text = selectedRow.Cells["Kontak Darurat (Hubungan)"].Value.ToString();

                MessageBox.Show("Data berhasil dimuat ke form. Silakan edit data, lalu simpan perubahan.", "Informasi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Terjadi kesalahan saat memuat data ke form: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadDataToGridView()
        {
            try
            {
                var documents = collection.Find(new BsonDocument()).ToList();
                var dataTable = new DataTable();

                dataTable.Columns.Add("_id", typeof(string)); // Tambahkan kolom ID
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

                foreach (var doc in documents)
                {
                    var kontakDarurat = doc["KontakDarurat"].AsBsonDocument;
                    dataTable.Rows.Add(
                        doc["_id"].ToString(), // Ambil _id dari MongoDB
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

                dataGridView1.DataSource = dataTable;
                dataGridView1.Columns["_id"].Visible = false; // Sembunyikan kolom ID
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Terjadi kesalahan saat memuat data: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonJadwal_Click(object sender, EventArgs e) //Polimorfisme
        {
            Jadwal formJadwal = new Jadwal(); // objek
            formJadwal.Show();
            this.Hide();
        }

        private void buttonLogout_Click(object sender, EventArgs e)
        {
            login loginForm = new login();
            loginForm.Show();
            this.Hide();
        }

        private void buttonInputManual_Click(object sender, EventArgs e)
        {
            InputManual formInputManual = new InputManual();
            formInputManual.Show();
            this.Hide();
        }

        private void buttonLaporan_Click(object sender, EventArgs e) //Polimorfisme
        {
            Laporan formLaporan = new Laporan();
            formLaporan.Show();
            this.Hide();
        }
    
    }
}
