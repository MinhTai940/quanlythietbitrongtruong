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
    public partial class ThongKe : Form
    {
        string connectionString = "Data Source=DESKTOP-T28R5TF\\SQLEXPRESS;Initial Catalog=QUANLYTHIETBI;Integrated Security = True";

        public ThongKe()
        {
            InitializeComponent();
            HienThiDanhSachChiTietPhieuMuon();
            HienThiDanhSachChiTietPhieuSua();
        }

        private void HienThiDanhSachChiTietPhieuMuon()
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string query = @"
        SELECT 
            PM.MAPM AS [MÃ PHIẾU MƯỢN],
            CT.MATHIETBI AS [MÃ THIẾT BỊ],
            TB.MAP AS [MÃ PHÒNG],
            P.TENPHONG AS [TÊN PHÒNG],
            TB.MADONGTHIETBI AS [MÃ DÒNG THIẾT BỊ],
            D.TENDONGTHIETBI AS [TÊN DÒNG THIẾT BỊ],
            SV.MASV AS [MÃ SINH VIÊN],
            SV.TENSV AS [TÊN SINH VIÊN],
            PM.NGAYMUON AS [NGÀY MƯỢN],
            PM.NGAYTRA AS [NGÀY TRẢ],
            PM.NGAYLAPPHIEU AS [NGÀY LẬP PHIẾU],
            PM.SOLUONGMUON AS [SỐ LƯỢNG MƯỢN]
        FROM CHITIETPHIEUMUON CT
        JOIN PHIEUMUON PM ON PM.MAPM = CT.MAPM
        JOIN THIETBI TB ON TB.MATHIETBI = CT.MATHIETBI
        JOIN DONGTHIETBI D ON D.MADONGTHIETBI = TB.MADONGTHIETBI
        JOIN PHONG P ON P.MAP = TB.MAP
        JOIN SINHVIEN SV ON SV.MASV = PM.MASV";

                    using (SqlDataAdapter adapter = new SqlDataAdapter(query, connection))
                    {
                        DataSet dataSet = new DataSet();
                        adapter.Fill(dataSet);
                        dgvTTchitietphieumuon.DataSource = dataSet.Tables[0];
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi hiển thị danh sách chi tiết phiếu mượn: " + ex.Message);
            }
        }

        private void HienThiDanhSachChiTietPhieuSua()
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string query = @"
SELECT 
    PS.MAPS AS [MÃ PHIẾU SỬA],
    CT.MATHIETBI AS [MÃ THIẾT BỊ],
    TB.MADONGTHIETBI AS [MÃ DÒNG THIẾT BỊ],
    DTB.TENDONGTHIETBI AS [TÊN DÒNG THIẾT BỊ],
    TB.MAP AS [MÃ PHÒNG],
    P.TENPHONG AS [TÊN PHÒNG],
    PS.NGAYLAP AS [NGÀY LẬP PHIẾU],
    PS.SOLUONG AS [SỐ LƯỢNG],
    PS.DONGIA AS [ĐƠN GIÁ],
    PS.TONGCHIPHI AS [TỔNG CHI PHÍ]
FROM CHITIETPHIEUSUA CT
JOIN PHIEUSUA PS ON CT.MAPS = PS.MAPS
JOIN THIETBI TB ON CT.MATHIETBI = TB.MATHIETBI
JOIN DONGTHIETBI DTB ON TB.MADONGTHIETBI = DTB.MADONGTHIETBI
JOIN PHONG P ON TB.MAP = P.MAP";

                    using (SqlDataAdapter adapter = new SqlDataAdapter(query, connection))
                    {
                        DataSet dataSet = new DataSet();
                        adapter.Fill(dataSet);
                        dgvchitietphieusua.DataSource = dataSet.Tables[0];
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi hiển thị danh sách chi tiết phiếu sửa: " + ex.Message);
            }
        }

        private void ThongKe_Load(object sender, EventArgs e)
        {

        }

        private void btnchitetphieumuon_Click(object sender, EventArgs e)
        {
            this.Hide();
            ChiTietPhieuMuon chiTietPhieuMuon = new ChiTietPhieuMuon();
            chiTietPhieuMuon.Show();
        }

        private void btnchitiephieusua_Click(object sender, EventArgs e)
        {
            this.Hide();
            ChiTietPhieuSua chiTietPhieuSua = new ChiTietPhieuSua();
            chiTietPhieuSua.Show();
        }

        private void btnTaiLaiThongKe_Click(object sender, EventArgs e)
        {
            HienThiDanhSachChiTietPhieuMuon();
            HienThiDanhSachChiTietPhieuSua();
        }


        private void btnquaylaithongke_Click(object sender, EventArgs e)
        {
            this.Hide();
            TrangChu trangChu = new TrangChu();
            trangChu.Show();
        }

        private void btnthoatthongke_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn thoát?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                Application.Exit();
            }
        }
    }
}
