CREATE TABLE [dbo].[Product](
	[Id] [int] IDENTITY(1,1) primary key ,
	[Name] [varchar](50) NOT NULL,
	[Category] [varchar](50) NOT NULL,
	[Price] [decimal](10, 2) NOT NULL,
)

INSERT [dbo].[Product] ([Name], [Category], [Price]) VALUES ( N'Potato', N'Groceries', CAST(100.00 AS Decimal(10, 2)))

