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
    public partial class Phong : Form
    {
        string connectionString = "Data Source=DESKTOP-T28R5TF\\SQLEXPRESS;Initial Catalog=QUANLYTHIETBI;Integrated Security = True";
        public Phong()
        {
            InitializeComponent();
            HienThiDanhSachCoSo();
            HienThiDanhSachPhong();
            LoadMaCoSo();
        }

        private void HienThiDanhSachCoSo()
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string query = "SELECT * FROM COSO";


                    using (SqlDataAdapter adapter = new SqlDataAdapter(query, connection))
                    {
                        DataSet dataSet = new DataSet();
                        adapter.Fill(dataSet);
                        dgvTTCoSo.DataSource = dataSet.Tables[0];
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi hiển thị danh sách cơ sở: " + ex.Message);
            }
        }

        private void HienThiDanhSachPhong()
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
                        dgvTTPhong.DataSource = dataSet.Tables[0];
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi hiển thị danh sách phòng: " + ex.Message);
            }
        }

        private void btnCapNhatTTPhongCoSo_Click(object sender, EventArgs e)
        {
            try
            {
                string maPhong = txtMaPhong.Text.Trim();
                string maCoSo = cmbMaCS.SelectedValue?.ToString();
                string tenPhong = txtTenPhong.Text.Trim();
                string loaiPhong = txtLoaiPhong.Text.Trim();
                string doiTuongUuTien = txtdouutien.Text.Trim();

                if (string.IsNullOrEmpty(maPhong) || string.IsNullOrEmpty(tenPhong) || string.IsNullOrEmpty(tenPhong))
                {
                    MessageBox.Show("Vui lòng nhập đầy đủ thông tin bắt buộc!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    string checkQuery = "SELECT COUNT(*) FROM PHONG WHERE MAP = @MAP";
                    using (SqlCommand checkCommand = new SqlCommand(checkQuery, connection))
                    {
                        checkCommand.Parameters.AddWithValue("@MAP", maPhong);
                        int count = (int)checkCommand.ExecuteScalar();
                        if (count > 0)
                        {
                            MessageBox.Show("Mã phòng đã tồn tại! Vui lòng nhập mã khác.");
                            return;
                        }
                    }

                    string query = "INSERT INTO PHONG (MAP, MACS, TENPHONG, LOAIPHONG, DOITUONGUUTIEN) " +
                                   "VALUES (@MAP, @MACS, @TENPHONG, @LOAIPHONG, @DOITUONGUUTIEN)";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@MAP", maPhong);
                        command.Parameters.AddWithValue("@MACS", maCoSo);
                        command.Parameters.AddWithValue("@TENPHONG", tenPhong);
                        command.Parameters.AddWithValue("@LOAIPHONG", loaiPhong);
                        command.Parameters.AddWithValue("@DOITUONGUUTIEN", doiTuongUuTien);
                        
                        command.ExecuteNonQuery();
                    }
                    MessageBox.Show("Cập nhật dữ liệu thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    HienThiDanhSachPhong();
                    ClearFormPhong();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi cập nhật dữ liệu phòng: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            try
            {
                string maCoSo = txtMaCoSo.Text;
                string tenCoSo = txtTenCoSo.Text;
                string diaChi = txtDiaChiCoSo.Text;

                if (string.IsNullOrEmpty(maCoSo) || string.IsNullOrEmpty(tenCoSo))
                {
                    MessageBox.Show("Vui lòng nhập đầy đủ thông tin bắt buộc!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    string checkQuery = "SELECT COUNT(*) FROM COSO WHERE MACS = @MACS";
                    using (SqlCommand checkCommand = new SqlCommand(checkQuery, connection))
                    {
                        checkCommand.Parameters.AddWithValue("@MACS", maCoSo);
                        int count = (int)checkCommand.ExecuteScalar();
                        if (count > 0)
                        {
                            MessageBox.Show("Mã cơ sở đã tồn tại! Vui lòng nhập mã khác.");
                            return;
                        }
                    }

                    string query = "INSERT INTO COSO (MACS, TENCS, DIACHI) " +
                                   "VALUES (@MACS, @TENCS, @DIACHI)";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@MACS", maCoSo);
                        command.Parameters.AddWithValue("@TENCS", tenCoSo);
                        command.Parameters.AddWithValue("@DIACHI", diaChi);
                        command.ExecuteNonQuery();
                    }
                    MessageBox.Show("Thêm dòng cơ sở thành công!");
                    HienThiDanhSachCoSo();
                    ClearFormCoSo();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi thêm cơ sở: " + ex.Message);
            }

        }

        private void ClearFormPhong()
        {
            txtMaPhong.Text = "";
            txtTenPhong.Text = "";
            cmbMaCS.SelectedIndex = -1;
            txtLoaiPhong.Text = "";
            txtdouutien.Text = "";

        }

        private void ClearFormCoSo()
        {
            txtMaCoSo.Text = "";
            txtTenCoSo.Text = "";
            txtDiaChiCoSo.Text = "";
            

        }

        private void btnSuaTTPhongCoSo_Click(object sender, EventArgs e)
        {
            try
            {

                if (dgvTTPhong.SelectedRows.Count == 0)
                {
                    MessageBox.Show("Vui lòng chọn phòng cần sửa!");
                    return;
                }


                string maPhong = dgvTTPhong.SelectedRows[0].Cells["MAP"].Value.ToString();
                string tenPhong = txtTenPhong.Text.Trim();
                string loaiPhong = txtLoaiPhong.Text.Trim();
                string maCoSo = cmbMaCS.SelectedValue?.ToString();
                string doiTuongUuTien = txtdouutien.Text.Trim();

                if (string.IsNullOrEmpty(maPhong) || string.IsNullOrEmpty(tenPhong) || string.IsNullOrEmpty(maCoSo))
                {
                    MessageBox.Show("Vui lòng nhập đầy đủ thông tin bắt buộc!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();



                    string query = "UPDATE PHONG SET MAP = @MAP, TENPHONG = @TENPHONG, MACS = @MACS, LOAIPHONG = @LOAIPHONG, DOITUONGUUTIEN = @DOITUONGUUTIEN " +
                                   "WHERE MAP = @MAP";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@MAP", maPhong);
                        command.Parameters.AddWithValue("@MACS", maCoSo);
                        command.Parameters.AddWithValue("@TENPHONG", tenPhong);
                        command.Parameters.AddWithValue("@LOAIPHONG", loaiPhong);
                        command.Parameters.AddWithValue("@DOITUONGUUTIEN", doiTuongUuTien);
                        command.ExecuteNonQuery();
                    }
                    MessageBox.Show("Sửa dữ liệu thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    HienThiDanhSachPhong();
                    ClearFormPhong();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi sửa dữ liệu phòng: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnXoaTTPhongCoSo_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvTTPhong.SelectedRows.Count == 0)
                {
                    MessageBox.Show("Vui lòng chọn phòng cần xóa!");
                    return;
                }

                string maPhong = dgvTTPhong.SelectedRows[0].Cells["MAP"].Value.ToString();
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string query = "DELETE FROM PHONG WHERE MAP = @MAP";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@MAP", maPhong);
                        command.ExecuteNonQuery();
                    }
                }
                MessageBox.Show("Xóa dữ liệu thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                HienThiDanhSachPhong();
                ClearFormPhong();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi xóa dữ liệu: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSuaTTCoSo_Click(object sender, EventArgs e)
        {
            try
            {

                if (dgvTTCoSo.SelectedRows.Count == 0)
                {
                    MessageBox.Show("Vui lòng chọn cơ sở cần sửa!");
                    return;
                }


                string maCoSo = dgvTTCoSo.SelectedRows[0].Cells["MACS"].Value.ToString();
                string tenCoSo = txtTenCoSo.Text.Trim();
                string diaChi = txtDiaChiCoSo.Text.Trim();
                

                if (string.IsNullOrEmpty(maCoSo) || string.IsNullOrEmpty(tenCoSo) || string.IsNullOrEmpty(diaChi))
                {
                    MessageBox.Show("Vui lòng nhập đầy đủ thông tin bắt buộc!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();



                    string query = "UPDATE COSO SET MACS = @MACS, TENCS = @TENCS, DIACHI = @DIACHI " +
                                   "WHERE MACS = @MACS";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@MACS", maCoSo);
                        command.Parameters.AddWithValue("@TENCS", tenCoSo);
                        command.Parameters.AddWithValue("@DIACHI", diaChi);
                        command.ExecuteNonQuery();
                    }
                    MessageBox.Show("Sửa dữ liệu thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    HienThiDanhSachCoSo();
                    ClearFormCoSo();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi sửa dữ liệu cơ sở: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnXoaTTCoSo_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvTTCoSo.SelectedRows.Count == 0)
                {
                    MessageBox.Show("Vui lòng chọn cơ sở cần xóa!");
                    return;
                }

                string maCoSo = dgvTTCoSo.SelectedRows[0].Cells["MACS"].Value.ToString();
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string query = "DELETE FROM COSO WHERE MACS = @MACS";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@MACS", maCoSo);
                        command.ExecuteNonQuery();
                    }
                }
                MessageBox.Show("Xóa dữ liệu thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                HienThiDanhSachCoSo();
                ClearFormCoSo();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi xóa dữ liệu: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnTimKiemTTphongcoso_Click(object sender, EventArgs e)
        {
            string tuKhoa = txtTimKiem.Text.Trim();

            if (string.IsNullOrEmpty(tuKhoa))
            {
                HienThiDanhSachPhong();
                HienThiDanhSachCoSo();
                return;
            }

            TimKiemPhong(tuKhoa);
            TimKiemCoSo(tuKhoa);
        }

        private void TimKiemPhong(string tuKhoa)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string query = "SELECT * FROM PHONG WHERE MAP LIKE @TuKhoa OR TENPHONG LIKE @TuKhoa";
                    using (SqlDataAdapter adapter = new SqlDataAdapter(query, connection))
                    {
                        adapter.SelectCommand.Parameters.AddWithValue("@TuKhoa", "%" + tuKhoa + "%");
                        DataSet dataSet = new DataSet();
                        adapter.Fill(dataSet);
                        dgvTTPhong.DataSource = dataSet.Tables[0];
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tìm kiếm phòng: " + ex.Message);
            }

        }

        private void TimKiemCoSo(string tuKhoa)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string query = "SELECT * FROM COSO WHERE MACS LIKE @TuKhoa OR TENCS LIKE @TuKhoa";
                    using (SqlDataAdapter adapter = new SqlDataAdapter(query, connection))
                    {
                        adapter.SelectCommand.Parameters.AddWithValue("@TuKhoa", "%" + tuKhoa + "%");
                        DataSet dataSet = new DataSet();
                        adapter.Fill(dataSet);
                        dgvTTCoSo.DataSource = dataSet.Tables[0];
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tìm kiếm cơ sở: " + ex.Message);
            }
        }

        private void btnTaiLaiTTphongcoso_Click(object sender, EventArgs e)
        {
            // Hiển thị lại danh sách Khoa và Ngành
            HienThiDanhSachPhong();
            HienThiDanhSachCoSo();

            // Xóa nội dung các TextBox nhập liệu
            ClearFormCoSo();
            ClearFormPhong();

            // Xóa nội dung tìm kiếm nếu có
            txtTimKiem.Text = "";
        }

        private void btnQuayLaiPhongCoSo_Click(object sender, EventArgs e)
        {
            this.Hide();
            CaiDat caiDat = new CaiDat();
            caiDat.ShowDialog();
        }

        private void LoadMaCoSo()
        {
            string query = "SELECT MACS FROM COSO";
            SqlDataAdapter da = new SqlDataAdapter(query, connectionString);
            DataTable dt = new DataTable();
            da.Fill(dt);

            cmbMaCS.DataSource = dt;
            cmbMaCS.DisplayMember = "MACS";
            cmbMaCS.ValueMember = "MACS";
        }

        private void dgvTTPhong_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvTTPhong.SelectedRows.Count == 0) return;

            DataGridViewRow row = dgvTTPhong.SelectedRows[0];

            txtMaPhong.Text = row.Cells["MAP"].Value?.ToString();
            cmbMaCS.Text = row.Cells["MACS"].Value?.ToString(); 
            txtTenPhong.Text = row.Cells["TENPHONG"].Value?.ToString();
            txtLoaiPhong.Text = row.Cells["LOAIPHONG"].Value?.ToString();
            txtdouutien.Text = row.Cells["DOITUONGUUTIEN"].Value?.ToString();

            
        }

        private void dgvTTCoSo_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvTTCoSo.SelectedRows.Count == 0) return;

            DataGridViewRow row = dgvTTCoSo.SelectedRows[0];

            txtMaCoSo.Text = row.Cells["MACS"].Value?.ToString();
            txtTenCoSo.Text = row.Cells["TENCS"].Value?.ToString();
            txtDiaChiCoSo.Text = row.Cells["DIACHI"].Value?.ToString();

           
        }


    }
}
