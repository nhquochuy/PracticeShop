USE [OnlineShop]
GO
/****** Object:  StoredProcedure [dbo].[S_GetAllUser]    Script Date: 5/28/2020 9:11:02 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create proc [dbo].[S_GetAllUser]
as
begin
	select * from [User]
end