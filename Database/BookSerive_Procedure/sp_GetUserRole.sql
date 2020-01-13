create proc sp_GetUserRole
	@Email varchar(100),
	@Role int output
as
begin
	set @Role = 0
	begin tran
		select @Role=Permission from Users where Email = @Email
	commit tran
	return
end

--declare @role1 int
--exec sp_GetUserRole '1612545',@role1 output
--print(@role1)