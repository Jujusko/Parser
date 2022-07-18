CREATE PROCEDURE [dbo].[AddTranzaction]
	@declaration nvarchar(31),
	@date nvarchar(11),
	@value nvarchar(30),
	@seller_id integer,
	@buyer_id integer
AS
	insert into [dbo].[Tranzactions]
	values(@declaration, @seller_id, @buyer_id, @date, @value)
