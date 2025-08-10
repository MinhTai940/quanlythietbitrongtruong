namespace QuanLyThietBiTrongTruongHoc
{
    partial class Thongkechitietphieusua
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
            this.datetimeTKPhieuSua = new System.Windows.Forms.DateTimePicker();
            this.guna2GroupBox1 = new Guna.UI2.WinForms.Guna2GroupBox();
            this.dgvTTThongKe = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.btnQuayLai = new Guna.UI2.WinForms.Guna2Button();
            this.btnTKTheoTuan = new Guna.UI2.WinForms.Guna2Button();
            this.btnThongKeTheoNgay = new Guna.UI2.WinForms.Guna2Button();
            this.lblTongTien = new System.Windows.Forms.Label();
            this.guna2GroupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTTThongKe)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).BeginInit();
            this.SuspendLayout();
            // 
            // datetimeTKPhieuSua
            // 
            this.datetimeTKPhieuSua.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.datetimeTKPhieuSua.Location = new System.Drawing.Point(21, 116);
            this.datetimeTKPhieuSua.Name = "datetimeTKPhieuSua";
            this.datetimeTKPhieuSua.Size = new System.Drawing.Size(274, 30);
            this.datetimeTKPhieuSua.TabIndex = 10;
            // 
            // guna2GroupBox1
            // 
            this.guna2GroupBox1.Controls.Add(this.dgvTTThongKe);
            this.guna2GroupBox1.CustomBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.guna2GroupBox1.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.guna2GroupBox1.ForeColor = System.Drawing.Color.White;
            this.guna2GroupBox1.Location = new System.Drawing.Point(9, 164);
            this.guna2GroupBox1.Name = "guna2GroupBox1";
            this.guna2GroupBox1.Size = new System.Drawing.Size(642, 269);
            this.guna2GroupBox1.TabIndex = 9;
            this.guna2GroupBox1.Text = "Thống Kê Thiết Bị Sửa";
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
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Times New Roman", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label1.Location = new System.Drawing.Point(424, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(373, 51);
            this.label1.TabIndex = 8;
            this.label1.Text = "Thống Kê Phiếu Sửa";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label2.Location = new System.Drawing.Point(784, 537);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(350, 19);
            this.label2.TabIndex = 15;
            this.label2.Text = "Biểu đồ thống kê thiết bị sửa theo ngày và tuần";
            // 
            // chart1
            // 
            chartArea1.Name = "ChartArea1";
            this.chart1.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.chart1.Legends.Add(legend1);
            this.chart1.Location = new System.Drawing.Point(677, 164);
            this.chart1.Name = "chart1";
            series1.ChartArea = "ChartArea1";
            series1.Legend = "Legend1";
            series1.Name = "Series1";
            this.chart1.Series.Add(series1);
            this.chart1.Size = new System.Drawing.Size(634, 353);
            this.chart1.TabIndex = 11;
            this.chart1.Text = "chart1";
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
            this.btnQuayLai.Location = new System.Drawing.Point(447, 448);
            this.btnQuayLai.Name = "btnQuayLai";
            this.btnQuayLai.Size = new System.Drawing.Size(204, 60);
            this.btnQuayLai.TabIndex = 12;
            this.btnQuayLai.Text = "Quay Lại";
            this.btnQuayLai.Click += new System.EventHandler(this.btnQuayLai_Click);
            // 
            // btnTKTheoTuan
            // 
            this.btnTKTheoTuan.BorderRadius = 15;
            this.btnTKTheoTuan.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnTKTheoTuan.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnTKTheoTuan.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnTKTheoTuan.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnTKTheoTuan.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.btnTKTheoTuan.ForeColor = System.Drawing.Color.White;
            this.btnTKTheoTuan.Image = global::QuanLyThietBiTrongTruongHoc.Properties.Resources.thongke;
            this.btnTKTheoTuan.Location = new System.Drawing.Point(228, 448);
            this.btnTKTheoTuan.Name = "btnTKTheoTuan";
            this.btnTKTheoTuan.Size = new System.Drawing.Size(204, 60);
            this.btnTKTheoTuan.TabIndex = 13;
            this.btnTKTheoTuan.Text = "Thống Kê Theo Tuần";
            this.btnTKTheoTuan.Click += new System.EventHandler(this.btnTKTheoTuan_Click);
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
            this.btnThongKeTheoNgay.Location = new System.Drawing.Point(9, 448);
            this.btnThongKeTheoNgay.Name = "btnThongKeTheoNgay";
            this.btnThongKeTheoNgay.Size = new System.Drawing.Size(204, 60);
            this.btnThongKeTheoNgay.TabIndex = 14;
            this.btnThongKeTheoNgay.Text = "Thống Kê Theo Ngày";
            this.btnThongKeTheoNgay.Click += new System.EventHandler(this.btnThongKeTheoNgay_Click);
            // 
            // lblTongTien
            // 
            this.lblTongTien.AutoSize = true;
            this.lblTongTien.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.lblTongTien.Location = new System.Drawing.Point(17, 578);
            this.lblTongTien.Name = "lblTongTien";
            this.lblTongTien.Size = new System.Drawing.Size(89, 19);
            this.lblTongTien.TabIndex = 16;
            this.lblTongTien.Text = "Tổng Tiền:";
            // 
            // Thongkechitietphieusua
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1323, 628);
            this.Controls.Add(this.lblTongTien);
            this.Controls.Add(this.datetimeTKPhieuSua);
            this.Controls.Add(this.guna2GroupBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnQuayLai);
            this.Controls.Add(this.btnTKTheoTuan);
            this.Controls.Add(this.btnThongKeTheoNgay);
            this.Controls.Add(this.chart1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "Thongkechitietphieusua";
            this.Text = "Thongkechitietphieusua";
            this.guna2GroupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvTTThongKe)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DateTimePicker datetimeTKPhieuSua;
        private Guna.UI2.WinForms.Guna2GroupBox guna2GroupBox1;
        private System.Windows.Forms.DataGridView dgvTTThongKe;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private Guna.UI2.WinForms.Guna2Button btnQuayLai;
        private Guna.UI2.WinForms.Guna2Button btnTKTheoTuan;
        private Guna.UI2.WinForms.Guna2Button btnThongKeTheoNgay;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart1;
        private System.Windows.Forms.Label lblTongTien;
    }
}