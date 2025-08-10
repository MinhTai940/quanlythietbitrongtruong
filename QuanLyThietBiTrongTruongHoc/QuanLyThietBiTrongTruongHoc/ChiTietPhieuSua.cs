using iTextSharp.text.pdf;
using iTextSharp.text;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyThietBiTrongTruongHoc
{
    public partial class ChiTietPhieuSua : Form
    {
        string connectionString = "Data Source=DESKTOP-T28R5TF\\SQLEXPRESS;Initial Catalog=QUANLYTHIETBI;Integrated Security = True";
        public ChiTietPhieuSua()
        {
            InitializeComponent();
            HienThiDanhSachChiTietPhieuSua();
            HienThiDanhSachLichSuPhieuSua();
            LoadMaPhieuSua();
            LoadMaThietBi();
            
        }

        private void HienThiDanhSachChiTietPhieuSua()
        {
            try
            {
                // Kiểm tra cả hai combobox đều được chọn
                if (cmbMaPhieuSua.SelectedItem == null || cmbMaThietBi.SelectedItem == null)
                    return;

                string maps = cmbMaPhieuSua.SelectedValue.ToString();
                string mathietbi = cmbMaThietBi.SelectedValue.ToString();

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
JOIN PHONG P ON TB.MAP = P.MAP
WHERE CT.MAPS = @maps AND CT.MATHIETBI = @mathietbi";

                using (SqlConnection conn = new SqlConnection(connectionString))
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@maps", maps);
                    cmd.Parameters.AddWithValue("@mathietbi", mathietbi);

                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);

                    dgvTTChiTietPhieuSua.DataSource = dt;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi hiển thị danh sách chi tiết phiếu sửa: " + ex.Message);
            }
        }

        private void HienThiDanhSachLichSuPhieuSua()
        {
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

            using (SqlConnection conn = new SqlConnection(connectionString))
            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                dgvLichSu.DataSource = dt; // Đổi tên này thành tên DataGridView của bạn nếu khác
            }
        }

        private void btnXuatExcel_Click(object sender, EventArgs e)
        {
            // Kiểm tra dữ liệu rỗng
            if (dgvLichSu.Rows.Count <= 1 || dgvLichSu.Rows.Cast<DataGridViewRow>().All(row => row.IsNewRow))
            {
                MessageBox.Show("Không có dữ liệu để xuất!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Khởi tạo ứng dụng Excel
            Microsoft.Office.Interop.Excel.Application excel = GetExcel();
            Microsoft.Office.Interop.Excel.Workbook workbook = excel.Workbooks.Add();
            Microsoft.Office.Interop.Excel.Worksheet worksheet = workbook.ActiveSheet;

            try
            {
                // Ghi tiêu đề cột từ DataGridView
                for (int j = 0; j < dgvLichSu.Columns.Count; j++)
                {
                    worksheet.Cells[1, j + 1] = dgvLichSu.Columns[j].HeaderText;
                    worksheet.Cells[1, j + 1].Font.Bold = true;
                    worksheet.Cells[1, j + 1].Interior.Color = System.Drawing.Color.LightGray.ToArgb(); // Màu nền
                }

                // Ghi dữ liệu từ DataGridView
                for (int i = 0; i < dgvLichSu.Rows.Count - 1; i++)
                {
                    for (int j = 0; j < dgvLichSu.Columns.Count; j++)
                    {
                        var cellValue = dgvLichSu.Rows[i].Cells[j].Value?.ToString();
                        worksheet.Cells[i + 2, j + 1] = cellValue;

                        // Định dạng ngày nếu dữ liệu là ngày
                        if (DateTime.TryParse(cellValue, out DateTime dateValue))
                        {
                            worksheet.Cells[i + 2, j + 1].NumberFormat = "dd/MM/yyyy";
                            worksheet.Cells[i + 2, j + 1].Value = dateValue;
                        }
                    }
                }

                // Tự động điều chỉnh cột
                worksheet.Columns.AutoFit();

                // Chọn nơi lưu file
                SaveFileDialog sfd = new SaveFileDialog();
                sfd.Filter = "Excel Files|*.xlsx";
                sfd.Title = "Lưu file Excel";
                sfd.FileName = $"ChiTietPhieuSua_{DateTime.Now:ddMMyyyy_HHmm}.xlsx"; // Ví dụ: ChiTietPhieuMuon_28052025_1909.xlsx

                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    workbook.SaveAs(sfd.FileName);
                    MessageBox.Show("Xuất Excel thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi xuất file: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                // Đóng và giải phóng tài nguyên
                workbook.Close();
                excel.Quit();

                // Giải phóng COM object
                System.Runtime.InteropServices.Marshal.ReleaseComObject(worksheet);
                System.Runtime.InteropServices.Marshal.ReleaseComObject(workbook);
                System.Runtime.InteropServices.Marshal.ReleaseComObject(excel);

                // Thu gom rác
                GC.Collect();
                GC.WaitForPendingFinalizers();
            }
        }
        private static Microsoft.Office.Interop.Excel.Application GetExcel()
        {
            return new Microsoft.Office.Interop.Excel.Application();
        }

        //private void ExportDataGridViewToPDF(DataGridView dgv, string fileName)
        //{
        //    if (dgv.Rows.Count == 0)
        //    {
        //        MessageBox.Show("Không có dữ liệu để xuất.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        //        return;
        //    }

        //    try
        //    {
        //        Document document = new Document(PageSize.A4.Rotate(), 10f, 10f, 10f, 10f);
        //        PdfWriter writer = PdfWriter.GetInstance(document, new FileStream(fileName, FileMode.Create));
        //        document.Open();

        //        // Font tiếng Việt
        //        string fontPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Fonts), "arial.ttf");
        //        BaseFont bf = BaseFont.CreateFont(fontPath, BaseFont.IDENTITY_H, BaseFont.EMBEDDED);
        //        iTextSharp.text.Font font = new iTextSharp.text.Font(bf, 12);
        //        iTextSharp.text.Font fontTitle = new iTextSharp.text.Font(bf, 16, iTextSharp.text.Font.BOLD);
        //        PdfPTable table = new PdfPTable(dgv.Columns.Count);
        //        table.WidthPercentage = 100;


        //        // Thêm tiêu đề
        //        Paragraph title = new Paragraph("DANH SÁCH PHIẾU SỬA THIẾT BỊ", fontTitle);
        //        title.Alignment = Element.ALIGN_CENTER;
        //        title.SpacingAfter = 10f;
        //        document.Add(title);

        //        // Thêm tiêu đề cột
        //        foreach (DataGridViewColumn column in dgv.Columns)
        //        {
        //            PdfPCell cell = new PdfPCell(new Phrase(column.HeaderText, font));
        //            cell.BackgroundColor = BaseColor.LIGHT_GRAY;
        //            table.AddCell(cell);
        //        }

        //        // Thêm dữ liệu từng dòng
        //        foreach (DataGridViewRow row in dgv.Rows)
        //        {
        //            if (!row.IsNewRow)
        //            {
        //                foreach (DataGridViewCell cell in row.Cells)
        //                {
        //                    table.AddCell(new Phrase(cell.Value?.ToString() ?? "", font));
        //                }
        //            }
        //        }

        //        document.Add(table);
        //        document.Close();

        //        MessageBox.Show("Xuất file PDF thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show("Lỗi khi xuất PDF: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //    }
        //}
        //private void btnXuatPDF_Click(object sender, EventArgs e)
        //{
        //    SaveFileDialog sfd = new SaveFileDialog();
        //    sfd.Filter = "PDF files (*.pdf)|*.pdf";
        //    sfd.FileName = "DanhSachPhieuMuon.pdf";

        //    if (sfd.ShowDialog() == DialogResult.OK)
        //    {
        //        ExportDataGridViewToPDF(dgvTTChiTietPhieuSua, sfd.FileName);
        //    }
        //}

        private void btnTaiLai_Click(object sender, EventArgs e)
        {
            HienThiDanhSachChiTietPhieuSua();
            HienThiDanhSachLichSuPhieuSua();

        }
        private void LoadMaPhieuSua()
        {
            string query = "SELECT MAPS FROM PHIEUSUA";
            SqlDataAdapter da = new SqlDataAdapter(query, connectionString);
            DataTable dt = new DataTable();
            da.Fill(dt);

            cmbMaPhieuSua.DataSource = dt;
            cmbMaPhieuSua.DisplayMember = "MAPS";  // Hiển thị MaKhoa luôn
            cmbMaPhieuSua.ValueMember = "MAPS";
        }
        private void LoadMaThietBi()
        {
            string query = "SELECT MATHIETBI FROM THIETBI";
            SqlDataAdapter da = new SqlDataAdapter(query, connectionString);
            DataTable dt = new DataTable();
            da.Fill(dt);

            cmbMaThietBi.DataSource = dt;
            cmbMaThietBi.DisplayMember = "MATHIETBI";  // Hiển thị MaKhoa luôn
            cmbMaThietBi.ValueMember = "MATHIETBI";
        }
        private void btnQuayLaiChiTietPM_Click(object sender, EventArgs e)
        {
            this.Hide();
            ThongKe thongKe = new ThongKe();
            thongKe.ShowDialog();
        }

        private void btnCapNhat_Click(object sender, EventArgs e)
        {
            if (cmbMaPhieuSua.SelectedItem == null || cmbMaThietBi.SelectedItem == null)
            {
                MessageBox.Show("Vui lòng chọn đầy đủ Mã Phiếu Mượn và Mã Thiết Bị.");
                return;
            }

            string maps = cmbMaPhieuSua.SelectedValue.ToString();
            string mathietbi = cmbMaThietBi.SelectedValue.ToString();

            string insertQuery = "INSERT INTO CHITIETPHIEUSUA (MAPS, MATHIETBI) VALUES (@maps, @mathietbi)";

            using (SqlConnection conn = new SqlConnection(connectionString))
            using (SqlCommand cmd = new SqlCommand(insertQuery, conn))
            {
                cmd.Parameters.AddWithValue("@maps", maps);
                cmd.Parameters.AddWithValue("@mathietbi", mathietbi);

                conn.Open();
                try
                {
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Thêm dữ liệu thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    HienThiDanhSachChiTietPhieuSua();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi thêm dữ liệu: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnXoaThongTinPhieuSua_Click(object sender, EventArgs e)
        {
            //if (cmbMaPhieuSua.SelectedItem == null || cmbMaThietBi.SelectedItem == null)
            //{
            //    MessageBox.Show("Vui lòng chọn đầy đủ Mã Phiếu Mượn và Mã Thiết Bị.");
            //    return;
            //}
            if (dgvLichSu.SelectedRows.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn phiếu mượn cần xóa!");
                return;
            }

            string maps = cmbMaPhieuSua.SelectedValue.ToString();
            string mathietbi = cmbMaThietBi.SelectedValue.ToString();

            DialogResult result = MessageBox.Show("Bạn có chắc muốn xóa bản ghi này?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (result == DialogResult.Yes)
            {
                string deleteQuery = "DELETE FROM CHITIETPHIEUSUA WHERE MAPS = @maps AND MATHIETBI = @mathietbi";

                using (SqlConnection conn = new SqlConnection(connectionString))
                using (SqlCommand cmd = new SqlCommand(deleteQuery, conn))
                {
                    cmd.Parameters.AddWithValue("@maps", maps);
                    cmd.Parameters.AddWithValue("@mathietbi", mathietbi);

                    conn.Open();
                    try
                    {
                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Xóa dữ liệu thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        HienThiDanhSachChiTietPhieuSua();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Lỗi khi xóa dữ liệu: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void cmbMaPhieuSua_SelectedIndexChanged(object sender, EventArgs e)
        {
            HienThiDanhSachChiTietPhieuSua();
        }

        private void cmbMaThietBi_SelectedIndexChanged(object sender, EventArgs e)
        {
            HienThiDanhSachChiTietPhieuSua();
        }

        private void btnTKphieusua_Click(object sender, EventArgs e)
        {
            this.Hide();
            Thongkechitietphieusua thongkechitietphieusua = new Thongkechitietphieusua();
            thongkechitietphieusua.ShowDialog();
        }

        private void ChiTietPhieuSua_Load(object sender, EventArgs e)
        {
            // Phân quyền cho form CaiDat
            if (Session.LoaiTaiKhoan.Trim().ToLower() == "nhân viên" || Session.LoaiTaiKhoan.Trim().ToLower() == "nhan vien")
            {
                btnCapNhat.Enabled = true;
                btnXoaThongTinPhieuSua.Enabled = true;
                btnTaiLai.Enabled = true;
                btnTKphieusua.Enabled = false;
                btnXuatFileExcel.Enabled = true;
                btnQuayLaiChiTietPM.Enabled = true;
                MessageBox.Show("Bạn đang dùng tài khoản Nhân viên - một số chức năng bị hạn chế.",
                "Thông báo phân quyền",
                MessageBoxButtons.OK,
                MessageBoxIcon.Warning);
            }
            else if (Session.LoaiTaiKhoan.Trim().ToLower() == "admin")
            {
                btnCapNhat.Enabled = true;
                btnXoaThongTinPhieuSua.Enabled = true;
                btnTaiLai.Enabled = true;
                btnTKphieusua.Enabled = false;
                btnXuatFileExcel.Enabled = true;
                btnQuayLaiChiTietPM.Enabled = true;
                MessageBox.Show("Tài khoản Admin – toàn quyền truy cập.",
                "Thông báo phân quyền",
                MessageBoxButtons.OK,
                MessageBoxIcon.Warning);
            }
        }
    }
}
