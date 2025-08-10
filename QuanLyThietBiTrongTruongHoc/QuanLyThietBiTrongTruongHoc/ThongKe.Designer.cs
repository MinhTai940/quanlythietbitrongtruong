namespace QuanLyThietBiTrongTruongHoc
{
    partial class ThongKe
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
            this.dgvTTchitietphieumuon = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.guna2GroupBox2 = new Guna.UI2.WinForms.Guna2GroupBox();
            this.dgvchitietphieusua = new System.Windows.Forms.DataGridView();
            this.btnthoatthongke = new Guna.UI2.WinForms.Guna2Button();
            this.btnquaylaithongke = new Guna.UI2.WinForms.Guna2Button();
            this.btnchitiephieusua = new Guna.UI2.WinForms.Guna2Button();
            this.btnchitetphieumuon = new Guna.UI2.WinForms.Guna2Button();
            this.btnTaiLaiThongKe = new Guna.UI2.WinForms.Guna2Button();
            this.guna2GroupBox1 = new Guna.UI2.WinForms.Guna2GroupBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTTchitietphieumuon)).BeginInit();
            this.guna2GroupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvchitietphieusua)).BeginInit();
            this.guna2GroupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvTTchitietphieumuon
            // 
            this.dgvTTchitietphieumuon.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTTchitietphieumuon.Location = new System.Drawing.Point(15, 58);
            this.dgvTTchitietphieumuon.Name = "dgvTTchitietphieumuon";
            this.dgvTTchitietphieumuon.RowHeadersWidth = 51;
            this.dgvTTchitietphieumuon.RowTemplate.Height = 24;
            this.dgvTTchitietphieumuon.Size = new System.Drawing.Size(753, 196);
            this.dgvTTchitietphieumuon.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(437, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(134, 32);
            this.label1.TabIndex = 4;
            this.label1.Text = "Thống Kê";
            // 
            // guna2GroupBox2
            // 
            this.guna2GroupBox2.Controls.Add(this.dgvchitietphieusua);
            this.guna2GroupBox2.CustomBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.guna2GroupBox2.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.guna2GroupBox2.ForeColor = System.Drawing.Color.White;
            this.guna2GroupBox2.Location = new System.Drawing.Point(185, 348);
            this.guna2GroupBox2.Name = "guna2GroupBox2";
            this.guna2GroupBox2.Size = new System.Drawing.Size(787, 279);
            this.guna2GroupBox2.TabIndex = 9;
            this.guna2GroupBox2.Text = "Chi Tiết Phiếu Sửa";
            // 
            // dgvchitietphieusua
            // 
            this.dgvchitietphieusua.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvchitietphieusua.Location = new System.Drawing.Point(15, 66);
            this.dgvchitietphieusua.Name = "dgvchitietphieusua";
            this.dgvchitietphieusua.RowHeadersWidth = 51;
            this.dgvchitietphieusua.RowTemplate.Height = 24;
            this.dgvchitietphieusua.Size = new System.Drawing.Size(753, 197);
            this.dgvchitietphieusua.TabIndex = 0;
            // 
            // btnthoatthongke
            // 
            this.btnthoatthongke.BackColor = System.Drawing.Color.Transparent;
            this.btnthoatthongke.BorderRadius = 15;
            this.btnthoatthongke.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnthoatthongke.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnthoatthongke.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnthoatthongke.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnthoatthongke.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.btnthoatthongke.ForeColor = System.Drawing.Color.White;
            this.btnthoatthongke.Image = global::QuanLyThietBiTrongTruongHoc.Properties.Resources.thoat;
            this.btnthoatthongke.Location = new System.Drawing.Point(-24, 571);
            this.btnthoatthongke.Name = "btnthoatthongke";
            this.btnthoatthongke.Size = new System.Drawing.Size(180, 56);
            this.btnthoatthongke.TabIndex = 10;
            this.btnthoatthongke.Text = "Thoát";
            this.btnthoatthongke.Click += new System.EventHandler(this.btnthoatthongke_Click);
            // 
            // btnquaylaithongke
            // 
            this.btnquaylaithongke.BackColor = System.Drawing.Color.Transparent;
            this.btnquaylaithongke.BorderRadius = 15;
            this.btnquaylaithongke.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnquaylaithongke.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnquaylaithongke.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnquaylaithongke.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnquaylaithongke.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.btnquaylaithongke.ForeColor = System.Drawing.Color.White;
            this.btnquaylaithongke.Image = global::QuanLyThietBiTrongTruongHoc.Properties.Resources.quaylai;
            this.btnquaylaithongke.Location = new System.Drawing.Point(-24, 508);
            this.btnquaylaithongke.Name = "btnquaylaithongke";
            this.btnquaylaithongke.Size = new System.Drawing.Size(180, 57);
            this.btnquaylaithongke.TabIndex = 5;
            this.btnquaylaithongke.Text = "Quay Lại";
            this.btnquaylaithongke.Click += new System.EventHandler(this.btnquaylaithongke_Click);
            // 
            // btnchitiephieusua
            // 
            this.btnchitiephieusua.BackColor = System.Drawing.Color.Transparent;
            this.btnchitiephieusua.BorderRadius = 15;
            this.btnchitiephieusua.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnchitiephieusua.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnchitiephieusua.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnchitiephieusua.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnchitiephieusua.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.btnchitiephieusua.ForeColor = System.Drawing.Color.White;
            this.btnchitiephieusua.Image = global::QuanLyThietBiTrongTruongHoc.Properties.Resources.hoadon;
            this.btnchitiephieusua.Location = new System.Drawing.Point(-24, 226);
            this.btnchitiephieusua.Name = "btnchitiephieusua";
            this.btnchitiephieusua.Size = new System.Drawing.Size(180, 52);
            this.btnchitiephieusua.TabIndex = 6;
            this.btnchitiephieusua.Text = "Phiếu Sửa";
            this.btnchitiephieusua.Click += new System.EventHandler(this.btnchitiephieusua_Click);
            // 
            // btnchitetphieumuon
            // 
            this.btnchitetphieumuon.BackColor = System.Drawing.Color.Transparent;
            this.btnchitetphieumuon.BorderRadius = 15;
            this.btnchitetphieumuon.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnchitetphieumuon.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnchitetphieumuon.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnchitetphieumuon.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnchitetphieumuon.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.btnchitetphieumuon.ForeColor = System.Drawing.Color.White;
            this.btnchitetphieumuon.Image = global::QuanLyThietBiTrongTruongHoc.Properties.Resources.hoadon;
            this.btnchitetphieumuon.Location = new System.Drawing.Point(-24, 166);
            this.btnchitetphieumuon.Name = "btnchitetphieumuon";
            this.btnchitetphieumuon.Size = new System.Drawing.Size(180, 54);
            this.btnchitetphieumuon.TabIndex = 7;
            this.btnchitetphieumuon.Text = "Phiếu Mượn";
            this.btnchitetphieumuon.Click += new System.EventHandler(this.btnchitetphieumuon_Click);
            // 
            // btnTaiLaiThongKe
            // 
            this.btnTaiLaiThongKe.BackColor = System.Drawing.Color.Transparent;
            this.btnTaiLaiThongKe.BorderRadius = 15;
            this.btnTaiLaiThongKe.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnTaiLaiThongKe.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnTaiLaiThongKe.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnTaiLaiThongKe.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnTaiLaiThongKe.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.btnTaiLaiThongKe.ForeColor = System.Drawing.Color.White;
            this.btnTaiLaiThongKe.Image = global::QuanLyThietBiTrongTruongHoc.Properties.Resources.tailai;
            this.btnTaiLaiThongKe.Location = new System.Drawing.Point(-24, 284);
            this.btnTaiLaiThongKe.Name = "btnTaiLaiThongKe";
            this.btnTaiLaiThongKe.Size = new System.Drawing.Size(180, 52);
            this.btnTaiLaiThongKe.TabIndex = 6;
            this.btnTaiLaiThongKe.Text = "Tải Lại";
            this.btnTaiLaiThongKe.Click += new System.EventHandler(this.btnTaiLaiThongKe_Click);
            // 
            // guna2GroupBox1
            // 
            this.guna2GroupBox1.Controls.Add(this.dgvTTchitietphieumuon);
            this.guna2GroupBox1.CustomBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.guna2GroupBox1.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.guna2GroupBox1.ForeColor = System.Drawing.Color.White;
            this.guna2GroupBox1.Location = new System.Drawing.Point(185, 74);
            this.guna2GroupBox1.Name = "guna2GroupBox1";
            this.guna2GroupBox1.Size = new System.Drawing.Size(787, 268);
            this.guna2GroupBox1.TabIndex = 8;
            this.guna2GroupBox1.Text = "Chi Tiết Phiếu Mượn";
            // 
            // ThongKe
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::QuanLyThietBiTrongTruongHoc.Properties.Resources.graphic_art_classroom_bathed_in_sunlight_k58f3l4vfs48pr6x;
            this.ClientSize = new System.Drawing.Size(984, 636);
            this.Controls.Add(this.guna2GroupBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.guna2GroupBox2);
            this.Controls.Add(this.btnthoatthongke);
            this.Controls.Add(this.btnquaylaithongke);
            this.Controls.Add(this.btnTaiLaiThongKe);
            this.Controls.Add(this.btnchitiephieusua);
            this.Controls.Add(this.btnchitetphieumuon);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "ThongKe";
            this.Text = "ThongKe";
            this.Load += new System.EventHandler(this.ThongKe_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvTTchitietphieumuon)).EndInit();
            this.guna2GroupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvchitietphieusua)).EndInit();
            this.guna2GroupBox1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.DataGridView dgvTTchitietphieumuon;
        private System.Windows.Forms.Label label1;
        private Guna.UI2.WinForms.Guna2GroupBox guna2GroupBox2;
        private System.Windows.Forms.DataGridView dgvchitietphieusua;
        private Guna.UI2.WinForms.Guna2Button btnthoatthongke;
        private Guna.UI2.WinForms.Guna2Button btnquaylaithongke;
        private Guna.UI2.WinForms.Guna2Button btnchitiephieusua;
        private Guna.UI2.WinForms.Guna2Button btnchitetphieumuon;
        private Guna.UI2.WinForms.Guna2Button btnTaiLaiThongKe;
        private Guna.UI2.WinForms.Guna2GroupBox guna2GroupBox1;
    }
}