USE [OnlineShop]
GO
/****** Object:  StoredProcedure [dbo].[S_GetUserByUserName]    Script Date: 5/28/2020 9:11:00 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER proc [dbo].[S_GetUserByUserName]
(
	@username nvarchar(100)
)
as
begin
	select top 1 * from [User] where UserName = @username 
end