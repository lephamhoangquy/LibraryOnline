create proc sp_DeleteBookById
	@BookID int
as
begin
	begin tran
		update Book
		set IsDelete = 1
		where BookID=@BookID
	commit tran
end