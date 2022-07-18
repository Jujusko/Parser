CREATE TABLE [dbo].[Users] (
    [Id]            INT            IDENTITY (1, 1) NOT NULL,
    [Name]          NVARCHAR (180) NOT NULL,
    [INN]           NVARCHAR (15)  NULL,
    [SellerOrBuyer] BIT            NOT NULL,
    CONSTRAINT [PK__Users__3214EC070A54C5E3] PRIMARY KEY CLUSTERED ([Id] ASC)
);

