﻿namespace tbpbo2
{
    partial class Laporan
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Laporan));
            chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            panel1 = new Panel();
            buttonInputManual = new Button();
            buttonLogout = new Button();
            buttonLaporan = new Button();
            buttonJadwal = new Button();
            label1 = new Label();
            buttonInput = new Button();
            ((System.ComponentModel.ISupportInitialize)chart1).BeginInit();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // chart1
            // 
            chartArea1.Name = "ChartArea1";
            chart1.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            chart1.Legends.Add(legend1);
            chart1.Location = new Point(175, 57);
            chart1.Name = "chart1";
            series1.ChartArea = "ChartArea1";
            series1.Legend = "Legend1";
            series1.Name = "Series1";
            chart1.Series.Add(series1);
            chart1.Size = new Size(561, 458);
            chart1.TabIndex = 45;
            chart1.Text = "chart1";
            // 
            // panel1
            // 
            panel1.Controls.Add(buttonInputManual);
            panel1.Controls.Add(buttonLogout);
            panel1.Controls.Add(buttonLaporan);
            panel1.Controls.Add(buttonJadwal);
            panel1.Controls.Add(label1);
            panel1.Controls.Add(buttonInput);
            panel1.Location = new Point(3, 2);
            panel1.Name = "panel1";
            panel1.Size = new Size(144, 612);
            panel1.TabIndex = 47;
            // 
            // buttonInputManual
            // 
            buttonInputManual.Font = new Font("Century", 7.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            buttonInputManual.ForeColor = Color.DarkRed;
            buttonInputManual.Image = (Image)resources.GetObject("buttonInputManual.Image");
            buttonInputManual.ImageAlign = ContentAlignment.TopCenter;
            buttonInputManual.Location = new Point(0, 289);
            buttonInputManual.Name = "buttonInputManual";
            buttonInputManual.Size = new Size(144, 71);
            buttonInputManual.TabIndex = 18;
            buttonInputManual.Text = "Input Manual Kondisi Kesehatan";
            buttonInputManual.TextAlign = ContentAlignment.BottomCenter;
            buttonInputManual.UseVisualStyleBackColor = true;
            // 
            // buttonLogout
            // 
            buttonLogout.BackColor = Color.DarkRed;
            buttonLogout.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            buttonLogout.ForeColor = Color.White;
            buttonLogout.Location = new Point(10, 518);
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
            buttonLaporan.Location = new Point(0, 403);
            buttonLaporan.Name = "buttonLaporan";
            buttonLaporan.Size = new Size(144, 71);
            buttonLaporan.TabIndex = 5;
            buttonLaporan.Text = "Laporan Kesehatan";
            buttonLaporan.TextAlign = ContentAlignment.BottomCenter;
            buttonLaporan.UseVisualStyleBackColor = true;
            // 
            // buttonJadwal
            // 
            buttonJadwal.Font = new Font("Century", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            buttonJadwal.ForeColor = Color.DarkRed;
            buttonJadwal.Image = (Image)resources.GetObject("buttonJadwal.Image");
            buttonJadwal.ImageAlign = ContentAlignment.TopCenter;
            buttonJadwal.Location = new Point(0, 176);
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
            buttonInput.Location = new Point(0, 64);
            buttonInput.Name = "buttonInput";
            buttonInput.Size = new Size(144, 74);
            buttonInput.TabIndex = 0;
            buttonInput.Text = "Input Data Pasien";
            buttonInput.TextAlign = ContentAlignment.BottomCenter;
            buttonInput.UseVisualStyleBackColor = true;
            // 
            // Laporan
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1247, 613);
            Controls.Add(panel1);
            Controls.Add(chart1);
            Name = "Laporan";
            Text = "Grafik";
            Load += Grafik_Load;
            ((System.ComponentModel.ISupportInitialize)chart1).EndInit();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion
        private System.Windows.Forms.DataVisualization.Charting.Chart chart1;
        private Panel panel1;
        private Button buttonInputManual;
        private Button buttonLogout;
        private Button buttonLaporan;
        private Button buttonJadwal;
        private Label label1;
        private Button buttonInput;
    }
}