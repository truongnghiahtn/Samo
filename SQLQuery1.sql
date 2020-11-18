Create DATABASE QLMONNEY
use QLMONNEY

go
create table KhachHang(
	idKhachHang int IDENTITY(1,1) primary key not null,
	taiKhoan nvarchar(max)  not null,
	matKhau nvarchar(max) not null,
	hoTen nvarchar(max) not null,
	soDuTK money ,
	gioiHan money, 
	NgayTao datetime,
	ngayUpdate datetime,
)

go
create table ThuNhap(
	idThuNhap int IDENTITY(1,1) primary key not null,
	tenThuNhap varchar(max) not null,
	moTa varchar(max) not null,
	hinh varchar(max),
	trangThai bit,
	ngayTao datetime,
	ngayUpdate datetime
)



go
create table dKThuNhap(
	idDKThuNhap int IDENTITY(1,1) primary key not null,
	idKhachHang int  not null,
	idThuNhap int  not null,
	tien money not null,
	moTa varchar(max) not null,
	ngayTao datetime,
	ngayUpdate datetime
)


go
create table ChiPhi(
	idChiPhi int IDENTITY(1,1) primary key not null,
	tenChiPhi varchar(max) not null,
	moTa varchar(max) not null,
	hing varchar(max),
	trangThai bit,
	ngayTao datetime,
	ngayUpdate datetime
)



go
create table dKChiPhi(
	idDKChiPhi int IDENTITY(1,1) primary key not null,
	idKhachHang int  not null,
	idChiPhi int  not null,
	tien money not null,
	moTa varchar(max) not null,
	ngayTao datetime,
	ngayUpdate datetime
)

go
create trigger tr1 on KhachHang after insert
as
begin
	update KhachHang set NgayTao = GETDATE() from KhachHang cd join inserted i on cd.idKhachHang = i.idKhachHang
end

go
create trigger tr2 on ThuNhap after insert
as
begin
	update ThuNhap set NgayTao = GETDATE() from ThuNhap cd join inserted i on cd.idThuNhap = i.idThuNhap
end

go
create trigger tr3 on ChiPhi after insert
as
begin
	update ChiPhi set NgayTao = GETDATE() from ChiPhi cd join inserted i on cd.idChiPhi = i.idChiPhi
end

go
create trigger tr4 on dKThuNhap after insert
as
begin
	update dKThuNhap set NgayTao = GETDATE() from dKThuNhap cd join inserted i on cd.idDKThuNhap = i.idDKThuNhap
	update KhachHang set soDuTK =soDuTK+ ( select tien from inserted) from KhachHang kh join inserted i on kh.idKhachHang=i.idKhachHang 
end

go
create trigger tr5 on dKChiPhi after insert
as
begin
	update dKChiPhi set NgayTao = GETDATE() from dKChiPhi cd join inserted i on cd.idDKChiPhi = i.idDKChiPhi
	update KhachHang set soDuTK =soDuTK - ( select tien from inserted) from KhachHang kh join inserted i on kh.idKhachHang=i.idKhachHang 
end

go
create trigger tr6 on KhachHang for update
as
begin
	update KhachHang set ngayUpdate = GETDATE() from KhachHang cd join inserted i on cd.idKhachHang = i.idKhachHang
end

go
create trigger tr7 on ThuNhap for update
as
begin
	update ThuNhap set ngayUpdate = GETDATE() from ThuNhap cd join inserted i on cd.idThuNhap = i.idThuNhap
end

go
create trigger tr8 on ChiPhi for update
as
begin
	update ChiPhi set ngayUpdate = GETDATE() from ChiPhi cd join inserted i on cd.idChiPhi = i.idChiPhi
end

go
create trigger tr9 on dKThuNhap after update
as
begin
	update dKThuNhap set ngayUpdate = GETDATE() from dKThuNhap cd join inserted i on cd.idDKThuNhap = i.idDKThuNhap
	
end


go
create trigger tr10 on dKChiPhi for update
as
begin
	update dKChiPhi set ngayUpdate = GETDATE() from dKChiPhi cd join inserted i on cd.idDKChiPhi = i.idDKChiPhi

end

go
create trigger tr11 on dKChiPhi for delete
as
begin
	update KhachHang set soDuTK =soDuTK + ( select tien from inserted) from KhachHang kh join inserted i on kh.idKhachHang=i.idKhachHang 
end

go
create trigger tr12 on dKThuNhap for delete
as
begin
	update KhachHang set soDuTK =soDuTK - ( select tien from inserted) from KhachHang kh join inserted i on kh.idKhachHang=i.idKhachHang 
end


alter table dKThuNhap
add constraint fk_KhachHang_dkThuNhap foreign key (idKhachHang) references KhachHang(idKhachHang)
alter table dKChiPhi
add constraint fk_KhachHang_dkChiPhi foreign key (idKhachHang) references  KhachHang(idKhachHang)
alter table dKThuNhap
add constraint fk_ThuNhap_dkThuNhap foreign key (idThuNhap) references ThuNhap(idThuNhap)
alter table dKChiPhi
add constraint fk_ChiPhi_dkThuNhap foreign key (idChiPhi) references ChiPhi(idChiPhi)

