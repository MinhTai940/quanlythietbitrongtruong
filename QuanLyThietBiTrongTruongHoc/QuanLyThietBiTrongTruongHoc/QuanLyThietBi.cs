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
    public partial class QuanLyThietBi : Form
    {
        string connectionString = "Data Source=DESKTOP-T28R5TF\\SQLEXPRESS;Initial Catalog=QUANLYTHIETBI;Integrated Security = True";
        public QuanLyThietBi()
        {
            InitializeComponent();
            HienThiDanhSachThietBi();
            LoadMaPhong();
            LoadMaDongThietBi();
            
        }

        private void HienThiDanhSachThietBi()
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string query = "SELECT * FROM THIETBI";


                    using (SqlDataAdapter adapter = new SqlDataAdapter(query, connection))
                    {
                        DataSet dataSet = new DataSet();
                        adapter.Fill(dataSet);
                        dgvTTThietBi.DataSource = dataSet.Tables[0];
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi hiển thị thông tin thiết bị: " + ex.Message);
            }
        }

        private void btnCapNhatTB_Click(object sender, EventArgs e)
        {
            try
            {
                string maThietBi = txtMaThietBi.Text;
                string seri = txtSeri.Text;
                string maPhong = cmbMaPhong.SelectedValue?.ToString();
                string maDongThietBi = cmbMaDonhThietBi.SelectedValue?.ToString();
                string trangThai = txtTrangThai.Text;
                if (string.IsNullOrEmpty(maThietBi) || string.IsNullOrEmpty(seri) || string.IsNullOrEmpty(maPhong) || string.IsNullOrEmpty(maDongThietBi))
                {
                    MessageBox.Show("Vui lòng nhập đầy đủ thông tin bắt buộc!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    string checkQuery = "SELECT COUNT(*) FROM THIETBI WHERE MATHIETBI = @MATHIETBI";
                    using (SqlCommand checkCommand = new SqlCommand(checkQuery, connection))
                    {
                        checkCommand.Parameters.AddWithValue("@MATHIETBI", maThietBi);
                        int count = (int)checkCommand.ExecuteScalar();
                        if (count > 0)
                        {
                            MessageBox.Show("Mã thiết bị đã tồn tại! Vui lòng nhập mã khác.");
                            return;
                        }
                    }

                    string query = "INSERT INTO THIETBI (MATHIETBI, SERI, MAP, MADONGTHIETBI, TRANTHAI) " +
                                   "VALUES (@MATHIETBI, @SERI, @MAP, @MADONGTHIETBI, @TRANTHAI)";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@MATHIETBI", maThietBi);
                        command.Parameters.AddWithValue("@SERI", seri);
                        command.Parameters.AddWithValue("@MAP", maPhong);
                        command.Parameters.AddWithValue("@MADONGTHIETBI", maDongThietBi);
                        command.Parameters.AddWithValue("@TRANTHAI", trangThai);
                        command.ExecuteNonQuery();
                    }
                    MessageBox.Show("Thêm dữ liệu thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    HienThiDanhSachThietBi();
                    ClearFormThietBi();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi thêm dữ liệu: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ClearFormThietBi()
        {
            txtMaThietBi.Text = "";
            txtSeri.Text = "";
            cmbMaDonhThietBi.SelectedIndex = -1;
            cmbMaPhong.SelectedIndex = -1;
            txtTrangThai.Text = "";
        }

        private void btnSuaTTTB_Click(object sender, EventArgs e)
        {
            try
            {

                if (dgvTTThietBi.SelectedRows.Count == 0)
                {
                    MessageBox.Show("Vui lòng chọn thiết bị cần sửa!");
                    return;
                }


                string maThietBi = dgvTTThietBi.SelectedRows[0].Cells["MATHIETBI"].Value.ToString();
                string seri = txtSeri.Text;
                string maPhong = cmbMaPhong.SelectedValue?.ToString();
                string maDongThietBi = cmbMaDonhThietBi.SelectedValue?.ToString();
                string trangThai = txtTrangThai.Text;
                if (string.IsNullOrEmpty(seri) || string.IsNullOrEmpty(maPhong) || string.IsNullOrEmpty(maDongThietBi))
                {
                    MessageBox.Show("Vui lòng nhập đầy đủ thông tin bắt buộc!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();



                    string query = "UPDATE THIETBI SET MATHIETBI = @MATHIETBI, SERI = @SERI, MAP = @MAP, MADONGTHIETBI = @MADONGTHIETBI, TRANTHAI = @TRANTHAI " +
                                   "WHERE MATHIETBI = @MATHIETBI";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@MATHIETBI", maThietBi);
                        command.Parameters.AddWithValue("@SERI", seri);
                        command.Parameters.AddWithValue("@MAP", maPhong);
                        command.Parameters.AddWithValue("@MADONGTHIETBI", maDongThietBi);
                        command.Parameters.AddWithValue("@TRANTHAI", trangThai);
                        command.ExecuteNonQuery();
                    }
                    MessageBox.Show("Sửa dữ liệu thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    HienThiDanhSachThietBi();
                    ClearFormThietBi();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi sửa dữ liệu: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnXoaTTTB_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvTTThietBi.SelectedRows.Count == 0)
                {
                    MessageBox.Show("Vui lòng chọn dòng khoa cần xóa!");
                    return;
                }

                string maThietBi = dgvTTThietBi.SelectedRows[0].Cells["MATHIETBI"].Value.ToString();
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string query = "DELETE FROM THIETBI WHERE MATHIETBI = @MATHIETBI";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@MATHIETBI", maThietBi);
                        command.ExecuteNonQuery();
                    }
                }
                MessageBox.Show("Xóa dữ liệu thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                HienThiDanhSachThietBi();
                ClearFormThietBi();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi xóa dữ liệu: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnimageTimKiemTB_Click(object sender, EventArgs e)
        {
            try
            {
                string maThietBi = txtTimKiemTB.Text.Trim();

                if (string.IsNullOrEmpty(maThietBi))
                {
                    MessageBox.Show("Vui lòng nhập mã thiết bị để tìm kiếm!");
                    return;
                }

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string query = "SELECT dtb.MATHIETBI, dtb.SERI, dtb.MAP, dtb.MADONGTHIETBI, dtb.TRANTHAI " +
                                   "FROM THIETBI dtb " +
                                   "WHERE dtb.MADONGTHIETBI LIKE @MADONGTHIETBI";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@MADONGTHIETBI", "%" + maThietBi + "%");

                        using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                        {
                            DataSet dataSet = new DataSet();
                            adapter.Fill(dataSet);
                            dgvTTThietBi.DataSource = dataSet.Tables[0];
                        }
                    }
                }

                if (dgvTTThietBi.Rows.Count == 0)
                {
                    MessageBox.Show("Không tìm thấy mã thiết bị!!!!" + maThietBi + "'!");
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tìm kiếm dữ liệu dữ liệu: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnQuayLaiTB_Click(object sender, EventArgs e)
        {
            this.Hide();
            ThietBi thietBi = new ThietBi();
            thietBi.ShowDialog();
        }
        private void LoadMaPhong()
        {
            string query = "SELECT MAP FROM PHONG";
            SqlDataAdapter da = new SqlDataAdapter(query, connectionString);
            DataTable dt = new DataTable();
            da.Fill(dt);

            cmbMaPhong.DataSource = dt;
            cmbMaPhong.DisplayMember = "MAP"; 
            cmbMaPhong.ValueMember = "MAP";
        }
        private void LoadMaDongThietBi()
        {
            string query = "SELECT MADONGTHIETBI FROM DONGTHIETBI";
            SqlDataAdapter da = new SqlDataAdapter(query, connectionString);
            DataTable dt = new DataTable();
            da.Fill(dt);

            cmbMaDonhThietBi.DataSource = dt;
            cmbMaDonhThietBi.DisplayMember = "MADONGTHIETBI";  
            cmbMaDonhThietBi.ValueMember = "MADONGTHIETBI";
        }
        private void dgvTTThietBi_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvTTThietBi.SelectedRows.Count == 0) return;

            DataGridViewRow row = dgvTTThietBi.SelectedRows[0];

            txtMaThietBi.Text = row.Cells["MATHIETBI"].Value?.ToString();
            txtSeri.Text = row.Cells["SERI"].Value?.ToString();

            cmbMaPhong.SelectedValue = row.Cells["MAP"].Value?.ToString();
            cmbMaDonhThietBi.SelectedValue = row.Cells["MADONGTHIETBI"].Value?.ToString();

            txtTrangThai.Text = row.Cells["TRANTHAI"].Value?.ToString();

            txtMaThietBi.ReadOnly = true;
        }

    }
}
