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
using System.Windows.Forms.DataVisualization.Charting;

namespace QuanLyThietBiTrongTruongHoc
{
    public partial class ThongKePhieuMuon : Form
    {
        public ThongKePhieuMuon()
        {
            InitializeComponent();
        }

        private void btnThongKeTheoNgay_Click(object sender, EventArgs e)
        {
            // Lấy ngày được chọn từ DateTimePicker
            DateTime ngayDuocChon = datetimeThongKePhieuMuon.Value.Date;

            // Chuỗi kết nối CSDL
            string connectionString = @"Data Source=DESKTOP-T28R5TF\SQLEXPRESS;Initial Catalog=QUANLYTHIETBI;Integrated Security=True";

            // Truy vấn thống kê thiết bị mượn theo ngày
            string query = @"
SELECT 
    PM.MAPM, 
    PM.MASV, 
    PM.MANV, 
    CTPM.MATHIETBI,
    PM.SOLUONGMUON,
    TB.MAP, 
    P.TENPHONG, 
    TB.MADONGTHIETBI, 
    DTB.TENDONGTHIETBI,
    PM.NGAYMUON, 
    PM.NGAYTRA
FROM PHIEUMUON PM
JOIN CHITIETPHIEUMUON CTPM ON PM.MAPM = CTPM.MAPM
JOIN THIETBI TB ON CTPM.MATHIETBI = TB.MATHIETBI
JOIN PHONG P ON TB.MAP = P.MAP
JOIN DONGTHIETBI DTB ON TB.MADONGTHIETBI = DTB.MADONGTHIETBI
WHERE CAST(PM.NGAYMUON AS DATE) = @NgayChon";

            using (SqlConnection conn = new SqlConnection(connectionString))
            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                // Gán tham số ngày
                cmd.Parameters.AddWithValue("@NgayChon", ngayDuocChon);

                // Đổ dữ liệu vào DataTable
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                adapter.Fill(dt);

                // Hiển thị dữ liệu lên DataGridView
                dgvTTThongKe.DataSource = dt;
                // === Vẽ lại biểu đồ theo tổng số lượng mượn ===
                chart1.Series.Clear();
                chart1.Titles.Clear();
                chart1.ChartAreas[0].AxisX.Title = "Tên dòng thiết bị";
                chart1.ChartAreas[0].AxisY.Title = "Tổng số lượng mượn";

                Series series = new Series("Tổng số lượng mượn");
                series.ChartType = SeriesChartType.Column;
                series.IsValueShownAsLabel = true;

                // Nhóm theo TENDONGTHIETBI và cộng dồn SOLUONGMUON
                var grouped = dt.AsEnumerable()
                                .GroupBy(r => r["TENDONGTHIETBI"].ToString())
                                .Select(g => new
                                {
                                    TenDongThietBi = g.Key,
                                    TongSoLuong = g.Sum(x => Convert.ToInt32(x["SOLUONGMUON"]))
                                });

                foreach (var item in grouped)
                {
                    series.Points.AddXY(item.TenDongThietBi, item.TongSoLuong);
                }

                chart1.Series.Add(series);
                chart1.Titles.Add($"Thống kê tổng số lượng mượn theo thiết bị - {ngayDuocChon:dd/MM/yyyy}");
            }
            
        }

        private void btnThongKeTheoTuan_Click(object sender, EventArgs e)
        {
            // Lấy ngày được chọn từ DateTimePicker
            DateTime ngayDuocChon = datetimeThongKePhieuMuon.Value.Date;

            // Xác định ngày bắt đầu (thứ 2) và kết thúc (chủ nhật) trong tuần chứa ngày được chọn
            int daysToMonday = ((int)ngayDuocChon.DayOfWeek + 6) % 7;
            DateTime ngayBatDauTuan = ngayDuocChon.AddDays(-daysToMonday).Date;
            DateTime ngayKetThucTuan = ngayBatDauTuan.AddDays(6).Date;

            // Chuỗi kết nối SQL Server (thay bằng CSDL thật của bạn)
            string connectionString = @"Data Source=DESKTOP-T28R5TF\SQLEXPRESS;Initial Catalog=QUANLYTHIETBI;Integrated Security=True";

            // Truy vấn SQL thống kê theo tuần
            string query = @"
SELECT 
    PM.MAPM, 
    PM.MASV, 
    PM.MANV, 
    CTPM.MATHIETBI, 
    PM.SOLUONGMUON, 
    TB.MAP, 
    P.TENPHONG, 
    TB.MADONGTHIETBI, 
    DTB.TENDONGTHIETBI,
    PM.NGAYMUON, 
    PM.NGAYTRA
FROM PHIEUMUON PM
JOIN CHITIETPHIEUMUON CTPM ON PM.MAPM = CTPM.MAPM
JOIN THIETBI TB ON CTPM.MATHIETBI = TB.MATHIETBI
JOIN PHONG P ON TB.MAP = P.MAP
JOIN DONGTHIETBI DTB ON TB.MADONGTHIETBI = DTB.MADONGTHIETBI
WHERE CAST(PM.NGAYMUON AS DATE) BETWEEN @NgayBatDau AND @NgayKetThuc";

            using (SqlConnection conn = new SqlConnection(connectionString))
            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@NgayBatDau", ngayBatDauTuan);
                cmd.Parameters.AddWithValue("@NgayKetThuc", ngayKetThucTuan);

                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                adapter.Fill(dt);

                // Hiển thị kết quả lên DataGridView
                dgvTTThongKe.DataSource = dt;

                // === Vẽ biểu đồ theo tổng số lượng mượn trong tuần ===
                chart1.Series.Clear();
                chart1.Titles.Clear();
                chart1.ChartAreas[0].AxisX.Title = "Tên dòng thiết bị";
                chart1.ChartAreas[0].AxisY.Title = "Tổng số lượng mượn";

                Series series = new Series("Tổng số lượng mượn");
                series.ChartType = SeriesChartType.Column;
                series.IsValueShownAsLabel = true;

                // Nhóm theo dòng thiết bị và tính tổng số lượng
                var grouped = dt.AsEnumerable()
                                .GroupBy(r => r["TENDONGTHIETBI"].ToString())
                                .Select(g => new
                                {
                                    TenDongThietBi = g.Key,
                                    TongSoLuong = g.Sum(x => Convert.ToInt32(x["SOLUONGMUON"]))
                                });

                foreach (var item in grouped)
                {
                    series.Points.AddXY(item.TenDongThietBi, item.TongSoLuong);
                }

                chart1.Series.Add(series);
                chart1.Titles.Add($"Thống kê theo tuần: {ngayBatDauTuan:dd/MM/yyyy} - {ngayKetThucTuan:dd/MM/yyyy}");
            }
        }

        private void btnQuayLai_Click(object sender, EventArgs e)
        {
            this.Hide();
            ChiTietPhieuMuon chiTietPhieuMuon = new ChiTietPhieuMuon();
            chiTietPhieuMuon.ShowDialog();
        }
    }
}
