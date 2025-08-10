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
    public partial class PhieuMuonSua : Form
    {
        string connectionString = "Data Source=DESKTOP-T28R5TF\\SQLEXPRESS;Initial Catalog=QUANLYTHIETBI;Integrated Security = True";

        public PhieuMuonSua()
        {
            InitializeComponent();
            HienThiDanhSachLapPhieuMuon();
            HienThiDanhSachPhieuSua();
        }

        private void HienThiDanhSachLapPhieuMuon()
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
                        dgvTTDanhSachPhieuMuon.DataSource = dataSet.Tables[0];
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi hiển thị danh sách phiếu mượn: " + ex.Message);
            }
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
                        dgvTTDanhSachPhieuSua.DataSource = dataSet.Tables[0];
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi hiển thị danh sách phiếu sửa: " + ex.Message);
            }
        }

        private void PhieuMuonSua_Load(object sender, EventArgs e)
        {

        }
        private void btnquanlyphieumuon_Click(object sender, EventArgs e)
        {
            this.Hide();
            LapPhieuMuon lapPhieuMuon = new LapPhieuMuon();
            lapPhieuMuon.ShowDialog();
        }

        private void btnquanlyphieusua_Click(object sender, EventArgs e)
        {
            this.Hide();
            LapPhieuSua lapPhieuSua = new LapPhieuSua();
            lapPhieuSua.ShowDialog();
        }

        private void btnTaiLaiPhieuMuonSua_Click(object sender, EventArgs e)
        {
            PhieuMuonSua_Load(sender, e);
        }

        private void btnquanlyphieumuonsuaquaylai_Click(object sender, EventArgs e)
        {
            this.Hide();
            TrangChu trangChu = new TrangChu();
            trangChu.ShowDialog();
        }

        private void btnThoatquanlyphieumuon_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn thoát?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                Application.Exit();
            }
        }
    }
}
