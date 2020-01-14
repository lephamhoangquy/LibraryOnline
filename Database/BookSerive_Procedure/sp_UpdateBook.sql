create proc sp_UpdateBook
	@BookID int,
	@Price float,
	@Author nvarchar(100),
	@Title nvarchar(100),
	@Qty int,
	@AboutBook nvarchar(max),
	@Base64String varchar(max)
as
begin
	begin tran
		update Book
		set Price=@Price, Author=@Author, Title=@Title,AboutBook=@AboutBook, Qty=@Qty
		where BookID=@BookID
		if (@Base64String <> '')
		begin
			update Book
			set Picture=cast(N'' as xml).value('xs:base64Binary(sql:variable("@Base64String"))', 'varbinary(max)')
			where BookID=@BookID
		end
	commit tran
	return
end