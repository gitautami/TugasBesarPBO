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
using System.Globalization;
using MongoDB.Bson;

namespace tbpbo2
{
    public partial class Jadwal : Form
    {
        private IMongoDatabase _database;

        public Jadwal()
        {
            InitializeComponent();
            InitializeMongoDB();
            LoadDataGridView();
            LoadComboBoxData();

            timerKunjungan.Tick += timerKunjungan_Tick_1;
            timerKunjungan.Start();
        }

        private void InitializeMongoDB()
        {
            var client = new MongoClient("mongodb://localhost:27017");
            _database = client.GetDatabase("tbpbo");
        }

        private void LoadComboBoxData()
        {
            var monitoringCollection = _database.GetCollection<dynamic>("monitoring");
            var dokterCollection = _database.GetCollection<dynamic>("dokter");

            // Mengisi comboBoxPasien
            var pasienList = monitoringCollection.Find(FilterDefinition<dynamic>.Empty).ToList();
            foreach (var pasien in pasienList)
            {
                comboBoxPasien.Items.Add(pasien.NamaPasien.ToString());
            }

            // Mengisi comboBoxDokter
            var dokterList = dokterCollection.Find(FilterDefinition<dynamic>.Empty).ToList();
            foreach (var dokter in dokterList)
            {
                comboBoxDokter.Items.Add(dokter.nama.ToString());
            }
        }

        private void buttonSimpan_Click(object sender, EventArgs e)
        {
            if (comboBoxPasien.SelectedIndex == -1 || comboBoxDokter.SelectedIndex == -1)
            {
                MessageBox.Show("Silakan pilih pasien dan dokter.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var jadwalCollection = _database.GetCollection<dynamic>("jadwalkunjungan");

            var jadwalKunjungan = new
            {
                NamaPasien = comboBoxPasien.SelectedItem.ToString(),
                NamaDokter = comboBoxDokter.SelectedItem.ToString(),
                TanggalKunjungan = dateTimePickerTanggal.Value.Date,
                WaktuKunjungan = dateTimePickerWaktu.Value.ToString("HH:mm", CultureInfo.InvariantCulture),
                Keperluan = textBoxKeperluan.Text,
                Catatan = textBoxCatatan.Text
            };

            jadwalCollection.InsertOne(jadwalKunjungan);
            MessageBox.Show("Data berhasil disimpan!", "Informasi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            LoadDataGridView();
        }

        private void LoadDataGridView()
        {
            var jadwalCollection = _database.GetCollection<dynamic>("jadwalkunjungan");
            var jadwalList = jadwalCollection.Find(FilterDefinition<dynamic>.Empty).ToList();

            // Membuat DataTable untuk di-bind ke DataGridView
            var dataTable = new System.Data.DataTable();
            dataTable.Columns.Add("_id", typeof(string));
            dataTable.Columns.Add("NamaPasien");
            dataTable.Columns.Add("NamaDokter");
            dataTable.Columns.Add("TanggalKunjungan");
            dataTable.Columns.Add("WaktuKunjungan");
            dataTable.Columns.Add("Keperluan");
            dataTable.Columns.Add("Catatan");

            foreach (var jadwal in jadwalList)
            {
                // Ambil hanya jam dan menit dari WaktuKunjungan
                string waktuKunjungan = jadwal.WaktuKunjungan.ToString();
                string waktuFormatted;

                try
                {
                    var parsedTime = DateTime.Parse(waktuKunjungan); // Parse string waktu
                    waktuFormatted = parsedTime.ToString("HH:mm", CultureInfo.InvariantCulture); // Format ke HH:mm
                }
                catch
                {
                    waktuFormatted = "Invalid Format"; // Jika parsing gagal
                }

                dataTable.Rows.Add(
                    jadwal._id.ToString(),
                    jadwal.NamaPasien,
                    jadwal.NamaDokter,
                    jadwal.TanggalKunjungan.ToLocalTime().ToString("yyyy-MM-dd"),
                    waktuFormatted,
                    jadwal.Keperluan,
                    jadwal.Catatan
                );
            }

            dataGridViewKunjungan.DataSource = dataTable;
            dataGridViewKunjungan.Columns["_id"].Visible = false;
        }

        private void timerKunjungan_Tick_1(object sender, EventArgs e)
        {
            var jadwalCollection = _database.GetCollection<dynamic>("jadwalkunjungan");
            var now = DateTime.Now;

            var upcomingJadwals = jadwalCollection.Find(FilterDefinition<dynamic>.Empty).ToList()
                .Where(jadwal =>
                {
                    var tanggal = ((DateTime)jadwal.TanggalKunjungan).Date;
                    var waktu = DateTime.Parse(jadwal.WaktuKunjungan.ToString());
                    var jadwalDateTime = tanggal.Add(waktu.TimeOfDay);
                    return jadwalDateTime > now && jadwalDateTime <= now.AddMinutes(15);
                });

            foreach (var jadwal in upcomingJadwals)
            {
                MessageBox.Show(
                    $"Pengingat: Kunjungan pasien {jadwal.NamaPasien} dengan dokter {jadwal.NamaDokter} dijadwalkan pada {jadwal.TanggalKunjungan.ToLocalTime():yyyy-MM-dd} pukul {jadwal.WaktuKunjungan}.",
                    "Pengingat Jadwal",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information
                );
            }
        }

        private void buttonEdit_Click(object sender, EventArgs e)
        {
            try
            {
                // Pastikan baris dipilih di DataGridView
                if (dataGridViewKunjungan.SelectedRows.Count == 0)
                {
                    MessageBox.Show("Pilih data yang ingin diedit.", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                var selectedRow = dataGridViewKunjungan.SelectedRows[0];

                comboBoxPasien.Text = selectedRow.Cells["NamaPasien"].Value.ToString();
                comboBoxDokter.Text = selectedRow.Cells["NamaDokter"].Value.ToString();
                dateTimePickerTanggal.Value = DateTime.Parse(selectedRow.Cells["TanggalKunjungan"].Value.ToString());

                string waktuKunjungan = selectedRow.Cells["WaktuKunjungan"].Value.ToString();
                DateTime waktu = DateTime.Parse(waktuKunjungan);
                dateTimePickerWaktu.Value = DateTime.ParseExact(waktu.ToString("HH:mm"), "HH:mm", CultureInfo.InvariantCulture);

                textBoxKeperluan.Text = selectedRow.Cells["Keperluan"].Value.ToString();
                textBoxCatatan.Text = selectedRow.Cells["Catatan"].Value.ToString();

                MessageBox.Show("Data berhasil dimuat ke form. Silakan edit data, lalu simpan perubahan.", "Informasi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Terjadi kesalahan saat memuat data ke form: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonSimpanEdit_Click(object sender, EventArgs e)
        {
            var jadwalCollection = _database.GetCollection<BsonDocument>("jadwalkunjungan");

            try
            {
                // Pastikan baris dipilih di DataGridView
                if (dataGridViewKunjungan.SelectedRows.Count == 0)
                {
                    MessageBox.Show("Pilih data yang ingin diedit.", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Ambil _id dari baris yang dipilih
                var selectedRow = dataGridViewKunjungan.SelectedRows[0];
                var id = selectedRow.Cells["_id"].Value.ToString();

                // Filter berdasarkan _id
                var filter = Builders<BsonDocument>.Filter.Eq("_id", ObjectId.Parse(id));

                string waktuKunjunganFormatted = dateTimePickerWaktu.Value.ToString("HH:mm", CultureInfo.InvariantCulture);

                // Perbarui data berdasarkan input pengguna
                var update = Builders<BsonDocument>.Update
                    .Set("NamaPasien", comboBoxPasien.Text)
                    .Set("NamaDokter", comboBoxDokter.Text)
                    .Set("TanggalKunjungan", dateTimePickerTanggal.Value)
                    .Set("WaktuKunjungan", waktuKunjunganFormatted)
                    .Set("Keperluan", textBoxKeperluan.Text)
                    .Set("Catatan", textBoxCatatan.Text);

                // Perbarui data di MongoDB
                var result = jadwalCollection.UpdateOne(filter, update);

                // Periksa apakah data berhasil diperbarui
                if (result.ModifiedCount > 0)
                {
                    MessageBox.Show("Data pasien berhasil diperbarui!", "Informasi", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // Muat ulang data ke DataGridView
                    LoadDataGridView();

                    // Reset form
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

        private void ResetForm()
        {
            comboBoxPasien.SelectedIndex = -1;
            comboBoxDokter.SelectedIndex = -1;
            dateTimePickerTanggal.Value = DateTime.Now;
            dateTimePickerWaktu.Value = DateTime.Today;
            textBoxKeperluan.Clear();
            textBoxCatatan.Clear();
        }

        private void buttonHapus_Click(object sender, EventArgs e)
        {
            try
            {
                if (dataGridViewKunjungan.SelectedRows.Count == 0)
                {
                    MessageBox.Show("Pilih data yang ingin dihapus.", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                var confirmResult = MessageBox.Show("Apakah Anda yakin ingin menghapus data ini?", "Konfirmasi Hapus",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                if (confirmResult == DialogResult.No)
                {
                    return;
                }

                var selectedRow = dataGridViewKunjungan.SelectedRows[0];
                var id = selectedRow.Cells["_id"].Value?.ToString();
                Console.WriteLine("Selected ID: " + id);  // Debug

                if (string.IsNullOrEmpty(id))
                {
                    MessageBox.Show("ID tidak valid.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                var jadwalCollection = _database.GetCollection<BsonDocument>("jadwalkunjungan");
                FilterDefinition<BsonDocument> filter;

                try
                {
                    filter = Builders<BsonDocument>.Filter.Eq("_id", new ObjectId(id));
                }
                catch (FormatException)
                {
                    filter = Builders<BsonDocument>.Filter.Eq("_id", id);
                }

                var result = jadwalCollection.DeleteOne(filter);

                if (result.DeletedCount > 0)
                {
                    MessageBox.Show("Data kunjungan pasien berhasil dihapus!", "Informasi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadDataGridView();
                }
                else
                {
                    MessageBox.Show("Data tidak ditemukan atau ID salah format.", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Terjadi kesalahan saat menghapus data: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonInput_Click(object sender, EventArgs e)
        {
            InputData formInputData = new InputData();
            formInputData.Show();
            this.Hide();
        }

        private void buttonInputManual_Click(object sender, EventArgs e)
        {
            InputManual formInputManual = new InputManual();
            formInputManual.Show();
            this.Hide();
        }

        private void buttonLaporan_Click(object sender, EventArgs e)
        {
            Laporan formLaporan = new Laporan();
            formLaporan.Show();
            this.Hide();
        }

        private void buttonLogout_Click(object sender, EventArgs e)
        {
            login loginForm = new login();
            loginForm.Show();
            this.Hide();
        }

        private void Jadwal_Load(object sender, EventArgs e)
        {

        }
    }
}
