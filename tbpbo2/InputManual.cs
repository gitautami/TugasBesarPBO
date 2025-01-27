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
        }

        // Koneksi ke MongoDB
        private void InitializeMongoDB()
        {
            var connectionString = "mongodb://localhost:27017/";
            var client = new MongoClient(connectionString);
            var database = client.GetDatabase("tbpbo");
            collection = database.GetCollection<BsonDocument>("pasien");
        }

        // Event handler ketika form dimuat
        private void InputManual_Load(object sender, EventArgs e)
        {
            comboBoxPasien.Items.Add("Pasien 1");
            comboBoxPasien.Items.Add("Pasien 2");
            comboBoxPasien.Items.Add("Pasien 3");

            dataGridView1.DataSource = dataTable;
            LoadDataFromMongoDB();

            var uniqueNames = dataTable.AsEnumerable()
                                       .Select(row => row.Field<string>("Nama Pasien"))
                                       .Distinct()
                                       .ToList();
            comboBoxFilterPasien.Items.AddRange(uniqueNames.ToArray());
        }

        // Inisialisasi DataTable
        private void InitializeDataTable()
        {
            dataTable = new DataTable();
            dataTable.Columns.Add("Id", typeof(string)); // Tambahan untuk menyimpan ID
            dataTable.Columns.Add("Nama Pasien", typeof(string));
            dataTable.Columns.Add("Tekanan Darah", typeof(string));
            dataTable.Columns.Add("Denyut Jantung", typeof(string));
            dataTable.Columns.Add("Suhu Tubuh", typeof(string));
            dataTable.Columns.Add("Berat Badan", typeof(string));
            dataTable.Columns.Add("Tanggal Pencatatan", typeof(DateTime));
            dataTable.Columns.Add("Catatan Tambahan", typeof(string));
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

                if (selectedDocumentId != ObjectId.Empty)
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

                    var selectedRow = dataGridView1.SelectedRows[0];
                    selectedRow.Cells["Nama Pasien"].Value = comboBoxPasien.Text;
                    selectedRow.Cells["Tekanan Darah"].Value = textBoxTekanan.Text;
                    selectedRow.Cells["Denyut Jantung"].Value = textBoxDenyut.Text;
                    selectedRow.Cells["Suhu Tubuh"].Value = textBoxSuhu.Text;
                    selectedRow.Cells["Berat Badan"].Value = textBoxBerat.Text;
                    selectedRow.Cells["Tanggal Pencatatan"].Value = dateTimePickerPencatatan.Value;
                    selectedRow.Cells["Catatan Tambahan"].Value = textBoxCatatan.Text;

                    MessageBox.Show("Data berhasil diperbarui.", "Informasi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
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
                    dataTable.Rows.Add(
                        document["_id"].ToString(),
                        comboBoxPasien.Text,
                        textBoxTekanan.Text,
                        textBoxDenyut.Text,
                        textBoxSuhu.Text,
                        textBoxBerat.Text,
                        dateTimePickerPencatatan.Value,
                        textBoxCatatan.Text
                    );

                    MessageBox.Show("Data berhasil disimpan ke MongoDB.", "Informasi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                ClearForm();
                selectedDocumentId = ObjectId.Empty;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Terjadi kesalahan: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Fungsi untuk membersihkan form
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

        // Tombol Edit
        private void buttonEdit_Click(object sender, EventArgs e)
        {
            try
            {
                if (dataGridView1.SelectedRows.Count == 0)
                {
                    MessageBox.Show("Pilih data yang ingin diedit.", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                var selectedRow = dataGridView1.SelectedRows[0];
                selectedDocumentId = ObjectId.Parse(selectedRow.Cells["Id"].Value.ToString());

                comboBoxPasien.Text = selectedRow.Cells["Nama Pasien"].Value.ToString();
                textBoxTekanan.Text = selectedRow.Cells["Tekanan Darah"].Value.ToString();
                textBoxDenyut.Text = selectedRow.Cells["Denyut Jantung"].Value.ToString();
                textBoxSuhu.Text = selectedRow.Cells["Suhu Tubuh"].Value.ToString();
                textBoxBerat.Text = selectedRow.Cells["Berat Badan"].Value.ToString();
                dateTimePickerPencatatan.Value = DateTime.Parse(selectedRow.Cells["Tanggal Pencatatan"].Value.ToString());
                textBoxCatatan.Text = selectedRow.Cells["Catatan Tambahan"].Value.ToString();

                MessageBox.Show("Data berhasil dimuat ke form. Silakan edit data, lalu klik tombol Simpan untuk memperbarui.", "Informasi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Terjadi kesalahan saat memuat data ke form: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Filter nama pasien
        private void comboBoxFilterPasien_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                string selectedFilter = comboBoxFilterPasien.Text;

                if (string.IsNullOrEmpty(selectedFilter))
                {
                    (dataGridView1.DataSource as DataTable).DefaultView.RowFilter = string.Empty;
                }
                else
                {
                    string filterExpression = $"[Nama Pasien] LIKE '%{selectedFilter}%'";
                    (dataGridView1.DataSource as DataTable).DefaultView.RowFilter = filterExpression;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Kesalahan saat memfilter: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
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
