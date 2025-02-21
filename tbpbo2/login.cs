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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace tbpbo2
{
    public partial class login : Form
    {
        // Deklarasi koleksi MongoDB
        private IMongoCollection<BsonDocument> collection;
        public login()
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

        private void buttonLogin_Click(object sender, EventArgs e)
        {
            string username = textBoxUsername.Text; //ambil data dari textbox username
            string password = textBoxPassword.Text; //ambil data dari textbox password

            if (AuthenticateUser(username, password))
            {
                MessageBox.Show("Login Berhasil!");
                InputData inputDataForm = new InputData();
                inputDataForm.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Username atau Password salah");
                //kalo gagal akan muncul seperti ini
            }
        }
        private bool AuthenticateUser(string username, string password) // Fungsi untuk mengautentikasi pengguna berdasarkan username dan password
        {
            var filter = Builders<BsonDocument>.Filter.Eq("Username", username) & Builders<BsonDocument>.Filter.Eq("Password", password); //cek username & password
            var user = collection.Find(filter).FirstOrDefault();
            return user != null;
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            register registerForm = new register();
            registerForm.Show();
            this.Hide();
        }

        private void login_Load(object sender, EventArgs e)
        {

        }
    }
}
