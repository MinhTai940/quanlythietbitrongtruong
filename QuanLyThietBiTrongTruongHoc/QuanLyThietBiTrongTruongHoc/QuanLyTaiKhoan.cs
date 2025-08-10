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
    public partial class QuanLyTaiKhoan : Form
    {
        string connectionString = "Data Source=DESKTOP-T28R5TF\\SQLEXPRESS;Initial Catalog=QUANLYTHIETBI;Integrated Security = True";

        public QuanLyTaiKhoan()
        {
            InitializeComponent();
            HienThiDanhSachTaiKhoan();
        }

        private void HienThiDanhSachTaiKhoan()
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string query = "SELECT MATK, MATKHAU, LOAITK FROM TAIKHOAN";


                    using (SqlDataAdapter adapter = new SqlDataAdapter(query, connection))
                    {
                        DataSet dataSet = new DataSet();
                        adapter.Fill(dataSet);
                        dgvTTTaiKhoan.DataSource = dataSet.Tables[0];
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi hiển thị thông tin tài khoản: " + ex.Message);
            }
        }

        private void btnSuaTTTK_Click(object sender, EventArgs e)
        {
            try
            {

                if (dgvTTTaiKhoan.SelectedRows.Count == 0)
                {
                    MessageBox.Show("Vui lòng chọn tài khoản cần sửa!");
                    return;
                }


                string maTaiKhoan = dgvTTTaiKhoan.SelectedRows[0].Cells["MATK"].Value.ToString();
                string maKhau = txtMatKhau.Text;
                string loaiTK = comboBox1.SelectedItem?.ToString();
                if (string.IsNullOrEmpty(maKhau))
                {
                    MessageBox.Show("Vui lòng nhập đầy đủ thông tin bắt buộc!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();



                    string query = "UPDATE TAIKHOAN SET MATK = @MATK, MATKHAU = @MATKHAU, LOAITK = @LOAITK " +
                                   "WHERE MATK = @MATK";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@MATK", maTaiKhoan);
                        command.Parameters.AddWithValue("@MATKHAU", maKhau);
                        command.Parameters.AddWithValue("@LOAITK",loaiTK);
                        command.ExecuteNonQuery();
                    }
                    MessageBox.Show("Sửa dữ liệu thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    HienThiDanhSachTaiKhoan();
                    ClearFormTaiKhoan();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi sửa dữ liệu: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCapNhatTK_Click(object sender, EventArgs e)
        {
            try
            {
                string maTaiKhoan = txtMaTaiKhoan.Text;
                string matKhau = txtMatKhau.Text;
                string loaiTK = comboBox1.SelectedItem?.ToString();

                if (string.IsNullOrEmpty(maTaiKhoan) || string.IsNullOrEmpty(matKhau))
                {
                    MessageBox.Show("Vui lòng nhập đầy đủ thông tin bắt buộc!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    string checkQuery = "SELECT COUNT(*) FROM TAIKHOAN WHERE MATK = @MATK";
                    using (SqlCommand checkCommand = new SqlCommand(checkQuery, connection))
                    {
                        checkCommand.Parameters.AddWithValue("@MATK", maTaiKhoan);
                        int count = (int)checkCommand.ExecuteScalar();
                        if (count > 0)
                        {
                            MessageBox.Show("Mã tài khoản đã tồn tại! Vui lòng nhập mã khác.");
                            return;
                        }
                    }

                    string query = "INSERT INTO TAIKHOAN (MATK, MATKHAU, LOAITK) " +
                                   "VALUES (@MATK, @MATKHAU, @LOAITK)";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@MATK", maTaiKhoan);
                        command.Parameters.AddWithValue("@MATKHAU", matKhau);
                        command.Parameters.AddWithValue("@LOAITK",loaiTK);
                        command.ExecuteNonQuery();
                    }
                    MessageBox.Show("Thêm dữ liệu thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    HienThiDanhSachTaiKhoan();
                    ClearFormTaiKhoan();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi thêm dữ liệu: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ClearFormTaiKhoan()
        {
            txtMaTaiKhoan.Text = "";
            txtMatKhau.Text = "";
            comboBox1.SelectedIndex = -1;

        }

        private void btnXoaTTTK_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvTTTaiKhoan.SelectedRows.Count == 0)
                {
                    MessageBox.Show("Vui lòng chọn dòng khoa cần xóa!");
                    return;
                }

                string maTaiKhoan = dgvTTTaiKhoan.SelectedRows[0].Cells["MATK"].Value.ToString();
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string query = "DELETE FROM TAIKHOAN WHERE MATK = @MATK";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@MATK", maTaiKhoan);
                        command.ExecuteNonQuery();
                    }
                }
                MessageBox.Show("Xóa dữ liệu thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                HienThiDanhSachTaiKhoan();
                ClearFormTaiKhoan();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi xóa dữ liệu: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnQuayLaiTK_Click(object sender, EventArgs e)
        {
            this.Hide();
            CaiDat caiDat = new CaiDat();
            caiDat.ShowDialog();
        }
    }
}
