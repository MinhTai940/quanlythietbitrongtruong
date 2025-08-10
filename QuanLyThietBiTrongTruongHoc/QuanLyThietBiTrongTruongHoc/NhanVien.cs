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
    public partial class NhanVien : Form
    {
        string connectionString = "Data Source=DESKTOP-T28R5TF\\SQLEXPRESS;Initial Catalog=QUANLYTHIETBI;Integrated Security = True";
        public NhanVien()
        {
            InitializeComponent();
            HienThiDanhSachNhanVien();
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
                        dgvTTNhanVien.DataSource = dataSet.Tables[0];
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi hiển thị danh sách nhân viên: " + ex.Message);
            }
        }

        private void btnCapNhatNhanVien_Click(object sender, EventArgs e)
        {
            try
            {
                string maNhanVien = txtMaNhanVien.Text.Trim();
                string hoTen = txtTenNhanVien.Text.Trim();
                string email = txtEmail.Text.Trim();
                string diaChi = txtDiaChi.Text.Trim();
                DateTime ngaySinh = dateNgaySinhNhanVien.Value;
                string gioiTinh = cmbGioiTinhNhanVien.SelectedItem?.ToString();

                if (string.IsNullOrEmpty(maNhanVien) || string.IsNullOrEmpty(hoTen) || string.IsNullOrEmpty(email) || string.IsNullOrEmpty(diaChi))
                {
                    MessageBox.Show("Vui lòng nhập đầy đủ thông tin bắt buộc!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    string checkQuery = "SELECT COUNT(*) FROM NHANVIEN WHERE MANV = @MANV";
                    using (SqlCommand checkCommand = new SqlCommand(checkQuery, connection))
                    {
                        checkCommand.Parameters.AddWithValue("@MANV", maNhanVien);
                        int count = (int)checkCommand.ExecuteScalar();
                        if (count > 0)
                        {
                            MessageBox.Show("Mã nhân viên đã tồn tại! Vui lòng nhập mã khác.");
                            return;
                        }
                    }

                    string query = "INSERT INTO NHANVIEN (MANV, HOTEN, GIOITINH, NGAYSINH, EMAIL, DIACHI) " +
                                   "VALUES (@MANV, @HOTEN, @GIOITINH, @NGAYSINH, @EMAIL, @DIACHI)";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@MANV", maNhanVien);
                        command.Parameters.AddWithValue("@HOTEN", hoTen);
                        command.Parameters.AddWithValue("@GIOITINH", gioiTinh);
                        command.Parameters.AddWithValue("@NGAYSINH", ngaySinh);
                        command.Parameters.AddWithValue("@EMAIL", email);
                        command.Parameters.AddWithValue("@DIACHI", diaChi);
                        command.ExecuteNonQuery();
                    }
                    MessageBox.Show("Cập nhật dữ liệu thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    HienThiDanhSachNhanVien();
                    ClearFormNhanVien();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi cập nhật dữ liệu nhân viên: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ClearFormNhanVien()
        {
            txtMaNhanVien.Text = "";
            txtTenNhanVien.Text = "";
            txtEmail.Text = "";
            txtDiaChi.Text = "";
            cmbGioiTinhNhanVien.SelectedIndex = -1;
            dateNgaySinhNhanVien.Checked = false;
        }

        private void btnSuaTTNhanVien_Click(object sender, EventArgs e)
        {
            try
            {

                if (dgvTTNhanVien.SelectedRows.Count == 0)
                {
                    MessageBox.Show("Vui lòng chọn nhân viên cần sửa!");
                    return;
                }


                string maNhanVien = dgvTTNhanVien.SelectedRows[0].Cells["MANV"].Value.ToString();
                string hoTen = txtTenNhanVien.Text.Trim();
                string email = txtEmail.Text.Trim();
                string diaChi = txtDiaChi.Text.Trim();
                DateTime ngaySinh = dateNgaySinhNhanVien.Value;
                string gioiTinh = cmbGioiTinhNhanVien.SelectedItem?.ToString();

                if (string.IsNullOrEmpty(maNhanVien) || string.IsNullOrEmpty(hoTen) || string.IsNullOrEmpty(email) || string.IsNullOrEmpty(diaChi))
                {
                    MessageBox.Show("Vui lòng nhập đầy đủ thông tin bắt buộc!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();



                    string query = "UPDATE NHANVIEN SET MANV = @MANV, HOTEN = @HOTEN, NGAYSINH = @NGAYSINH, GIOITINH = @GIOITINH, EMAIL = @EMAIL, DIACHI = @DIACHI " +
                                   "WHERE MANV = @MANV";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@MANV", maNhanVien);
                        command.Parameters.AddWithValue("@HOTEN", hoTen);
                        command.Parameters.AddWithValue("@GIOITINH", gioiTinh);
                        command.Parameters.AddWithValue("@NGAYSINH", ngaySinh);
                        command.Parameters.AddWithValue("@EMAIL", email);
                        command.Parameters.AddWithValue("@DIACHI", diaChi);
                        command.ExecuteNonQuery();
                    }
                    MessageBox.Show("Sửa dữ liệu thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    HienThiDanhSachNhanVien();
                    ClearFormNhanVien();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi sửa dữ liệu nhân viên: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnXoaTTNhanvien_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvTTNhanVien.SelectedRows.Count == 0)
                {
                    MessageBox.Show("Vui lòng chọn nhân viên cần xóa!");
                    return;
                }

                string maNhanVien = dgvTTNhanVien.SelectedRows[0].Cells["MANV"].Value.ToString();
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string query = "DELETE FROM NHANVIEN WHERE MANV = @MANV";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@MANV", maNhanVien);
                        command.ExecuteNonQuery();
                    }
                }
                MessageBox.Show("Xóa dữ liệu thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                HienThiDanhSachNhanVien();
                ClearFormNhanVien();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi xóa dữ liệu: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnTimKiemNhanVien_Click(object sender, EventArgs e)
        {
            try
            {
                string maNhanVien = txtTimKiemTTNhanVien.Text.Trim();

                if (string.IsNullOrEmpty(maNhanVien))
                {
                    MessageBox.Show("Vui lòng nhập mã nhân viên để tìm kiếm!");
                    return;
                }

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string query = "SELECT dtb.MANV, dtb.HOTEN, dtb.GIOITINH, dtb.NGAYSINH, dtb.EMAIL, dtb.DIACHI  " +
                                   "FROM NHANVIEN dtb " +
                                   "WHERE dtb.MANV LIKE @MANV";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@MANV", "%" + maNhanVien + "%");

                        using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                        {
                            DataSet dataSet = new DataSet();
                            adapter.Fill(dataSet);
                            dgvTTNhanVien.DataSource = dataSet.Tables[0];
                        }
                    }
                }

                if (dgvTTNhanVien.Rows.Count == 0)
                {
                    MessageBox.Show("Không tìm thấy mã nhân viên bị" + maNhanVien + "'!");
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tìm kiếm dữ liệu dữ liệu: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnQuayLaiNhanVien_Click(object sender, EventArgs e)
        {
            this.Hide();
            CaiDat caiDat = new CaiDat();
            caiDat.ShowDialog();
        }

        private void btnTaiLaiTTNhanVien_Click(object sender, EventArgs e)
        {
            HienThiDanhSachNhanVien();
            ClearFormNhanVien();
            txtTimKiemTTNhanVien.Text = "";
        }

        private void dgvNhanVien_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvTTNhanVien.SelectedRows.Count == 0) return;

            DataGridViewRow row = dgvTTNhanVien.SelectedRows[0];

            txtMaNhanVien.Text = row.Cells["MANV"].Value?.ToString();
            txtTenNhanVien.Text = row.Cells["HOTEN"].Value?.ToString();
            cmbGioiTinhNhanVien.SelectedItem = row.Cells["GIOITINH"].Value?.ToString();

            if (DateTime.TryParse(row.Cells["NGAYSINH"].Value?.ToString(), out DateTime ngaySinh))
            {
                dateNgaySinhNhanVien.Value = ngaySinh;
            }

            txtEmail.Text = row.Cells["EMAIL"].Value?.ToString();
            txtDiaChi.Text = row.Cells["DIACHI"].Value?.ToString();
        }
    }
}
