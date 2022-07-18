CREATE PROCEDURE [dbo].[GetUserByName]
	@name nvarchar(180)
AS
	SELECT * from [dbo].Users as U
	where U.[Name] = @name