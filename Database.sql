USE [master]
GO
/****** Object:  Database [Technocy]    Script Date: 12/7/2021 11:11:03 AM ******/
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
/****** Object:  Table [dbo].[Category]    Script Date: 12/7/2021 11:11:03 AM ******/
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
/****** Object:  Table [dbo].[Customer]    Script Date: 12/7/2021 11:11:03 AM ******/
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
/****** Object:  Table [dbo].[Employee]    Script Date: 12/7/2021 11:11:03 AM ******/
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
/****** Object:  Table [dbo].[Order]    Script Date: 12/7/2021 11:11:03 AM ******/
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
/****** Object:  Table [dbo].[OrderDetails]    Script Date: 12/7/2021 11:11:03 AM ******/
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
/****** Object:  Table [dbo].[Product]    Script Date: 12/7/2021 11:11:03 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Product](
	[ProductId] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](450) NULL,
	[Slug] [nvarchar](450) NULL,
	[Summary] [varchar](max) NULL,
	[Description] [varchar](max) NULL,
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
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ProductCategory]    Script Date: 12/7/2021 11:11:03 AM ******/
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
/****** Object:  Table [dbo].[ProductGallery]    Script Date: 12/7/2021 11:11:03 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ProductGallery](
	[ProductGalleryId] [int] IDENTITY(1,1) NOT NULL,
	[ProductId] [int] NULL,
	[Name] [nvarchar](450) NULL,
	[URL] [nvarchar](450) NULL,
	[AltText] [nvarchar](450) NULL,
 CONSTRAINT [PK_ProductGallery] PRIMARY KEY CLUSTERED 
(
	[ProductGalleryId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Role]    Script Date: 12/7/2021 11:11:03 AM ******/
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
/****** Object:  Table [dbo].[Wishlist]    Script Date: 12/7/2021 11:11:03 AM ******/
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
INSERT [dbo].[Category] ([CategoryId], [Name], [Slug], [Description], [Visibility], [Status], [MetaTitle], [MetaDescription], [InsertDate], [LastUpdatedDate]) VALUES (9, N'Promovime', N'promovime', N'Kategoria per promovime te ndryshme ', 0, 1, NULL, NULL, CAST(N'2021-11-24T00:05:28.097' AS DateTime), CAST(N'2021-12-04T20:07:27.107' AS DateTime))
INSERT [dbo].[Category] ([CategoryId], [Name], [Slug], [Description], [Visibility], [Status], [MetaTitle], [MetaDescription], [InsertDate], [LastUpdatedDate]) VALUES (10, N'Aksesorë', N'aksesorë', N'Lorem Ipsum is simply dummy text of the printing and typesetting industry.', 1, 1, N'Aksesorë', N'Aksesorë', CAST(N'2021-12-04T20:05:32.673' AS DateTime), NULL)
INSERT [dbo].[Category] ([CategoryId], [Name], [Slug], [Description], [Visibility], [Status], [MetaTitle], [MetaDescription], [InsertDate], [LastUpdatedDate]) VALUES (11, N'Çka ka t''re?', N'cka-ka-tre', N'Kategoria për risi dhe produkte të sapo ardhura', 1, 1, N'Çka ka t''re?', N'Çka ka t''re?', CAST(N'2021-12-05T17:00:11.180' AS DateTime), CAST(N'2021-12-06T23:23:17.477' AS DateTime))
SET IDENTITY_INSERT [dbo].[Category] OFF
GO
SET IDENTITY_INSERT [dbo].[Employee] ON 

INSERT [dbo].[Employee] ([EmployeeId], [RoleId], [Name], [Surname], [Email], [Username], [PasswordHash], [Status], [Birthdate], [Address], [City], [Country], [PostalCode], [Phone], [InsertDate], [LastUpdatedDate]) VALUES (3, 1, N'Albin', N'Halitaj', N'albin.halitaj@gmail.com', N'albinhalitaj', N'YWxiaW5oYWxpdGFq', 1, CAST(N'2001-08-15' AS Date), N'Fadil Elshani, Sopijë', N'Suharekë', N'Kosovë', N'23000', N'049200236', CAST(N'2021-11-19T22:56:48.687' AS DateTime), NULL)
SET IDENTITY_INSERT [dbo].[Employee] OFF
GO
SET IDENTITY_INSERT [dbo].[Product] ON 

INSERT [dbo].[Product] ([ProductId], [Name], [Slug], [Summary], [Description], [Visibility], [Stock], [SKU], [Price], [OldPrice], [Status], [MetaTitle], [MetaDescription], [InsertDate], [LastUpdatedDate]) VALUES (27, N'Kompjuter Apple iMac (2020), 21.5" 4K UHD, Intel Core i5, 8GB RAM DDR4 256GB SSD', N'kompjuter-apple-imac-2020-21.5-4k-uhd-intel-core-i5-8gb-ram-ddr4-256gb-ssd-amd-radeon-pro-560x-i-argjendte', N'iMac vazhdon të evoluojë, dhe tani ju mund të bëni me të më shumë punë dhe argëtim se kurrë më parë. Ai ju ofron performancë të shkëlqyer në një dizajn klasik elegant me teknologji të lehtë për t’u përdorur. Kjo është saktësisht çfarë prisni nga një ', N'<p>Detajet teknike</p>

<p>Besueshm&euml;ria:</p>

<p>100 %</p>

<p>Bluetooth:</p>

<p>Diagonalja e ekranit:</p>

<p>21,5</p>

<p>Drive optik:</p>

<p>Jo</p>

<p>EAN:</p>

<p>194252160763</p>

<p>Frekuenca e memories MHz:</p>

<p>2&nbsp;050</p>

<p>Garancioni nga prodhuesi:</p>

<p>1 vit</p>

<p>Gjer&euml;sia mm:</p>

<p>528</p>

<p>Kapaciteti i memories GB:</p>

<p>8</p>

<p>Kapaciteti i memories grafike MB:&lt;/</p>
', 1, 1, N'294715', 1299.5000, 1593.5000, 1, N'Kompjuter Apple iMac (2020), 21.5" 4K UHD, Intel Core i5, 8GB RAM DDR4 256GB SSD', N'Imazhi është prodhuar nga kartela grafike AMD Radeon Pro 560x me 4GB memorie GDDR5. Një hard disk 256 GB SSD është i gatshëm për sistemin, të dhënat dhe aplikacionet. Kompjuteri përfshin një kamerë të integruar FaceTime HD 720p mbi ekran, ndërfaqe wireless WiFi ac dhe portë Gigabit Ethernet për komunikim. Ju do të vlerësoni gjithashtu teknologjinë Bluetooth 4.2, 2x Thunderbolt 3, 4x USB 3.0 / 3.1 / 3.2 Gen 1, slotin për kartat e memories dhe dalj', CAST(N'2021-11-23T19:54:43.077' AS DateTime), CAST(N'2021-12-05T20:04:04.870' AS DateTime))
INSERT [dbo].[Product] ([ProductId], [Name], [Slug], [Summary], [Description], [Visibility], [Stock], [SKU], [Price], [OldPrice], [Status], [MetaTitle], [MetaDescription], [InsertDate], [LastUpdatedDate]) VALUES (28, N'Karrige CONNECT IT LeMans Pro, e zezë / portokalli', N'karrige-connect-it-lemans-pro,-e-zezë-portokalli', N'Karriga në formë ergonomike me një dizajn modern siguron ulje të rehatshme kur luani lojëra. Mbështetësja e shpinës krijon një mbështetje të besueshme për të gjithë sipërfaqen e pasme, duke mbajtur drejt shtyllën kurrizore. Karriga ka ndërtim të leht', N'<p>Detajet teknike</p>

<p>Besueshm&euml;ria:</p>

<p>100 %</p>

<p>EAN:</p>

<p>8595610627751</p>

<p>Garancioni nga prodhuesi:</p>

<p>1 vit</p>

<p>Gjer&euml;sia mm:</p>

<p>680</p>

<p>Jast&euml;k p&euml;r kok&euml;:</p>

<p>Kapaciteti i bartjes kg:</p>

<p>150</p>

<p>Kodi:</p>

<p>CGC-0700-OR</p>

<p>Lansuar:</p>

<p>17. 6. 2020</p>

<p>Lart&euml;si t&euml; personalizueshme t&euml; karriges mm:</p>

<p>100&lt;</p>
', 1, 5, N'290775', 227.0100, 245.5000, 1, N'Karrige CONNECT IT LeMans Pro, e zezë / portokalli', N'Karriga në formë ergonomike me një dizajn modern siguron ulje të rehatshme kur luani lojëra. Mbështetësja e shpinës krijon një mbështetje të besueshme për të gjithë sipërfaqen e pasme, duke mbajtur drejt shtyllën kurrizore. Karriga ka ndërtim të lehtë dhe të qëndrueshëm me ulëse të një cilësie të lartë dhe mbushje në pjesën e pasme, të mbuluar me lëkurë që ajroset. ', CAST(N'2021-11-23T19:57:25.137' AS DateTime), CAST(N'2021-12-05T19:26:13.467' AS DateTime))
INSERT [dbo].[Product] ([ProductId], [Name], [Slug], [Summary], [Description], [Visibility], [Stock], [SKU], [Price], [OldPrice], [Status], [MetaTitle], [MetaDescription], [InsertDate], [LastUpdatedDate]) VALUES (29, N'Televizor Samsung UE50AU8072UXXH, 50" (125cm), 4K UHD, i zi', N'televizor-samsung-ue50au8072uxxh-50-125cm-4k-uhd-i-zi', N'Një televizor i mrekullueshëm që krijon një atmosferë të këndshme në shtëpinë tuaj, plot tinguj dhe imazhe mahnitëse - ky është Samsung UE50AU8072UXXH.

Crystal Dynamic Color është një teknologji për ngjyra të pastra, të ndritshme dhe të llojllojsh', N'<p>Detajet teknike</p>

<p>Audio optike:</p>

<p>Bluetooth:</p>

<p>CI:</p>

<p>Diagonalja e ekranit:</p>

<p>50</p>

<p>Diagonalja e ekranit cm:</p>

<p>125</p>

<p>DLNA:</p>

<p>EAN:</p>

<p>8806092049802</p>

<p>EPG:</p>

<p>Frekuenc&euml; Hz:</p>

<p>50</p>

<p>Garancioni nga prodhuesi:</p>

<p>2 vite</p>

<p>Gjer&euml;sia mm:</p>

<p>1&nbsp;118</p>
', 1, 8, N'918792smg', 549.0000, 699.5000, 1, N'Televizor Samsung UE50AU8072UXXH, 50" (125cm), 4K UHD, i zi', N'Falë zgjidhjes Q-Symphony, do të kënaqeni me tinguj edhe më të fuqishëm dhe hapësinorë kur shikoni multimedia. Kur lidhet një soundbar i pajtueshëm, altoparlantët e vetë televizorit mund të luajnë akoma përveç tij - natyrisht në harmoni të përsosur.

Dëshironi një televizor që, përveç relaksit, mund të bëjë një punë të shkëlqyeshme? Kështu që ju jeni këtu! Ju mund ta lidhni me lehtësi këtë TV Samsung si me kompjuterin tuaj ashtu edhe me laptopi', CAST(N'2021-11-23T19:59:30.950' AS DateTime), NULL)
INSERT [dbo].[Product] ([ProductId], [Name], [Slug], [Summary], [Description], [Visibility], [Stock], [SKU], [Price], [OldPrice], [Status], [MetaTitle], [MetaDescription], [InsertDate], [LastUpdatedDate]) VALUES (32, N'Laptop Lenovo Legion 5 17IMH05, 17.3'''', Intel Core i5, 16 GB RAM, 512 GB SSD, NVIDIA GeForce GTX 1650 Ti, i zi', N'laptop-lenovo-legion-5-17imh05-17.3-intel-core-i5-16-gb-ram-512-gb-ssd-nvidia-geforce-gtx-1650-ti-i-zi', N'Shënim: Tastiera te pjesa numerike ka disa simbole çeke. Ndërsa, Microsoft Office është në verzion provues ose nuk është i instaluar fare. Ky laptop ka procesor të fuqishëm Intel Core i5 10300H me 4 bërthama dhe memorie RAM 16 GB ndërsa për të dhëna ', N'<p>Prodhuesi: Lenovo</p>
', 1, 6, N'325123', 839.5000, 973.5000, 1, N'Laptop Lenovo Legion 5 17IMH05, 17.3'''', Intel Core i5, 16 GB RAM, 512 GB SSD, NVIDIA GeForce GTX 1650 Ti, i zi', N'Shënim: Tastiera te pjesa numerike ka disa simbole çeke. Ndërsa, Microsoft Office është në verzion provues ose nuk është i instaluar fare. Ky laptop ka procesor të fuqishëm Intel Core i5 10300H me 4 bërthama dhe memorie RAM 16 GB ndërsa për të dhëna 512 GB SSD. Ekrani 17.3'''' ka rezolucion 1920 x 1080 pikselë në kombinim me kartelën grafike NVIDIA GeForce GTX 1650 Ti me memorie prej 4,096 MB. Mbështet WiFi, Bluetooth, porte USB. Nuk ka sistem oper', CAST(N'2021-12-03T23:40:34.670' AS DateTime), NULL)
INSERT [dbo].[Product] ([ProductId], [Name], [Slug], [Summary], [Description], [Visibility], [Stock], [SKU], [Price], [OldPrice], [Status], [MetaTitle], [MetaDescription], [InsertDate], [LastUpdatedDate]) VALUES (33, N'Tablet Samsung Galaxy TAB S6 SM-P615 Lite LTE, i hirtë', N'tablet-samsung-galaxy-tab-s6-sm-p615-lite-lte-i-hirte', N'Samsung sjell në treg verzionin më të ri të tabletëve Samsung Galaxy Tab S6 Lite P615N me performancë superiore dhe dizajn kompakt e elegant. Samsung Galaxy Tab S6 Lite P615N ka ekran me prekje (touch) 10.4” me rezolucion 2000 x 1200 pikselë me të ci', N'<p>Diagonalja e ekranit: 10.4</p>

<p>EAN: 8806090478765</p>
', 1, 0, N'768299smg', 369.5000, 0.0000, 0, N'Tablet Samsung Galaxy TAB S6 SM-P615 Lite LTE, i hirtë', N'Samsung sjell në treg verzionin më të ri të tabletëve Samsung Galaxy Tab S6 Lite P615N me performancë superiore dhe dizajn kompakt e elegant. Samsung Galaxy Tab S6 Lite P615N ka ekran me prekje (touch) 10.4” me rezolucion 2000 x 1200 pikselë me të cilin shfaq imazhe me qartësi dhe detaje të jashtzakonshme. Poashtu, kap edhe imazhe me qartësi të lartë përmes dy kamerave, një të përparme 5 MP dhe një të pasme 8MP.

', CAST(N'2021-12-04T19:04:38.483' AS DateTime), CAST(N'2021-12-06T22:57:18.643' AS DateTime))
INSERT [dbo].[Product] ([ProductId], [Name], [Slug], [Summary], [Description], [Visibility], [Stock], [SKU], [Price], [OldPrice], [Status], [MetaTitle], [MetaDescription], [InsertDate], [LastUpdatedDate]) VALUES (34, N'Kompjuter Gjirafa50 Paladin GC112, Intel Core i5, 16GB RAM, 500GB SSD, 1TB HDD, Gainward RTX 3070 Phoenix 8GB GDDR6, i zi', N'kompjuter-czc-paladin-gc112-intel-core-i5-16gb-ram-500gb-ssd-nvidia-geforce-rtx-3070-i-zi', N'Gjirafa50 Paladin GC112 është kompjuter kompakt dhe i lehtë i cili ju plotëson të gjitha kërkesat me performancën e tij të lartë dhe në të njëjtën kohë nuk ju zë shumë vend.

Kompjuteri vjen i pajisur me procesorin 6 bërthamësh Intel Core i5-10600K', N'<p>Drive optik: Jo</p>

<p>Energjia elektrike maksimale W: 700</p>

<p>Frekuenca e memories MHz: 3200</p>

<p>Garancioni nga prodhuesi: 1 vit</p>

<p>Gjenerata e procesorit: Comet Lake - gjenerata e 10-t&euml;</p>

<p>Gjer&euml;sia mm: 210</p>

<p>Kapaciteti i memories GB: 16</p>

<p>Kapaciteti i memories grafike MB: 8192</p>

<p>Kapaciteti i SSD-s&euml; GB: 500</p>
', 1, 4, N'305445', 1870.5600, 1948.5000, 1, N'Kompjuter Gjirafa50 Paladin GC112, Intel Core i5, 16GB RAM, 500GB SSD', N'Gjirafa50 Paladin GC112 është kompjuter kompakt dhe i lehtë i cili ju plotëson të gjitha kërkesat me performancën e tij të lartë dhe në të njëjtën kohë nuk ju zë shumë vend', CAST(N'2021-12-04T20:02:24.073' AS DateTime), CAST(N'2021-12-06T17:30:20.723' AS DateTime))
INSERT [dbo].[Product] ([ProductId], [Name], [Slug], [Summary], [Description], [Visibility], [Stock], [SKU], [Price], [OldPrice], [Status], [MetaTitle], [MetaDescription], [InsertDate], [LastUpdatedDate]) VALUES (35, N'Maus Logitech MX Master 3, Graphite', N'maus-logitech-mx-master-3-graphite', N'Maus wireless profesional i nivelit të lartë që do ta bëjë punën tuaj më të lehtë dhe do të rrisë produktivitetin tuaj. Ai ka dizajn kompakt, saktësia të lartë dhe tipare të shkëlqyera. Do të kënaqeni gjithashtu nga prania e një rrote metalike të kri', N'<p>Besueshm&euml;ria: 100 %</p>

<p>EAN: 5099206085800</p>

<p>Ergonomia: P&euml;r djathtak&euml;</p>

<p>Garancioni nga prodhuesi: 1 vit</p>

<p>Gjer&euml;sia mm: 84,3</p>

<p>Kodi: 910-005694</p>

<p>Lansuar: 13. 9. 2019</p>
', 1, 12, N'269835', 92.6200, 0.0000, 1, N'Maus Logitech MX Master 3, Graphite', N'Maus wireless profesional i nivelit të lartë që do ta bëjë punën tuaj më të lehtë dhe do të rrisë produktivitetin tuaj. Ai ka dizajn kompakt, saktësia të lartë dhe tipare të shkëlqyera. Do të kënaqeni gjithashtu nga prania e një rrote metalike të krijuar posaçërisht. Sensori lazer me saktësi 5x siguron që kursori i mausit është në përputhje me qëllimin tuaj.', CAST(N'2021-12-04T20:13:29.003' AS DateTime), CAST(N'2021-12-05T20:04:30.680' AS DateTime))
INSERT [dbo].[Product] ([ProductId], [Name], [Slug], [Summary], [Description], [Visibility], [Stock], [SKU], [Price], [OldPrice], [Status], [MetaTitle], [MetaDescription], [InsertDate], [LastUpdatedDate]) VALUES (36, N'Karikues Apple USB-C, 20W, i bardhë (bulk)', N'karikues-apple-usb-c-20w-i-bardhe-bulk', N'Karikues i fuqishëm 20W USB - C Apple përdoret për karikim të shpejtë dhe efikas në shtëpi, në zyrë dhe në lëvizje. Është në përputhje me çdo pajisje USB-C, por për performancën optimale të karikimit, Apple rekomandon përdorimin e tij me iPad Pro 11-', N'<p>Besueshm&euml;ria: 100 %</p>

<p>Dizajnuar p&euml;r: Celular, kufje, tablet</p>

<p>EAN: 194252157022</p>

<p>Garancioni nga prodhuesi: 1 vit</p>

<p>Karikim pa kabllo: Jo</p>

<p>Kodi: MHJE3ZM/A</p>

<p>Konektory: USB-C</p>
', 1, 3, N'327976', 19.5000, 0.0000, 1, N'Karikues Apple USB-C, 20W, i bardhë (bulk)', N'Karikues i fuqishëm 20W USB - C Apple përdoret për karikim të shpejtë dhe efikas në shtëpi, në zyrë dhe në lëvizje. Është në përputhje me çdo pajisje USB-C, por për performancën optimale të karikimit, Apple rekomandon përdorimin e tij me iPad Pro 11-inç ose iPad Pro 12.9-inç (gjenerata e 3-të). Ai gjithashtu mbështet karikimin e shpejtë të iPhone 8 dhe më të ri. Vjen pa kabllo. Produkti vjen i paketuar në qese.', CAST(N'2021-12-05T17:02:57.723' AS DateTime), CAST(N'2021-12-06T17:43:24.310' AS DateTime))
INSERT [dbo].[Product] ([ProductId], [Name], [Slug], [Summary], [Description], [Visibility], [Stock], [SKU], [Price], [OldPrice], [Status], [MetaTitle], [MetaDescription], [InsertDate], [LastUpdatedDate]) VALUES (37, N'Lente Sony FE, 70–200mm, f/2.8 GM OSS', N'lente-sony-fe-70200mm-f-2.8-gm-oss', N'Lente Sony FE me ndricim f / 2.8 GM OSS. Lentet ofrojnë dizajn optik të shkëlqyer, motor AF (SSM) dhe dy motorë të tjerë linearë që prejnë saktë dhe shpejt. Natyrisht, ky lent në sajë të një motori të dyfishtë linear, drejton mekanizmin e fokusimit q', N'<p>Apertura: 2,8</p>

<p>Bayonet: Sony E</p>

<p>Diametri i filterit [mm]: 77</p>

<p>Distanca e fokusit [m]: 0,96</p>

<p>EAN: 4548736038417</p>

<p>Garancioni nga prodhuesi: 1 vit</p>

<p>Gjat&euml;sia e lent&euml;s / objektivit [mm]: 200</p>

<p>Gjat&euml;sia maksimale fokale [mm]: 200</p>

<p>Gjat&euml;sia minimale fokale [mm]: 70</p>
', 1, 2, N'215307', 3354.7200, 3494.5000, 1, N'Lente Sony FE, 70–200mm, f/2.8 GM OSS', N'Lente Sony FE me ndricim f / 2.8 GM OSS. Lentet ofrojnë dizajn optik të shkëlqyer, motor AF (SSM) dhe dy motorë të tjerë linearë që prejnë saktë dhe shpejt. Natyrisht, ky lent në sajë të një motori të dyfishtë linear, drejton mekanizmin e fokusimit qetë. Një shok ideal jo vetëm për të bërë filma, por edhe për fotografi në sporte, fenomene natyrore dhe shumë ngjarje të tjera. Lentet janë rezistent ndaj pluhurit dhe lagështirës. Gjatësia fokale min', CAST(N'2021-12-05T21:47:52.400' AS DateTime), NULL)
INSERT [dbo].[Product] ([ProductId], [Name], [Slug], [Summary], [Description], [Visibility], [Stock], [SKU], [Price], [OldPrice], [Status], [MetaTitle], [MetaDescription], [InsertDate], [LastUpdatedDate]) VALUES (38, N'Konzolë Xbox Series S, 512GB, i bardhë', N'konzole-xbox-series-s', N'Një konzolë novatore me performancë të lartë që bën përshtypje me trupin e saj kompakt, ndër të tjera - është madje pothuajse 60 për qind më e vogël se vëllai i tij më i fuqishëm, Xbox Series X. Për të rritur fuqinë kompjuterike, konzola përdor një z', N'<p>EAN: 889842651409</p>

<p>Garancioni nga prodhuesi: 1 vit</p>

<p>Kapaciteti i diskut SSD [GB]: 512</p>

<p>Kodi: RRS-00010</p>

<p>Lansuar: 9.9.2020</p>

<p>Lloji: Xbox Series S</p>

<p>Maksimumi i shkrepjeve [fps]: Deri n&euml; 120</p>

<p>Ngjyra: Bardh&euml;</p>

<p>Prodhuesi: Microsoft</p>

<p>Ueb-i i prodhuesit: microsoft.com</p>
', 1, 13, N'297406', 369.5000, 413.5000, 1, N'Konzolë Xbox Series S, 512GB, i bardhë', N'Një konzolë novatore me performancë të lartë që bën përshtypje me trupin e saj kompakt, ndër të tjera - është madje pothuajse 60 për qind më e vogël se vëllai i tij më i fuqishëm, Xbox Series X. Për të rritur fuqinë kompjuterike, konzola përdor një zgjidhje të dizajnuar me porosi NVME SSD me arkitekturë Xbox Velocity, e cila ka një ndikim të rëndësishëm në zvogëlimin e shpejtësisë së ngarkimit të skedarëve të lojërave dhe ndërrimin e shpejtë të l', CAST(N'2021-12-05T23:26:07.693' AS DateTime), NULL)
INSERT [dbo].[Product] ([ProductId], [Name], [Slug], [Summary], [Description], [Visibility], [Stock], [SKU], [Price], [OldPrice], [Status], [MetaTitle], [MetaDescription], [InsertDate], [LastUpdatedDate]) VALUES (39, N'Rrip metalik UNIQ Dante për Apple Watch 42/44mm, i hirtë', N'rrip-metalik-uniq-dante-për-apple-watch-4244mm-i-hirtë', N'Një rrip elegant prej çeliku do të zbukurojë jo vetëm orën, por edhe dorën tuaj. Dizajni elegant kombinohet me forcë të lartë. Ai qëndron shumë rehatshëm në kyçin e dorës dhe siguron rehati të lartë gjatë veshjes. Kur e përdorni për herë të parë, mja', N'<p>Besueshm&euml;ria: 100 %</p>

<p>EAN: 8886463675786</p>

<p>Garancioni nga prodhuesi: 1 vit</p>

<p>Kodi: UNIQ-44MM-DANGRP</p>

<p>Prodhuesi: UNIQ</p>

<p>Vnab&iacute;dce od: 30. 10. 2021</p>

<p>Vendi i origjin&euml;s: Singapore</p>
', 1, 2, N'331272', 49.3900, 55.5000, 1, N'rrip-metalik-uniq-dante-për-apple-watch-4244mm-i-hirtë', N'Një rrip elegant prej çeliku do të zbukurojë jo vetëm orën, por edhe dorën tuaj. Dizajni elegant kombinohet me forcë të lartë. Ai qëndron shumë rehatshëm në kyçin e dorës dhe siguron rehati të lartë gjatë veshjes. Kur e përdorni për herë të parë, mjafton të lidhni rripin në orë me skajet magnetike, të bashkoni pjesën e parë të rripit me të dytin dhe më pas ta fiksoni aty ku ju nevojitet me skajin magnetik.
', CAST(N'2021-12-06T23:10:12.847' AS DateTime), NULL)
SET IDENTITY_INSERT [dbo].[Product] OFF
GO
SET IDENTITY_INSERT [dbo].[ProductCategory] ON 

INSERT [dbo].[ProductCategory] ([ProductCategoryId], [ProductId], [CategoryId]) VALUES (25, 29, 8)
INSERT [dbo].[ProductCategory] ([ProductCategoryId], [ProductId], [CategoryId]) VALUES (28, 32, 2)
INSERT [dbo].[ProductCategory] ([ProductCategoryId], [ProductId], [CategoryId]) VALUES (41, 28, 1)
INSERT [dbo].[ProductCategory] ([ProductCategoryId], [ProductId], [CategoryId]) VALUES (44, 27, 2)
INSERT [dbo].[ProductCategory] ([ProductCategoryId], [ProductId], [CategoryId]) VALUES (45, 35, 10)
INSERT [dbo].[ProductCategory] ([ProductCategoryId], [ProductId], [CategoryId]) VALUES (46, 35, 11)
INSERT [dbo].[ProductCategory] ([ProductCategoryId], [ProductId], [CategoryId]) VALUES (50, 37, 6)
INSERT [dbo].[ProductCategory] ([ProductCategoryId], [ProductId], [CategoryId]) VALUES (51, 37, 8)
INSERT [dbo].[ProductCategory] ([ProductCategoryId], [ProductId], [CategoryId]) VALUES (54, 38, 1)
INSERT [dbo].[ProductCategory] ([ProductCategoryId], [ProductId], [CategoryId]) VALUES (74, 34, 2)
INSERT [dbo].[ProductCategory] ([ProductCategoryId], [ProductId], [CategoryId]) VALUES (75, 36, 10)
INSERT [dbo].[ProductCategory] ([ProductCategoryId], [ProductId], [CategoryId]) VALUES (76, 33, 3)
INSERT [dbo].[ProductCategory] ([ProductCategoryId], [ProductId], [CategoryId]) VALUES (77, 39, 11)
SET IDENTITY_INSERT [dbo].[ProductCategory] OFF
GO
SET IDENTITY_INSERT [dbo].[ProductGallery] ON 

INSERT [dbo].[ProductGallery] ([ProductGalleryId], [ProductId], [Name], [URL], [AltText]) VALUES (42, 27, N'appleMac1.jpg', N'/Admin/images/products/f7d56d44-f4bf-4369-8d6f-fe2952ac3788_appleMac1.jpg', NULL)
INSERT [dbo].[ProductGallery] ([ProductGalleryId], [ProductId], [Name], [URL], [AltText]) VALUES (43, 27, N'appleMac2.jpg', N'/Admin/images/products/c8310d03-2009-43bc-a8b5-43cc204cce94_appleMac2.jpg', NULL)
INSERT [dbo].[ProductGallery] ([ProductGalleryId], [ProductId], [Name], [URL], [AltText]) VALUES (44, 28, N'karrige1.jpg', N'/Admin/images/products/d7986343-c46c-477d-8486-1cce3ea74877_karrige1.jpg', NULL)
INSERT [dbo].[ProductGallery] ([ProductGalleryId], [ProductId], [Name], [URL], [AltText]) VALUES (45, 28, N'karrige2.jpg', N'/Admin/images/products/d39e1467-5121-4533-adc9-ea735b4c10ac_karrige2.jpg', NULL)
INSERT [dbo].[ProductGallery] ([ProductGalleryId], [ProductId], [Name], [URL], [AltText]) VALUES (46, 28, N'karrige3.jpg', N'/Admin/images/products/9b77b246-3b6f-4abf-9097-7fef39d1ec02_karrige3.jpg', NULL)
INSERT [dbo].[ProductGallery] ([ProductGalleryId], [ProductId], [Name], [URL], [AltText]) VALUES (47, 29, N'samsungtv1.jpg', N'/Admin/images/products/d204d272-9cda-4f95-ac13-798e666e0425_samsungtv1.jpg', NULL)
INSERT [dbo].[ProductGallery] ([ProductGalleryId], [ProductId], [Name], [URL], [AltText]) VALUES (48, 29, N'samsungtv2.jpg', N'/Admin/images/products/ffc5efb5-4396-4fde-88a7-922e68a9de70_samsungtv2.jpg', NULL)
INSERT [dbo].[ProductGallery] ([ProductGalleryId], [ProductId], [Name], [URL], [AltText]) VALUES (49, 29, N'samsungtv3.jpg', N'/Admin/images/products/7e4c22e5-ddef-4d35-b0e6-0baf7a66a470_samsungtv3.jpg', NULL)
INSERT [dbo].[ProductGallery] ([ProductGalleryId], [ProductId], [Name], [URL], [AltText]) VALUES (54, 32, N'lenovo1.jpg', N'/Admin/images/products/3a9d1012-486e-43bc-90fe-3f298e9f95fd_lenovo1.jpg', NULL)
INSERT [dbo].[ProductGallery] ([ProductGalleryId], [ProductId], [Name], [URL], [AltText]) VALUES (55, 32, N'lenovo2.jpg', N'/Admin/images/products/258e5c7f-6947-4225-b85d-d6b922fae9a6_lenovo2.jpg', NULL)
INSERT [dbo].[ProductGallery] ([ProductGalleryId], [ProductId], [Name], [URL], [AltText]) VALUES (56, 32, N'lenovo3.jpg', N'/Admin/images/products/e0f95066-b75c-4ef6-8cc1-a94e41fbb851_lenovo3.jpg', NULL)
INSERT [dbo].[ProductGallery] ([ProductGalleryId], [ProductId], [Name], [URL], [AltText]) VALUES (57, 33, N'tablet.jpg', N'/Admin/images/products/04a42d7e-024d-46c2-9602-435dbdd7a6a7_tablet.jpg', NULL)
INSERT [dbo].[ProductGallery] ([ProductGalleryId], [ProductId], [Name], [URL], [AltText]) VALUES (58, 34, N'kompjuter.jpg', N'/Admin/images/products/1b101824-6736-4f9a-9bc5-cf867ee77e75_kompjuter.jpg', NULL)
INSERT [dbo].[ProductGallery] ([ProductGalleryId], [ProductId], [Name], [URL], [AltText]) VALUES (59, 35, N'maus1.jpg', N'/Admin/images/products/200fba1b-c02e-4481-8dd3-d2d3982c13a7_maus1.jpg', NULL)
INSERT [dbo].[ProductGallery] ([ProductGalleryId], [ProductId], [Name], [URL], [AltText]) VALUES (60, 35, N'maus2.jpg', N'/Admin/images/products/e0ac4c47-8b38-43d6-9438-dc2350199fe9_maus2.jpg', NULL)
INSERT [dbo].[ProductGallery] ([ProductGalleryId], [ProductId], [Name], [URL], [AltText]) VALUES (61, 35, N'maus3.jpg', N'/Admin/images/products/88ace4c9-bb7e-42e1-a21a-3f23ada7e3c8_maus3.jpg', NULL)
INSERT [dbo].[ProductGallery] ([ProductGalleryId], [ProductId], [Name], [URL], [AltText]) VALUES (62, 35, N'maus4.jpg', N'/Admin/images/products/0e5801c1-2b25-41fc-adb7-b29529d29031_maus4.jpg', NULL)
INSERT [dbo].[ProductGallery] ([ProductGalleryId], [ProductId], [Name], [URL], [AltText]) VALUES (64, 36, N'karikues1.jpg', N'/Admin/images/products/b12a33ba-4052-4fb1-92fd-39c0d289c347_karikues1.jpg', NULL)
INSERT [dbo].[ProductGallery] ([ProductGalleryId], [ProductId], [Name], [URL], [AltText]) VALUES (65, 36, N'karikues2.jpg', N'/Admin/images/products/68c62f86-a2e4-4157-a9dd-5b3c3be357f1_karikues2.jpg', NULL)
INSERT [dbo].[ProductGallery] ([ProductGalleryId], [ProductId], [Name], [URL], [AltText]) VALUES (73, 35, N'maus5.jpg', N'/Admin/images/products/e22709c3-9fc5-45dc-8e55-022a09173723_maus5.jpg', NULL)
INSERT [dbo].[ProductGallery] ([ProductGalleryId], [ProductId], [Name], [URL], [AltText]) VALUES (74, 37, N'lens.jpg', N'/Admin/images/products/a3f810e4-8e6b-4874-b44b-bf622b420c41_lens.jpg', NULL)
INSERT [dbo].[ProductGallery] ([ProductGalleryId], [ProductId], [Name], [URL], [AltText]) VALUES (75, 37, N'lens1.jpg', N'/Admin/images/products/36b7413f-8e4a-405c-8a66-8c9b1e59ad82_lens1.jpg', NULL)
INSERT [dbo].[ProductGallery] ([ProductGalleryId], [ProductId], [Name], [URL], [AltText]) VALUES (76, 37, N'lens2.jpg', N'/Admin/images/products/41946398-315f-4c6a-af25-94495b05dd3a_lens2.jpg', NULL)
INSERT [dbo].[ProductGallery] ([ProductGalleryId], [ProductId], [Name], [URL], [AltText]) VALUES (78, 38, N'xboxs.jpg', N'/Admin/images/products/1b46b06b-6a59-43e1-a1ed-2a8395778324_xboxs.jpg', NULL)
INSERT [dbo].[ProductGallery] ([ProductGalleryId], [ProductId], [Name], [URL], [AltText]) VALUES (81, 36, N'karikues3.jpg', N'/Admin/images/products/f2151e81-b297-4c19-ab71-db24024ac68d_karikues3.jpg', NULL)
INSERT [dbo].[ProductGallery] ([ProductGalleryId], [ProductId], [Name], [URL], [AltText]) VALUES (94, 39, N'rrip.jpg', N'/Admin/images/products/91f1ad24-1926-4539-930b-0b2b7351a5cb_rrip.jpg', NULL)
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
/****** Object:  StoredProcedure [dbo].[usp_DeleteCategory]    Script Date: 12/7/2021 11:11:03 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[usp_DeleteCategory]
	@id int
AS
BEGIN

		DELETE FROM dbo.Category WHERE CategoryId = @id

END
GO
/****** Object:  StoredProcedure [dbo].[usp_DeleteProduct]    Script Date: 12/7/2021 11:11:03 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[usp_DeleteProduct]
	@productId int
AS
BEGIN
	
	DELETE FROM dbo.Product WHERE ProductId = @productId

END
GO
/****** Object:  StoredProcedure [dbo].[usp_DeleteProductCategories]    Script Date: 12/7/2021 11:11:03 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[usp_DeleteProductCategories]
	@productId int
AS
BEGIN
	
	DELETE FROM dbo.ProductCategory WHERE ProductId = @productId

END
GO
/****** Object:  StoredProcedure [dbo].[usp_DeleteProductGalleries]    Script Date: 12/7/2021 11:11:03 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[usp_DeleteProductGalleries]
	@productId int
AS
BEGIN
	
	DELETE FROM dbo.ProductGallery WHERE ProductId = @productId

END
GO
/****** Object:  StoredProcedure [dbo].[usp_DeleteProductImage]    Script Date: 12/7/2021 11:11:03 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[usp_DeleteProductImage]
	@url nvarchar(450)
AS
BEGIN
	
	DELETE FROM dbo.ProductGallery WHERE URL = @url

END
GO
/****** Object:  StoredProcedure [dbo].[usp_EditCategory]    Script Date: 12/7/2021 11:11:03 AM ******/
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
/****** Object:  StoredProcedure [dbo].[usp_FilterProducts]    Script Date: 12/7/2021 11:11:03 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[usp_FilterProducts] 
	@startingPrice DECIMAL(19, 4),
	@endingPrice DECIMAL(19, 4),
	@visibility bit,
	@categories nvarchar(50)
AS
BEGIN

	IF LEN(@categories) > 0
		SELECT p.ProductId,
           p.Name,
           p.Slug,
           p.Summary,
           p.Description,
           p.Visibility,
           p.Stock,
           p.SKU,
           p.Price,
           p.OldPrice,
           p.Status,
           p.MetaTitle,
           p.MetaDescription,
           p.InsertDate,
           p.LastUpdatedDate,
           pc.ProductCategoryId,
           pc.ProductId,
           pc.CategoryId FROM dbo.Product AS p 
		   INNER join dbo.ProductCategory as pc 
		   ON P.ProductId = PC.ProductId
			WHERE p.Price BETWEEN @startingPrice AND @endingPrice 
			AND p.Visibility = @visibility
			AND pc.CategoryId IN (SELECT value from STRING_SPLIT(@categories,','))
	ELSE
		SELECT p.ProductId,
           p.Name,
           p.Slug,
           p.Summary,
           p.Description,
           p.Visibility,
           p.Stock,
           p.SKU,
           p.Price,
           p.OldPrice,
           p.Status,
           p.MetaTitle,
           p.MetaDescription,
           p.InsertDate,
           p.LastUpdatedDate,
           pc.ProductCategoryId,
           pc.ProductId,
           pc.CategoryId FROM dbo.Product AS p 
		   INNER join dbo.ProductCategory as pc 
		   ON P.ProductId = PC.ProductId
			WHERE p.Price BETWEEN @startingPrice AND @endingPrice 
			AND p.Visibility = @visibility

END
GO
/****** Object:  StoredProcedure [dbo].[usp_GetCategories]    Script Date: 12/7/2021 11:11:03 AM ******/
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
/****** Object:  StoredProcedure [dbo].[usp_GetCategory]    Script Date: 12/7/2021 11:11:03 AM ******/
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
/****** Object:  StoredProcedure [dbo].[usp_GetCategoryProductsCount]    Script Date: 12/7/2021 11:11:03 AM ******/
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
/****** Object:  StoredProcedure [dbo].[usp_GetDiscountProducts]    Script Date: 12/7/2021 11:11:03 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[usp_GetDiscountProducts]
AS
BEGIN
	
	SELECT ProductId,
           Name,
           Slug,
           Summary,
           Description,
           Visibility,
           Stock,
           SKU,
           Price,
           OldPrice,
           Status,
           MetaTitle,
           MetaDescription,
           InsertDate,
           LastUpdatedDate 
		   FROM dbo.Product 
	WHERE OldPrice > 0
	ORDER BY InsertDate DESC

END
GO
/****** Object:  StoredProcedure [dbo].[usp_GetEmployee]    Script Date: 12/7/2021 11:11:03 AM ******/
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
/****** Object:  StoredProcedure [dbo].[usp_GetLastProductId]    Script Date: 12/7/2021 11:11:03 AM ******/
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
/****** Object:  StoredProcedure [dbo].[usp_GetLatestProducts]    Script Date: 12/7/2021 11:11:03 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[usp_GetLatestProducts]
AS
BEGIN
	
	SELECT ProductId,
           Name,
           Slug,
           Summary,
           Description,
           Visibility,
           Stock,
           SKU,
           Price,
           OldPrice,
           Status,
           MetaTitle,
           MetaDescription,
           InsertDate,
           LastUpdatedDate 
		   FROM dbo.Product 
	ORDER BY InsertDate DESC

END
GO
/****** Object:  StoredProcedure [dbo].[usp_GetProduct]    Script Date: 12/7/2021 11:11:03 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[usp_GetProduct] 
	@productId int
AS
BEGIN
	
	SELECT * FROM Product WHERE ProductId = @productId

END
GO
/****** Object:  StoredProcedure [dbo].[usp_GetProductByPrice]    Script Date: 12/7/2021 11:11:03 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[usp_GetProductByPrice]
	@startingPrice DECIMAL(19, 4),
	@endingPrice DECIMAL(19, 4)
AS
BEGIN
	
	SELECT ProductId,
           Name,
           Slug,
           Summary,
           Description,
           Visibility,
           Stock,
           SKU,
           Price,
           OldPrice,
           Status,
           MetaTitle,
           MetaDescription,
           InsertDate,
           LastUpdatedDate FROM dbo.Product
	WHERE Price BETWEEN @startingPrice AND @endingPrice

END
GO
/****** Object:  StoredProcedure [dbo].[usp_GetProductCategories]    Script Date: 12/7/2021 11:11:03 AM ******/
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
/****** Object:  StoredProcedure [dbo].[usp_GetProductGallery]    Script Date: 12/7/2021 11:11:03 AM ******/
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
/****** Object:  StoredProcedure [dbo].[usp_GetProductNew]    Script Date: 12/7/2021 11:11:03 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[usp_GetProductNew]
AS
BEGIN
	
	SELECT p.ProductId,
           p.Name,
           p.Slug,
           p.Summary,
           p.Description,
           p.Visibility,
           p.Stock,
           p.SKU,
           p.Price,
           p.OldPrice,
           p.Status,
           p.MetaTitle,
           p.MetaDescription,
           p.InsertDate,
           p.LastUpdatedDate
	FROM dbo.ProductCategory AS pc 
	INNER JOIN dbo.Category AS c ON pc.CategoryId = c.CategoryId
	INNER JOIN dbo.Product AS p ON pc.ProductId = p.ProductId
	WHERE c.Name = 'Çka ka t''re?'
	ORDER BY p.ProductId DESC
	

END
GO
/****** Object:  StoredProcedure [dbo].[usp_GetProducts]    Script Date: 12/7/2021 11:11:03 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[usp_GetProducts]
AS
BEGIN
	
	SELECT p.* from Product as p
	order by InsertDate desc

END
GO
/****** Object:  StoredProcedure [dbo].[usp_GetProductsByAscPrice]    Script Date: 12/7/2021 11:11:03 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[usp_GetProductsByAscPrice]
AS
BEGIN
	
	SELECT ProductId,
           Name,
           Slug,
           Summary,
           Description,
           Visibility,
           Stock,
           SKU,
           Price,
           OldPrice,
           Status,
           MetaTitle,
           MetaDescription,
           InsertDate,
           LastUpdatedDate FROM dbo.Product
	ORDER BY Price ASC

END
GO
/****** Object:  StoredProcedure [dbo].[usp_GetProductsByCategory]    Script Date: 12/7/2021 11:11:03 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[usp_GetProductsByCategory]
	@slug NVARCHAR(450)
AS
BEGIN
	

	SELECT p.ProductId,
           p.Name,
           p.Slug,
           p.Summary,
           p.Description,
           p.Visibility,
           p.Stock,
           p.SKU,
           p.Price,
           p.OldPrice,
           p.Status,
           p.MetaTitle,
           p.MetaDescription,
           p.InsertDate,
           p.LastUpdatedDate FROM dbo.Product AS p 
	INNER JOIN dbo.ProductCategory AS pc ON p.ProductId = pc.ProductId
	WHERE pc.CategoryId = (SELECT CategoryId FROM dbo.Category AS c WHERE c.Slug = @slug)

END
GO
/****** Object:  StoredProcedure [dbo].[usp_GetProductsByDescPrice]    Script Date: 12/7/2021 11:11:03 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[usp_GetProductsByDescPrice]
AS
BEGIN
	
	SELECT ProductId,
           Name,
           Slug,
           Summary,
           Description,
           Visibility,
           Stock,
           SKU,
           Price,
           OldPrice,
           Status,
           MetaTitle,
           MetaDescription,
           InsertDate,
           LastUpdatedDate FROM dbo.Product
	ORDER BY Price DESC

END
GO
/****** Object:  StoredProcedure [dbo].[usp_GetProductSku]    Script Date: 12/7/2021 11:11:03 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create PROCEDURE [dbo].[usp_GetProductSku]
	@sku nvarchar(50)
AS
BEGIN
	
	select SKU from Product where SKU = @sku

END
GO
/****** Object:  StoredProcedure [dbo].[usp_InsertCategory]    Script Date: 12/7/2021 11:11:03 AM ******/
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
/****** Object:  StoredProcedure [dbo].[usp_InsertProduct]    Script Date: 12/7/2021 11:11:03 AM ******/
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
/****** Object:  StoredProcedure [dbo].[usp_InsertProductCategories]    Script Date: 12/7/2021 11:11:03 AM ******/
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
/****** Object:  StoredProcedure [dbo].[usp_InsertProductGallery]    Script Date: 12/7/2021 11:11:03 AM ******/
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
/****** Object:  StoredProcedure [dbo].[usp_UpdateProduct]    Script Date: 12/7/2021 11:11:03 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[usp_UpdateProduct] 
	@id INT,
	@name NVARCHAR(450),
	@slug NVARCHAR(450),
	@summary VARCHAR(MAX),
	@description VARCHAR(MAX),
	@visibility BIT,
	@stock INT,
	@sku NVARCHAR(50),
	@price DECIMAL(19, 4),
	@oldPrice DECIMAL(19, 4),
	@status BIT,
	@metaTitle NVARCHAR(250),
	@metaDescription NVARCHAR(450),
	@lastUpdatedDate DATETIME

AS
BEGIN
	
	UPDATE [dbo].[Product]
   SET [Name] = @name
      ,[Slug] = @slug
      ,[Summary] = @summary
      ,[Description] = @description
      ,[Visibility] = @visibility
      ,[Stock] = @stock
      ,[SKU] = @sku
      ,[Price] = @price
      ,[OldPrice] = @oldPrice
      ,[Status] = @status
      ,[MetaTitle] = @metaTitle
      ,[MetaDescription] = @metaDescription
      ,[LastUpdatedDate] = @lastUpdatedDate
 WHERE ProductId = @id


END
GO
/****** Object:  StoredProcedure [dbo].[usp_ValidateProductSku]    Script Date: 12/7/2021 11:11:03 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[usp_ValidateProductSku]
	@sku nvarchar(50)
AS
BEGIN
	
	select SKU from Product where SKU = @sku

END
GO
USE [master]
GO
ALTER DATABASE [Technocy] SET  READ_WRITE 
GO
