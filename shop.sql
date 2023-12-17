Use Master
GO
    IF exists(Select name From sys.databases Where name='shop' )
    DROP Database shop
GO
    Create Database shop
GO

USE shop;

CREATE TABLE CUAHANG(
	MaCH int primary key identity(1,1),
	Ten nvarchar(100) not null,
	DienThoai varchar(20),
	DiaChi nvarchar(100)
) 
GO

CREATE TABLE DANHMUC(
	MaDM int primary key identity(1,1),
	Ten nvarchar(100) not null
) 
GO

CREATE TABLE MATHANG(
	MaMH int primary key identity(1,1),
	Ten nvarchar(100) not null,
	GiaGoc int default 0,
	GiaBan int default 0,
	SoLuong smallint default 0,
	MoTa nvarchar(1000),
	HinhAnh varchar(255),
	MaDM int not null foreign key(MaDM) references DANHMUC(MaDM),
	LuotXem int default 0,
	LuotMua int default 0
) 
GO

CREATE TABLE CHUCVU(
	MaCV int primary key identity(1,1),
	Ten nvarchar(100) not null,
	HeSo float default 1.0
) 
GO

CREATE TABLE NHANVIEN(
	MaNV int primary key identity(1,1),
	Ten nvarchar(100) not null,
	MaCV int not null foreign key(MaCV) references CHUCVU(MaCV),
	DienThoai varchar(20),
	Email varchar(255),
	MatKhau varchar(255)	
) 
GO

CREATE TABLE KHACHHANG(
	MaKH int primary key identity(1,1),
	Ten nvarchar(100) not null,
	DienThoai varchar(20),
	Email varchar(255),
	MatKhau varchar(255)
) 
GO

CREATE TABLE DIACHI(	
	MaDC int primary key identity(1,1),
	MaKH int not null foreign key(MaKH) references KHACHHANG(MaKH),
	DiaChi nvarchar(100) not null,
	PhuongXa varchar(20) default N'Đông Xuyên',
	QuanHuyen varchar(50) default N'TP. Long Xuyên',
	TinhThanh varchar(50) default N'An Giang',
	MacDinh int default 1	
) 
GO

CREATE TABLE HOADON(
	MaHD int primary key identity(1,1),
	Ngay datetime default getdate(),
	TongTien int default 0,
	MaKH int not null foreign key(MaKH) references KHACHHANG(MaKH),
	TrangThai int default 0
) 
GO

CREATE TABLE CTHOADON(
	MaCTHD int primary key identity(1,1),
	MaHD int not null foreign key(MaHD) references HOADON(MaHD),	
	MaMH int not null foreign key(MaMH) references MATHANG(MaMH),
	DonGia int default 0,
	SoLuong smallint default 1,
	ThanhTien int
) 
GO

-- Dữ liệu bảng CUA_HANG
INSERT INTO CUAHANG(Ten, DienThoai, DiaChi) VALUES(N'SHOP GD1','037-3837382',N'18 Ung Văn Khiêm, P Đông Xuyên, TP Long Xuyên, An Giang');
INSERT INTO CUAHANG(Ten, DienThoai, DiaChi) VALUES(N'SHOP GD2','037-3324231',N'QL91, TT An Châu, Châu Thành, An Giang');

-- Dữ liệu bảng LOAI_HANG
INSERT INTO DANHMUC(Ten) VALUES(N'Gia dụng phòng bếp');
INSERT INTO DANHMUC(Ten) VALUES(N'Gia dụng phòng tắm');
INSERT INTO DANHMUC(Ten) VALUES(N'Gia dụng phòng khách');
INSERT INTO DANHMUC(Ten) VALUES(N'Gia dụng phòng ngủ');

-- Dữ liệu bảng MAT_HANG
INSERT INTO MATHANG(Ten,MoTa,GiaGoc,GiaBan,SoLuong,HinhAnh,MaDM,LuotXem,LuotMua) VALUES(N'Ấm siêu tốc inox Happy Time HTD1088 1.8L',N'Happy Time HTD1088 có dung tích 1.8 lít đáp ứng đủ nhu cầu sử dụng nước cho các gia đình. Ngoài ra ấm siêu tốc có khả năng đun nước sôi nhanh chóng sẽ là lựa chọn lý tưởng cho các bạn sinh viên ở trọ, vừa đun nước uống, vừa đun nước tắm tiện lợi.',200000,180000,10,'1.jpg',1,0,0);
INSERT INTO MATHANG(Ten,MoTa,GiaGoc,GiaBan,SoLuong,HinhAnh,MaDM,LuotXem,LuotMua) VALUES(N'Máy vắt cam Steba ZP2',N'Bộ sản phẩm máy ép cam Steba ZP2 được thiết kế độc đáo với chất liệu vỏ inox 18/10 bao gồm 3 bộ phận chính là đế, trụ và phần nắp. Bạn có thể tháo lắp các bộ phận một cách dễ dàng, nhờ vậy, việc vệ sinh cũng đơn giản hơn bao giờ hết.',2500000,2000000,20,'2.jpg',1,0,0);
INSERT INTO MATHANG(Ten,MoTa,GiaGoc,GiaBan,SoLuong,HinhAnh,MaDM,LuotXem,LuotMua) VALUES(N'Bộ dao inox Elmich 7 món EL3800',N'Bộ dao inox Elmich 7 món EL3800 gồm 7 món. Trong đó có 4 dao, 1 thanh mài dao, 1 kéo cắt gà và 1 giá để dao.',2600000,2600000,20,'3.jpg',1,0,0);
INSERT INTO MATHANG(Ten,MoTa,GiaGoc,GiaBan,SoLuong,HinhAnh,MaDM,LuotXem,LuotMua) VALUES(N'Chậu rửa treo tường Inax L-280V',N'Chậu rửa treo tường Inax L-280V sở hữu thiết kế sang trọng và hiện đại, nổi bật với gam màu trắng tinh khôi của sứ mang lại vẻ đẹp cho không gian lắp đặt.',500000,450000,30,'4.jpg',2,0,0);
INSERT INTO MATHANG(Ten,MoTa,GiaGoc,GiaBan,SoLuong,HinhAnh,MaDM,LuotXem,LuotMua) VALUES(N'Bộ sen và vòi tắm Teka MT Plus',N'Bộ sen và vòi tắm Teka MT Plus thiết kế hiện đại phù hợp với nhiều không gian nhà tắm. Teka MT Plus bao gồm vòi sen thấp và vòi tắm từ trên cao phù hợp với sở thích của mọi đối tượng, thành viên trong gia đình.',8000000,6000000,25,'5.jpg',2,0,0);
INSERT INTO MATHANG(Ten,MoTa,GiaGoc,GiaBan,SoLuong,HinhAnh,MaDM,LuotXem,LuotMua) VALUES(N'Vòi cảm ứng Sokimi SM 1102',N'Vòi cảm ứng sử dụng nguồn điện AC 110V - 220V DC 6V sẽ cảm biến thông minh nhận biết chuyển động của tay để tự động xả nước.',2000000,1500000,50,'6.jpg',2,0,0);
INSERT INTO MATHANG(Ten,MoTa,GiaGoc,GiaBan,SoLuong,HinhAnh,MaDM,LuotXem,LuotMua) VALUES(N'Máy điều hòa di động thông minh FujiHome PAC07',N'Điều hòa di động thiết kế nhỏ gọn, thông minh với cục nóng và cục lạnh trên cùng một thiết bị nên không cần lắp đặt cục nóng hay cục lạnh. Người dùng chỉ cần lắp ống xả hơi nóng qua cửa sổ là có thể dùng được luôn.',5000000,5000000,10,'7.jpg',3,0,0);
INSERT INTO MATHANG(Ten,MoTa,GiaGoc,GiaBan,SoLuong,HinhAnh,MaDM,LuotXem,LuotMua) VALUES(N'Android tivi Sharp HD 32 inch 2T-C32DE2X',N'Android tivi Sharp 32 inch 2T C32DE2X là mẫu tivi Sharp 32 inch sở hữu thiết kế siêu mỏng với khung viền sắc nét tạo sự sang trọng, thanh lịch phù hợp với mọi không gian nội thất.',4000000,36000000,20,'8.jpg',3,0,0);
INSERT INTO MATHANG(Ten,MoTa,GiaGoc,GiaBan,SoLuong,HinhAnh,MaDM,LuotXem,LuotMua) VALUES(N'Bàn Trà Sofa phòng khách phong cách hiện đại GP81',N'Bàn trà sofa, bàn cafe làm việc B Table phù hợp mọi loại ghế thông minh hiện đại phòng khách- GP81',700000,600000,20,'9.jpg',3,0,0);
INSERT INTO MATHANG(Ten,MoTa,GiaGoc,GiaBan,SoLuong,HinhAnh,MaDM,LuotXem,LuotMua) VALUES(N'Bàn Trang Điểm - Bàn Makeup phong cách bắc âu',N'bàn dạng kéo hiện đại siêu yêu, kích thước 50x100',3000000,2000000,30,'10.jpg',4,0,0);
INSERT INTO MATHANG(Ten,MoTa,GiaGoc,GiaBan,SoLuong,HinhAnh,MaDM,LuotXem,LuotMua) VALUES(N'Kệ sách để bàn bằng gỗ đa năng',N'Kệ sách gỗ để bàn Kệ đa năng mini giá sách gỗ màu trắng lắp ghép dễ dàng tiện lợi. Kích thước: Cao 34, rộng có thể kéo chỉnh từ 30 đến 60cm, sâu 17cm',90000,60000,25,'11.jpg',4,0,0);
INSERT INTO MATHANG(Ten,MoTa,GiaGoc,GiaBan,SoLuong,HinhAnh,MaDM,LuotXem,LuotMua) VALUES(N'Đèn ngủ để bàn',N'Đèn ngủ để bàn có hệ thống tăng giảm ánh sáng, đèn có chiêu cao 50cm, chao đèn có bán kính rộng 25cm, thân đèn làm bằng innox mạ sơn tĩnh điện.',300000,1500000,50,'12.jpg',4,0,0);
-- Dữ liệu bảng CHUC_VU
INSERT INTO CHUCVU(Ten) VALUES(N'Quản lý');
INSERT INTO CHUCVU(Ten) VALUES(N'Nhân viên thu ngân');
INSERT INTO CHUCVU(Ten) VALUES(N'Nhân viên kho');

-- Dữ liệu bảng NHANVIEN
INSERT INTO NHANVIEN(Ten,MaCV,DienThoai,Email,MatKhau) VALUES(N'Nguyễn Phước Tân',1,'0909456789','nptan@gmail.com','202cb962ac59075b964b07152d234b70');
--INSERT INTO NHANVIEN(Ten,MaCV,DienThoai,Email,MatKhau) VALUES(N'Dương Thị Mỹ Thuận',2,'0988778899','dtmthuan@gmail.com','202cb962ac59075b964b07152d234b70');
--INSERT INTO NHANVIEN(Ten,MaCV,DienThoai,Email,MatKhau) VALUES(N'Trần Huỳnh Sơn',3,'0903123123','thson@gmail.com','202cb962ac59075b964b07152d234b70');
--INSERT INTO NHANVIEN(Ten,MaCV,DienThoai,Email,MatKhau) VALUES(N'Lê Ngọc Thanh',2,'0913454544','lnthanh@gmail.com','202cb962ac59075b964b07152d234b70');

-- Dữ liệu bảng KHACHHANG
--INSERT INTO KHACHHANG(Ten,DienThoai,Email,MatKhau) VALUES(N'Lê Ngọc Sơn','0998234544','l','Aa@12345');

-- Dữ liệu bảng DIACHI
INSERT INTO DIACHI(MaKH,DiaChi,PhuongXa,QuanHuyen,TinhThanh,MacDinh) VALUES(1,N'18 Ung Văn Khiêm',N'P Đông Xuyên',N'TP Long Xuyên',N'An Giang',1);

-- Dữ liệu bảng HOADON
--INSERT INTO HOADON(TongTien,MaKH,TrangThai) VALUES(70000,1,0);


-- Dữ liệu bảng CTHOA_DON
--INSERT INTO CTHOADON(MaHD,MaMH,DonGia,SoLuong,ThanhTien) VALUES(1,2,23000,1,23000);

GO

SELECT * FROM DANHMUC;
SELECT * FROM MATHANG;
SELECT * FROM KHACHHANG;
SELECT * FROM HOADON;
SELECT * FROM CTHOADON;
SELECT * FROM NHANVIEN;
SELECT * FROM DIACHI;


