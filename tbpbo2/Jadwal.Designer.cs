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
            panel1 = new Panel();
            buttonLogout = new Button();
            buttonLaporan = new Button();
            buttonJadwal = new Button();
            label1 = new Label();
            buttonInput = new Button();
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
            dataGridView1 = new DataGridView();
            label9 = new Label();
            timer1 = new System.Windows.Forms.Timer(components);
            buttonInputManual = new Button();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.Controls.Add(buttonInputManual);
            panel1.Controls.Add(buttonLogout);
            panel1.Controls.Add(buttonLaporan);
            panel1.Controls.Add(buttonJadwal);
            panel1.Controls.Add(label1);
            panel1.Controls.Add(buttonInput);
            panel1.Location = new Point(1, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(144, 612);
            panel1.TabIndex = 1;
            // 
            // buttonLogout
            // 
            buttonLogout.BackColor = Color.DarkRed;
            buttonLogout.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            buttonLogout.ForeColor = Color.White;
            buttonLogout.Location = new Point(9, 524);
            buttonLogout.Name = "buttonLogout";
            buttonLogout.Size = new Size(124, 49);
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
            buttonLaporan.Location = new Point(3, 425);
            buttonLaporan.Name = "buttonLaporan";
            buttonLaporan.Size = new Size(144, 71);
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
            buttonJadwal.Location = new Point(3, 195);
            buttonJadwal.Name = "buttonJadwal";
            buttonJadwal.Size = new Size(144, 75);
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
            label1.Location = new Point(19, 21);
            label1.Name = "label1";
            label1.Size = new Size(109, 22);
            label1.TabIndex = 3;
            label1.Text = "Dashboard";
            // 
            // buttonInput
            // 
            buttonInput.Font = new Font("Century", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            buttonInput.ForeColor = Color.DarkRed;
            buttonInput.Image = (Image)resources.GetObject("buttonInput.Image");
            buttonInput.ImageAlign = ContentAlignment.TopCenter;
            buttonInput.Location = new Point(0, 84);
            buttonInput.Name = "buttonInput";
            buttonInput.Size = new Size(144, 74);
            buttonInput.TabIndex = 0;
            buttonInput.Text = "Input Data Pasien";
            buttonInput.TextAlign = ContentAlignment.BottomCenter;
            buttonInput.UseVisualStyleBackColor = true;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Century", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label6.ForeColor = Color.DarkRed;
            label6.Location = new Point(164, 339);
            label6.Name = "label6";
            label6.Size = new Size(64, 18);
            label6.TabIndex = 28;
            label6.Text = "Catatan";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Century", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label7.ForeColor = Color.DarkRed;
            label7.Location = new Point(164, 304);
            label7.Name = "label7";
            label7.Size = new Size(83, 18);
            label7.TabIndex = 27;
            label7.Text = "Keperluan";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Century", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label2.ForeColor = Color.DarkRed;
            label2.Location = new Point(164, 267);
            label2.Name = "label2";
            label2.Size = new Size(136, 18);
            label2.TabIndex = 26;
            label2.Text = "Waktu Kunjungan";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Century", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label5.ForeColor = Color.DarkRed;
            label5.Location = new Point(164, 233);
            label5.Name = "label5";
            label5.Size = new Size(145, 18);
            label5.TabIndex = 25;
            label5.Text = "Tanggal Kunjungan";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Century", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label4.ForeColor = Color.DarkRed;
            label4.Location = new Point(164, 195);
            label4.Name = "label4";
            label4.Size = new Size(103, 18);
            label4.TabIndex = 24;
            label4.Text = "Nama Dokter";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Century", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label3.ForeColor = Color.DarkRed;
            label3.Location = new Point(164, 155);
            label3.Name = "label3";
            label3.Size = new Size(100, 18);
            label3.TabIndex = 23;
            label3.Text = "Nama Pasien";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new Font("Century", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label8.ForeColor = Color.DarkRed;
            label8.Location = new Point(164, 111);
            label8.Name = "label8";
            label8.Size = new Size(201, 23);
            label8.TabIndex = 29;
            label8.Text = "Form Penjadwalan";
            // 
            // comboBoxPasien
            // 
            comboBoxPasien.FormattingEnabled = true;
            comboBoxPasien.Location = new Point(349, 151);
            comboBoxPasien.Name = "comboBoxPasien";
            comboBoxPasien.Size = new Size(250, 28);
            comboBoxPasien.TabIndex = 30;
            // 
            // comboBoxDokter
            // 
            comboBoxDokter.FormattingEnabled = true;
            comboBoxDokter.Location = new Point(349, 191);
            comboBoxDokter.Name = "comboBoxDokter";
            comboBoxDokter.Size = new Size(250, 28);
            comboBoxDokter.TabIndex = 31;
            // 
            // dateTimePickerTanggal
            // 
            dateTimePickerTanggal.Location = new Point(349, 227);
            dateTimePickerTanggal.Name = "dateTimePickerTanggal";
            dateTimePickerTanggal.Size = new Size(250, 27);
            dateTimePickerTanggal.TabIndex = 32;
            // 
            // textBoxKeperluan
            // 
            textBoxKeperluan.Location = new Point(349, 300);
            textBoxKeperluan.Name = "textBoxKeperluan";
            textBoxKeperluan.Size = new Size(250, 27);
            textBoxKeperluan.TabIndex = 33;
            // 
            // textBoxCatatan
            // 
            textBoxCatatan.Location = new Point(349, 335);
            textBoxCatatan.Name = "textBoxCatatan";
            textBoxCatatan.Size = new Size(250, 27);
            textBoxCatatan.TabIndex = 34;
            // 
            // dateTimePickerWaktu
            // 
            dateTimePickerWaktu.Location = new Point(349, 261);
            dateTimePickerWaktu.Name = "dateTimePickerWaktu";
            dateTimePickerWaktu.Size = new Size(250, 27);
            dateTimePickerWaktu.TabIndex = 35;
            // 
            // buttonEdit
            // 
            buttonEdit.BackColor = Color.DarkRed;
            buttonEdit.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            buttonEdit.ForeColor = Color.White;
            buttonEdit.Location = new Point(387, 381);
            buttonEdit.Name = "buttonEdit";
            buttonEdit.Size = new Size(114, 36);
            buttonEdit.TabIndex = 43;
            buttonEdit.Text = "Edit";
            buttonEdit.UseVisualStyleBackColor = false;
            // 
            // buttonSimpan
            // 
            buttonSimpan.BackColor = Color.DarkRed;
            buttonSimpan.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            buttonSimpan.ForeColor = Color.White;
            buttonSimpan.Location = new Point(251, 381);
            buttonSimpan.Name = "buttonSimpan";
            buttonSimpan.Size = new Size(114, 36);
            buttonSimpan.TabIndex = 42;
            buttonSimpan.Text = "Simpan";
            buttonSimpan.UseVisualStyleBackColor = false;
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(630, 21);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersWidth = 51;
            dataGridView1.Size = new Size(605, 552);
            dataGridView1.TabIndex = 44;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Font = new Font("Century", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label9.ForeColor = Color.DarkRed;
            label9.Location = new Point(164, 524);
            label9.Name = "label9";
            label9.Size = new Size(116, 18);
            label9.TabIndex = 45;
            label9.Text = "PENGINGAT!!!";
            // 
            // buttonInputManual
            // 
            buttonInputManual.Font = new Font("Century", 7.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            buttonInputManual.ForeColor = Color.DarkRed;
            buttonInputManual.Image = (Image)resources.GetObject("buttonInputManual.Image");
            buttonInputManual.ImageAlign = ContentAlignment.TopCenter;
            buttonInputManual.Location = new Point(0, 313);
            buttonInputManual.Name = "buttonInputManual";
            buttonInputManual.Size = new Size(144, 71);
            buttonInputManual.TabIndex = 18;
            buttonInputManual.Text = "Input Manual Kondisi Kesehatan";
            buttonInputManual.TextAlign = ContentAlignment.BottomCenter;
            buttonInputManual.UseVisualStyleBackColor = true;
            // 
            // Jadwal
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1247, 613);
            Controls.Add(label9);
            Controls.Add(dataGridView1);
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
            Controls.Add(panel1);
            Name = "Jadwal";
            Text = "Jadwal";
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Panel panel1;
        private Button buttonLogout;
        private Button buttonLaporan;
        private Button buttonJadwal;
        private Label label1;
        private Button buttonInput;
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
        private DataGridView dataGridView1;
        private Label label9;
        private System.Windows.Forms.Timer timer1;
        private Button buttonInputManual;
    }
}