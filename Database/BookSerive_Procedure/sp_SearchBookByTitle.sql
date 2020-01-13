create proc sp_SearchBookByTitle
	@TextToSearch nvarchar(100),
	@offset int,
	@limit int,
	@total int output
as
begin
	set @total = 0
	begin tran
	select @total=count(BookID) from Book where Book.Title like N'%'+@TextToSearch+'%' and IsDelete=0
	if (@limit > 0)
	begin
		select B.*, C.CategoryName
		from Book B join Category C on B.CategoryID=C.CategoryID
		where B.Title like N'%'+@TextToSearch+'%' and B.IsDelete = 0
		order by B.BookID
		OFFSET @offset ROWS FETCH NEXT @limit ROWS ONLY;
	end
	else
	begin
		select B.*, C.CategoryName
		from Book B join Category C on B.CategoryID=C.CategoryID
		where B.Title like N'%'+@TextToSearch+'%' and B.IsDelete = 0
		order by B.BookID
		OFFSET @offset ROWS
	end
	commit tran
	return
end

--drop proc sp_SearchBookByTitle
--declare @total1 int
--exec sp_SearchBookByTitle N'facebook',0,0,@total1 output