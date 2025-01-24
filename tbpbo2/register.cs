using MongoDB.Bson;
using MongoDB.Driver;

namespace tbpbo2
{
    public partial class register : Form
    {
        // Deklarasi koleksi MongoDB
        private IMongoCollection<BsonDocument> collection;
        public register()
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
            collection = database.GetCollection<BsonDocument>("users");
        }

        private void buttonRegister_Click(object sender, EventArgs e)
        {
            try
            {
                // Ambil data dari input form
                string name = textBoxNama.Text;
                string username = textBoxUsername.Text;
                string password = textBoxPassword.Text;

                // Buat dokumen BSON untuk menyimpan ke database
                var document = new BsonDocument
                {
                    { "Name", name },
                    { "Username", username },
                    { "Password", password },
                };

                // Masukkan dokumen ke koleksi MongoDB
                collection.InsertOne(document);

                // Tampilkan pesan berhasil
                MessageBox.Show("Data berhasil dimasukkan ke database!");
            }
            catch (Exception ex)
            {
                // Tampilkan pesan kesalahan
                MessageBox.Show($"Terjadi kesalahan: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            login formLogin = new login();
            formLogin.Show();
            this.Hide();
        }
    }
}
