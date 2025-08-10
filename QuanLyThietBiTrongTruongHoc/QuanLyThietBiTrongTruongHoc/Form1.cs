using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyThietBiTrongTruongHoc
{
    public partial class TrangChu : Form
    {
        
        public TrangChu()
        {
            InitializeComponent();
          
        }

        private void btnQuanLyThietBi_Click(object sender, EventArgs e)
        {
            this.Hide();
            ThietBi thietBi = new ThietBi();
            thietBi.ShowDialog();
        }

        private void btnQuanLyPhieuMuon_Click(object sender, EventArgs e)
        {
            this.Hide();
            PhieuMuonSua phieuMuonSua = new PhieuMuonSua();
            phieuMuonSua.ShowDialog();
        }

        private void btnBaoCaoThongKe_Click(object sender, EventArgs e)
        {
            this.Hide();
            ThongKe thongKe = new ThongKe();
            thongKe.ShowDialog();
        }

        private void btnCaiDat_Click(object sender, EventArgs e)
        {
            this.Hide();
            CaiDat caiDat = new CaiDat();
            caiDat.ShowDialog();
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn thoát?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                this.Hide();
                DangNhap dangNhap = new DangNhap();
                dangNhap.ShowDialog();
            }
        }

        private void btnTimKiemForm_Click(object sender, EventArgs e)
        {
            string keyword = txtTimKiemForm.Text.Trim().ToLower();

            if (string.IsNullOrEmpty(keyword))
            {
                MessageBox.Show("Vui lòng nhập từ khóa tìm kiếm.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

        
            if (keyword.Contains("thiết bị") || keyword.Contains("thiet bi"))
            {
                this.Hide();
                ThietBi thietBi = new ThietBi();
                thietBi.ShowDialog();
            }
            
            else if (keyword.Contains("phiếu mượn sửa") || keyword.Contains("phieu mươn sua"))
            {
                this.Hide();
                PhieuMuonSua phieuMuonSua = new PhieuMuonSua();
                phieuMuonSua.ShowDialog();
            }
            
            else if (keyword.Contains("thống kê") || keyword.Contains("thong ke"))
            {
                this.Hide();
                ThongKe thongKe = new ThongKe();
                thongKe.ShowDialog();
            }

            else if (keyword.Contains("cài đặt") || keyword.Contains("cai dat"))
            {
                this.Hide();
                CaiDat caiDat = new CaiDat();
                caiDat.ShowDialog();
            }

            else if (keyword.Contains("chi tiết phiếu mượn") || keyword.Contains("chi tiet phieu muon"))
            {
                this.Hide();
                ChiTietPhieuMuon chiTietPhieuMuon = new ChiTietPhieuMuon();
                chiTietPhieuMuon.ShowDialog();
            }

            else if (keyword.Contains("chi tiết phiếu sửa") || keyword.Contains("chi tiet phieu sua"))
            {
                this.Hide();
                ChiTietPhieuSua chiTietPhieuSua = new ChiTietPhieuSua();
                chiTietPhieuSua.ShowDialog();
            }

            else if (keyword.Contains("dòng thiết bị") || keyword.Contains("dong thiet bi"))
            {
                this.Hide();
                DongThietBi dongThietBi = new DongThietBi();
                dongThietBi.ShowDialog();
            }

            else if (keyword.Contains("khoa") || keyword.Contains("khoa"))
            {
                this.Hide();
                Khoa khoa = new Khoa();
                khoa.ShowDialog();
            }

            else if (keyword.Contains("lập phiếu mượn") || keyword.Contains("lap phieu muon"))
            {
                this.Hide();
                LapPhieuMuon lapPhieuMuon = new LapPhieuMuon();
                lapPhieuMuon.ShowDialog();
            }

            else if (keyword.Contains("lập phiếu sửa") || keyword.Contains("lap phieu sua"))
            {
                this.Hide();
                LapPhieuSua lapPhieuSua = new LapPhieuSua();
                lapPhieuSua.ShowDialog();
            }

            else if (keyword.Contains("nhân viên") || keyword.Contains("nhan vien"))
            {
                this.Hide();
                NhanVien nhanVien = new NhanVien();
                nhanVien.ShowDialog();
            }

            else if (keyword.Contains("phòng") || keyword.Contains("phong"))
            {
                this.Hide();
                Phong phong = new Phong();
                phong.ShowDialog();
            }

            else if (keyword.Contains("tài khoản") || keyword.Contains("tai khoan"))
            {
                this.Hide();
                QuanLyTaiKhoan quanLyTaiKhoan = new QuanLyTaiKhoan();
                quanLyTaiKhoan.ShowDialog();
            }

            else if (keyword.Contains("quản lý thiết bị") || keyword.Contains("quan ly thiet bi"))
            {
                this.Hide();
                QuanLyThietBi quanLyThietBi = new QuanLyThietBi();
                quanLyThietBi.ShowDialog();
            }

            else if (keyword.Contains("sinh viên") || keyword.Contains("sinh vien"))
            {
                this.Hide();
                SinhVien sinhVien = new SinhVien();
                sinhVien.ShowDialog();
            }


            else
            {
                MessageBox.Show("Không tìm thấy form phù hợp với từ khóa.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

        }

        private void TrangChu_Load(object sender, EventArgs e)
        {
            //lblWelcome.Text = "Xin chào: " + Session.TenDangNhap + " (" + Session.LoaiTaiKhoan + ")";

            if (Session.LoaiTaiKhoan.Trim().ToLower() == "nhân viên" || Session.LoaiTaiKhoan.Trim().ToLower() == "nhan vien")
            {
                // Ẩn các nút chỉ dành cho admin
                btnQuanLyPhieuMuon.Visible = true;
                btnCaiDat.Visible = true;
                btnThoat.Visible = true;
                btnTrangChu.Visible = true;
                btnQuanLyThietBi.Visible = true;
                btnBaoCaoThongKe.Visible = true;
            }
            else if (Session.LoaiTaiKhoan.Trim().ToLower() == "admin")
            {
                // Admin thấy tất cả
                btnQuanLyPhieuMuon.Visible = true;
                btnCaiDat.Visible = true;
                btnThoat.Visible = true;
                btnTrangChu.Visible = true;
                btnQuanLyThietBi.Visible = true;
                btnBaoCaoThongKe.Visible = true;

            }
        }
    }
}
