using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyThietBiTrongTruongHoc
{
    public partial class CaiDat : Form
    {
        string connectionString = "Data Source=DESKTOP-T28R5TF\\SQLEXPRESS;Initial Catalog=QUANLYTHIETBI;Integrated Security = True";
        public CaiDat()
        {
            InitializeComponent();
            HienThiDanhSachNhanVien();
            HienThiDanhSachSinhVien();
            HienThiDanhSachPhongCoSo();
            HienThiDanhSachKhoa();
            HienThiDanhSachNganh();
        }

        private void CaiDat_Load(object sender, EventArgs e)
        {
            // Phân quyền cho form CaiDat
            if (Session.LoaiTaiKhoan.Trim().ToLower() == "nhân viên" || Session.LoaiTaiKhoan.Trim().ToLower() == "nhan vien")
            {
                // Ví dụ: Ẩn hoặc khóa các nút dành cho Admin
                btnkhoanganhcaidat.Enabled = false;
                btnnhanviencaidat.Enabled = false;
                btnphongcosocaidat.Enabled = true;
                btnTaiKhoan.Enabled = false;
                dgvnhanviencaidat.Visible = false;
                //txtSuaThongTin.ReadOnly = true;
                //cboCapDoQuyen.Enabled = false;

                MessageBox.Show("Bạn đang dùng tài khoản Nhân viên - một số chức năng bị hạn chế.",
                "Thông báo phân quyền",
                MessageBoxButtons.OK,
                MessageBoxIcon.Warning);
            }
            else if (Session.LoaiTaiKhoan.Trim().ToLower() == "admin")
            {
                // Admin được toàn quyền
                btnnhanviencaidat.Enabled = true;
                btnsinhviencaidat.Enabled = true;
                btnquaylaicaidat.Enabled = true;
                btnTaiLaiCaiDat.Enabled = true;
                btnkhoanganhcaidat.Enabled = true;
                btnphongcosocaidat.Enabled = true;
                btnThoatcaidat.Enabled = true;
                btnTaiKhoan.Enabled = true;
                MessageBox.Show("Tài khoản Admin – toàn quyền truy cập.",
                "Thông báo phân quyền",
                MessageBoxButtons.OK,
                MessageBoxIcon.Warning);
            }
        }

        private void btnnhanviencaidat_Click(object sender, EventArgs e)
        {
            this.Hide();
            NhanVien nhanVien = new NhanVien();
            nhanVien.ShowDialog();
        }

        private void btnsinhviencaidat_Click(object sender, EventArgs e)
        {
            this.Hide();
            SinhVien sinhVien = new SinhVien();
            sinhVien.ShowDialog();
        }

        private void btnkhoanganhcaidat_Click(object sender, EventArgs e)
        {
            this.Hide();
            Khoa khoa = new Khoa();
            khoa.ShowDialog();
        }

        private void btnphongcosocaidat_Click(object sender, EventArgs e)
        {
            this.Hide();
            Phong phong = new Phong();
            phong.ShowDialog();
        }

        private void btnTaiLaiCaiDat_Click(object sender, EventArgs e)
        {
            HienThiDanhSachNhanVien();
            HienThiDanhSachSinhVien();
            HienThiDanhSachPhongCoSo();
            HienThiDanhSachKhoa();
            HienThiDanhSachNganh();
        }

        private void btnquaylaicaidat_Click(object sender, EventArgs e)
        {
            this.Hide();
            TrangChu trangChu = new TrangChu();
            trangChu.ShowDialog();
        }

        private void btnThoatcaidat_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn thoát?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void HienThiDanhSachNhanVien()
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string query = "SELECT * FROM NHANVIEN";
                    using (SqlDataAdapter adapter = new SqlDataAdapter(query, connection))
                    {
                        DataSet dataSet = new DataSet();
                        adapter.Fill(dataSet);
                        dgvnhanviencaidat.DataSource = dataSet.Tables[0];
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi hiển thị danh sách nhân viên: " + ex.Message);
            }
        }

        private void HienThiDanhSachSinhVien()
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string query = "SELECT * FROM SINHVIEN";
                    using (SqlDataAdapter adapter = new SqlDataAdapter(query, connection))
                    {
                        DataSet dataSet = new DataSet();
                        adapter.Fill(dataSet);
                        dgvsinhviencaidat.DataSource = dataSet.Tables[0];
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi hiển thị danh sách sinh viên: " + ex.Message);
            }
        }

        private void HienThiDanhSachPhongCoSo()
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string query = "SELECT * FROM PHONG";


                    using (SqlDataAdapter adapter = new SqlDataAdapter(query, connection))
                    {
                        DataSet dataSet = new DataSet();
                        adapter.Fill(dataSet);
                        dgvphongcosocaidat.DataSource = dataSet.Tables[0];
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi hiển thị danh sách phòng cơ sở: " + ex.Message);
            }
        }

        private void HienThiDanhSachKhoa()
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string query = "SELECT * FROM KHOA";


                    using (SqlDataAdapter adapter = new SqlDataAdapter(query, connection))
                    {
                        DataSet dataSet = new DataSet();
                        adapter.Fill(dataSet);
                        dgvkhoacaidat.DataSource = dataSet.Tables[0];
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi hiển thị danh sách khoa: " + ex.Message);
            }
        }

        private void HienThiDanhSachNganh()
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string query = "SELECT * FROM Nganh";


                    using (SqlDataAdapter adapter = new SqlDataAdapter(query, connection))
                    {
                        DataSet dataSet = new DataSet();
                        adapter.Fill(dataSet);
                        dgvTTnganhcaidat.DataSource = dataSet.Tables[0];
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi hiển thị danh sách ngành: " + ex.Message);
            }
        }

        private void btnTaiKhoan_Click(object sender, EventArgs e)
        {
            this.Hide();
            QuanLyTaiKhoan quanLyTaiKhoan = new QuanLyTaiKhoan();
            quanLyTaiKhoan.ShowDialog();
        }
    }
}
