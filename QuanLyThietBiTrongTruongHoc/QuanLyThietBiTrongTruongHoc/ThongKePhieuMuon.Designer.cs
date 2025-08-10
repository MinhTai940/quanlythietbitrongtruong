namespace QuanLyThietBiTrongTruongHoc
{
    partial class ThongKePhieuMuon
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend2 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.label1 = new System.Windows.Forms.Label();
            this.guna2GroupBox1 = new Guna.UI2.WinForms.Guna2GroupBox();
            this.dgvTTThongKe = new System.Windows.Forms.DataGridView();
            this.datetimeThongKePhieuMuon = new System.Windows.Forms.DateTimePicker();
            this.chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.btnThongKeTheoNgay = new Guna.UI2.WinForms.Guna2Button();
            this.btnThongKeTheoTuan = new Guna.UI2.WinForms.Guna2Button();
            this.btnQuayLai = new Guna.UI2.WinForms.Guna2Button();
            this.label2 = new System.Windows.Forms.Label();
            this.guna2GroupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTTThongKe)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Times New Roman", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label1.Location = new System.Drawing.Point(427, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(373, 51);
            this.label1.TabIndex = 0;
            this.label1.Text = "Thống Kê Phiếu Mượn";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // guna2GroupBox1
            // 
            this.guna2GroupBox1.Controls.Add(this.dgvTTThongKe);
            this.guna2GroupBox1.CustomBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.guna2GroupBox1.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.guna2GroupBox1.ForeColor = System.Drawing.Color.White;
            this.guna2GroupBox1.Location = new System.Drawing.Point(12, 163);
            this.guna2GroupBox1.Name = "guna2GroupBox1";
            this.guna2GroupBox1.Size = new System.Drawing.Size(642, 269);
            this.guna2GroupBox1.TabIndex = 1;
            this.guna2GroupBox1.Text = "Thống Kê Thiết Bị Mượn";
            // 
            // dgvTTThongKe
            // 
            this.dgvTTThongKe.BackgroundColor = System.Drawing.Color.White;
            this.dgvTTThongKe.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTTThongKe.Location = new System.Drawing.Point(12, 52);
            this.dgvTTThongKe.Name = "dgvTTThongKe";
            this.dgvTTThongKe.RowHeadersWidth = 51;
            this.dgvTTThongKe.RowTemplate.Height = 24;
            this.dgvTTThongKe.Size = new System.Drawing.Size(611, 201);
            this.dgvTTThongKe.TabIndex = 0;
            // 
            // datetimeThongKePhieuMuon
            // 
            this.datetimeThongKePhieuMuon.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.datetimeThongKePhieuMuon.Location = new System.Drawing.Point(24, 115);
            this.datetimeThongKePhieuMuon.Name = "datetimeThongKePhieuMuon";
            this.datetimeThongKePhieuMuon.Size = new System.Drawing.Size(274, 30);
            this.datetimeThongKePhieuMuon.TabIndex = 2;
            // 
            // chart1
            // 
            chartArea2.Name = "ChartArea1";
            this.chart1.ChartAreas.Add(chartArea2);
            legend2.Name = "Legend1";
            this.chart1.Legends.Add(legend2);
            this.chart1.Location = new System.Drawing.Point(680, 163);
            this.chart1.Name = "chart1";
            series2.ChartArea = "ChartArea1";
            series2.Legend = "Legend1";
            series2.Name = "Series1";
            this.chart1.Series.Add(series2);
            this.chart1.Size = new System.Drawing.Size(662, 353);
            this.chart1.TabIndex = 3;
            this.chart1.Text = "chart1";
            // 
            // btnThongKeTheoNgay
            // 
            this.btnThongKeTheoNgay.BorderRadius = 15;
            this.btnThongKeTheoNgay.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnThongKeTheoNgay.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnThongKeTheoNgay.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnThongKeTheoNgay.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnThongKeTheoNgay.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.btnThongKeTheoNgay.ForeColor = System.Drawing.Color.White;
            this.btnThongKeTheoNgay.Image = global::QuanLyThietBiTrongTruongHoc.Properties.Resources.thongke;
            this.btnThongKeTheoNgay.Location = new System.Drawing.Point(12, 447);
            this.btnThongKeTheoNgay.Name = "btnThongKeTheoNgay";
            this.btnThongKeTheoNgay.Size = new System.Drawing.Size(204, 60);
            this.btnThongKeTheoNgay.TabIndex = 6;
            this.btnThongKeTheoNgay.Text = "Thống Kê Theo Ngày";
            this.btnThongKeTheoNgay.Click += new System.EventHandler(this.btnThongKeTheoNgay_Click);
            // 
            // btnThongKeTheoTuan
            // 
            this.btnThongKeTheoTuan.BorderRadius = 15;
            this.btnThongKeTheoTuan.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnThongKeTheoTuan.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnThongKeTheoTuan.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnThongKeTheoTuan.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnThongKeTheoTuan.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.btnThongKeTheoTuan.ForeColor = System.Drawing.Color.White;
            this.btnThongKeTheoTuan.Image = global::QuanLyThietBiTrongTruongHoc.Properties.Resources.thongke;
            this.btnThongKeTheoTuan.Location = new System.Drawing.Point(231, 447);
            this.btnThongKeTheoTuan.Name = "btnThongKeTheoTuan";
            this.btnThongKeTheoTuan.Size = new System.Drawing.Size(204, 60);
            this.btnThongKeTheoTuan.TabIndex = 6;
            this.btnThongKeTheoTuan.Text = "Thống Kê Theo Tuần";
            this.btnThongKeTheoTuan.Click += new System.EventHandler(this.btnThongKeTheoTuan_Click);
            // 
            // btnQuayLai
            // 
            this.btnQuayLai.BorderRadius = 15;
            this.btnQuayLai.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnQuayLai.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnQuayLai.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnQuayLai.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnQuayLai.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.btnQuayLai.ForeColor = System.Drawing.Color.White;
            this.btnQuayLai.Image = global::QuanLyThietBiTrongTruongHoc.Properties.Resources.quaylai;
            this.btnQuayLai.Location = new System.Drawing.Point(450, 447);
            this.btnQuayLai.Name = "btnQuayLai";
            this.btnQuayLai.Size = new System.Drawing.Size(204, 60);
            this.btnQuayLai.TabIndex = 6;
            this.btnQuayLai.Text = "Quay Lại";
            this.btnQuayLai.Click += new System.EventHandler(this.btnQuayLai_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label2.Location = new System.Drawing.Point(850, 533);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(367, 19);
            this.label2.TabIndex = 7;
            this.label2.Text = "Biểu đồ thống kê thiết bị mượn theo ngày và tuần";
            // 
            // ThongKePhieuMuon
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1354, 628);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnQuayLai);
            this.Controls.Add(this.btnThongKeTheoTuan);
            this.Controls.Add(this.btnThongKeTheoNgay);
            this.Controls.Add(this.chart1);
            this.Controls.Add(this.datetimeThongKePhieuMuon);
            this.Controls.Add(this.guna2GroupBox1);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "ThongKePhieuMuon";
            this.Text = "ThongKePhieuMuon";
            this.guna2GroupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvTTThongKe)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private Guna.UI2.WinForms.Guna2GroupBox guna2GroupBox1;
        private System.Windows.Forms.DateTimePicker datetimeThongKePhieuMuon;
        private System.Windows.Forms.DataGridView dgvTTThongKe;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart1;
        private Guna.UI2.WinForms.Guna2Button btnThongKeTheoNgay;
        private Guna.UI2.WinForms.Guna2Button btnThongKeTheoTuan;
        private Guna.UI2.WinForms.Guna2Button btnQuayLai;
        private System.Windows.Forms.Label label2;
    }
}