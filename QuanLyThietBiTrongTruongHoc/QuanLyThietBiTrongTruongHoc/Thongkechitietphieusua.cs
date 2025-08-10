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
    public partial class Thongkechitietphieusua : Form
    {
        public Thongkechitietphieusua()
        {
            InitializeComponent();
        }

        private void btnThongKeTheoNgay_Click(object sender, EventArgs e)
        {
            DateTime ngayDuocChon = datetimeTKPhieuSua.Value.Date;

            string connectionString = @"Data Source=DESKTOP-T28R5TF\SQLEXPRESS;Initial Catalog=QUANLYTHIETBI;Integrated Security=True";

            string query = @"
SELECT 
    PS.MAPS,
    CTPS.MATHIETBI,
    TB.MADONGTHIETBI,
    DTB.TENDONGTHIETBI,
    TB.MAP,
    P.TENPHONG,
    PS.SOLUONG,
    PS.DONGIA,
    PS.TONGCHIPHI
FROM PHIEUSUA PS
JOIN CHITIETPHIEUSUA CTPS ON PS.MAPS = CTPS.MAPS
JOIN THIETBI TB ON CTPS.MATHIETBI = TB.MATHIETBI
JOIN PHONG P ON TB.MAP = P.MAP
JOIN DONGTHIETBI DTB ON TB.MADONGTHIETBI = DTB.MADONGTHIETBI
WHERE CAST(PS.NGAYLAP AS DATE) = @NgayChon";

            using (SqlConnection conn = new SqlConnection(connectionString))
            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@NgayChon", ngayDuocChon);

                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                adapter.Fill(dt);

                // Hiển thị lên DataGridView
                dgvTTThongKe.DataSource = dt;

                // Tính tổng chi phí
                decimal tongChiPhi = 0;
                foreach (DataRow row in dt.Rows)
                {
                    if (row["TONGCHIPHI"] != DBNull.Value)
                    {
                        tongChiPhi += Convert.ToDecimal(row["TONGCHIPHI"]);
                    }
                }

                // Hiển thị tổng chi phí lên Label
                lblTongTien.Text = $"Tổng chi phí: {tongChiPhi:N0} VNĐ";

                chart1.Series.Clear();
                chart1.Titles.Clear();
                chart1.ChartAreas[0].AxisX.Title = "Dòng thiết bị";
                chart1.ChartAreas[0].AxisY.Title = "Số Lượng Sửa";

                Series series = new Series("Số lượng sửa");
                series.ChartType = SeriesChartType.Column;
                series.IsValueShownAsLabel = true;

                foreach (DataRow row in dt.Rows)
                {
                    string tenDong = row["TENDONGTHIETBI"].ToString();
                    int soLuong = Convert.ToInt32(row["SOLUONG"]);
                    series.Points.AddXY(tenDong, soLuong);
                }

                chart1.Series.Add(series);
                chart1.Titles.Add($"Thống kê số lượng thiết bị sửa - {ngayDuocChon:dd/MM/yyyy}");
            }
        }

        private void btnTKTheoTuan_Click(object sender, EventArgs e)
        {
            // Lấy ngày bắt đầu tuần từ DateTimePicker (không cần tính lại thứ 2 nữa)
            DateTime ngayBatDauTuan = datetimeTKPhieuSua.Value.Date;
            DateTime ngayKetThucTuan = ngayBatDauTuan.AddDays(6);

            string connectionString = @"Data Source=DESKTOP-T28R5TF\SQLEXPRESS;Initial Catalog=QUANLYTHIETBI;Integrated Security=True";

            // Truy vấn thống kê phiếu sửa theo tuần
            string query = @"
SELECT 
    PS.MAPS,
    CTPS.MATHIETBI,
    TB.MADONGTHIETBI,
    DTB.TENDONGTHIETBI,
    TB.MAP,
    P.TENPHONG,
    PS.SOLUONG,
    PS.DONGIA,
    PS.TONGCHIPHI
FROM PHIEUSUA PS
JOIN CHITIETPHIEUSUA CTPS ON PS.MAPS = CTPS.MAPS
JOIN THIETBI TB ON CTPS.MATHIETBI = TB.MATHIETBI
JOIN PHONG P ON TB.MAP = P.MAP
JOIN DONGTHIETBI DTB ON TB.MADONGTHIETBI = DTB.MADONGTHIETBI
WHERE CAST(PS.NGAYLAP AS DATE) BETWEEN @NgayBatDau AND @NgayKetThuc";

            using (SqlConnection conn = new SqlConnection(connectionString))
            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@NgayBatDau", ngayBatDauTuan);
                cmd.Parameters.AddWithValue("@NgayKetThuc", ngayKetThucTuan);

                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                adapter.Fill(dt);

                // Hiển thị dữ liệu lên DataGridView
                dgvTTThongKe.DataSource = dt;

                // === Tính tổng chi phí ===
                decimal tongChiPhiTuan = 0;
                foreach (DataRow row in dt.Rows)
                {
                    if (row["TONGCHIPHI"] != DBNull.Value)
                    {
                        tongChiPhiTuan += Convert.ToDecimal(row["TONGCHIPHI"]);
                    }
                }

                // Hiển thị tổng chi phí trong tuần
                lblTongTien.Text = $"Tổng chi phí sửa trong tuần: {tongChiPhiTuan:N0} VNĐ";

                // === Vẽ biểu đồ theo TENDONGTHIETBI - tổng SOLUONG ===
                chart1.Series.Clear();
                chart1.Titles.Clear();
                chart1.ChartAreas[0].AxisX.Title = "Dòng thiết bị";
                chart1.ChartAreas[0].AxisY.Title = "Tổng số lượng sửa";

                Series series = new Series("Số lượng sửa");
                series.ChartType = SeriesChartType.Column;
                series.IsValueShownAsLabel = true;

                // Gộp và tính tổng số lượng theo TENDONGTHIETBI
                var grouped = dt.AsEnumerable()
                                .GroupBy(r => r["TENDONGTHIETBI"].ToString())
                                .Select(g => new
                                {
                                    TenDong = g.Key,
                                    TongSoLuong = g.Sum(x => Convert.ToInt32(x["SOLUONG"]))
                                });

                foreach (var item in grouped)
                {
                    series.Points.AddXY(item.TenDong, item.TongSoLuong);
                }

                chart1.Series.Add(series);
                chart1.Titles.Add($"Thống kê sửa: {ngayBatDauTuan:dd/MM/yyyy} - {ngayKetThucTuan:dd/MM/yyyy}");
            }
        }

        private void btnQuayLai_Click(object sender, EventArgs e)
        {
            this.Hide();
            ChiTietPhieuSua chiTietPhieuSua = new ChiTietPhieuSua();
            chiTietPhieuSua.ShowDialog();
        }
    }
    
}
