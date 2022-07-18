CREATE TABLE [dbo].[Tranzactions] (
    [Id]          INT           IDENTITY (1, 1) NOT NULL,
    [Declaration] NVARCHAR (36) NOT NULL,
    [SellerId]    INT           NOT NULL,
    [BuyerId]     INT           NOT NULL,
    [Date]        NVARCHAR (11) NOT NULL,
    [Value]       NVARCHAR (30) NOT NULL,
    CONSTRAINT [PK__Tranzact__3214EC075550A7A8] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK__Tranzacti__Buyer__29572725] FOREIGN KEY ([BuyerId]) REFERENCES [dbo].[Users] ([Id]),
    CONSTRAINT [FK__Tranzacti__Selle__286302EC] FOREIGN KEY ([SellerId]) REFERENCES [dbo].[Users] ([Id])
);

