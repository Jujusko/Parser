CREATE PROCEDURE [dbo].[GetUserByINN]
	@inn nvarchar(15)
AS
	SELECT * from [dbo].Users as U
	where U.INN = @inn