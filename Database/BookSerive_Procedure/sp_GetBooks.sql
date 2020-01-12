create proc sp_GetBooks
	@offset int,
	@limit int,
	@total int output
as
begin
	set @total = 0
	begin tran
		select @total = count(BookID) from Book
		if (@limit > 0)
		begin
			select B.*, C.CategoryName
			from Book B join Category C on B.CategoryID=C.CategoryID
			order by B.BookID
			OFFSET @offset ROWS FETCH NEXT @limit ROWS ONLY;
		end
		else
		begin
			select B.*, C.CategoryName
			from Book B join Category C on B.CategoryID=C.CategoryID
			order by B.BookID
			OFFSET @offset ROWS;
		end
	commit tran
	return
end

