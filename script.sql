USE [MyShop]
GO

/****** Object: Table [dbo].[Customers] Script Date: 19-07-2022 01:57:38 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

IF OBJECT_ID(N'dbo.OrderItems', N'U') IS NOT NULL  
	DROP TABLE [dbo].[OrderItems];
GO
IF OBJECT_ID(N'dbo.Orders', N'U') IS NOT NULL  
	DROP TABLE [dbo].[Orders];
GO
IF OBJECT_ID(N'dbo.Customers', N'U') IS NOT NULL  
	DROP TABLE [dbo].[Customers];
GO

CREATE TABLE [dbo].[Customers] (
    [Id]        INT            IDENTITY (1, 1) NOT NULL,
    [Firstname] NVARCHAR (50)  NOT NULL,
    [Lastname]  NVARCHAR (50)  NOT NULL,
    [Email]     NVARCHAR (100) NOT NULL,
    [Phone]     NVARCHAR (20)  NULL,
    [Street]    NVARCHAR (100) NOT NULL,
    [City]      NVARCHAR (50)  NOT NULL,
    [State]     NVARCHAR (5)   NOT NULL,
    [ZipCode]   NVARCHAR (7)   NOT NULL,
	PRIMARY KEY CLUSTERED ([Id] ASC)
);

GO

CREATE TABLE [dbo].[Orders] (
    [Id]           INT      NOT NULL,
    [CustomerId]   INT      NOT NULL,
    [Status]       TINYINT  NOT NULL,
    [OrderDate]    DATETIME NOT NULL,
    [RequiredDate] DATETIME NOT NULL,
    [ShippedDate]  DATETIME NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_Table_Customers] FOREIGN KEY ([CustomerId]) REFERENCES [dbo].[Customers] ([Id])
);

GO

CREATE TABLE [dbo].[OrderItems] (
    [Id]        INT            IDENTITY (1, 1) NOT NULL,
    [OrderId]   INT            NOT NULL,
    [ItemId]    INT            NOT NULL,
    [ListPrice] DECIMAL (7, 2) DEFAULT ((0)) NOT NULL,
    [Discount]  DECIMAL (3, 2) DEFAULT ((0)) NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_OrderItems_Orders] FOREIGN KEY ([OrderId]) REFERENCES [dbo].[Orders] ([Id])
);

GO