namespace tbpbo2
{
    partial class Jadwal
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Jadwal));
            label6 = new Label();
            label7 = new Label();
            label2 = new Label();
            label5 = new Label();
            label4 = new Label();
            label3 = new Label();
            label8 = new Label();
            comboBoxPasien = new ComboBox();
            comboBoxDokter = new ComboBox();
            dateTimePickerTanggal = new DateTimePicker();
            textBoxKeperluan = new TextBox();
            textBoxCatatan = new TextBox();
            dateTimePickerWaktu = new DateTimePicker();
            buttonEdit = new Button();
            buttonSimpan = new Button();
            dataGridViewKunjungan = new DataGridView();
            label9 = new Label();
            panel1 = new Panel();
            buttonInputManual = new Button();
            buttonLogout = new Button();
            buttonLaporan = new Button();
            buttonJadwal = new Button();
            label1 = new Label();
            buttonInput = new Button();
            timerKunjungan = new System.Windows.Forms.Timer(components);
            buttonSimpanEdit = new Button();
            buttonHapus = new Button();
            ((System.ComponentModel.ISupportInitialize)dataGridViewKunjungan).BeginInit();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Century", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label6.ForeColor = Color.DarkRed;
            label6.Location = new Point(205, 424);
            label6.Margin = new Padding(4, 0, 4, 0);
            label6.Name = "label6";
            label6.Size = new Size(78, 22);
            label6.TabIndex = 28;
            label6.Text = "Catatan";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Century", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label7.ForeColor = Color.DarkRed;
            label7.Location = new Point(205, 380);
            label7.Margin = new Padding(4, 0, 4, 0);
            label7.Name = "label7";
            label7.Size = new Size(98, 22);
            label7.TabIndex = 27;
            label7.Text = "Keperluan";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Century", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label2.ForeColor = Color.DarkRed;
            label2.Location = new Point(205, 334);
            label2.Margin = new Padding(4, 0, 4, 0);
            label2.Name = "label2";
            label2.Size = new Size(166, 22);
            label2.TabIndex = 26;
            label2.Text = "Waktu Kunjungan";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Century", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label5.ForeColor = Color.DarkRed;
            label5.Location = new Point(205, 291);
            label5.Margin = new Padding(4, 0, 4, 0);
            label5.Name = "label5";
            label5.Size = new Size(178, 22);
            label5.TabIndex = 25;
            label5.Text = "Tanggal Kunjungan";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Century", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label4.ForeColor = Color.DarkRed;
            label4.Location = new Point(205, 244);
            label4.Margin = new Padding(4, 0, 4, 0);
            label4.Name = "label4";
            label4.Size = new Size(124, 22);
            label4.TabIndex = 24;
            label4.Text = "Nama Dokter";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Century", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label3.ForeColor = Color.DarkRed;
            label3.Location = new Point(205, 194);
            label3.Margin = new Padding(4, 0, 4, 0);
            label3.Name = "label3";
            label3.Size = new Size(122, 22);
            label3.TabIndex = 23;
            label3.Text = "Nama Pasien";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new Font("Century", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label8.ForeColor = Color.DarkRed;
            label8.Location = new Point(205, 139);
            label8.Margin = new Padding(4, 0, 4, 0);
            label8.Name = "label8";
            label8.Size = new Size(240, 28);
            label8.TabIndex = 29;
            label8.Text = "Form Penjadwalan";
            // 
            // comboBoxPasien
            // 
            comboBoxPasien.FormattingEnabled = true;
            comboBoxPasien.Location = new Point(436, 189);
            comboBoxPasien.Margin = new Padding(4);
            comboBoxPasien.Name = "comboBoxPasien";
            comboBoxPasien.Size = new Size(312, 33);
            comboBoxPasien.TabIndex = 30;
            // 
            // comboBoxDokter
            // 
            comboBoxDokter.FormattingEnabled = true;
            comboBoxDokter.Location = new Point(436, 239);
            comboBoxDokter.Margin = new Padding(4);
            comboBoxDokter.Name = "comboBoxDokter";
            comboBoxDokter.Size = new Size(312, 33);
            comboBoxDokter.TabIndex = 31;
            // 
            // dateTimePickerTanggal
            // 
            dateTimePickerTanggal.Location = new Point(436, 284);
            dateTimePickerTanggal.Margin = new Padding(4);
            dateTimePickerTanggal.Name = "dateTimePickerTanggal";
            dateTimePickerTanggal.Size = new Size(312, 31);
            dateTimePickerTanggal.TabIndex = 32;
            // 
            // textBoxKeperluan
            // 
            textBoxKeperluan.Location = new Point(436, 375);
            textBoxKeperluan.Margin = new Padding(4);
            textBoxKeperluan.Name = "textBoxKeperluan";
            textBoxKeperluan.Size = new Size(312, 31);
            textBoxKeperluan.TabIndex = 33;
            // 
            // textBoxCatatan
            // 
            textBoxCatatan.Location = new Point(436, 419);
            textBoxCatatan.Margin = new Padding(4);
            textBoxCatatan.Name = "textBoxCatatan";
            textBoxCatatan.Size = new Size(312, 31);
            textBoxCatatan.TabIndex = 34;
            // 
            // dateTimePickerWaktu
            // 
            dateTimePickerWaktu.CustomFormat = "";
            dateTimePickerWaktu.Location = new Point(436, 326);
            dateTimePickerWaktu.Margin = new Padding(4);
            dateTimePickerWaktu.Name = "dateTimePickerWaktu";
            dateTimePickerWaktu.Size = new Size(312, 31);
            dateTimePickerWaktu.TabIndex = 35;
            dateTimePickerWaktu.Value = new DateTime(2025, 1, 26, 20, 55, 0, 0);
            // 
            // buttonEdit
            // 
            buttonEdit.BackColor = Color.DarkRed;
            buttonEdit.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            buttonEdit.ForeColor = Color.White;
            buttonEdit.Location = new Point(369, 472);
            buttonEdit.Margin = new Padding(4);
            buttonEdit.Name = "buttonEdit";
            buttonEdit.Size = new Size(142, 45);
            buttonEdit.TabIndex = 43;
            buttonEdit.Text = "Edit";
            buttonEdit.UseVisualStyleBackColor = false;
            buttonEdit.Click += buttonEdit_Click;
            // 
            // buttonSimpan
            // 
            buttonSimpan.BackColor = Color.DarkRed;
            buttonSimpan.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            buttonSimpan.ForeColor = Color.White;
            buttonSimpan.Location = new Point(203, 472);
            buttonSimpan.Margin = new Padding(4);
            buttonSimpan.Name = "buttonSimpan";
            buttonSimpan.Size = new Size(142, 45);
            buttonSimpan.TabIndex = 42;
            buttonSimpan.Text = "Simpan";
            buttonSimpan.UseVisualStyleBackColor = false;
            buttonSimpan.Click += buttonSimpan_Click;
            // 
            // dataGridViewKunjungan
            // 
            dataGridViewKunjungan.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewKunjungan.Location = new Point(788, 26);
            dataGridViewKunjungan.Margin = new Padding(4);
            dataGridViewKunjungan.Name = "dataGridViewKunjungan";
            dataGridViewKunjungan.RowHeadersWidth = 51;
            dataGridViewKunjungan.Size = new Size(756, 690);
            dataGridViewKunjungan.TabIndex = 44;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Font = new Font("Century", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label9.ForeColor = Color.DarkRed;
            label9.Location = new Point(205, 655);
            label9.Margin = new Padding(4, 0, 4, 0);
            label9.Name = "label9";
            label9.Size = new Size(140, 22);
            label9.TabIndex = 45;
            label9.Text = "PENGINGAT!!!";
            // 
            // panel1
            // 
            panel1.Controls.Add(buttonInputManual);
            panel1.Controls.Add(buttonLogout);
            panel1.Controls.Add(buttonLaporan);
            panel1.Controls.Add(buttonJadwal);
            panel1.Controls.Add(label1);
            panel1.Controls.Add(buttonInput);
            panel1.Location = new Point(2, 0);
            panel1.Margin = new Padding(4);
            panel1.Name = "panel1";
            panel1.Size = new Size(180, 765);
            panel1.TabIndex = 46;
            // 
            // buttonInputManual
            // 
            buttonInputManual.Font = new Font("Century", 7.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            buttonInputManual.ForeColor = Color.DarkRed;
            buttonInputManual.Image = (Image)resources.GetObject("buttonInputManual.Image");
            buttonInputManual.ImageAlign = ContentAlignment.TopCenter;
            buttonInputManual.Location = new Point(0, 361);
            buttonInputManual.Margin = new Padding(4);
            buttonInputManual.Name = "buttonInputManual";
            buttonInputManual.Size = new Size(180, 89);
            buttonInputManual.TabIndex = 18;
            buttonInputManual.Text = "Input Manual Kondisi Kesehatan";
            buttonInputManual.TextAlign = ContentAlignment.BottomCenter;
            buttonInputManual.UseVisualStyleBackColor = true;
            buttonInputManual.Click += buttonInputManual_Click;
            // 
            // buttonLogout
            // 
            buttonLogout.BackColor = Color.DarkRed;
            buttonLogout.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            buttonLogout.ForeColor = Color.White;
            buttonLogout.Location = new Point(12, 648);
            buttonLogout.Margin = new Padding(4);
            buttonLogout.Name = "buttonLogout";
            buttonLogout.Size = new Size(155, 61);
            buttonLogout.TabIndex = 17;
            buttonLogout.Text = "Logout";
            buttonLogout.UseVisualStyleBackColor = false;
            // 
            // buttonLaporan
            // 
            buttonLaporan.Font = new Font("Century", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            buttonLaporan.ForeColor = Color.DarkRed;
            buttonLaporan.Image = (Image)resources.GetObject("buttonLaporan.Image");
            buttonLaporan.ImageAlign = ContentAlignment.TopCenter;
            buttonLaporan.Location = new Point(0, 504);
            buttonLaporan.Margin = new Padding(4);
            buttonLaporan.Name = "buttonLaporan";
            buttonLaporan.Size = new Size(180, 89);
            buttonLaporan.TabIndex = 5;
            buttonLaporan.Text = "Laporan Kesehatan";
            buttonLaporan.TextAlign = ContentAlignment.BottomCenter;
            buttonLaporan.UseVisualStyleBackColor = true;
            buttonLaporan.Click += buttonLaporan_Click;
            // 
            // buttonJadwal
            // 
            buttonJadwal.Font = new Font("Century", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            buttonJadwal.ForeColor = Color.DarkRed;
            buttonJadwal.Image = (Image)resources.GetObject("buttonJadwal.Image");
            buttonJadwal.ImageAlign = ContentAlignment.TopCenter;
            buttonJadwal.Location = new Point(0, 220);
            buttonJadwal.Margin = new Padding(4);
            buttonJadwal.Name = "buttonJadwal";
            buttonJadwal.Size = new Size(180, 94);
            buttonJadwal.TabIndex = 4;
            buttonJadwal.Text = "Jadwal Kunjungan";
            buttonJadwal.TextAlign = ContentAlignment.BottomCenter;
            buttonJadwal.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Century", 10.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.DarkRed;
            label1.Location = new Point(24, 26);
            label1.Margin = new Padding(4, 0, 4, 0);
            label1.Name = "label1";
            label1.Size = new Size(131, 27);
            label1.TabIndex = 3;
            label1.Text = "Dashboard";
            // 
            // buttonInput
            // 
            buttonInput.Font = new Font("Century", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            buttonInput.ForeColor = Color.DarkRed;
            buttonInput.Image = (Image)resources.GetObject("buttonInput.Image");
            buttonInput.ImageAlign = ContentAlignment.TopCenter;
            buttonInput.Location = new Point(0, 80);
            buttonInput.Margin = new Padding(4);
            buttonInput.Name = "buttonInput";
            buttonInput.Size = new Size(180, 92);
            buttonInput.TabIndex = 0;
            buttonInput.Text = "Input Data Pasien";
            buttonInput.TextAlign = ContentAlignment.BottomCenter;
            buttonInput.UseVisualStyleBackColor = true;
            buttonInput.Click += buttonInput_Click;
            // 
            // timerKunjungan
            // 
            timerKunjungan.Enabled = true;
            timerKunjungan.Interval = 1000;
            timerKunjungan.Tick += timerKunjungan_Tick_1;
            // 
            // buttonSimpanEdit
            // 
            buttonSimpanEdit.BackColor = Color.DarkRed;
            buttonSimpanEdit.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            buttonSimpanEdit.ForeColor = Color.White;
            buttonSimpanEdit.Location = new Point(536, 472);
            buttonSimpanEdit.Margin = new Padding(4);
            buttonSimpanEdit.Name = "buttonSimpanEdit";
            buttonSimpanEdit.Size = new Size(142, 45);
            buttonSimpanEdit.TabIndex = 47;
            buttonSimpanEdit.Text = "Simpan Edit";
            buttonSimpanEdit.UseVisualStyleBackColor = false;
            buttonSimpanEdit.Click += buttonSimpanEdit_Click;
            // 
            // buttonHapus
            // 
            buttonHapus.BackColor = Color.DarkRed;
            buttonHapus.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            buttonHapus.ForeColor = Color.White;
            buttonHapus.Location = new Point(369, 548);
            buttonHapus.Margin = new Padding(4);
            buttonHapus.Name = "buttonHapus";
            buttonHapus.Size = new Size(142, 45);
            buttonHapus.TabIndex = 48;
            buttonHapus.Text = "Hapus";
            buttonHapus.UseVisualStyleBackColor = false;
            buttonHapus.Click += buttonHapus_Click;
            // 
            // Jadwal
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1559, 766);
            Controls.Add(buttonHapus);
            Controls.Add(buttonSimpanEdit);
            Controls.Add(panel1);
            Controls.Add(label9);
            Controls.Add(dataGridViewKunjungan);
            Controls.Add(buttonEdit);
            Controls.Add(buttonSimpan);
            Controls.Add(dateTimePickerWaktu);
            Controls.Add(textBoxCatatan);
            Controls.Add(textBoxKeperluan);
            Controls.Add(dateTimePickerTanggal);
            Controls.Add(comboBoxDokter);
            Controls.Add(comboBoxPasien);
            Controls.Add(label8);
            Controls.Add(label6);
            Controls.Add(label7);
            Controls.Add(label2);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Margin = new Padding(4);
            Name = "Jadwal";
            Text = "Jadwal";
            ((System.ComponentModel.ISupportInitialize)dataGridViewKunjungan).EndInit();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Label label6;
        private Label label7;
        private Label label2;
        private Label label5;
        private Label label4;
        private Label label3;
        private Label label8;
        private ComboBox comboBoxPasien;
        private ComboBox comboBoxDokter;
        private DateTimePicker dateTimePickerTanggal;
        private TextBox textBoxKeperluan;
        private TextBox textBoxCatatan;
        private DateTimePicker dateTimePickerWaktu;
        private Button buttonEdit;
        private Button buttonSimpan;
        private DataGridView dataGridViewKunjungan;
        private Label label9;
        private Panel panel1;
        private Button buttonInputManual;
        private Button buttonLogout;
        private Button buttonLaporan;
        private Button buttonJadwal;
        private Label label1;
        private Button buttonInput;
        private System.Windows.Forms.Timer timerKunjungan;
        private Button buttonSimpanEdit;
        private Button buttonHapus;
    }
}