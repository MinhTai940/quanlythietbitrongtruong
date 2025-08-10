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
   
    public partial class DangNhap : Form
    {
        private string connectionString = "Data Source=DESKTOP-T28R5TF\\SQLEXPRESS;Initial Catalog=QUANLYTHIETBI;Integrated Security = True";
        public DangNhap()
        {
            InitializeComponent();
        }

        private void btnDangNhap_Click(object sender, EventArgs e)
        {
            string username = txtTK.Text.Trim();
            string password = txtPasss.Text.Trim();

            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ tài khoản và mật khẩu!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    string query = "SELECT LOAITK FROM TAIKHOAN WHERE MATK = @MATK AND MATKHAU = @MATKHAU";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@MATK", username);
                    cmd.Parameters.AddWithValue("@MATKHAU", password);

                    var result = cmd.ExecuteScalar();

                    if (result != null)
                    {
                        // Lưu thông tin vào Session
                        Session.TenDangNhap = username;
                        Session.LoaiTaiKhoan = result.ToString();

                        MessageBox.Show("Đăng nhập thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.Hide();
                        TrangChu frm = new TrangChu();
                        frm.ShowDialog();
                    }
                    else
                    {
                        MessageBox.Show("Tài khoản hoặc mật khẩu không đúng.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi kết nối: " + ex.Message);
            }
        }

        //public static string LoaiTaiKhoan = ""; // lưu quyền đăng nhập

        //private bool AuthenticateUser(string username, string password)
        //{
        //    try
        //    {
        //        using (SqlConnection conn = new SqlConnection(connectionString))
        //        {
        //            conn.Open();
        //            string query = "SELECT LOAITK FROM TAIKHOAN WHERE MATK = @MATK AND MATKHAU = @MATKHAU";
        //            using (SqlCommand cmd = new SqlCommand(query, conn))
        //            {
        //                cmd.Parameters.AddWithValue("@MATK", username);
        //                cmd.Parameters.AddWithValue("@MATKHAU", password); // chưa mã hóa

        //                SqlDataReader reader = cmd.ExecuteReader();
        //                if (reader.Read())
        //                {
        //                    LoaiTaiKhoan = reader["LOAITK"].ToString();
        //                    return true;
        //                }
        //                else
        //                {
        //                    return false;
        //                }
        //            }
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show("Error: " + ex.Message);
        //        return false;
        //    }
        //}


        private void btnthoatdangnhap_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn thoát?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void btntailaidangnhap_Click(object sender, EventArgs e)
        {
            // Clear the username and password fields to "reload" the form
            txtTK.Text = string.Empty;
            txtPasss.Text = string.Empty;
            txtTK.Focus(); // Set focus to the username field
        }

        
    }
}
