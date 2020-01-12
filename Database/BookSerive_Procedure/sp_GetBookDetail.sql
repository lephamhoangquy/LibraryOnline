create proc sp_GetBookDetail
	@BookID int
as
begin
	begin tran
		select B.*, C.CategoryName
		from Book B join Category C on B.CategoryID = C.CategoryID
		where B.BookID=@BookID
	commit tran
	return
end
