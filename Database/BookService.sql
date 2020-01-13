go
create database BookService
go
use BookService
go
create table Users(
	Email varchar(100) not null,
	primary key (Email)
)
go
insert into Users values ('1612545')
insert into Users values ('1612557')

go
create table Category (
	CategoryID int identity (1,1),
	CategoryName nvarchar(100),
	primary key (CategoryID)
)
go
insert into Category(CategoryName) values (N'Sách kinh tế'), (N'Sách thiếu nhi'),
										(N'Truyện ngắn'),(N'Sách nấu ăn')

go
create table Book(
	BookID int identity (1,1),
	Title nvarchar(100),
	Author nvarchar(100),
	Picture Image,
	AboutBook nvarchar(max),
	CategoryID int,
	Qty int,
	CreatedAt datetime,
	Price float,
	IsDelete bit,
	Primary key (BookID)
)
go
insert into Book(Title,Author,AboutBook,CategoryID,Qty,CreatedAt,Price,IsDelete)
values
	(N'Quảng cáo Facebook từ A đến Z',N'Trung Đức - Bình Nguyên',N'Cuốn sách Quảng Cáo Facebook Từ A Đến Z này tập trung vào hướng thực hành, hướng dẫn người đọc thao tác từng bước một, khá đơn giản và dễ hiểu. Giúp người đọc có cái nhìn toàn diện hơn về quảng cáo Facebook nói riêng và ngành quảng cáo nói chung.',1,50,GETDATE(),50000,0)
go
insert into Book(Title,Author,AboutBook,CategoryID,Qty,CreatedAt,Price,IsDelete)
values
	(N'Học từ vấp ngã để thành công',N'John C. Maxwell',N'Thành công và thất bại chỉ đơn thuần là những điểm mốc nối tiếp nhau trong cuộc sống để tôi luyện nên sự trưởng thành của con người. Thất bại giúp con người đúc kết được kinh nghiệm để vươn tới chiến thắng và khiến những thành công đạt được thêm phần ý nghĩa.',1,50,GETDATE(),50000,0),
	(N'Người Giỏi Không Phải Là Người Làm Tất Cả',N'Donna M. Genett, Ph.D',N'Dù bạn là người uỷ thác hay được uỷ thác công việc, nhưng nếu biết ứng dụng sáu nguyên tắc này, chắc chắn bạn sẽ cảm thấy khối lượng công việc giảm đi đáng kể, nhờ vậy bạn sẽ có thêm nhiều thời gian để tập trung vào những điều thật sự quan trọng trong công việc và trong cuộc sống.',1,50,GETDATE(),20000,0),
	(N'Phi lý trí',N'Dan Ariely',N'Mỗi chúng ta cần xem lại những mỏ neo của cuộc đời mình để thấy chúng ta đã phi lý như thế nào trong vô số quyết định từ nhỏ nhặt nhất tới trọng đại nhất trên con đường đã qua. Phi lý trí của Ariely gợi mở, khuyến khích chúng ta nhìn nhận lại tất cả những quyết định đó, rút ra bài học từ những sai lầm trong hành vi của chính mình và những người khác.',1,50,GETDATE(),25000,0)
go
insert into Book(Title,Author,AboutBook,CategoryID,Qty,CreatedAt,Price,IsDelete)
values
	(N'Từ Mũi Hảo Vọng Đến Thảo Cầm Viên',N'Phan Việt Lâm',N'Nhắc đến châu Phi, người ta nghĩ ngay đến những loài vật hoang dã mạnh mẽ và đẹp nhất hành tinh. Trong số đó, những loài quý hiếm đang bị săn lùng ráo riết đến mức gần tuyệt chủng.',2,50,GETDATE(),25000,0),
	(N'Tôn Ngộ Không Phá Án - Tập 1',N'Nhiều tác giả',N'Ngộ Không không những là cao thủ trừ yêu diệt quái, mà còn là một thám tử thông minh với khả năng suy luận lôgic và óc quan sát tinh tường trong khi phá những vụ án mà người khác phải bó tay.',2,50,GETDATE(),25000,0),
	(N'Tôn Ngộ Không Phá Án - Tập 2',N'Nhiều tác giả',N'Ngộ Không không những là cao thủ trừ yêu diệt quái, mà còn là một thám tử thông minh với khả năng suy luận lôgic và óc quan sát tinh tường trong khi phá những vụ án mà người khác phải bó tay.',2,50,GETDATE(),55000,0)

go
insert into Book(Title,Author,AboutBook,CategoryID,Qty,CreatedAt,Price,IsDelete)
values
	(N'Mắt Biếc (Tái Bản 2019)',N'Nguyễn Nhật Ánh',N'Tôi gửi tình yêu cho mùa hè, nhưng mùa hè không giữ nổi. Mùa hè chỉ biết ra hoa, phượng đỏ sân trường và tiếng ve nỉ non trong lá. Mùa hè ngây ngô, giống như tôi vậy. Nó chẳng làm được những điều tôi ký thác. Nó để Hà Lan đốt tôi, đốt rụi. Trái tim tôi cháy thành tro, rơi vãi trên đường về.',3,50,GETDATE(),100000,0),
	(N'Cho Tôi Xin Một Vé Đi Tuổi Thơ (Tái Bản 2015)',N'Nguyễn Nhật Ánh',N'Truyện Cho tôi xin một vé đi tuổi thơ là sáng tác mới nhất của nhà văn Nguyễn Nhật Ánh. Nhà văn mời người đọc lên chuyến tàu quay ngược trở lại thăm tuổi thơ và tình bạn dễ thương của 4 bạn nhỏ. Những trò chơi dễ thương thời bé, tính cách thật thà, thẳng thắn một cách thông minh và dại dột, những ước mơ tự do trong lòng… khiến cuốn sách có thể làm các bậc phụ huynh lo lắng rồi thở phào.',3,50,GETDATE(),100000,0)
go
insert into Book(Title,Author,AboutBook,CategoryID,Qty,CreatedAt,Price,IsDelete)
values
	(N'Nhật Ký Học Làm Bánh (Tập 1)',N'Linh Trang',N'Nhật kí học làm bánh không chỉ đơn thuần là một tập hợp các công thức bánh trái. Nó trước hết là một quyển nhật kí về chặng đường tự vật lộn với bột, bơ, đường, trứng, sữa của một cô nàng không có nhiều kinh nghiệm bếp núc và hoàn toàn chẳng có hoa tay nào cả.',4,50,GetDate(),60000,0)

go
create table Cards(
	CardID int identity(1,1),
	Email varchar(100),
	TotalPrice float,
	AddressDeliver nvarchar(1000),
	CreatedAt date,
	primary key (CardID)
)
go
create table Cards_Book(
	CardID int,
	BookID int,
	Qty int,
	primary key (CardID,BookID)
)
go
create table Cart(
	CartID int identity(1,1),
	SessionID varchar(500),
	Email varchar(100),
	primary key (CartID)
)
go
create table CartDetail(
	CartID int,
	BookID int,
	Qty int,
	primary key(CartID,BookID)
)

go

--Insert Image
/*
update Book
set Picture = (Select MyImage.* from Openrowset(Bulk 'C:\Users\User\Desktop\BookImage\1.jpg', Single_Blob) MyImage)
where BookID = 1*/