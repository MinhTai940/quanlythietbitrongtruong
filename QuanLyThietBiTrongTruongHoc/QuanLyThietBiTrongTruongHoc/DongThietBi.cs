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
    public partial class DongThietBi : Form
    {
        string connectionString = "Data Source=DESKTOP-T28R5TF\\SQLEXPRESS;Initial Catalog=QUANLYTHIETBI;Integrated Security = True";
        public DongThietBi()
        {
            InitializeComponent();
            HienThiDanhSachDongThietBi();
        }

        private void HienThiDanhSachDongThietBi()
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string query = "SELECT * FROM DONGTHIETBI";


                    using (SqlDataAdapter adapter = new SqlDataAdapter(query, connection))
                    {
                        DataSet dataSet = new DataSet();
                        adapter.Fill(dataSet);
                        dgvTTDongTB.DataSource = dataSet.Tables[0];
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi hiển thị danh sách dòng thiết bị: " + ex.Message);
            }
        }

        private void btnCapNhatDongTB_Click(object sender, EventArgs e)
        {
            try
            {
                string maDongThietBi = txtMaDongTB.Text;
                string tenThietDongThietBi = txtTenDongTB.Text;
                string soLuong = txtSoLuonDongThietBi.Text;
                string moTa = txtMoTaTB.Text;

                if (string.IsNullOrEmpty(maDongThietBi) || string.IsNullOrEmpty(tenThietDongThietBi) || string.IsNullOrEmpty(soLuong))
                {
                    MessageBox.Show("Vui lòng nhập đầy đủ thông tin bắt buộc!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    string checkQuery = "SELECT COUNT(*) FROM DONGTHIETBI WHERE MaDongThietBi = @MaDongThietBi";
                    using (SqlCommand checkCommand = new SqlCommand(checkQuery, connection))
                    {
                        checkCommand.Parameters.AddWithValue("@MaDongThietBi", maDongThietBi);
                        int count = (int)checkCommand.ExecuteScalar();
                        if (count > 0)
                        {
                            MessageBox.Show("Mã thiết bị đã tồn tại! Vui lòng nhập mã khác.");
                            return;
                        }
                    }

                    string query = "INSERT INTO DONGTHIETBI (MaDongThietBi, TenDongThietBi, SoLuong, MoTa) " +
                                   "VALUES (@MaDongThietBi, @TenDongThietBi, @SoLuong, @MoTa)";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@MaDongThietBi", maDongThietBi);
                        command.Parameters.AddWithValue("@TenDongThietBi", tenThietDongThietBi);
                        command.Parameters.AddWithValue("@SoLuong", soLuong);
                        command.Parameters.AddWithValue("@MoTa", moTa);
                        command.ExecuteNonQuery();
                    }
                    MessageBox.Show("Thêm dòng thiết bị thành công!");
                    HienThiDanhSachDongThietBi();
                    ClearFormDongThietBi();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi thêm dòng thiết bị: " + ex.Message);
            }
        }

        private void ClearFormDongThietBi()
        {
            txtMaDongTB.Text = "";
            txtTenDongTB.Text = "";
            txtSoLuonDongThietBi.Text = "";
            txtMoTaTB.Text = "";
        }

        private void btnSuaTTDongThietBi_Click(object sender, EventArgs e)
        {
            try
            {
                
                if (dgvTTDongTB.SelectedRows.Count == 0)
                {
                    MessageBox.Show("Vui lòng chọn dòng thiết bị cần sửa!");
                    return;
                }

                
                string maDongThietBi = dgvTTDongTB.SelectedRows[0].Cells["MaDongThietBi"].Value.ToString();
                string tenDongThietBi = txtTenDongTB.Text;
                string soLuong = txtSoLuonDongThietBi.Text;
                string moTa = txtMoTaTB.Text;

                if (string.IsNullOrEmpty(maDongThietBi) || string.IsNullOrEmpty(tenDongThietBi) || string.IsNullOrEmpty(soLuong))
                {
                    MessageBox.Show("Vui lòng nhập đầy đủ thông tin bắt buộc!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    

                    string query = "UPDATE DONGTHIETBI SET MaDongThietBi = @MaDongThietBi, TenDongThietBi = @TenDongThietBi, SoLuong = @SoLuong, MoTa = @MoTa " +
                                   "WHERE MaDongThietBi = @MaDongThietBi";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@MaDongThietBi", maDongThietBi);
                        command.Parameters.AddWithValue("@TenDongThietBi", tenDongThietBi);
                        command.Parameters.AddWithValue("@SoLuong", soLuong);
                        command.Parameters.AddWithValue("@MoTa", moTa);
                        command.ExecuteNonQuery();
                    }
                    MessageBox.Show("Cập nhật thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    HienThiDanhSachDongThietBi();
                    ClearFormDongThietBi();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi cập nhật dữ liệu: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void btnXoaTTDongTB_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvTTDongTB.SelectedRows.Count == 0)
                {
                    MessageBox.Show("Vui lòng chọn dòng thiết bị cần xóa!");
                    return;
                }
                 
                string maDongThietBi = dgvTTDongTB.SelectedRows[0].Cells["MaDongThietBi"].Value.ToString();
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string query = "DELETE FROM DONGTHIETBI WHERE MaDongThietBi = @MaDongThietBi";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@MaDongThietBi", maDongThietBi);
                        command.ExecuteNonQuery();
                    }
                }
                MessageBox.Show("Xóa dữ liệu thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                HienThiDanhSachDongThietBi();
                ClearFormDongThietBi();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi xóa dữ liệu: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnTimKiemdongthietbi_Click(object sender, EventArgs e)
        {
            try
            {
                string maDongThietBi = txtTimKiemDongThietBi.Text.Trim();

                if (string.IsNullOrEmpty(maDongThietBi))
                {
                    MessageBox.Show("Vui lòng nhập mã dòng thiết bị để tìm kiếm!");
                    return;
                }

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string query = "SELECT dtb.MaDongThietBi, dtb.TenDongThietBi, dtb.SoLuong, dtb.MoTa " +
                                   "FROM DONGTHIETBI dtb " +
                                   "WHERE dtb.MaDongThietBi LIKE @MaDongThietBi";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@MaDongThietBi", "%" + maDongThietBi + "%");

                        using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                        {
                            DataSet dataSet = new DataSet();
                            adapter.Fill(dataSet);
                            dgvTTDongTB.DataSource = dataSet.Tables[0];
                        }
                    }
                }

                if (dgvTTDongTB.Rows.Count == 0)
                {
                    MessageBox.Show("Không tìm thấy mã dòng thiết bị" + maDongThietBi + "'!");
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tìm kiếm dữ liệu dữ liệu: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnTaiLaiTTdongthietbi_Click(object sender, EventArgs e)
        {
            
            HienThiDanhSachDongThietBi();
          

            
            ClearFormDongThietBi();
           

            
            txtTimKiemDongThietBi.Text = "";
        }

        private void btnQuayLaiDongTB_Click(object sender, EventArgs e)
        {
            this.Hide();
            ThietBi thietBi = new ThietBi();
            thietBi.ShowDialog();
        }

        private void dgvTTDongTB_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvTTDongTB.SelectedRows.Count == 0) return;

            DataGridViewRow row = dgvTTDongTB.SelectedRows[0];

            txtMaDongTB.Text = row.Cells["MADONGTHIETBI"].Value?.ToString();
            txtTenDongTB.Text = row.Cells["TENDONGTHIETBI"].Value?.ToString();
            txtSoLuonDongThietBi.Text = row.Cells["SOLUONG"].Value?.ToString();
            txtMoTaTB.Text = row.Cells["MOTA"].Value?.ToString();

           
        }

    }
}
