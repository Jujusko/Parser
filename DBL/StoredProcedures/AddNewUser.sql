CREATE PROCEDURE [dbo].[AddNewUser]
	@inn nvarchar(15),
	@name nvarchar(180),
	@seller_or_buyer bit

AS
	insert into [dbo].[Users]
	output INSERTED.Id
	values(@name, @inn, @seller_or_buyer)
