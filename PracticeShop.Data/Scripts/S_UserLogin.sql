create proc S_UserLogin
(@username nvarchar(100), @password nvarchar(100))
as
begin
declare @re bit
	if exists ( select * from [User] where UserName = @username and Password = @password)
	begin
		set @re = 1
	end
	else
		set @re = 0
	select @re
end