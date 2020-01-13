create proc sp_GetBooks
	@offset int,
	@limit int,
	@total int output
as
begin
	set @total = 0
	begin tran
		select @total = count(BookID) from Book where IsDelete = 0
		if (@limit > 0)
		begin
			select B.*, C.CategoryName
			from Book B join Category C on B.CategoryID=C.CategoryID
			where B.IsDelete = 0
			order by B.CreatedAt desc
			OFFSET @offset ROWS FETCH NEXT @limit ROWS ONLY;
		end
		else
		begin
			select B.*, C.CategoryName
			from Book B join Category C on B.CategoryID=C.CategoryID
			where B.IsDelete = 0
			order by B.CreatedAt desc
			OFFSET @offset ROWS;
		end
	commit tran
	return
end

--drop proc sp_GetBooks
--declare @total1 int
--exec sp_GetBooks 0,0,@total1 output