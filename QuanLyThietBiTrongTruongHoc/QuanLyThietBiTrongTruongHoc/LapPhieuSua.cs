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
    public partial class LapPhieuSua : Form
    {
        string connectionString = "Data Source=DESKTOP-T28R5TF\\SQLEXPRESS;Initial Catalog=QUANLYTHIETBI;Integrated Security = True";
        public LapPhieuSua()
        {
            InitializeComponent();
            HienThiDanhSachPhieuSua();
        }

        private void HienThiDanhSachPhieuSua()
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string query = "SELECT * FROM PHIEUSUA";


                    using (SqlDataAdapter adapter = new SqlDataAdapter(query, connection))
                    {
                        DataSet dataSet = new DataSet();
                        adapter.Fill(dataSet);
                        dgvTTPhieuSua.DataSource = dataSet.Tables[0];
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi hiển thị danh sách phiếu sửa: " + ex.Message);
            }
        }
        private void btnCapNhatPhieuSua_Click(object sender, EventArgs e)
        {
            try
            {
                string maPhieuSua = txtMaPhieuSua.Text.Trim();
                string trangThai = txtTrangThaiPhieuSua.Text.Trim();
                string moTa = txtMoTa.Text.Trim();
                DateTime ngayLap = datetimeLapPhieu.Value;
                string donGia = txtDonGia.Text.Trim(); // Lấy giá trị từ NumericUpDown
                int soLuong = (int)numberSoLuong.Value;

                if (string.IsNullOrEmpty(maPhieuSua) || string.IsNullOrEmpty(trangThai))
                {
                    MessageBox.Show("Vui lòng nhập đầy đủ thông tin bắt buộc!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    string checkQuery = "SELECT COUNT(*) FROM PHIEUSUA WHERE MAPS = @MAPS";
                    using (SqlCommand checkCommand = new SqlCommand(checkQuery, connection))
                    {
                        checkCommand.Parameters.AddWithValue("@MAPS", maPhieuSua);
                        int count = (int)checkCommand.ExecuteScalar();
                        if (count > 0)
                        {
                            MessageBox.Show("Mã phiếu sửa đã tồn tại! Vui lòng nhập mã khác.");
                            return;
                        }
                    }

                    string query = "INSERT INTO PHIEUSUA (MAPS, TRANGTHAI, MOTA, NGAYLAP, SOLUONG, DONGIA) " +
                                   "VALUES (@MAPS, @TRANGTHAI, @MOTA, @NGAYLAP, @SOLUONG, @DONGIA)";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@MAPS", maPhieuSua);
                        command.Parameters.AddWithValue("@TRANGTHAI", trangThai);
                        command.Parameters.AddWithValue("@MOTA", moTa);
                        command.Parameters.AddWithValue("@NGAYLAP", ngayLap);
                        command.Parameters.AddWithValue("@SOLUONG",soLuong);
                        command.Parameters.AddWithValue("@DONGIA",donGia);

                        command.ExecuteNonQuery();
                    }
                    MessageBox.Show("Cập nhật dữ liệu thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    HienThiDanhSachPhieuSua();
                    ClearFormPhieuSua();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi cập nhật dữ liệu phiếu sửa: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ClearFormPhieuSua()
        {
            txtMaPhieuSua.Text = "";
            txtTrangThaiPhieuSua.Text = "";
            txtMoTa.Text = "";
            datetimeLapPhieu.Checked = false;
            txtDonGia.Text = "";
            numberSoLuong.Value = 0;
        }

        private void btnSuaTTPhieuSua_Click(object sender, EventArgs e)
        {
            try
            {

                if (dgvTTPhieuSua.SelectedRows.Count == 0)
                {
                    MessageBox.Show("Vui lòng chọn phiếu sửa cần sửa!");
                    return;
                }


                string maPhieuSua = dgvTTPhieuSua.SelectedRows[0].Cells["MAPS"].Value.ToString();
                string trangThai = txtTrangThaiPhieuSua.Text.Trim();
                string moTa = txtMoTa.Text.Trim();
                DateTime ngayLap = datetimeLapPhieu.Value;
                string donGia = txtDonGia.Text.Trim(); // Lấy giá trị từ NumericUpDown
                int soLuong = (int)numberSoLuong.Value;

                if (string.IsNullOrEmpty(maPhieuSua) || string.IsNullOrEmpty(trangThai))
                {
                    MessageBox.Show("Vui lòng nhập đầy đủ thông tin bắt buộc!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();



                    string query = "UPDATE PHIEUSUA SET MAPS = @MAPS, TRANGTHAI = @TRANGTHAI, MOTA = @MOTA, NGAYLAP = @NGAYLAP, SOLUONG = @SOLUONG, DONGIA = @DONGIA " +
                                   "WHERE MAPS = @MAPS";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@MAPS", maPhieuSua);
                        command.Parameters.AddWithValue("@TRANGTHAI", trangThai);
                        command.Parameters.AddWithValue("@MOTA", moTa);
                        command.Parameters.AddWithValue("@NGAYLAP", ngayLap);
                        command.Parameters.AddWithValue("@SOLUONG", soLuong);
                        command.Parameters.AddWithValue("@DONGIA", donGia);
                        command.ExecuteNonQuery();
                    }
                    MessageBox.Show("Sửa dữ liệu thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    HienThiDanhSachPhieuSua();
                    ClearFormPhieuSua();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi sửa dữ liệu phiếu sửa: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnXoaTTPhieuSua_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvTTPhieuSua.SelectedRows.Count == 0)
                {
                    MessageBox.Show("Vui lòng chọn phiếu sửa cần xóa!");
                    return;
                }

                string maPhieuSua = dgvTTPhieuSua.SelectedRows[0].Cells["MAPS"].Value.ToString();
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string query = "DELETE FROM PHIEUSUA WHERE MAPS = @MAPS";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@MAPS", maPhieuSua);
                        command.ExecuteNonQuery();
                    }
                }
                MessageBox.Show("Xóa dữ liệu thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                HienThiDanhSachPhieuSua();
                ClearFormPhieuSua();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi xóa dữ liệu: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnQuayLaiPhieuSua_Click(object sender, EventArgs e)
        {
            this.Hide();
            PhieuMuonSua phieuMuonSua = new PhieuMuonSua();
            phieuMuonSua.ShowDialog();
        }

        private void dgvTTPhieuSua_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvTTPhieuSua.SelectedRows.Count == 0) return;

            DataGridViewRow row = dgvTTPhieuSua.SelectedRows[0];

            txtMaPhieuSua.Text = row.Cells["MAPS"].Value?.ToString();
            txtTrangThaiPhieuSua.Text = row.Cells["TRANGTHAI"].Value?.ToString();
            datetimeLapPhieu.Value = Convert.ToDateTime(row.Cells["NGAYLAP"].Value);
            txtMoTa.Text = row.Cells["MOTA"].Value?.ToString();
            txtDonGia.Text = row.Cells["DONGIA"].Value?.ToString();
            if (row.Cells["SOLUONG"].Value != null && int.TryParse(row.Cells["SOLUONG"].Value.ToString(), out int soLuong))
            {
                numberSoLuong.Value = soLuong;
            }
            else
            {
                numberSoLuong.Value = 0;
            }


            TinhTongChiPhi(); 
        }
        private void TinhTongChiPhi()
        {
            if (decimal.TryParse(txtDonGia.Text, out decimal donGia))
            {
                decimal tong = donGia * numberSoLuong.Value;
                lblTongTien.Text = tong.ToString("N0") + " VND";
            }
            else
            {
                lblTongTien.Text = "Không hợp lệ!";
            }
        }

        private void btnTaiLai_Click(object sender, EventArgs e)
        {
            HienThiDanhSachPhieuSua();
        }
    }
}
