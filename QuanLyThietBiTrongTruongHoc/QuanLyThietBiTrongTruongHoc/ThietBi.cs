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
    public partial class ThietBi : Form
    {
        string connectionString = "Data Source=DESKTOP-T28R5TF\\SQLEXPRESS;Initial Catalog=QUANLYTHIETBI;Integrated Security = True";

        public ThietBi()
        {
            InitializeComponent();
            HienThiDanhSachDongThietBi();
            HienThiDanhSachThietBi();
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
                        dgvTTDongThietBi.DataSource = dataSet.Tables[0];
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi hiển thị danh dòng thiết bị: " + ex.Message);
            }
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
                MessageBox.Show("Lỗi khi hiển thị danh sách thiết bị: " + ex.Message);
            }
        }

        private void btnquaylythietbi_Click(object sender, EventArgs e)
        {
            this.Hide();
            QuanLyThietBi quanLyThietBi = new QuanLyThietBi();
            quanLyThietBi.ShowDialog();
        }

        private void btnquanlydongthietbi_Click(object sender, EventArgs e)
        {
            this.Hide();
            DongThietBi dongThietBi = new DongThietBi();
            dongThietBi.ShowDialog();
        }

        private void btnquanlythietbiquaylai_Click(object sender, EventArgs e)
        {
            this.Hide();
            TrangChu trangChu = new TrangChu();
            trangChu.ShowDialog();
        }

        private void btnThoatquanlythietbi_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn thoát?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void btnTaiLaiThietBi_Click(object sender, EventArgs e)
        {
            HienThiDanhSachDongThietBi();
            HienThiDanhSachThietBi();
        }
    }
}
