using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace tbpbo2
{
    public partial class InputManual : Form
    {
        // Deklarasi koleksi MongoDB
        private IMongoCollection<BsonDocument> collection;
        private DataTable dataTable;
        private ObjectId selectedDocumentId; // Menyimpan ID dokumen yang dipilih

        // Constructor
        public InputManual()
        {
            InitializeComponent();
            InitializeDataTable();
            InitializeMongoDB();
            LoadPatientNames(); // Mengisi daftar nama pasien di comboBoxPasien
            LoadDataFromMongoDB(); // Memuat data vital pasien ke DataGridView
        }

        // Koneksi ke MongoDB
        private void InitializeMongoDB()
        {
            var connectionString = "mongodb://localhost:27017/";
            var client = new MongoClient(connectionString);
            var database = client.GetDatabase("tbpbo");
            collection = database.GetCollection<BsonDocument>("pasien");
        }

        // Inisialisasi DataTable
        private void InitializeDataTable()
        {
            dataTable = new DataTable();
            dataTable.Columns.Add("Id", typeof(string));
            dataTable.Columns.Add("Nama Pasien", typeof(string));
            dataTable.Columns.Add("Tekanan Darah", typeof(string));
            dataTable.Columns.Add("Denyut Jantung", typeof(string));
            dataTable.Columns.Add("Suhu Tubuh", typeof(string));
            dataTable.Columns.Add("Berat Badan", typeof(string));
            dataTable.Columns.Add("Tanggal Pencatatan", typeof(DateTime));
            dataTable.Columns.Add("Catatan Tambahan", typeof(string));

            dataGridView1.DataSource = dataTable;
        }

        // Mengisi comboBoxPasien dengan daftar nama pasien dari database
        private void LoadPatientNames()
        {
            try
            {
                comboBoxPasien.Items.Clear();

                // Ubah nama koleksi jika daftar pasien disimpan di koleksi berbeda
                var database = new MongoClient("mongodb://localhost:27017/").GetDatabase("tbpbo");
                var pasienCollection = database.GetCollection<BsonDocument>("monitoring");

                var documents = pasienCollection.Find(new BsonDocument()).ToList();
                var uniqueNames = documents
                    .Select(doc => doc["NamaPasien"].AsString)
                    .Distinct()
                    .ToList();

                comboBoxPasien.Items.AddRange(uniqueNames.ToArray());
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Kesalahan saat mengambil nama pasien: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        // Fungsi untuk memuat data dari MongoDB ke DataTable
        private void LoadDataFromMongoDB()
        {
            try
            {
                dataTable.Clear();
                var documents = collection.Find(new BsonDocument()).ToList();

                foreach (var doc in documents)
                {
                    dataTable.Rows.Add(
                        doc["_id"].ToString(),
                        doc["Nama Pasien"].AsString,
                        doc["Tekanan Darah"].AsString,
                        doc["Denyut Jantung"].AsString,
                        doc["Suhu Tubuh"].AsString,
                        doc["Berat Badan"].AsString,
                        doc["Tanggal Pencatatan"].ToUniversalTime(),
                        doc["Catatan Tambahan"].AsString
                    );
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Kesalahan saat memuat data: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Tombol Simpan
        private void buttonSimpan_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(comboBoxPasien.Text) ||
                    string.IsNullOrWhiteSpace(textBoxTekanan.Text) ||
                    string.IsNullOrWhiteSpace(textBoxDenyut.Text) ||
                    string.IsNullOrWhiteSpace(textBoxSuhu.Text) ||
                    string.IsNullOrWhiteSpace(textBoxBerat.Text))
                {
                    MessageBox.Show("Semua field harus diisi.", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (selectedDocumentId != ObjectId.Empty) // Jika sedang mengedit data
                {
                    var filter = Builders<BsonDocument>.Filter.Eq("_id", selectedDocumentId);
                    var update = Builders<BsonDocument>.Update
                        .Set("Nama Pasien", comboBoxPasien.Text)
                        .Set("Tekanan Darah", textBoxTekanan.Text)
                        .Set("Denyut Jantung", textBoxDenyut.Text)
                        .Set("Suhu Tubuh", textBoxSuhu.Text)
                        .Set("Berat Badan", textBoxBerat.Text)
                        .Set("Tanggal Pencatatan", dateTimePickerPencatatan.Value)
                        .Set("Catatan Tambahan", textBoxCatatan.Text);

                    collection.UpdateOne(filter, update);

                    MessageBox.Show("Data berhasil diperbarui!", "Informasi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else // Jika sedang menambah data baru
                {
                    var document = new BsonDocument
            {
                { "Nama Pasien", comboBoxPasien.Text },
                { "Tekanan Darah", textBoxTekanan.Text },
                { "Denyut Jantung", textBoxDenyut.Text },
                { "Suhu Tubuh", textBoxSuhu.Text },
                { "Berat Badan", textBoxBerat.Text },
                { "Tanggal Pencatatan", dateTimePickerPencatatan.Value },
                { "Catatan Tambahan", textBoxCatatan.Text }
            };

                    collection.InsertOne(document);
                    MessageBox.Show("Data berhasil disimpan ke MongoDB!", "Informasi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                LoadPatientNames(); // Update daftar pasien di comboBox
                LoadDataFromMongoDB(); // Refresh DataGridView setelah update
                ClearForm(); // Reset form setelah simpan/edit
                selectedDocumentId = ObjectId.Empty; // Reset ID setelah menyimpan
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Terjadi kesalahan: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ClearForm()
        {
            comboBoxPasien.SelectedIndex = -1;
            textBoxTekanan.Clear();
            textBoxDenyut.Clear();
            textBoxSuhu.Clear();
            textBoxBerat.Clear();
            textBoxCatatan.Clear();
            dateTimePickerPencatatan.Value = DateTime.Now;
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

                // Simpan ID dari dokumen yang akan diedit
                selectedDocumentId = ObjectId.Parse(selectedRow.Cells["Id"].Value.ToString());

                // Isi form dengan data dari DataGridView, cek null agar tidak error
                comboBoxPasien.Text = selectedRow.Cells["Nama Pasien"].Value?.ToString() ?? "";
                textBoxTekanan.Text = selectedRow.Cells["Tekanan Darah"].Value?.ToString() ?? "";
                textBoxDenyut.Text = selectedRow.Cells["Denyut Jantung"].Value?.ToString() ?? "";
                textBoxSuhu.Text = selectedRow.Cells["Suhu Tubuh"].Value?.ToString() ?? "";
                textBoxBerat.Text = selectedRow.Cells["Berat Badan"].Value?.ToString() ?? "";

                // Konversi tanggal dengan pengecekan null
                if (DateTime.TryParse(selectedRow.Cells["Tanggal Pencatatan"].Value?.ToString(), out DateTime parsedDate))
                {
                    dateTimePickerPencatatan.Value = parsedDate;
                }
                else
                {
                    dateTimePickerPencatatan.Value = DateTime.Now; // Default jika parsing gagal
                }

                textBoxCatatan.Text = selectedRow.Cells["Catatan Tambahan"].Value?.ToString() ?? "";

                MessageBox.Show("Data berhasil dimuat ke form. Silakan edit lalu simpan.", "Informasi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Terjadi kesalahan saat memuat data ke form: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonHapus_Click(object sender, EventArgs e)
        {
            try
            {
                // Pastikan ada baris yang dipilih di DataGridView
                if (dataGridView1.SelectedRows.Count == 0)
                {
                    MessageBox.Show("Pilih data yang ingin dihapus.", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Konfirmasi penghapusan data
                DialogResult result = MessageBox.Show("Apakah Anda yakin ingin menghapus data ini?",
                    "Konfirmasi Hapus", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                if (result == DialogResult.No)
                    return;

                // Ambil baris yang dipilih
                var selectedRow = dataGridView1.SelectedRows[0];
                string idString = selectedRow.Cells["Id"].Value?.ToString();

                if (!ObjectId.TryParse(idString, out ObjectId id))
                {
                    MessageBox.Show("ID data tidak valid.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Filter untuk menghapus data berdasarkan ID
                var filter = Builders<BsonDocument>.Filter.Eq("_id", id);
                collection.DeleteOne(filter);

                // Hapus dari DataTable (DataGridView)
                dataTable.Rows.RemoveAt(selectedRow.Index);

                MessageBox.Show("Data berhasil dihapus!", "Informasi", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Perbarui daftar pasien di comboBox
                LoadPatientNames();
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

        private void buttonJadwal_Click(object sender, EventArgs e)
        {
            Jadwal formJadwal = new Jadwal();
            formJadwal.Show();
            this.Hide();
        }

        private void buttonLaporan_Click(object sender, EventArgs e)
        {
            Laporan formLaporan = new Laporan();
            formLaporan.Show();
            this.Hide();
        }
    }
}
