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

    public partial class SinhVien : Form
    {
        string connectionString = "Data Source=DESKTOP-T28R5TF\\SQLEXPRESS;Initial Catalog=QUANLYTHIETBI;Integrated Security = True";

        public SinhVien()
        {
            InitializeComponent();
            HienThiDanhSachSinhVien();
            LoadMaKhoa();
            LoadMaNganh();
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
                        dgvTTSinhVien.DataSource = dataSet.Tables[0];
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi hiển thị thông tin sinh viên: " + ex.Message);
            }
        }

        private void btnCapNhatSinhVien_Click(object sender, EventArgs e)
        {
            try
            {
                string maSV = txtMaSinhVien.Text.Trim();
                string tenSV = txtTenSinhVien.Text.Trim();
                string maKhoa = cmbMaKhoa.SelectedValue?.ToString();
                string maNganh = cmbMaNganh.SelectedValue?.ToString();
                string gioiTinh = cmbGioiTinhSinhVien.SelectedItem?.ToString();
                DateTime ngaySinh = datetimeNgaySinh.Value;
                string email = txtEmailSinhVien.Text.Trim();
                string sdt = txtSDTSinhVien.Text.Trim();
                string diaChi = txtDiaChi.Text.Trim();

                
                if (string.IsNullOrEmpty(maSV) || string.IsNullOrEmpty(tenSV) || string.IsNullOrEmpty(maKhoa) || string.IsNullOrEmpty(maNganh))
                {
                    MessageBox.Show("Vui lòng nhập đầy đủ thông tin bắt buộc!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    string checkQuery = "SELECT COUNT(*) FROM SINHVIEN WHERE MASV = @MASV";
                    using (SqlCommand checkCommand = new SqlCommand(checkQuery, connection))
                    {
                        checkCommand.Parameters.AddWithValue("@MASV", maSV);
                        int count = (int)checkCommand.ExecuteScalar();
                        if (count > 0)
                        {
                            MessageBox.Show("Mã sinh viên đã tồn tại! Vui lòng nhập mã khác.");
                            return;
                        }
                    }

                    string query = "INSERT INTO SINHVIEN (MASV, TENSV, MANGANH, MAKHOA, EMAIL, SDT, NGAYSINH, DIACHI, GIOITINH) " +
                                   "VALUES (@MASV, @TENSV, @MANGANH, @MAKHOA, @EMAIL, @SDT, @NGAYSINH, @DIACHI, @GIOITINH)";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@MASV", maSV);
                        command.Parameters.AddWithValue("@TENSV", tenSV);
                        command.Parameters.AddWithValue("@MAKHOA", maKhoa);
                        command.Parameters.AddWithValue("@MANGANH", maNganh);
                        command.Parameters.AddWithValue("@GIOITINH", gioiTinh);
                        command.Parameters.AddWithValue("@NGAYSINH", ngaySinh);
                        command.Parameters.AddWithValue("@EMAIL", email);
                        command.Parameters.AddWithValue("@SDT", sdt);
                        command.Parameters.AddWithValue("@DIACHI", diaChi);
                        command.ExecuteNonQuery();
                    }
                    MessageBox.Show("Thêm dữ liệu thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    HienThiDanhSachSinhVien();
                    ClearFormSinhVien();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi thêm dữ liệu: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ClearFormSinhVien()
        {
            txtMaSinhVien.Text = "";
            txtTenSinhVien.Text = "";
            cmbMaKhoa.SelectedIndex = -1;
            cmbMaNganh.SelectedIndex = -1;
            txtEmailSinhVien.Text = "";
            txtSDTSinhVien.Text = "";
            txtDiaChi.Text = "";
            cmbGioiTinhSinhVien.SelectedIndex = -1;
            datetimeNgaySinh.Checked = false;
        }

        private void btnSuaTTSinhVien_Click(object sender, EventArgs e)
        {
            try
            {

                if (dgvTTSinhVien.SelectedRows.Count == 0)
                {
                    MessageBox.Show("Vui lòng chọn sinh viên cần sửa!");
                    return;
                }


                string maSV = dgvTTSinhVien.SelectedRows[0].Cells["MASV"].Value.ToString();
                string tenSV = txtTenSinhVien.Text.Trim();
                string maKhoa = cmbMaKhoa.SelectedValue?.ToString();
                string maNganh = cmbMaNganh.SelectedValue?.ToString();
                string gioiTinh = cmbGioiTinhSinhVien.SelectedItem?.ToString();
                DateTime ngaySinh = datetimeNgaySinh.Value;
                string email = txtEmailSinhVien.Text.Trim();
                string sdt = txtSDTSinhVien.Text.Trim();
                string diaChi = txtDiaChi.Text.Trim();
                if (string.IsNullOrEmpty(tenSV) || string.IsNullOrEmpty(maKhoa) || string.IsNullOrEmpty(maNganh))
                {
                    MessageBox.Show("Vui lòng nhập đầy đủ thông tin bắt buộc!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();



                    string query = "UPDATE SINHVIEN SET MASV = @MASV, TENSV = @TENSV, MANGANH = @MANGANH, MAKHOA = @MAKHOA, EMAIL = @EMAIL, SDT = @SDT, NGAYSINH = @NGAYSINH, DIACHI = @DIACHI, GIOITINH = @GIOITINH " +
                                   "WHERE MASV = @MASV";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@MASV", maSV);
                        command.Parameters.AddWithValue("@TENSV", tenSV);
                        command.Parameters.AddWithValue("@MAKHOA", maKhoa);
                        command.Parameters.AddWithValue("@MANGANH", maNganh);
                        command.Parameters.AddWithValue("@GIOITINH", gioiTinh);
                        command.Parameters.AddWithValue("@NGAYSINH", ngaySinh);
                        command.Parameters.AddWithValue("@EMAIL", email);
                        command.Parameters.AddWithValue("@SDT", sdt);
                        command.Parameters.AddWithValue("@DIACHI", diaChi);
                        command.ExecuteNonQuery();
                    }
                    MessageBox.Show("Sửa dữ liệu thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    HienThiDanhSachSinhVien();
                    ClearFormSinhVien();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi sửa dữ liệu: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnXoaTTSinhvien_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvTTSinhVien.SelectedRows.Count == 0)
                {
                    MessageBox.Show("Vui lòng chọn dòng khoa cần xóa!");
                    return;
                }

                string maSV = dgvTTSinhVien.SelectedRows[0].Cells["MASV"].Value.ToString();
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string query = "DELETE FROM SINHVIEN WHERE MASV = @MASV";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@MASV", maSV);
                        command.ExecuteNonQuery();
                    }
                }
                MessageBox.Show("Xóa dữ liệu thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                HienThiDanhSachSinhVien();
                ClearFormSinhVien();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi xóa dữ liệu: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnTimKiemTTSinhVien_Click(object sender, EventArgs e)
        {
            string tuKhoa = txtTimKiemTTSinhVien.Text.Trim();

            if (string.IsNullOrEmpty(tuKhoa))
            {
                MessageBox.Show("Vui lòng nhập từ khóa tìm kiếm!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string query = @"SELECT * FROM SINHVIEN 
                         WHERE MaSV LIKE @TuKhoa OR TenSV LIKE @TuKhoa";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@TuKhoa", "%" + tuKhoa + "%");

                    SqlDataAdapter adapter = new SqlDataAdapter(command);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);

                    dgvTTSinhVien.DataSource = dt;

                    if (dt.Rows.Count == 0)
                    {
                        MessageBox.Show("Không tìm thấy sinh viên phù hợp!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
        }

        private void btnTaiLaiTTSinhVien_Click(object sender, EventArgs e)
        {
            HienThiDanhSachSinhVien();
            ClearFormSinhVien();
            txtTimKiemTTSinhVien.Text = "";
        }

        private void btnQuayLaSinhVien_Click(object sender, EventArgs e)
        {
            this.Hide();
            CaiDat caiDat = new CaiDat();
            caiDat.ShowDialog();
        }

        private void LoadMaKhoa()
        {
            string query = "SELECT MaKhoa FROM Khoa";
            SqlDataAdapter da = new SqlDataAdapter(query, connectionString);
            DataTable dt = new DataTable();
            da.Fill(dt);

            cmbMaKhoa.DataSource = dt;
            cmbMaKhoa.DisplayMember = "MaKhoa";  // Hiển thị MaKhoa luôn
            cmbMaKhoa.ValueMember = "MaKhoa";
        }

        private void LoadMaNganh()
        {
            string query = "SELECT MaNganh FROM Nganh";
            SqlDataAdapter da = new SqlDataAdapter(query, connectionString);
            DataTable dt = new DataTable();
            da.Fill(dt);

            cmbMaNganh.DataSource = dt;
            cmbMaNganh.DisplayMember = "MaNganh";
            cmbMaNganh.ValueMember = "MaNganh";
        }

        private void dgvTTSinhVien_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvTTSinhVien.SelectedRows.Count == 0) return;

            DataGridViewRow row = dgvTTSinhVien.SelectedRows[0];

            txtMaSinhVien.Text = row.Cells["MASV"].Value?.ToString();
            txtTenSinhVien.Text = row.Cells["TENSV"].Value?.ToString();
            cmbMaKhoa.SelectedValue = row.Cells["MAKHOA"].Value?.ToString();
            cmbMaNganh.SelectedValue = row.Cells["MANGANH"].Value?.ToString();
            cmbGioiTinhSinhVien.SelectedItem = row.Cells["GIOITINH"].Value?.ToString();
            datetimeNgaySinh.Value = Convert.ToDateTime(row.Cells["NGAYSINH"].Value);
            txtEmailSinhVien.Text = row.Cells["EMAIL"].Value?.ToString();
            txtSDTSinhVien.Text = row.Cells["SDT"].Value?.ToString();
            txtDiaChi.Text = row.Cells["DIACHI"].Value?.ToString();

            
        }

        
    }
}
