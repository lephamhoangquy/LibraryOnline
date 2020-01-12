go
create database IAMService
go
use IAMService
go
create table Users(
	Email varchar(100),
	FullName nvarchar(100),
	Phone varchar(11),
	UserPassword varchar(max),
	primary key (Email)
)
go
insert into Users values ('1612545',N'Quý Lê','0333268168','$2y$12$a1ePEMyMb/MTo2OmVMhwtOis0.ky9wYdO2XCorDIVNTRCVsPidK3m')
go
insert into Users values ('1612557',N'Sang Lê','0979279932','$2y$12$a1ePEMyMb/MTo2OmVMhwtOis0.ky9wYdO2XCorDIVNTRCVsPidK3m')
