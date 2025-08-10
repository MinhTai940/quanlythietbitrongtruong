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
    public partial class Khoa : Form
    {
        string connectionString = "Data Source=DESKTOP-T28R5TF\\SQLEXPRESS;Initial Catalog=QUANLYTHIETBI;Integrated Security = True";
        public Khoa()
        {
            InitializeComponent();
            HienThiDanhSachKhoa();
            HienThiDanhSachNganh();
        }

        private void btnQuayLaiKhoa_Click(object sender, EventArgs e)
        {
            this.Hide();
            CaiDat caiDat = new CaiDat();
            caiDat.ShowDialog();
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
                        dgvTTKhoa.DataSource = dataSet.Tables[0];
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
                    string query = "SELECT * FROM NGANH";


                    using (SqlDataAdapter adapter = new SqlDataAdapter(query, connection))
                    {
                        DataSet dataSet = new DataSet();
                        adapter.Fill(dataSet);
                        dgvTTNganh.DataSource = dataSet.Tables[0];
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi hiển thị danh sách ngành: " + ex.Message);
            }
        }

        private void btnCapNhatKhoa_Click(object sender, EventArgs e)
        {
            try
            {
                string maKhoa = txtMaKhoa.Text;
                string tenKhoa = txtTenKhoa.Text;
                
                if (string.IsNullOrEmpty(maKhoa) || string.IsNullOrEmpty(tenKhoa))
                {
                    MessageBox.Show("Vui lòng nhập đầy đủ thông tin bắt buộc!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    string checkQuery = "SELECT COUNT(*) FROM KHOA WHERE MaKhoa = @MaKhoa";
                    using (SqlCommand checkCommand = new SqlCommand(checkQuery, connection))
                    {
                        checkCommand.Parameters.AddWithValue("@MaKhoa", maKhoa);
                        int count = (int)checkCommand.ExecuteScalar();
                        if (count > 0)
                        {
                            MessageBox.Show("Mã khoa đã tồn tại! Vui lòng nhập mã khác.");
                            return;
                        }
                    }

                    string query = "INSERT INTO KHOA (MaKhoa, TenKhoa) " +
                                   "VALUES (@MaKhoa, @TenKhoa)";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@MaKhoa", maKhoa);
                        command.Parameters.AddWithValue("@TenKhoa", tenKhoa);
                        command.ExecuteNonQuery();
                    }
                    MessageBox.Show("Thêm dữ liệu thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    HienThiDanhSachKhoa();
                    ClearFormKhoa();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi thêm dữ liệu: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }

            try
            {
                string maNganh = txtMaNganh.Text;
                string tenNganh = txtTenNganh.Text;

                if (string.IsNullOrEmpty(maNganh) || string.IsNullOrEmpty(tenNganh))
                {
                    MessageBox.Show("Vui lòng nhập đầy đủ thông tin bắt buộc!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    string checkQuery = "SELECT COUNT(*) FROM NGANH WHERE MaNganh = @MaNganh";
                    using (SqlCommand checkCommand = new SqlCommand(checkQuery, connection))
                    {
                        checkCommand.Parameters.AddWithValue("@MaNganh", maNganh);
                        int count = (int)checkCommand.ExecuteScalar();
                        if (count > 0)
                        {
                            MessageBox.Show("Mã ngành đã tồn tại! Vui lòng nhập mã khác.");
                            return;
                        }
                    }

                    string query = "INSERT INTO NGANH (MaNganh, TenNganh) " +
                                   "VALUES (@MaNganh, @TenNganh)";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@MaNganh", maNganh);
                        command.Parameters.AddWithValue("@TenNganh", tenNganh);
                        command.ExecuteNonQuery();
                    }
                    MessageBox.Show("Thêm dữ liệu thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    HienThiDanhSachNganh();
                    ClearFormNganh();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi thêm dữ liệu: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ClearFormNganh()
        {
            txtMaNganh.Text = "";
            txtTenNganh.Text = "";
        }

        private void ClearFormKhoa()
        {
            txtMaKhoa.Text = "";
            txtTenKhoa.Text = "";
        }

        private void btnSuaThongTinKhoa_Click(object sender, EventArgs e)
        {
            try
            {

                if (dgvTTKhoa.SelectedRows.Count == 0)
                {
                    MessageBox.Show("Vui lòng chọn dòng khoa cần sửa!");
                    return;
                }


                string maKhoa = dgvTTKhoa.SelectedRows[0].Cells["MaKhoa"].Value.ToString();
                string tenKhoa = txtTenKhoa.Text;

                if (string.IsNullOrEmpty(tenKhoa))
                {
                    MessageBox.Show("Vui lòng nhập đầy đủ thông tin bắt buộc!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();



                    string query = "UPDATE KHOA SET MaKhoa = @MaKhoa, TenKhoa = @TenKhoa " +
                                   "WHERE MaKhoa = @MaKhoa";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@MaKhoa", maKhoa);
                        command.Parameters.AddWithValue("@TenKhoa", tenKhoa);
                        command.ExecuteNonQuery();
                    }
                    MessageBox.Show("Sửa dữ liệu thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    HienThiDanhSachKhoa();
                    ClearFormKhoa();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi sửa dữ liệu: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSuaTTNganh_Click(object sender, EventArgs e)
        {
            try
            {

                if (dgvTTNganh.SelectedRows.Count == 0)
                {
                    MessageBox.Show("Vui lòng chọn dòng ngành cần sửa!");
                    return;
                }


                string maNganh = dgvTTNganh.SelectedRows[0].Cells["MaNganh"].Value.ToString();
                string tenNganh = txtTenNganh.Text;

                if (string.IsNullOrEmpty(tenNganh))
                {
                    MessageBox.Show("Vui lòng nhập đầy đủ thông tin bắt buộc!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();



                    string query = "UPDATE NGANH SET MaNganh = @MaNganh, TenNganh = @TenNganh " +
                                   "WHERE MaNganh = @MaNganh";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@MaNganh", maNganh);
                        command.Parameters.AddWithValue("@TenNganh", tenNganh);
                        command.ExecuteNonQuery();
                    }
                    MessageBox.Show("Sửa dữ liệu thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    HienThiDanhSachNganh();
                    ClearFormNganh();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi sửa dữ liệu: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void btnXoaThongTinKhoa_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvTTKhoa.SelectedRows.Count == 0)
                {
                    MessageBox.Show("Vui lòng chọn dòng khoa cần xóa!");
                    return;
                }

                string maKhoa = dgvTTKhoa.SelectedRows[0].Cells["MaKhoa"].Value.ToString();
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string query = "DELETE FROM KHOA WHERE MaKhoa = @MaKhoa";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@MaKhoa", maKhoa);
                        command.ExecuteNonQuery();
                    }
                }
                MessageBox.Show("Xóa dữ liệu thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                HienThiDanhSachKhoa();
                ClearFormKhoa();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi xóa dữ liệu: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnXoaTTNganh_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvTTNganh.SelectedRows.Count == 0)
                {
                    MessageBox.Show("Vui lòng chọn dòng ngành cần xóa!");
                    return;
                }

                string maNganh = dgvTTNganh.SelectedRows[0].Cells["MaNganh"].Value.ToString();
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string query = "DELETE FROM NGANH WHERE MaNganh = @MaNganh";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@MaNganh", maNganh);
                        command.ExecuteNonQuery();
                    }
                }
                MessageBox.Show("Xóa dữ liệu thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                HienThiDanhSachNganh();
                ClearFormNganh();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi xóa dữ liệu: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnTimKiemKhoaNganh_Click(object sender, EventArgs e)
        {
            string tuKhoa = txtTimKiemKhoaNganh.Text.Trim();

            if (string.IsNullOrEmpty(tuKhoa))
            {
                HienThiDanhSachKhoa();
                HienThiDanhSachNganh();
                return;
            }

            TimKiemKhoa(tuKhoa);
            TimKiemNganh(tuKhoa);
        }

        private void TimKiemKhoa(string tuKhoa)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string query = "SELECT * FROM KHOA WHERE MaKhoa LIKE @TuKhoa OR TenKhoa LIKE @TuKhoa";
                    using (SqlDataAdapter adapter = new SqlDataAdapter(query, connection))
                    {
                        adapter.SelectCommand.Parameters.AddWithValue("@TuKhoa", "%" + tuKhoa + "%");
                        DataSet dataSet = new DataSet();
                        adapter.Fill(dataSet);
                        dgvTTKhoa.DataSource = dataSet.Tables[0];
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tìm kiếm khoa: " + ex.Message);
            }
        }

        private void TimKiemNganh(string tuKhoa)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string query = "SELECT * FROM NGANH WHERE MaNganh LIKE @TuKhoa OR TenNganh LIKE @TuKhoa";
                    using (SqlDataAdapter adapter = new SqlDataAdapter(query, connection))
                    {
                        adapter.SelectCommand.Parameters.AddWithValue("@TuKhoa", "%" + tuKhoa + "%");
                        DataSet dataSet = new DataSet();
                        adapter.Fill(dataSet);
                        dgvTTNganh.DataSource = dataSet.Tables[0];
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tìm kiếm ngành: " + ex.Message);
            }
        }

        private void btnTaiLaiTTKhoaNganh_Click(object sender, EventArgs e)
        {
            // Hiển thị lại danh sách Khoa và Ngành
            HienThiDanhSachKhoa();
            HienThiDanhSachNganh();

            // Xóa nội dung các TextBox nhập liệu
            ClearFormKhoa();
            ClearFormNganh();

            // Xóa nội dung tìm kiếm nếu có
            txtTimKiemKhoaNganh.Text = "";
        }

        private void dgvTTKhoa_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvTTKhoa.SelectedRows.Count == 0) return;

            DataGridViewRow row = dgvTTKhoa.SelectedRows[0];

            txtMaKhoa.Text = row.Cells["MAKHOA"].Value?.ToString();
            txtTenKhoa.Text = row.Cells["TENKHOA"].Value?.ToString();

            
        }
        private void dgvTTNganh_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvTTNganh.SelectedRows.Count == 0) return;

            DataGridViewRow row = dgvTTNganh.SelectedRows[0];

            txtMaNganh.Text = row.Cells["MANGANH"].Value?.ToString();
            txtTenNganh.Text = row.Cells["TENNGANH"].Value?.ToString();

            
        }

    }
}
