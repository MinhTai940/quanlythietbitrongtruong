namespace QuanLyThietBiTrongTruongHoc
{
    partial class NhanVien
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(NhanVien));
            this.txtTimKiemTTNhanVien = new System.Windows.Forms.TextBox();
            this.dgvTTNhanVien = new System.Windows.Forms.DataGridView();
            this.label5 = new System.Windows.Forms.Label();
            this.btnCapNhatNhanVien = new Guna.UI2.WinForms.Guna2Button();
            this.txtDiaChi = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnTimKiemNhanVien = new Guna.UI2.WinForms.Guna2ImageButton();
            this.dateNgaySinhNhanVien = new System.Windows.Forms.DateTimePicker();
            this.label4 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btnXoaTTNhanvien = new Guna.UI2.WinForms.Guna2Button();
            this.btnSuaTTNhanVien = new Guna.UI2.WinForms.Guna2Button();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.txtMaNhanVien = new System.Windows.Forms.TextBox();
            this.btnQuayLaiNhanVien = new Guna.UI2.WinForms.Guna2Button();
            this.txtTenNhanVien = new System.Windows.Forms.TextBox();
            this.guna2GroupBox1 = new Guna.UI2.WinForms.Guna2GroupBox();
            this.cmbGioiTinhNhanVien = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.btnTaiLaiTTNhanVien = new Guna.UI2.WinForms.Guna2Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTTNhanVien)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.guna2GroupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtTimKiemTTNhanVien
            // 
            this.txtTimKiemTTNhanVien.Location = new System.Drawing.Point(15, 56);
            this.txtTimKiemTTNhanVien.Multiline = true;
            this.txtTimKiemTTNhanVien.Name = "txtTimKiemTTNhanVien";
            this.txtTimKiemTTNhanVien.Size = new System.Drawing.Size(244, 39);
            this.txtTimKiemTTNhanVien.TabIndex = 0;
            // 
            // dgvTTNhanVien
            // 
            this.dgvTTNhanVien.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTTNhanVien.Location = new System.Drawing.Point(447, 77);
            this.dgvTTNhanVien.Name = "dgvTTNhanVien";
            this.dgvTTNhanVien.RowHeadersWidth = 51;
            this.dgvTTNhanVien.RowTemplate.Height = 24;
            this.dgvTTNhanVien.Size = new System.Drawing.Size(485, 501);
            this.dgvTTNhanVien.TabIndex = 0;
            this.dgvTTNhanVien.SelectionChanged += new System.EventHandler(this.dgvNhanVien_SelectionChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.ForeColor = System.Drawing.Color.Black;
            this.label5.Location = new System.Drawing.Point(12, 285);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(60, 19);
            this.label5.TabIndex = 0;
            this.label5.Text = "Email:";
            // 
            // btnCapNhatNhanVien
            // 
            this.btnCapNhatNhanVien.BorderRadius = 15;
            this.btnCapNhatNhanVien.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnCapNhatNhanVien.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnCapNhatNhanVien.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnCapNhatNhanVien.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnCapNhatNhanVien.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.btnCapNhatNhanVien.ForeColor = System.Drawing.Color.White;
            this.btnCapNhatNhanVien.Image = global::QuanLyThietBiTrongTruongHoc.Properties.Resources.capnhat;
            this.btnCapNhatNhanVien.Location = new System.Drawing.Point(11, 675);
            this.btnCapNhatNhanVien.Name = "btnCapNhatNhanVien";
            this.btnCapNhatNhanVien.Size = new System.Drawing.Size(180, 61);
            this.btnCapNhatNhanVien.TabIndex = 5;
            this.btnCapNhatNhanVien.Text = "Cập Nhật";
            this.btnCapNhatNhanVien.Click += new System.EventHandler(this.btnCapNhatNhanVien_Click);
            // 
            // txtDiaChi
            // 
            this.txtDiaChi.Location = new System.Drawing.Point(172, 341);
            this.txtDiaChi.Multiline = true;
            this.txtDiaChi.Name = "txtDiaChi";
            this.txtDiaChi.Size = new System.Drawing.Size(231, 68);
            this.txtDiaChi.TabIndex = 1;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.ForeColor = System.Drawing.Color.Black;
            this.label6.Location = new System.Drawing.Point(12, 349);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(72, 19);
            this.label6.TabIndex = 0;
            this.label6.Text = "Địa Chỉ:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(12, 73);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(118, 19);
            this.label1.TabIndex = 0;
            this.label1.Text = "Mã Nhân Viên:";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnTimKiemNhanVien);
            this.groupBox1.Controls.Add(this.txtTimKiemTTNhanVien);
            this.groupBox1.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.groupBox1.Location = new System.Drawing.Point(586, 601);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(346, 117);
            this.groupBox1.TabIndex = 9;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Tìm Kiếm";
            // 
            // btnTimKiemNhanVien
            // 
            this.btnTimKiemNhanVien.CheckedState.ImageSize = new System.Drawing.Size(64, 64);
            this.btnTimKiemNhanVien.HoverState.ImageSize = new System.Drawing.Size(64, 64);
            this.btnTimKiemNhanVien.Image = ((System.Drawing.Image)(resources.GetObject("btnTimKiemNhanVien.Image")));
            this.btnTimKiemNhanVien.ImageOffset = new System.Drawing.Point(0, 0);
            this.btnTimKiemNhanVien.ImageRotate = 0F;
            this.btnTimKiemNhanVien.Location = new System.Drawing.Point(256, 48);
            this.btnTimKiemNhanVien.Name = "btnTimKiemNhanVien";
            this.btnTimKiemNhanVien.PressedState.ImageSize = new System.Drawing.Size(64, 64);
            this.btnTimKiemNhanVien.Size = new System.Drawing.Size(64, 54);
            this.btnTimKiemNhanVien.TabIndex = 1;
            this.btnTimKiemNhanVien.Click += new System.EventHandler(this.btnTimKiemNhanVien_Click);
            // 
            // dateNgaySinhNhanVien
            // 
            this.dateNgaySinhNhanVien.Location = new System.Drawing.Point(172, 220);
            this.dateNgaySinhNhanVien.Name = "dateNgaySinhNhanVien";
            this.dateNgaySinhNhanVien.Size = new System.Drawing.Size(243, 27);
            this.dateNgaySinhNhanVien.TabIndex = 2;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.ForeColor = System.Drawing.Color.Black;
            this.label4.Location = new System.Drawing.Point(12, 220);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(89, 19);
            this.label4.TabIndex = 0;
            this.label4.Text = "Ngày Sinh:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(12, 146);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(121, 19);
            this.label2.TabIndex = 0;
            this.label2.Text = "Tên Nhân Viên:";
            // 
            // btnXoaTTNhanvien
            // 
            this.btnXoaTTNhanvien.BorderRadius = 15;
            this.btnXoaTTNhanvien.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnXoaTTNhanvien.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnXoaTTNhanvien.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnXoaTTNhanvien.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnXoaTTNhanvien.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.btnXoaTTNhanvien.ForeColor = System.Drawing.Color.White;
            this.btnXoaTTNhanvien.Image = global::QuanLyThietBiTrongTruongHoc.Properties.Resources.xoa;
            this.btnXoaTTNhanvien.Location = new System.Drawing.Point(197, 601);
            this.btnXoaTTNhanvien.Name = "btnXoaTTNhanvien";
            this.btnXoaTTNhanvien.Size = new System.Drawing.Size(180, 61);
            this.btnXoaTTNhanvien.TabIndex = 6;
            this.btnXoaTTNhanvien.Text = "Xóa Thông Tin";
            this.btnXoaTTNhanvien.Click += new System.EventHandler(this.btnXoaTTNhanvien_Click);
            // 
            // btnSuaTTNhanVien
            // 
            this.btnSuaTTNhanVien.BorderRadius = 15;
            this.btnSuaTTNhanVien.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnSuaTTNhanVien.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnSuaTTNhanVien.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnSuaTTNhanVien.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnSuaTTNhanVien.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.btnSuaTTNhanVien.ForeColor = System.Drawing.Color.White;
            this.btnSuaTTNhanVien.Image = global::QuanLyThietBiTrongTruongHoc.Properties.Resources.sửa;
            this.btnSuaTTNhanVien.Location = new System.Drawing.Point(11, 601);
            this.btnSuaTTNhanVien.Name = "btnSuaTTNhanVien";
            this.btnSuaTTNhanVien.Size = new System.Drawing.Size(180, 61);
            this.btnSuaTTNhanVien.TabIndex = 7;
            this.btnSuaTTNhanVien.Text = "Sửa Thông Tin";
            this.btnSuaTTNhanVien.Click += new System.EventHandler(this.btnSuaTTNhanVien_Click);
            // 
            // txtEmail
            // 
            this.txtEmail.Location = new System.Drawing.Point(172, 277);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(231, 27);
            this.txtEmail.TabIndex = 1;
            // 
            // txtMaNhanVien
            // 
            this.txtMaNhanVien.Location = new System.Drawing.Point(172, 73);
            this.txtMaNhanVien.Name = "txtMaNhanVien";
            this.txtMaNhanVien.Size = new System.Drawing.Size(231, 27);
            this.txtMaNhanVien.TabIndex = 1;
            // 
            // btnQuayLaiNhanVien
            // 
            this.btnQuayLaiNhanVien.BorderRadius = 15;
            this.btnQuayLaiNhanVien.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnQuayLaiNhanVien.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnQuayLaiNhanVien.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnQuayLaiNhanVien.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnQuayLaiNhanVien.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.btnQuayLaiNhanVien.ForeColor = System.Drawing.Color.White;
            this.btnQuayLaiNhanVien.Image = global::QuanLyThietBiTrongTruongHoc.Properties.Resources.quaylai;
            this.btnQuayLaiNhanVien.Location = new System.Drawing.Point(197, 668);
            this.btnQuayLaiNhanVien.Name = "btnQuayLaiNhanVien";
            this.btnQuayLaiNhanVien.Size = new System.Drawing.Size(180, 61);
            this.btnQuayLaiNhanVien.TabIndex = 8;
            this.btnQuayLaiNhanVien.Text = "Quay Lại";
            this.btnQuayLaiNhanVien.Click += new System.EventHandler(this.btnQuayLaiNhanVien_Click);
            // 
            // txtTenNhanVien
            // 
            this.txtTenNhanVien.Location = new System.Drawing.Point(172, 143);
            this.txtTenNhanVien.Name = "txtTenNhanVien";
            this.txtTenNhanVien.Size = new System.Drawing.Size(231, 27);
            this.txtTenNhanVien.TabIndex = 1;
            // 
            // guna2GroupBox1
            // 
            this.guna2GroupBox1.Controls.Add(this.cmbGioiTinhNhanVien);
            this.guna2GroupBox1.Controls.Add(this.dateNgaySinhNhanVien);
            this.guna2GroupBox1.Controls.Add(this.txtDiaChi);
            this.guna2GroupBox1.Controls.Add(this.txtEmail);
            this.guna2GroupBox1.Controls.Add(this.txtTenNhanVien);
            this.guna2GroupBox1.Controls.Add(this.txtMaNhanVien);
            this.guna2GroupBox1.Controls.Add(this.label8);
            this.guna2GroupBox1.Controls.Add(this.label6);
            this.guna2GroupBox1.Controls.Add(this.label5);
            this.guna2GroupBox1.Controls.Add(this.label4);
            this.guna2GroupBox1.Controls.Add(this.label2);
            this.guna2GroupBox1.Controls.Add(this.label1);
            this.guna2GroupBox1.CustomBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.guna2GroupBox1.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.guna2GroupBox1.ForeColor = System.Drawing.Color.White;
            this.guna2GroupBox1.Location = new System.Drawing.Point(11, 77);
            this.guna2GroupBox1.Name = "guna2GroupBox1";
            this.guna2GroupBox1.Size = new System.Drawing.Size(430, 501);
            this.guna2GroupBox1.TabIndex = 4;
            this.guna2GroupBox1.Text = "Thông Tin Nhân Viên";
            // 
            // cmbGioiTinhNhanVien
            // 
            this.cmbGioiTinhNhanVien.FormattingEnabled = true;
            this.cmbGioiTinhNhanVien.Items.AddRange(new object[] {
            "Nam",
            "Nữ"});
            this.cmbGioiTinhNhanVien.Location = new System.Drawing.Point(173, 434);
            this.cmbGioiTinhNhanVien.Name = "cmbGioiTinhNhanVien";
            this.cmbGioiTinhNhanVien.Size = new System.Drawing.Size(230, 27);
            this.cmbGioiTinhNhanVien.TabIndex = 3;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.ForeColor = System.Drawing.Color.Black;
            this.label8.Location = new System.Drawing.Point(12, 434);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(88, 19);
            this.label8.TabIndex = 0;
            this.label8.Text = "Giới Tính:";
            // 
            // label7
            // 
            this.label7.Font = new System.Drawing.Font("Times New Roman", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label7.Location = new System.Drawing.Point(231, 9);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(383, 44);
            this.label7.TabIndex = 15;
            this.label7.Text = "Quản Lý Nhân Viên";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnTaiLaiTTNhanVien
            // 
            this.btnTaiLaiTTNhanVien.BorderRadius = 15;
            this.btnTaiLaiTTNhanVien.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnTaiLaiTTNhanVien.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnTaiLaiTTNhanVien.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnTaiLaiTTNhanVien.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnTaiLaiTTNhanVien.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.btnTaiLaiTTNhanVien.ForeColor = System.Drawing.Color.White;
            this.btnTaiLaiTTNhanVien.Image = global::QuanLyThietBiTrongTruongHoc.Properties.Resources.tailai;
            this.btnTaiLaiTTNhanVien.Location = new System.Drawing.Point(383, 601);
            this.btnTaiLaiTTNhanVien.Name = "btnTaiLaiTTNhanVien";
            this.btnTaiLaiTTNhanVien.Size = new System.Drawing.Size(180, 61);
            this.btnTaiLaiTTNhanVien.TabIndex = 8;
            this.btnTaiLaiTTNhanVien.Text = "Tải Lại";
            this.btnTaiLaiTTNhanVien.Click += new System.EventHandler(this.btnTaiLaiTTNhanVien_Click);
            // 
            // NhanVien
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(944, 740);
            this.Controls.Add(this.dgvTTNhanVien);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.btnCapNhatNhanVien);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnXoaTTNhanvien);
            this.Controls.Add(this.btnSuaTTNhanVien);
            this.Controls.Add(this.btnTaiLaiTTNhanVien);
            this.Controls.Add(this.btnQuayLaiNhanVien);
            this.Controls.Add(this.guna2GroupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "NhanVien";
            this.Text = "NhanVien";
            ((System.ComponentModel.ISupportInitialize)(this.dgvTTNhanVien)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.guna2GroupBox1.ResumeLayout(false);
            this.guna2GroupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox txtTimKiemTTNhanVien;
        private System.Windows.Forms.DataGridView dgvTTNhanVien;
        private System.Windows.Forms.Label label5;
        private Guna.UI2.WinForms.Guna2Button btnCapNhatNhanVien;
        private System.Windows.Forms.TextBox txtDiaChi;
        private Guna.UI2.WinForms.Guna2ImageButton btnTimKiemNhanVien;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DateTimePicker dateNgaySinhNhanVien;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label2;
        private Guna.UI2.WinForms.Guna2Button btnXoaTTNhanvien;
        private Guna.UI2.WinForms.Guna2Button btnSuaTTNhanVien;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.TextBox txtMaNhanVien;
        private Guna.UI2.WinForms.Guna2Button btnQuayLaiNhanVien;
        private System.Windows.Forms.TextBox txtTenNhanVien;
        private Guna.UI2.WinForms.Guna2GroupBox guna2GroupBox1;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox cmbGioiTinhNhanVien;
        private System.Windows.Forms.Label label8;
        private Guna.UI2.WinForms.Guna2Button btnTaiLaiTTNhanVien;
    }
}