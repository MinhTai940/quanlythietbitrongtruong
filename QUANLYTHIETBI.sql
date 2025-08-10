create database QUANLYTHIETBI

-- Tạo Bảng KHOA
CREATE TABLE KHOA (
    MAKHOA VARCHAR(10) PRIMARY KEY,
    TENKHOA NVARCHAR(100)
);

-- Tạo bảng NGANH
CREATE TABLE NGANH (
    MANGANH VARCHAR(10) PRIMARY KEY,
    TENNGANH NVARCHAR(100)
   
);

-- Tạo bảng TAIKHOAN
CREATE TABLE TAIKHOAN (
    MATK NVARCHAR(100) PRIMARY KEY,
    MATKHAU VARCHAR(10),
    LOAITK VARCHAR(20),
);

-- Tạo bảng SINHVIEN
CREATE TABLE SINHVIEN (
    MASV VARCHAR(10) PRIMARY KEY,
    TENSV NVARCHAR(100),
    MANGANH VARCHAR(10),
	MAKHOA VARCHAR(10),
    EMAIL VARCHAR(100),
    SDT VARCHAR(15),
    NGAYSINH DATE,
    DIACHI NVARCHAR(255),
	GIOITINH VARCHAR(10),
    FOREIGN KEY (MANGANH) REFERENCES NGANH(MANGANH),
    FOREIGN KEY (MAKHOA) REFERENCES KHOA(MAKHOA),
	
);

-- Tạo bảng NHANVIEN
CREATE TABLE NHANVIEN (
    MANV VARCHAR(10) PRIMARY KEY,
    HOTEN NVARCHAR(100),
    GIOITINH NVARCHAR(10),
    NGAYSINH DATE,
    EMAIL VARCHAR(100),
    DIACHI NVARCHAR(255),
);

-- Tạo bảng COSO
CREATE TABLE COSO (
    MACS VARCHAR(10) PRIMARY KEY,
    TENCS NVARCHAR(100),
    DIACHI NVARCHAR(255)
);

--Tạo bảng PHONG
CREATE TABLE PHONG (
    MAP VARCHAR(10) PRIMARY KEY,
	MACS VARCHAR(10),
    TENPHONG NVARCHAR(100),
    LOAIPHONG NVARCHAR(50),
    DOITUONGUUTIEN NVARCHAR(100)
	FOREIGN KEY (MACS) REFERENCES COSO(MACS)
);

-- Tạo bảng DONGTHIETBI
CREATE TABLE DONGTHIETBI (
    MADONGTHIETBI VARCHAR(10) PRIMARY KEY,
    TENDONGTHIETBI NVARCHAR(100),
    SOLUONG INT,
    MOTA NVARCHAR(255)
);

-- Tạo bảng THIETBI
CREATE TABLE THIETBI (
    MATHIETBI VARCHAR(10) PRIMARY KEY,
    SERI VARCHAR(50),
    MAP VARCHAR(10),
    MADONGTHIETBI VARCHAR(10),
    TRANGTHAI NVARCHAR(50),
    FOREIGN KEY (MAP) REFERENCES PHONG(MAP),
    FOREIGN KEY (MADONGTHIETBI) REFERENCES DONGTHIETBI(MADONGTHIETBI)
);

-- Tạo bảng PHIEUMUON
CREATE TABLE PHIEUMUON (
    MAPM VARCHAR(10) PRIMARY KEY,
	NGAYMUON DATE,
    NGAYLAPPHIEU DATE,
	NGAYTRA DATE,
    MANV VARCHAR(10),
    MASV VARCHAR(10),
	TRANGTHAI NVARCHAR(255),
    LYDOMUON NVARCHAR(255),
	LYDOTUCHOI NVARCHAR(255),
    LYDOHUY NVARCHAR(255),
	SOLUONGMUON INT,
    FOREIGN KEY (MANV) REFERENCES NHANVIEN(MANV),
    FOREIGN KEY (MASV) REFERENCES SINHVIEN(MASV)
);

-- Tạo bảng CHITIETPHIEUMUON
CREATE TABLE CHITIETPHIEUMUON (
    MAPM VARCHAR(10),
    MATHIETBI VARCHAR(10),
	PRIMARY KEY (MAPM, MATHIETBI),
    FOREIGN KEY (MAPM) REFERENCES PHIEUMUON(MAPM),
    FOREIGN KEY (MATHIETBI) REFERENCES THIETBI(MATHIETBI)
);

CREATE TABLE PHIEUSUA (
    MAPS VARCHAR(10) PRIMARY KEY,
    TRANGTHAI NVARCHAR(50),
    NGAYLAP DATE,
    MOTA NVARCHAR(255),
    SOLUONG INT,
    DONGIA DECIMAL(10,2),
    TONGCHIPHI AS (SOLUONG * DONGIA) PERSISTED
);


-- Tạo bảng CHITIETPHIEUSUA
CREATE TABLE CHITIETPHIEUSUA (
    MAPS VARCHAR(10),
    MATHIETBI VARCHAR(10),
    PRIMARY KEY (MAPS, MATHIETBI),
    FOREIGN KEY (MAPS) REFERENCES PHIEUSUA(MAPS),
    FOREIGN KEY (MATHIETBI) REFERENCES THIETBI(MATHIETBI)
);
-- Thêm sữ liệu vào bảng tài khoản
INSERT INTO TAIKHOAN (MATK, MATKHAU, LOAITK) VALUES
('hovuminhtai@gmail.com', '225736', 'Admin'),
('duongminhtan@gmail.com', '222309', 'Admin');

-- Thêm dữ liệu vào bảng KHOA
INSERT INTO KHOA (MAKHOA, TENKHOA) VALUES
('CNTT', N'Công Nghệ Thông Tin'),
('QTKD', N'Quản Trị Kinh Doanh'),
('KT',   N'Kế Toán'),
('NN',   N'Ngôn Ngữ'),
('LUAT', N'Luật'),
('YH',   N'Y Học'),
('SP',   N'Sư Phạm'),
('XD',   N'Xây Dựng');

-- Thêm dữ liệu vào bảng NGANH
INSERT INTO NGANH (MANGANH, TENNGANH) VALUES
('CNTT01', N'Kỹ thuật phần mềm'),
('CNTT02', N'Khoa học máy tính'),
('QTKD01', N'Quản trị doanh nghiệp'),
('KT01',   N'Kế toán tài chính'),
('NN01',   N'Tiếng Anh'),
('LUAT01', N'Luật hình sự'),
('YH01',   N'Y đa khoa'),
('SP01',   N'Sư phạm Toán'),
('XD01',   N'Kỹ thuật xây dựng');

-- Thêm dữ liệu mẫu vào bảng SINHVIEN
INSERT INTO SINHVIEN (MASV, TENSV, MANGANH, MAKHOA, EMAIL, SDT, NGAYSINH, DIACHI, GIOITINH) VALUES
('SV001', N'Nguyễn Văn An', 'CNTT01', 'CNTT', 'an.nguyen@example.com', '0912345678', '2003-01-15', N'Hà Nội', 'Nam'),
('SV002', N'Trần Thị Bình', 'QTKD01', 'QTKD', 'binh.tran@example.com', '0987654321', '2002-07-20', N'TP. Hồ Chí Minh', 'Nữ'),
('SV003', N'Lê Văn Cường', 'KT01', 'KT', 'cuong.le@example.com', '0901122334', '2001-05-30', N'Đà Nẵng', 'Nam'),
('SV004', N'Phạm Thị Dung', 'NN01', 'NN', 'dung.pham@example.com', '0933445566', '2003-09-12', N'Cần Thơ', 'Nữ'),
('SV005', N'Hoàng Minh Đức', 'XD01', 'XD', 'duc.hoang@example.com', '0966554433', '2002-11-03', N'Hải Phòng', 'Nam');

-- Thêm dữ liệu mẫu vào bảng NHANVIEN
INSERT INTO NHANVIEN (MANV, HOTEN, GIOITINH, NGAYSINH, EMAIL, DIACHI) VALUES
('NV001', N'Nguyễn Văn An',    N'Nam', '1985-04-10', 'an.nguyen@truong.edu.vn',    N'Hà Nội'),
('NV002', N'Lê Thị Bình',      N'Nữ', '1990-08-25', 'binh.le@truong.edu.vn',       N'TP. Hồ Chí Minh'),
('NV003', N'Trần Văn Cường',   N'Nam', '1982-12-15', 'cuong.tran@truong.edu.vn',    N'Đà Nẵng'),
('NV004', N'Phạm Thị Dung',    N'Nữ', '1988-06-05', 'dung.pham@truong.edu.vn',     N'Cần Thơ'),
('NV005', N'Hoàng Minh Đức',   N'Nam', '1993-02-28', 'duc.hoang@truong.edu.vn',     N'Hải Phòng');


INSERT INTO COSO (MACS, TENCS, DIACHI) VALUES
('CS001', N'Cơ sở Hà Nội', N'Số 1 Đại Cồ Việt, Hai Bà Trưng, Hà Nội'),
('CS002', N'Cơ sở TP. Hồ Chí Minh', N'12 Nguyễn Văn Bảo, Gò Vấp, TP. Hồ Chí Minh'),
('CS003', N'Cơ sở Đà Nẵng', N'54 Nguyễn Lương Bằng, Liên Chiểu, Đà Nẵng'),
('CS004', N'Cơ sở Cần Thơ', N'3/2, Ninh Kiều, Cần Thơ'),
('CS005', N'Cơ sở Hải Phòng', N'Số 45 Trần Nguyên Hãn, Lê Chân, Hải Phòng');


INSERT INTO PHONG (MAP, MACS, TENPHONG, LOAIPHONG, DOITUONGUUTIEN) VALUES
('P001', 'CS001', N'Phòng I2-02', N'Phòng học lý thuyết', N'Sinh viên nghèo vượt khó'),
('P002', 'CS001', N'Phòng I3-02', N'Phòng học máy tính', N'Sinh viên xuất sắc'),
('P003', 'CS002', N'Phòng A4-06', N'Phòng thí nghiệm', N'Sinh viên nghiên cứu khoa học'),
('P004', 'CS003', N'Phòng B1-01', N'Phòng thực hành', N'Sinh viên miền núi'),
('P005', 'CS004', N'Phòng E5-06', N'Phòng đa năng', N'Con em thương binh liệt sĩ');

INSERT INTO DONGTHIETBI (MADONGTHIETBI, TENDONGTHIETBI, SOLUONG, MOTA) VALUES
('DTB001', N'Máy chiếu Epson X123', 10, N'Máy chiếu dùng cho giảng đường'),
('DTB002', N'Máy in HP LaserJet P1102', 5, N'Máy in sử dụng cho văn phòng khoa'),
('DTB003', N'Máy tính bàn Dell Optiplex 7080', 20, N'Dùng trong phòng máy tính'),
('DTB004', N'Micro không dây Shure BLX288', 8, N'Thiết bị âm thanh cho hội trường'),
('DTB005', N'Camera an ninh Hikvision DS-2CE1', 12, N'Camera giám sát hành lang');

INSERT INTO THIETBI (MATHIETBI, SERI, MAP, MADONGTHIETBI, TRANTHAI) VALUES
('TB001', 'SERI001', 'P001', 'DTB001', N'Hoạt động tốt'),
('TB002', 'SERI002', 'P001', 'DTB002', N'Hoạt động tốt'),
('TB003', 'SERI003', 'P002', 'DTB003', N'Hỏng cần sửa'),
('TB004', 'SERI004', 'P003', 'DTB004', N'Hoạt động tốt'),
('TB005', 'SERI005', 'P004', 'DTB005', N'Hoạt động tốt');

INSERT INTO PHIEUMUON (MAPM, NGAYMUON, NGAYLAPPHIEU, MANV, MASV, TRANGTHAI, LYDOMUON, LYDOTUCHOI, LYDOHUY, SOLUONGMUON) VALUES
('PM001', '2025-05-01', '2025-04-30', 'NV001', 'SV001', N'Đang mượn', N'Mượn thiết bị phục vụ học tập', NULL, NULL, 2),
('PM002', '2025-05-02', '2025-05-01', 'NV002', 'SV002', N'Đã duyệt', N'Mượn phòng học thực hành', NULL, NULL, 1),
('PM003', '2025-05-03', '2025-05-02', 'NV003', 'SV003', N'Từ chối', NULL, N'Thiếu giấy tờ xác nhận', NULL, 1),
('PM004', '2025-05-04', '2025-05-03', 'NV004', 'SV004', N'Đã hủy', NULL, NULL, N'Yêu cầu không phù hợp', 1),
('PM005', '2025-05-05', '2025-05-04', 'NV005', 'SV005', N'Đang mượn', N'Mượn thiết bị phục vụ nghiên cứu', NULL, NULL, 2);

INSERT INTO CHITIETPHIEUMUON (MAPM, MATHIETBI) VALUES
('PM001', 'TB001'),
('PM001', 'TB002'),
('PM002', 'TB003'),
('PM005', 'TB004'),
('PM005', 'TB005');

INSERT INTO PHIEUSUA (MAPS, TRANGTHAI, NGAYLAP, MOTA, SOLUONG, DONGIA) VALUES
('PS001', N'Đang sửa', '2025-05-10', N'Hỏng nặng', 2, 750000),
('PS002', N'Hoàn thành', '2025-04-20', N'Hư nhẹ', 1, 2300000),
('PS003', N'Chờ duyệt', '2025-05-15', N'Cần sửa gấp', 3, 400000),
('PS004', N'Hoàn thành', '2025-03-30', N'Chưa thanh toán', 2, 450000),
('PS005', N'Đang sửa', '2025-05-18', N'Lỗi điện', 1, 1800000);


INSERT INTO CHITIETPHIEUSUA (MAPS, MATHIETBI) VALUES
('PS001', 'TB003'),
('PS001', 'TB004'),
('PS002', 'TB001'),
('PS003', 'TB005'),
('PS005', 'TB002');
