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
    public partial class LapPhieuMuon : Form
    {
        string connectionString = "Data Source=DESKTOP-T28R5TF\\SQLEXPRESS;Initial Catalog=QUANLYTHIETBI;Integrated Security = True";
        public LapPhieuMuon()
        {
            InitializeComponent();
            HienThiDanhSachPhieuMuon();
            LoadMaNhanVien();
            LoadMaSinhVien();
        }

        private void HienThiDanhSachPhieuMuon()
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string query = "SELECT * FROM PHIEUMUON";


                    using (SqlDataAdapter adapter = new SqlDataAdapter(query, connection))
                    {
                        DataSet dataSet = new DataSet();
                        adapter.Fill(dataSet);
                        dgvTTPhieuMuon.DataSource = dataSet.Tables[0];
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi hiển thị danh sách phiếu mượn: " + ex.Message);
            }
        }

        private void btnCapNhatPhieuMuon_Click(object sender, EventArgs e)
        {
            try
            {
                string maPhieuMuon = txtMaPhieuMuon.Text.Trim();
                string maNhanVien = cmbMaNV.SelectedValue?.ToString();
                string maSinhVien = cmbMaSV.SelectedValue?.ToString();
                string trangThai = txtTrangThaiPhieuMuon.Text.Trim();
                string lyDoMuon = txtLyDoMuon.Text.Trim();
                string lyDoTuChoi = txtLyDoTuChoi.Text.Trim();
                string lyDoHuy = txtLyDoHuy.Text.Trim();
                string soLuong = txtSoLuong.Text.Trim();
                DateTime ngayMuon = datetimeNgayMuon.Value;
                DateTime ngayLap = datetimeNgayLapPhieu.Value;
                DateTime ngayTra = datatimeNgayTra.Value;

                if (string.IsNullOrEmpty(maPhieuMuon) || string.IsNullOrEmpty(maNhanVien) || string.IsNullOrEmpty(maSinhVien))
                {
                    MessageBox.Show("Vui lòng nhập đầy đủ thông tin bắt buộc!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    string checkQuery = "SELECT COUNT(*) FROM PHIEUMUON WHERE MAPM = @MAPM";
                    using (SqlCommand checkCommand = new SqlCommand(checkQuery, connection))
                    {
                        checkCommand.Parameters.AddWithValue("@MAPM", maPhieuMuon);
                        int count = (int)checkCommand.ExecuteScalar();
                        if (count > 0)
                        {
                            MessageBox.Show("Mã phiếu mượn đã tồn tại! Vui lòng nhập mã khác.");
                            return;
                        }
                    }

                    string query = "INSERT INTO PHIEUMUON (MAPM, MANV, MASV, NGAYMUON, NGAYLAPPHIEU, NGAYTRA, TRANGTHAI, LYDOMUON, LYDOTUCHOI, LYDOHUY, SOLUONGMUON) " +
                                   "VALUES (@MAPM, @MANV, @MASV, @NGAYMUON, @NGAYLAPPHIEU, @NGAYTRA, @TRANGTHAI, @LYDOMUON, @LYDOTUCHOI, @LYDOHUY, @SOLUONGMUON)";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@MAPM", maPhieuMuon);
                        command.Parameters.AddWithValue("@MANV", maNhanVien);
                        command.Parameters.AddWithValue("@MASV", maSinhVien);
                        command.Parameters.AddWithValue("@NGAYMUON", ngayMuon);
                        command.Parameters.AddWithValue("@NGAYLAPPHIEU", ngayLap);
                        command.Parameters.AddWithValue("@NGAYTRA", ngayTra);
                        command.Parameters.AddWithValue("@TRANGTHAI", trangThai);
                        command.Parameters.AddWithValue("@LYDOMUON", lyDoMuon);
                        command.Parameters.AddWithValue("@LYDOTUCHOI", lyDoTuChoi);
                        command.Parameters.AddWithValue("@LYDOHUY", lyDoHuy);
                        command.Parameters.AddWithValue("@SOLUONGMUON", soLuong);
                        command.ExecuteNonQuery();
                    }
                    MessageBox.Show("Thêm dữ liệu thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    HienThiDanhSachPhieuMuon();
                    ClearFormPhieuMuon();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi thêm dữ liệu: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ClearFormPhieuMuon()
        {
            txtMaPhieuMuon.Text = "";
            cmbMaNV.SelectedIndex = -1;
            cmbMaSV.SelectedIndex = -1;
            txtLyDoMuon.Text = "";
            txtLyDoTuChoi.Text = "";
            txtLyDoHuy.Text = "";
            txtSoLuong.Text = "";
            txtTrangThaiPhieuMuon.Text = "";
            datetimeNgayMuon.Checked = false;
            datetimeNgayLapPhieu.Checked = false;
            datatimeNgayTra.Checked = false;
        }

        private void btnSuaTTPhieuMuon_Click(object sender, EventArgs e)
        {
            try
            {

                if (dgvTTPhieuMuon.SelectedRows.Count == 0)
                {
                    MessageBox.Show("Vui lòng chọn phiếu mượn cần sửa!");
                    return;
                }


                string maPhieuMuon = dgvTTPhieuMuon.SelectedRows[0].Cells["MAPM"].Value.ToString();
                string maNhanVien = cmbMaNV.SelectedValue?.ToString();
                string maSinhVien = cmbMaSV.SelectedValue?.ToString();
                string trangThai = txtTrangThaiPhieuMuon.Text.Trim();
                string lyDoMuon = txtLyDoMuon.Text.Trim();
                string lyDoTuChoi = txtLyDoTuChoi.Text.Trim();
                string lyDoHuy = txtLyDoHuy.Text.Trim();
                string soLuong = txtSoLuong.Text.Trim();
                DateTime ngayMuon = datetimeNgayMuon.Value;
                DateTime ngayLap = datetimeNgayLapPhieu.Value;
                DateTime ngayTra = datatimeNgayTra.Value;

                if (string.IsNullOrEmpty(maNhanVien) || string.IsNullOrEmpty(maSinhVien))
                {
                    MessageBox.Show("Vui lòng nhập đầy đủ thông tin bắt buộc!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();



                    string query = "UPDATE PHIEUMUON SET MAPM = @MAPM, MANV = @MANV, MASV = @MASV, NGAYMUON = @NGAYMUON, NGAYLAPPHIEU = @NGAYLAPPHIEU, NGAYTRA = @NGAYTRA, TRANGTHAI = @TRANGTHAI, LYDOMUON = @LYDOMUON, LYDOTUCHOI = @LYDOTUCHOI, LYDOHUY = @LYDOHUY, SOLUONGMUON = @SOLUONGMUON " +
                                   "WHERE MAPM = @MAPM";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@MAPM", maPhieuMuon);
                        command.Parameters.AddWithValue("@MANV", maNhanVien);
                        command.Parameters.AddWithValue("@MASV", maSinhVien);
                        command.Parameters.AddWithValue("@NGAYMUON", ngayMuon);
                        command.Parameters.AddWithValue("@NGAYLAPPHIEU", ngayLap);
                        command.Parameters.AddWithValue("@NGAYTRA", ngayTra);
                        command.Parameters.AddWithValue("@TRANGTHAI", trangThai);
                        command.Parameters.AddWithValue("@LYDOMUON", lyDoMuon);
                        command.Parameters.AddWithValue("@LYDOTUCHOI", lyDoTuChoi);
                        command.Parameters.AddWithValue("@LYDOHUY", lyDoHuy);
                        command.Parameters.AddWithValue("@SOLUONGMUON", soLuong);
                        command.ExecuteNonQuery();
                    }
                    MessageBox.Show("Sửa dữ liệu thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    HienThiDanhSachPhieuMuon();
                    ClearFormPhieuMuon();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi sử dữ liệu phiếu mượn dữ liệu: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void btnXoaTTPhieuMuon_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvTTPhieuMuon.SelectedRows.Count == 0)
                {
                    MessageBox.Show("Vui lòng chọn phiếu mượn cần xóa!");
                    return;
                }

                string maPhieuMuon = dgvTTPhieuMuon.SelectedRows[0].Cells["MAPM"].Value.ToString();
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string query = "DELETE FROM PHIEUMUON WHERE MAPM = @MAPM";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@MAPM", maPhieuMuon);
                        command.ExecuteNonQuery();
                    }
                }
                MessageBox.Show("Xóa dữ liệu thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                HienThiDanhSachPhieuMuon();
                ClearFormPhieuMuon();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi xóa dữ liệu: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnQuayLaiPhieuMuon_Click(object sender, EventArgs e)
        {
            this.Hide();
            PhieuMuonSua phieuMuonSua = new PhieuMuonSua();
            phieuMuonSua.ShowDialog();
        }
        private void LoadMaNhanVien()
        {
            string query = "SELECT MANV FROM NHANVIEN";
            SqlDataAdapter da = new SqlDataAdapter(query, connectionString);
            DataTable dt = new DataTable();
            da.Fill(dt);

            cmbMaNV.DataSource = dt;
            cmbMaNV.DisplayMember = "MANV";  // Hiển thị MaKhoa luôn
            cmbMaNV.ValueMember = "MANV";
        }
        private void LoadMaSinhVien()
        {
            string query = "SELECT MASV FROM SINHVIEN";
            SqlDataAdapter da = new SqlDataAdapter(query, connectionString);
            DataTable dt = new DataTable();
            da.Fill(dt);

            cmbMaSV.DataSource = dt;
            cmbMaSV.DisplayMember = "MASV";  // Hiển thị MaKhoa luôn
            cmbMaSV.ValueMember = "MASV";
        }

        private void dgvTTPhieuMuon_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvTTPhieuMuon.SelectedRows.Count == 0) return;

            DataGridViewRow row = dgvTTPhieuMuon.SelectedRows[0];

            txtMaPhieuMuon.Text = row.Cells["MAPM"].Value?.ToString();
            datetimeNgayMuon.Value = Convert.ToDateTime(row.Cells["NGAYMUON"].Value);
            datetimeNgayLapPhieu.Value = Convert.ToDateTime(row.Cells["NGAYLAPPHIEU"].Value);
            datatimeNgayTra.Value = Convert.ToDateTime(row.Cells["NGAYTRA"].Value);

            cmbMaNV.SelectedValue = row.Cells["MANV"].Value?.ToString();
            cmbMaSV.SelectedValue = row.Cells["MASV"].Value?.ToString();
            txtTrangThaiPhieuMuon.Text = row.Cells["TRANGTHAI"].Value?.ToString();

            txtLyDoMuon.Text = row.Cells["LYDOMUON"].Value?.ToString();
            txtLyDoTuChoi.Text = row.Cells["LYDOTUCHOI"].Value?.ToString();
            txtLyDoHuy.Text = row.Cells["LYDOHUY"].Value?.ToString();

            txtSoLuong.Text = row.Cells["SOLUONGMUON"].Value?.ToString();

            
        }

        private void btnTimKiemPhieuMuon_Click(object sender, EventArgs e)
        {
            try
            {
                string maSinhVien = txtTimKiemTTPhieuMuon.Text.Trim();

                if (string.IsNullOrEmpty(maSinhVien))
                {
                    MessageBox.Show("Vui lòng nhập mã sinh viên để tìm kiếm!");
                    return;
                }

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    string query = @"SELECT MAPM, NGAYMUON, NGAYLAPPHIEU, NGAYTRA,
                                MANV, MASV, TRANGTHAI,
                                LYDOMUON, LYDOTUCHOI, LYDOHUY, SOLUONGMUON
                         FROM PHIEUMUON
                         WHERE MASV LIKE @MaSV";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@MaSV", "%" + maSinhVien + "%");

                        using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                        {
                            DataSet dataSet = new DataSet();
                            adapter.Fill(dataSet);
                            dgvTTPhieuMuon.DataSource = dataSet.Tables[0];
                        }
                    }
                }

                if (dgvTTPhieuMuon.Rows.Count == 0)
                {
                    MessageBox.Show("Không tìm thấy sinh viên có mã: '" + maSinhVien + "'!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tìm kiếm dữ liệu: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void btnTaiLai_Click(object sender, EventArgs e)
        {
            HienThiDanhSachPhieuMuon();
        }
    }
}
