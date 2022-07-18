CREATE PROCEDURE [dbo].[GetTranzactionByDeclaration]
	@declaration nvarchar(35)
AS
	SELECT * from [dbo].Tranzactions AS T
	WHERE T.Declaration = @declaration

