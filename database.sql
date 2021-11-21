USE [master]
GO
/****** Object:  Database [Technocy]    Script Date: 11/21/2021 12:35:13 PM ******/
CREATE DATABASE [Technocy]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'Technocy', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\Technocy.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'Technocy_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\Technocy_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [Technocy] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [Technocy].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [Technocy] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [Technocy] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [Technocy] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [Technocy] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [Technocy] SET ARITHABORT OFF 
GO
ALTER DATABASE [Technocy] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [Technocy] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [Technocy] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [Technocy] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [Technocy] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [Technocy] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [Technocy] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [Technocy] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [Technocy] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [Technocy] SET  DISABLE_BROKER 
GO
ALTER DATABASE [Technocy] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [Technocy] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [Technocy] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [Technocy] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [Technocy] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [Technocy] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [Technocy] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [Technocy] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [Technocy] SET  MULTI_USER 
GO
ALTER DATABASE [Technocy] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [Technocy] SET DB_CHAINING OFF 
GO
ALTER DATABASE [Technocy] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [Technocy] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [Technocy] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [Technocy] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
ALTER DATABASE [Technocy] SET QUERY_STORE = OFF
GO
USE [Technocy]
GO
/****** Object:  Table [dbo].[Category]    Script Date: 11/21/2021 12:35:13 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Category](
	[CategoryId] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NULL,
	[Slug] [nvarchar](450) NULL,
	[Description] [nvarchar](450) NULL,
	[Visibility] [bit] NULL,
	[Status] [bit] NULL,
	[MetaTitle] [nvarchar](150) NULL,
	[MetaDescription] [nvarchar](450) NULL,
	[InsertDate] [datetime] NULL,
	[LastUpdatedDate] [datetime] NULL,
 CONSTRAINT [PK_Category] PRIMARY KEY CLUSTERED 
(
	[CategoryId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Customer]    Script Date: 11/21/2021 12:35:13 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Customer](
	[CustomerId] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NULL,
	[Surname] [nvarchar](50) NULL,
	[Email] [nvarchar](50) NULL,
	[PasswordHash] [nvarchar](450) NULL,
	[Birthdate] [date] NULL,
	[Address] [nvarchar](150) NULL,
	[City] [nvarchar](50) NULL,
	[Country] [nvarchar](50) NULL,
	[PostalCode] [nvarchar](50) NULL,
	[Phone] [nvarchar](50) NULL,
	[InsertDate] [datetime] NULL,
	[LastUpdatedDate] [datetime] NULL,
 CONSTRAINT [PK_Customer] PRIMARY KEY CLUSTERED 
(
	[CustomerId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Employee]    Script Date: 11/21/2021 12:35:13 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Employee](
	[EmployeeId] [int] IDENTITY(1,1) NOT NULL,
	[RoleId] [int] NOT NULL,
	[Name] [nvarchar](50) NULL,
	[Surname] [nvarchar](50) NULL,
	[Email] [nvarchar](50) NULL,
	[Username] [nvarchar](50) NULL,
	[PasswordHash] [nvarchar](450) NULL,
	[Status] [bit] NULL,
	[Birthdate] [date] NULL,
	[Address] [nvarchar](150) NULL,
	[City] [nvarchar](50) NULL,
	[Country] [nvarchar](50) NULL,
	[PostalCode] [nvarchar](50) NULL,
	[Phone] [nvarchar](50) NULL,
	[InsertDate] [datetime] NULL,
	[LastUpdatedDate] [datetime] NULL,
 CONSTRAINT [PK_Employee] PRIMARY KEY CLUSTERED 
(
	[EmployeeId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Order]    Script Date: 11/21/2021 12:35:13 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Order](
	[OrderId] [int] IDENTITY(1,1) NOT NULL,
	[OrderNumber] [nchar](10) NULL,
	[CustomerId] [int] NULL,
	[OrderDate] [datetime] NULL,
	[ShippedDate] [datetime] NULL,
	[PaymentStatus] [bit] NULL,
	[PaymentMethod] [int] NULL,
	[Status] [int] NULL,
	[ShipName] [nvarchar](50) NULL,
	[ShipSurname] [nvarchar](50) NULL,
	[ShipAddress] [nvarchar](450) NULL,
	[ShipCity] [nvarchar](50) NULL,
	[ShipCountry] [nvarchar](50) NULL,
	[ShipPostalCode] [nvarchar](50) NULL,
	[ShipPhone] [nvarchar](50) NULL,
	[SubTotal] [money] NULL,
	[Total] [money] NULL,
	[OrderNotes] [nvarchar](450) NULL,
	[LastUpdatedDate] [datetime] NULL,
 CONSTRAINT [PK_Order] PRIMARY KEY CLUSTERED 
(
	[OrderId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[OrderDetails]    Script Date: 11/21/2021 12:35:13 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[OrderDetails](
	[OrderId] [int] NOT NULL,
	[ProductId] [int] NOT NULL,
	[Price] [money] NULL,
	[Quantity] [int] NULL,
	[Discount] [float] NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Product]    Script Date: 11/21/2021 12:35:13 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Product](
	[ProductId] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](450) NULL,
	[Slug] [nvarchar](450) NULL,
	[Summary] [nvarchar](250) NULL,
	[Description] [nvarchar](450) NULL,
	[Visibility] [bit] NULL,
	[Stock] [int] NULL,
	[SKU] [nvarchar](50) NULL,
	[Price] [money] NULL,
	[OldPrice] [money] NULL,
	[Status] [bit] NULL,
	[MetaTitle] [nvarchar](250) NULL,
	[MetaDescription] [nvarchar](450) NULL,
	[InsertDate] [datetime] NULL,
	[LastUpdatedDate] [datetime] NULL,
 CONSTRAINT [PK_Product] PRIMARY KEY CLUSTERED 
(
	[ProductId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ProductCategory]    Script Date: 11/21/2021 12:35:13 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ProductCategory](
	[ProductCategoryId] [int] IDENTITY(1,1) NOT NULL,
	[ProductId] [int] NULL,
	[CategoryId] [int] NULL,
 CONSTRAINT [PK_ProductCategory] PRIMARY KEY CLUSTERED 
(
	[ProductCategoryId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ProductGallery]    Script Date: 11/21/2021 12:35:13 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ProductGallery](
	[ProductGalleryId] [int] IDENTITY(1,1) NOT NULL,
	[ProductId] [int] NULL,
	[Name] [nvarchar](450) NULL,
	[URL] [nvarchar](450) NULL,
 CONSTRAINT [PK_ProductGallery] PRIMARY KEY CLUSTERED 
(
	[ProductGalleryId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Role]    Script Date: 11/21/2021 12:35:13 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Role](
	[RoleId] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NULL,
	[Description] [nvarchar](50) NULL,
 CONSTRAINT [PK_Role] PRIMARY KEY CLUSTERED 
(
	[RoleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Wishlist]    Script Date: 11/21/2021 12:35:13 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Wishlist](
	[WishlistId] [int] IDENTITY(1,1) NOT NULL,
	[CustomerId] [int] NULL,
	[ProductId] [int] NULL,
	[Price] [money] NULL,
	[Stock] [bit] NULL,
	[AddedOn] [datetime] NULL,
 CONSTRAINT [PK_Wishlist] PRIMARY KEY CLUSTERED 
(
	[WishlistId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Category] ON 

INSERT [dbo].[Category] ([CategoryId], [Name], [Slug], [Description], [Visibility], [Status], [MetaTitle], [MetaDescription], [InsertDate], [LastUpdatedDate]) VALUES (1, N'Gaming', N'gaming', N'Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry''s standard dummy text ever since the 1500s,', 1, 1, N'gaming', N'gaming', CAST(N'2021-11-20T13:37:30.147' AS DateTime), CAST(N'2021-11-20T15:57:35.683' AS DateTime))
INSERT [dbo].[Category] ([CategoryId], [Name], [Slug], [Description], [Visibility], [Status], [MetaTitle], [MetaDescription], [InsertDate], [LastUpdatedDate]) VALUES (2, N'Kompjuterë', N'kompjutere', N'Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry''s standard dummy text ever since the 1500s.', 1, 1, N'kompjuterë', N'kompjuterë', CAST(N'2021-11-20T14:03:23.663' AS DateTime), NULL)
INSERT [dbo].[Category] ([CategoryId], [Name], [Slug], [Description], [Visibility], [Status], [MetaTitle], [MetaDescription], [InsertDate], [LastUpdatedDate]) VALUES (3, N'Celularë', N'celulare', N'Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry''s standard dummy text ever since the 1500s.', 0, 1, N'celularë', N'celularë', CAST(N'2021-11-20T14:16:10.807' AS DateTime), NULL)
INSERT [dbo].[Category] ([CategoryId], [Name], [Slug], [Description], [Visibility], [Status], [MetaTitle], [MetaDescription], [InsertDate], [LastUpdatedDate]) VALUES (4, N'Pjesë për kompjuterë', N'pjese-per-kompjutere', N'Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry''s standard dummy text ever since the 1500s.', 1, 1, N'pjese per kompjutere', N'pjese per kompjutere', CAST(N'2021-11-20T14:17:07.497' AS DateTime), NULL)
INSERT [dbo].[Category] ([CategoryId], [Name], [Slug], [Description], [Visibility], [Status], [MetaTitle], [MetaDescription], [InsertDate], [LastUpdatedDate]) VALUES (6, N'Aparate Fotografike', N'aparate-fotografike', N'Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry''s standard dummy text ever since the 1500s,', 1, 1, N'aparate fotografike', N'aparate fotografike', CAST(N'2021-11-20T14:18:24.170' AS DateTime), NULL)
INSERT [dbo].[Category] ([CategoryId], [Name], [Slug], [Description], [Visibility], [Status], [MetaTitle], [MetaDescription], [InsertDate], [LastUpdatedDate]) VALUES (8, N'Tv, video dhe audio', N'tv-video-audio', N'Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry''s standard dummy text ever since the 1500s.', 1, 1, N'tv, video dhe audio', N'tv, video dhe audio', CAST(N'2021-11-20T16:01:10.170' AS DateTime), NULL)
SET IDENTITY_INSERT [dbo].[Category] OFF
GO
SET IDENTITY_INSERT [dbo].[Employee] ON 

INSERT [dbo].[Employee] ([EmployeeId], [RoleId], [Name], [Surname], [Email], [Username], [PasswordHash], [Status], [Birthdate], [Address], [City], [Country], [PostalCode], [Phone], [InsertDate], [LastUpdatedDate]) VALUES (3, 1, N'Albin', N'Halitaj', N'albin.halitaj@gmail.com', N'albinhalitaj', N'YWxiaW5oYWxpdGFq', 1, CAST(N'2001-08-15' AS Date), N'Fadil Elshani, Sopijë', N'Suharekë', N'Kosovë', N'23000', N'049200236', CAST(N'2021-11-19T22:56:48.687' AS DateTime), NULL)
SET IDENTITY_INSERT [dbo].[Employee] OFF
GO
SET IDENTITY_INSERT [dbo].[Product] ON 

INSERT [dbo].[Product] ([ProductId], [Name], [Slug], [Summary], [Description], [Visibility], [Stock], [SKU], [Price], [OldPrice], [Status], [MetaTitle], [MetaDescription], [InsertDate], [LastUpdatedDate]) VALUES (11, N'Maus Zowie by BenQ FK1 + -B, i zi', N'maus-zowie-by-benq-fk1-b-i-zi', N'Ky është një maus optik i lojërave që ofron një profil të ulët. Është simetrik me butona të përshtatur për dorën e djathtë. Ka një madhësi XL. Ofron 5 butona. Përdor ndërfaqen USB për t''u lidhur me pajisjen tuaj. Ka një ndjeshmëri të rregullueshme pr', N'<p>Detajet teknike<br />
Besueshm&euml;ria: 100 %</p>

<p>EAN:471875508152100</p>

<p>Ergonomia: P&euml;r djathtak&euml;</p>

<p>Garancioni nga prodhuesi: 1 vit</p>

<p>Gjat&euml;sia e kabllos m: 2</p>

<p>Gjer&euml;sia mm: 68</p>

<p>Kategoria e pesh&euml;s: I leht&euml; (deri n&euml; 89g)</p>

<p>Kodi: 9H.N2EBB.A2E</p>

<p>Koha e reagimit ms: 1</p>

<p>Lansuar: 16. 7. 2020</p>

<p>Lart&euml;sia mm: 38</p>

<p>Lidh&euml;si', 1, 12, N'ZO0001', 49.5000, 69.5000, 1, N'Maus Zowie by BenQ FK1 + -B, i zi', N'maus-zowie-by-benq-fk1-b-i-zi', CAST(N'2021-11-20T22:59:40.643' AS DateTime), NULL)
SET IDENTITY_INSERT [dbo].[Product] OFF
GO
SET IDENTITY_INSERT [dbo].[ProductCategory] ON 

INSERT [dbo].[ProductCategory] ([ProductCategoryId], [ProductId], [CategoryId]) VALUES (4, 11, 1)
INSERT [dbo].[ProductCategory] ([ProductCategoryId], [ProductId], [CategoryId]) VALUES (5, 11, 4)
SET IDENTITY_INSERT [dbo].[ProductCategory] OFF
GO
SET IDENTITY_INSERT [dbo].[ProductGallery] ON 

INSERT [dbo].[ProductGallery] ([ProductGalleryId], [ProductId], [Name], [URL]) VALUES (1, 11, N'zowie1.jpg', N'/Admin/images/products/5d36bb7e-96ea-4660-b91b-0a8d41675007_zowie1.jpg')
INSERT [dbo].[ProductGallery] ([ProductGalleryId], [ProductId], [Name], [URL]) VALUES (2, 11, N'zowie2.jpg', N'/Admin/images/products/e7981f07-5219-44da-88ea-64e3f6aa8712_zowie2.jpg')
SET IDENTITY_INSERT [dbo].[ProductGallery] OFF
GO
SET IDENTITY_INSERT [dbo].[Role] ON 

INSERT [dbo].[Role] ([RoleId], [Name], [Description]) VALUES (1, N'Administrator', N'Roli i Administratorit')
INSERT [dbo].[Role] ([RoleId], [Name], [Description]) VALUES (2, N'Menagjer', N'Roli i Menagjerit')
INSERT [dbo].[Role] ([RoleId], [Name], [Description]) VALUES (3, N'Punëtor', N'Roli i Punëtorit')
INSERT [dbo].[Role] ([RoleId], [Name], [Description]) VALUES (4, N'Financa', N'Roli per Financa')
SET IDENTITY_INSERT [dbo].[Role] OFF
GO
ALTER TABLE [dbo].[Employee]  WITH CHECK ADD  CONSTRAINT [FK_Employee_Role] FOREIGN KEY([RoleId])
REFERENCES [dbo].[Role] ([RoleId])
GO
ALTER TABLE [dbo].[Employee] CHECK CONSTRAINT [FK_Employee_Role]
GO
ALTER TABLE [dbo].[Order]  WITH CHECK ADD  CONSTRAINT [FK_Order_Customer] FOREIGN KEY([CustomerId])
REFERENCES [dbo].[Customer] ([CustomerId])
GO
ALTER TABLE [dbo].[Order] CHECK CONSTRAINT [FK_Order_Customer]
GO
ALTER TABLE [dbo].[OrderDetails]  WITH CHECK ADD  CONSTRAINT [FK_OrderDetails_Order] FOREIGN KEY([OrderId])
REFERENCES [dbo].[Order] ([OrderId])
GO
ALTER TABLE [dbo].[OrderDetails] CHECK CONSTRAINT [FK_OrderDetails_Order]
GO
ALTER TABLE [dbo].[OrderDetails]  WITH CHECK ADD  CONSTRAINT [FK_OrderDetails_Product] FOREIGN KEY([ProductId])
REFERENCES [dbo].[Product] ([ProductId])
GO
ALTER TABLE [dbo].[OrderDetails] CHECK CONSTRAINT [FK_OrderDetails_Product]
GO
ALTER TABLE [dbo].[ProductCategory]  WITH CHECK ADD  CONSTRAINT [FK_ProductCategory_Category] FOREIGN KEY([CategoryId])
REFERENCES [dbo].[Category] ([CategoryId])
GO
ALTER TABLE [dbo].[ProductCategory] CHECK CONSTRAINT [FK_ProductCategory_Category]
GO
ALTER TABLE [dbo].[ProductCategory]  WITH CHECK ADD  CONSTRAINT [FK_ProductCategory_Product] FOREIGN KEY([ProductId])
REFERENCES [dbo].[Product] ([ProductId])
GO
ALTER TABLE [dbo].[ProductCategory] CHECK CONSTRAINT [FK_ProductCategory_Product]
GO
ALTER TABLE [dbo].[ProductGallery]  WITH CHECK ADD  CONSTRAINT [FK_ProductGallery_Product] FOREIGN KEY([ProductId])
REFERENCES [dbo].[Product] ([ProductId])
GO
ALTER TABLE [dbo].[ProductGallery] CHECK CONSTRAINT [FK_ProductGallery_Product]
GO
ALTER TABLE [dbo].[Wishlist]  WITH CHECK ADD  CONSTRAINT [FK_Wishlist_Customer] FOREIGN KEY([CustomerId])
REFERENCES [dbo].[Customer] ([CustomerId])
GO
ALTER TABLE [dbo].[Wishlist] CHECK CONSTRAINT [FK_Wishlist_Customer]
GO
ALTER TABLE [dbo].[Wishlist]  WITH CHECK ADD  CONSTRAINT [FK_Wishlist_Product] FOREIGN KEY([ProductId])
REFERENCES [dbo].[Product] ([ProductId])
GO
ALTER TABLE [dbo].[Wishlist] CHECK CONSTRAINT [FK_Wishlist_Product]
GO
/****** Object:  StoredProcedure [dbo].[usp_DeleteCategory]    Script Date: 11/21/2021 12:35:13 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[usp_DeleteCategory]
	@id int
AS
BEGIN
	
	DELETE FROM Category WHERE CategoryId = @id

END
GO
/****** Object:  StoredProcedure [dbo].[usp_EditCategory]    Script Date: 11/21/2021 12:35:13 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[usp_EditCategory]
	@id int,
	@name nvarchar(150),
	@slug nvarchar(150),
	@description nvarchar(450),
	@visibility int,
	@status bit,
	@metaTitle nvarchar(250),
	@metadescription nvarchar(250),
	@lastUpdatedDate datetime
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

	UPDATE [dbo].[Category]
   SET [Name] = @name
      ,[Slug] = @slug
      ,[Description] = @description
      ,[Visibility] = @visibility
      ,[Status] = @status
      ,[MetaTitle] = @metaTitle
      ,[MetaDescription] = @metadescription
	  ,[LastUpdatedDate] = @lastUpdatedDate
 	WHERE CategoryId = @id

END
GO
/****** Object:  StoredProcedure [dbo].[usp_GetCategories]    Script Date: 11/21/2021 12:35:13 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[usp_GetCategories]
AS
BEGIN
	
	SELECT * FROM Category 

END
GO
/****** Object:  StoredProcedure [dbo].[usp_GetCategory]    Script Date: 11/21/2021 12:35:13 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[usp_GetCategory]
	@id int
AS
BEGIN

	SELECT * From Category as c where c.CategoryId = @id

END
GO
/****** Object:  StoredProcedure [dbo].[usp_GetCategoryProductsCount]    Script Date: 11/21/2021 12:35:13 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[usp_GetCategoryProductsCount] 
	@id int
AS
BEGIN
	
	SELECT COUNT(*) AS Count FROM ProductCategory WHERE CategoryId = @id

END
GO
/****** Object:  StoredProcedure [dbo].[usp_GetEmployee]    Script Date: 11/21/2021 12:35:13 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[usp_GetEmployee]
	@username nvarchar(50),
	@password nvarchar(450)
AS
BEGIN


    SELECT e.*,r.Name FROM Employee AS e INNER JOIN Role AS r ON e.RoleId = r.RoleId 
	WHERE e.Username = @username AND e.PasswordHash = @password

END
GO
/****** Object:  StoredProcedure [dbo].[usp_GetLastProductId]    Script Date: 11/21/2021 12:35:13 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[usp_GetLastProductId]
AS
BEGIN
	
	SELECT IDENT_CURRENT('Product')

END
GO
/****** Object:  StoredProcedure [dbo].[usp_GetProductCategories]    Script Date: 11/21/2021 12:35:13 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[usp_GetProductCategories]
	@productId int
AS
BEGIN
	
	SELECT pc.*,c.* from ProductCategory as pc inner join Product as p on pc.ProductId = p.ProductId
	inner join Category as c on pc.CategoryId = c.CategoryId
	where pc.ProductId = @productId

END
GO
/****** Object:  StoredProcedure [dbo].[usp_GetProductGallery]    Script Date: 11/21/2021 12:35:13 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[usp_GetProductGallery]
	@productId int
AS
BEGIN
	
	SELECT p.* from ProductGallery as p where p.ProductId = @productId

END
GO
/****** Object:  StoredProcedure [dbo].[usp_GetProducts]    Script Date: 11/21/2021 12:35:13 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[usp_GetProducts]
AS
BEGIN
	
	SELECT p.* from Product as p

END
GO
/****** Object:  StoredProcedure [dbo].[usp_InsertCategory]    Script Date: 11/21/2021 12:35:13 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[usp_InsertCategory] 
	@name nvarchar(50),
	@slug nvarchar(450),
	@description nvarchar(450),
	@visibility bit,
	@status bit,
	@metaTitle nvarchar(150),
	@metaDescription nvarchar(450),
	@insertDate datetime
AS
BEGIN

	INSERT INTO [dbo].[Category]
           ([Name]
           ,[Slug]
           ,[Description]
           ,[Visibility]
           ,[Status]
           ,[MetaTitle]
           ,[MetaDescription]
           ,[InsertDate])
     VALUES
           (@name
           ,@slug
           ,@description
           ,@visibility
           ,@status
           ,@metaTitle
           ,@metaDescription
           ,@insertDate)

END
GO
/****** Object:  StoredProcedure [dbo].[usp_InsertProduct]    Script Date: 11/21/2021 12:35:13 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[usp_InsertProduct]
	@name nvarchar(450),
	@slug nvarchar(450),
	@summary nvarchar(250),
	@description nvarchar(450),
	@visibility bit,
	@stock int,
	@sku nvarchar(50),
	@price money,
	@oldPrice money,
	@status bit,
	@metaTitle nvarchar(250),
	@metaDescription nvarchar(450),
	@insertDate datetime,
	@new_identity int OUTPUT
AS
BEGIN
	
	INSERT INTO [dbo].[Product]
           ([Name]
           ,[Slug]
           ,[Summary]
           ,[Description]
           ,[Visibility]
           ,[Stock]
           ,[SKU]
           ,[Price]
           ,[OldPrice]
           ,[Status]
           ,[MetaTitle]
           ,[MetaDescription]
           ,[InsertDate])
     VALUES
           (@name
           ,@slug
           ,@summary
           ,@description
           ,@visibility
           ,@stock
           ,@sku
           ,@price
           ,@oldPrice
           ,@status
           ,@metaTitle
           ,@metaDescription
           ,@insertDate)


		SELECT @new_identity = SCOPE_IDENTITY()

		SELECT @new_identity AS id

		RETURN


END


GO
/****** Object:  StoredProcedure [dbo].[usp_InsertProductCategories]    Script Date: 11/21/2021 12:35:13 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[usp_InsertProductCategories]
	@productId int,
	@categoryId int
AS
BEGIN
	
	INSERT INTO [dbo].[ProductCategory]
           ([ProductId]
           ,[CategoryId])
     VALUES
           (@productId
           ,@categoryId)

END
GO
/****** Object:  StoredProcedure [dbo].[usp_InsertProductGallery]    Script Date: 11/21/2021 12:35:13 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[usp_InsertProductGallery]
	@productId int,
	@name nvarchar(450),
	@url nvarchar(450)
AS
BEGIN
	
	INSERT INTO [dbo].[ProductGallery]
           ([ProductId]
           ,[Name]
           ,[URL])
     VALUES
           (@productId
           ,@name
           ,@url)

END
GO
USE [master]
GO
ALTER DATABASE [Technocy] SET  READ_WRITE 
GO
