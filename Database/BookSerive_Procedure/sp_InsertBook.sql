use BookService
go
create proc sp_InsertBook
	@Author nvarchar(100),
	@Title nvarchar(100),
	@AboutBook nvarchar(max),
	@Price float,
	@Qty int,
	@Base64String varchar(max),
	@CreatedBookId int output
as
begin
	declare @lastedBookID int
	set @CreatedBookId = 0
	begin tran
		insert into Book(Author, Title, AboutBook, Price, Qty,CategoryID,IsDelete,CreatedAt)
		values (@Author,@Title,@AboutBook,@Price,@Qty,1,0,GETDATE())

		select top 1 @lastedBookID=BookID
		from Book
		order by BookID desc

		set @CreatedBookId = @lastedBookID

		if (@Base64String <> '')
		begin
			update Book
			set Picture=cast(N'' as xml).value('xs:base64Binary(sql:variable("@Base64String"))', 'varbinary(max)')
			where BookID=@lastedBookID
		end

	commit tran
	return
end
