USE [master]
GO
/****** Object:  Database [resturantASP]    Script Date: 10/14/2022 1:47:53 AM ******/
CREATE DATABASE [resturantASP]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'resturantASP', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.SQLEXPRESS\MSSQL\DATA\resturantASP.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'resturantASP_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.SQLEXPRESS\MSSQL\DATA\resturantASP_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO
ALTER DATABASE [resturantASP] SET COMPATIBILITY_LEVEL = 140
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [resturantASP].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [resturantASP] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [resturantASP] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [resturantASP] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [resturantASP] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [resturantASP] SET ARITHABORT OFF 
GO
ALTER DATABASE [resturantASP] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [resturantASP] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [resturantASP] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [resturantASP] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [resturantASP] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [resturantASP] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [resturantASP] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [resturantASP] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [resturantASP] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [resturantASP] SET  DISABLE_BROKER 
GO
ALTER DATABASE [resturantASP] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [resturantASP] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [resturantASP] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [resturantASP] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [resturantASP] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [resturantASP] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [resturantASP] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [resturantASP] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [resturantASP] SET  MULTI_USER 
GO
ALTER DATABASE [resturantASP] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [resturantASP] SET DB_CHAINING OFF 
GO
ALTER DATABASE [resturantASP] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [resturantASP] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [resturantASP] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [resturantASP] SET QUERY_STORE = OFF
GO
USE [resturantASP]
GO
/****** Object:  Table [dbo].[__EFMigrationsHistory]    Script Date: 10/14/2022 1:47:53 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[__EFMigrationsHistory](
	[MigrationId] [nvarchar](150) NOT NULL,
	[ProductVersion] [nvarchar](32) NOT NULL,
 CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY CLUSTERED 
(
	[MigrationId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Categories]    Script Date: 10/14/2022 1:47:53 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Categories](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[CreatedAt] [datetime2](7) NOT NULL,
	[IsActive] [bit] NOT NULL,
	[DeletedAt] [datetime2](7) NULL,
	[DeletedBy] [nvarchar](max) NULL,
	[UpdatedAt] [datetime2](7) NULL,
	[UpdatedBy] [nvarchar](max) NULL,
 CONSTRAINT [PK_Categories] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Ingredients]    Script Date: 10/14/2022 1:47:53 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Ingredients](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[CreatedAt] [datetime2](7) NOT NULL,
	[IsActive] [bit] NOT NULL,
	[DeletedAt] [datetime2](7) NULL,
	[DeletedBy] [nvarchar](max) NULL,
	[UpdatedAt] [datetime2](7) NULL,
	[UpdatedBy] [nvarchar](max) NULL,
 CONSTRAINT [PK_Ingredients] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[OrderItems]    Script Date: 10/14/2022 1:47:53 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[OrderItems](
	[PricelistId] [int] NOT NULL,
	[OrderId] [int] NOT NULL,
	[Quantity] [int] NOT NULL,
	[Id] [int] NOT NULL,
	[CreatedAt] [datetime2](7) NOT NULL,
	[IsActive] [bit] NOT NULL,
	[DeletedAt] [datetime2](7) NULL,
	[DeletedBy] [nvarchar](max) NULL,
	[UpdatedAt] [datetime2](7) NULL,
	[UpdatedBy] [nvarchar](max) NULL,
 CONSTRAINT [PK_OrderItems] PRIMARY KEY CLUSTERED 
(
	[PricelistId] ASC,
	[OrderId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Orders]    Script Date: 10/14/2022 1:47:53 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Orders](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[UserId] [int] NOT NULL,
	[CreatedAt] [datetime2](7) NOT NULL,
	[IsActive] [bit] NOT NULL,
	[DeletedAt] [datetime2](7) NULL,
	[DeletedBy] [nvarchar](max) NULL,
	[UpdatedAt] [datetime2](7) NULL,
	[UpdatedBy] [nvarchar](max) NULL,
 CONSTRAINT [PK_Orders] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Pricelists]    Script Date: 10/14/2022 1:47:53 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Pricelists](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Price] [decimal](18, 2) NOT NULL,
	[Date] [datetime2](7) NOT NULL,
	[SpecialtyId] [int] NOT NULL,
	[CreatedAt] [datetime2](7) NOT NULL,
	[IsActive] [bit] NOT NULL,
	[DeletedAt] [datetime2](7) NULL,
	[DeletedBy] [nvarchar](max) NULL,
	[UpdatedAt] [datetime2](7) NULL,
	[UpdatedBy] [nvarchar](max) NULL,
 CONSTRAINT [PK_Pricelists] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Specialities]    Script Date: 10/14/2022 1:47:53 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Specialities](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[Image] [nvarchar](50) NOT NULL,
	[Weight] [nvarchar](50) NOT NULL,
	[CategoryId] [int] NOT NULL,
	[CreatedAt] [datetime2](7) NOT NULL,
	[IsActive] [bit] NOT NULL,
	[DeletedAt] [datetime2](7) NULL,
	[DeletedBy] [nvarchar](max) NULL,
	[UpdatedAt] [datetime2](7) NULL,
	[UpdatedBy] [nvarchar](max) NULL,
 CONSTRAINT [PK_Specialities] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[SpecialtyIngredients]    Script Date: 10/14/2022 1:47:53 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SpecialtyIngredients](
	[SpecialtyId] [int] NOT NULL,
	[IngredientId] [int] NOT NULL,
 CONSTRAINT [PK_SpecialtyIngredients] PRIMARY KEY CLUSTERED 
(
	[SpecialtyId] ASC,
	[IngredientId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Users]    Script Date: 10/14/2022 1:47:53 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Users](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[FirstName] [nvarchar](40) NOT NULL,
	[LastName] [nvarchar](40) NOT NULL,
	[Email] [nvarchar](40) NOT NULL,
	[Password] [nvarchar](100) NOT NULL,
	[PhoneNumber] [nvarchar](20) NOT NULL,
	[Address] [nvarchar](50) NOT NULL,
	[CreatedAt] [datetime2](7) NOT NULL,
	[IsActive] [bit] NOT NULL,
	[DeletedAt] [datetime2](7) NULL,
	[DeletedBy] [nvarchar](max) NULL,
	[UpdatedAt] [datetime2](7) NULL,
	[UpdatedBy] [nvarchar](max) NULL,
 CONSTRAINT [PK_Users] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[UserUseCases]    Script Date: 10/14/2022 1:47:53 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UserUseCases](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[UserId] [int] NOT NULL,
	[UseCaseId] [int] NOT NULL,
	[CreatedAt] [datetime2](7) NOT NULL,
	[IsActive] [bit] NOT NULL,
	[DeletedAt] [datetime2](7) NULL,
	[DeletedBy] [nvarchar](max) NULL,
	[UpdatedAt] [datetime2](7) NULL,
	[UpdatedBy] [nvarchar](max) NULL,
 CONSTRAINT [PK_UserUseCases] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20220829211133_InitialData', N'5.0.17')
GO
SET IDENTITY_INSERT [dbo].[Categories] ON 

INSERT [dbo].[Categories] ([Id], [Name], [CreatedAt], [IsActive], [DeletedAt], [DeletedBy], [UpdatedAt], [UpdatedBy]) VALUES (1, N'Breakfast', CAST(N'2022-08-29T21:14:50.8205250' AS DateTime2), 1, NULL, NULL, NULL, NULL)
INSERT [dbo].[Categories] ([Id], [Name], [CreatedAt], [IsActive], [DeletedAt], [DeletedBy], [UpdatedAt], [UpdatedBy]) VALUES (2, N'Pasta', CAST(N'2022-08-29T21:14:50.8205686' AS DateTime2), 1, NULL, NULL, NULL, NULL)
INSERT [dbo].[Categories] ([Id], [Name], [CreatedAt], [IsActive], [DeletedAt], [DeletedBy], [UpdatedAt], [UpdatedBy]) VALUES (3, N'Fish', CAST(N'2022-08-29T21:14:50.8205690' AS DateTime2), 1, NULL, NULL, NULL, NULL)
INSERT [dbo].[Categories] ([Id], [Name], [CreatedAt], [IsActive], [DeletedAt], [DeletedBy], [UpdatedAt], [UpdatedBy]) VALUES (4, N'Steak', CAST(N'2022-08-29T21:14:50.8205692' AS DateTime2), 1, NULL, NULL, NULL, NULL)
SET IDENTITY_INSERT [dbo].[Categories] OFF
GO
SET IDENTITY_INSERT [dbo].[Ingredients] ON 

INSERT [dbo].[Ingredients] ([Id], [Name], [CreatedAt], [IsActive], [DeletedAt], [DeletedBy], [UpdatedAt], [UpdatedBy]) VALUES (1, N'iceberg', CAST(N'2022-08-29T21:14:50.8205695' AS DateTime2), 1, NULL, NULL, NULL, NULL)
INSERT [dbo].[Ingredients] ([Id], [Name], [CreatedAt], [IsActive], [DeletedAt], [DeletedBy], [UpdatedAt], [UpdatedBy]) VALUES (2, N'Caesar dressing', CAST(N'2022-08-29T21:14:50.8205697' AS DateTime2), 1, NULL, NULL, NULL, NULL)
INSERT [dbo].[Ingredients] ([Id], [Name], [CreatedAt], [IsActive], [DeletedAt], [DeletedBy], [UpdatedAt], [UpdatedBy]) VALUES (3, N'cheese', CAST(N'2022-08-29T21:14:50.8205699' AS DateTime2), 1, NULL, NULL, NULL, NULL)
INSERT [dbo].[Ingredients] ([Id], [Name], [CreatedAt], [IsActive], [DeletedAt], [DeletedBy], [UpdatedAt], [UpdatedBy]) VALUES (4, N'ham', CAST(N'2022-08-29T21:14:50.8205702' AS DateTime2), 1, NULL, NULL, NULL, NULL)
INSERT [dbo].[Ingredients] ([Id], [Name], [CreatedAt], [IsActive], [DeletedAt], [DeletedBy], [UpdatedAt], [UpdatedBy]) VALUES (5, N'tortilla', CAST(N'2022-08-29T21:14:50.8205703' AS DateTime2), 1, NULL, NULL, NULL, NULL)
INSERT [dbo].[Ingredients] ([Id], [Name], [CreatedAt], [IsActive], [DeletedAt], [DeletedBy], [UpdatedAt], [UpdatedBy]) VALUES (6, N'4 toasts', CAST(N'2022-08-29T21:14:50.8205706' AS DateTime2), 1, NULL, NULL, NULL, NULL)
INSERT [dbo].[Ingredients] ([Id], [Name], [CreatedAt], [IsActive], [DeletedAt], [DeletedBy], [UpdatedAt], [UpdatedBy]) VALUES (7, N'ketchup', CAST(N'2022-08-29T21:14:50.8205708' AS DateTime2), 1, NULL, NULL, NULL, NULL)
INSERT [dbo].[Ingredients] ([Id], [Name], [CreatedAt], [IsActive], [DeletedAt], [DeletedBy], [UpdatedAt], [UpdatedBy]) VALUES (8, N'French fries', CAST(N'2022-08-29T21:14:50.8205709' AS DateTime2), 1, NULL, NULL, NULL, NULL)
INSERT [dbo].[Ingredients] ([Id], [Name], [CreatedAt], [IsActive], [DeletedAt], [DeletedBy], [UpdatedAt], [UpdatedBy]) VALUES (9, N'steak', CAST(N'2022-08-29T21:14:50.8205711' AS DateTime2), 1, NULL, NULL, NULL, NULL)
INSERT [dbo].[Ingredients] ([Id], [Name], [CreatedAt], [IsActive], [DeletedAt], [DeletedBy], [UpdatedAt], [UpdatedBy]) VALUES (10, N'baked potato', CAST(N'2022-08-29T21:14:50.8205713' AS DateTime2), 1, NULL, NULL, NULL, NULL)
SET IDENTITY_INSERT [dbo].[Ingredients] OFF
GO
INSERT [dbo].[OrderItems] ([PricelistId], [OrderId], [Quantity], [Id], [CreatedAt], [IsActive], [DeletedAt], [DeletedBy], [UpdatedAt], [UpdatedBy]) VALUES (3, 1, 2, 0, CAST(N'2022-08-29T21:14:50.8205752' AS DateTime2), 1, NULL, NULL, NULL, NULL)
INSERT [dbo].[OrderItems] ([PricelistId], [OrderId], [Quantity], [Id], [CreatedAt], [IsActive], [DeletedAt], [DeletedBy], [UpdatedAt], [UpdatedBy]) VALUES (3, 2, 10, 0, CAST(N'2022-09-01T10:28:47.0224822' AS DateTime2), 1, NULL, NULL, NULL, NULL)
GO
SET IDENTITY_INSERT [dbo].[Orders] ON 

INSERT [dbo].[Orders] ([Id], [UserId], [CreatedAt], [IsActive], [DeletedAt], [DeletedBy], [UpdatedAt], [UpdatedBy]) VALUES (1, 1, CAST(N'2022-08-29T21:14:50.8205751' AS DateTime2), 1, NULL, NULL, NULL, NULL)
INSERT [dbo].[Orders] ([Id], [UserId], [CreatedAt], [IsActive], [DeletedAt], [DeletedBy], [UpdatedAt], [UpdatedBy]) VALUES (2, 1, CAST(N'2022-09-01T10:28:47.0224021' AS DateTime2), 1, NULL, NULL, NULL, NULL)
SET IDENTITY_INSERT [dbo].[Orders] OFF
GO
SET IDENTITY_INSERT [dbo].[Pricelists] ON 

INSERT [dbo].[Pricelists] ([Id], [Price], [Date], [SpecialtyId], [CreatedAt], [IsActive], [DeletedAt], [DeletedBy], [UpdatedAt], [UpdatedBy]) VALUES (1, CAST(380.00 AS Decimal(18, 2)), CAST(N'2022-06-01T00:00:00.0000000' AS DateTime2), 1, CAST(N'2022-08-29T21:14:50.8205724' AS DateTime2), 1, NULL, NULL, NULL, NULL)
INSERT [dbo].[Pricelists] ([Id], [Price], [Date], [SpecialtyId], [CreatedAt], [IsActive], [DeletedAt], [DeletedBy], [UpdatedAt], [UpdatedBy]) VALUES (2, CAST(320.00 AS Decimal(18, 2)), CAST(N'2022-06-01T00:00:00.0000000' AS DateTime2), 2, CAST(N'2022-08-29T21:14:50.8205727' AS DateTime2), 1, NULL, NULL, NULL, NULL)
INSERT [dbo].[Pricelists] ([Id], [Price], [Date], [SpecialtyId], [CreatedAt], [IsActive], [DeletedAt], [DeletedBy], [UpdatedAt], [UpdatedBy]) VALUES (3, CAST(2250.00 AS Decimal(18, 2)), CAST(N'2022-06-01T00:00:00.0000000' AS DateTime2), 3, CAST(N'2022-08-29T21:14:50.8205734' AS DateTime2), 1, NULL, NULL, NULL, NULL)
SET IDENTITY_INSERT [dbo].[Pricelists] OFF
GO
SET IDENTITY_INSERT [dbo].[Specialities] ON 

INSERT [dbo].[Specialities] ([Id], [Name], [Image], [Weight], [CategoryId], [CreatedAt], [IsActive], [DeletedAt], [DeletedBy], [UpdatedAt], [UpdatedBy]) VALUES (1, N'Tortilla with ham', N'image1.jpg', N'300gr', 1, CAST(N'2022-08-29T21:14:50.8205716' AS DateTime2), 1, NULL, NULL, NULL, NULL)
INSERT [dbo].[Specialities] ([Id], [Name], [Image], [Weight], [CategoryId], [CreatedAt], [IsActive], [DeletedAt], [DeletedBy], [UpdatedAt], [UpdatedBy]) VALUES (2, N'Tost sandwich', N'image2.jpg', N'350gr', 1, CAST(N'2022-08-29T21:14:50.8205719' AS DateTime2), 1, NULL, NULL, NULL, NULL)
INSERT [dbo].[Specialities] ([Id], [Name], [Image], [Weight], [CategoryId], [CreatedAt], [IsActive], [DeletedAt], [DeletedBy], [UpdatedAt], [UpdatedBy]) VALUES (3, N'Grilled beefsteak', N'image3.jpg', N'300gr', 4, CAST(N'2022-08-29T21:14:50.8205722' AS DateTime2), 1, NULL, NULL, NULL, NULL)
SET IDENTITY_INSERT [dbo].[Specialities] OFF
GO
INSERT [dbo].[SpecialtyIngredients] ([SpecialtyId], [IngredientId]) VALUES (1, 1)
INSERT [dbo].[SpecialtyIngredients] ([SpecialtyId], [IngredientId]) VALUES (1, 2)
INSERT [dbo].[SpecialtyIngredients] ([SpecialtyId], [IngredientId]) VALUES (1, 3)
INSERT [dbo].[SpecialtyIngredients] ([SpecialtyId], [IngredientId]) VALUES (2, 3)
INSERT [dbo].[SpecialtyIngredients] ([SpecialtyId], [IngredientId]) VALUES (1, 4)
INSERT [dbo].[SpecialtyIngredients] ([SpecialtyId], [IngredientId]) VALUES (2, 4)
INSERT [dbo].[SpecialtyIngredients] ([SpecialtyId], [IngredientId]) VALUES (1, 5)
INSERT [dbo].[SpecialtyIngredients] ([SpecialtyId], [IngredientId]) VALUES (2, 6)
INSERT [dbo].[SpecialtyIngredients] ([SpecialtyId], [IngredientId]) VALUES (2, 7)
INSERT [dbo].[SpecialtyIngredients] ([SpecialtyId], [IngredientId]) VALUES (2, 8)
INSERT [dbo].[SpecialtyIngredients] ([SpecialtyId], [IngredientId]) VALUES (3, 9)
INSERT [dbo].[SpecialtyIngredients] ([SpecialtyId], [IngredientId]) VALUES (3, 10)
GO
SET IDENTITY_INSERT [dbo].[Users] ON 

INSERT [dbo].[Users] ([Id], [FirstName], [LastName], [Email], [Password], [PhoneNumber], [Address], [CreatedAt], [IsActive], [DeletedAt], [DeletedBy], [UpdatedAt], [UpdatedBy]) VALUES (1, N'Jovana', N'Bosnic', N'jovana.bosnic.90.18@ict.edu.rs', N'$2a$11$iU6zkdd6E/8WyDLkLi2Si.eV6JqJFVoJJKYcGJxJD.MdYpcwf2kPC', N'063 444 4444', N'Njegoseva 33', CAST(N'2022-08-29T21:14:50.8205749' AS DateTime2), 1, NULL, NULL, NULL, NULL)
SET IDENTITY_INSERT [dbo].[Users] OFF
GO
SET IDENTITY_INSERT [dbo].[UserUseCases] ON 

INSERT [dbo].[UserUseCases] ([Id], [UserId], [UseCaseId], [CreatedAt], [IsActive], [DeletedAt], [DeletedBy], [UpdatedAt], [UpdatedBy]) VALUES (1, 1, 14, CAST(N'2022-08-29T21:14:50.8206050' AS DateTime2), 1, NULL, NULL, NULL, NULL)
INSERT [dbo].[UserUseCases] ([Id], [UserId], [UseCaseId], [CreatedAt], [IsActive], [DeletedAt], [DeletedBy], [UpdatedAt], [UpdatedBy]) VALUES (2, 1, 13, CAST(N'2022-08-29T21:14:50.8206048' AS DateTime2), 1, NULL, NULL, NULL, NULL)
INSERT [dbo].[UserUseCases] ([Id], [UserId], [UseCaseId], [CreatedAt], [IsActive], [DeletedAt], [DeletedBy], [UpdatedAt], [UpdatedBy]) VALUES (3, 1, 12, CAST(N'2022-08-29T21:14:50.8206045' AS DateTime2), 1, NULL, NULL, NULL, NULL)
INSERT [dbo].[UserUseCases] ([Id], [UserId], [UseCaseId], [CreatedAt], [IsActive], [DeletedAt], [DeletedBy], [UpdatedAt], [UpdatedBy]) VALUES (4, 1, 11, CAST(N'2022-08-29T21:14:50.8206043' AS DateTime2), 1, NULL, NULL, NULL, NULL)
INSERT [dbo].[UserUseCases] ([Id], [UserId], [UseCaseId], [CreatedAt], [IsActive], [DeletedAt], [DeletedBy], [UpdatedAt], [UpdatedBy]) VALUES (5, 1, 10, CAST(N'2022-08-29T21:14:50.8206041' AS DateTime2), 1, NULL, NULL, NULL, NULL)
INSERT [dbo].[UserUseCases] ([Id], [UserId], [UseCaseId], [CreatedAt], [IsActive], [DeletedAt], [DeletedBy], [UpdatedAt], [UpdatedBy]) VALUES (6, 1, 9, CAST(N'2022-08-29T21:14:50.8206038' AS DateTime2), 1, NULL, NULL, NULL, NULL)
INSERT [dbo].[UserUseCases] ([Id], [UserId], [UseCaseId], [CreatedAt], [IsActive], [DeletedAt], [DeletedBy], [UpdatedAt], [UpdatedBy]) VALUES (7, 1, 7, CAST(N'2022-08-29T21:14:50.8206034' AS DateTime2), 1, NULL, NULL, NULL, NULL)
INSERT [dbo].[UserUseCases] ([Id], [UserId], [UseCaseId], [CreatedAt], [IsActive], [DeletedAt], [DeletedBy], [UpdatedAt], [UpdatedBy]) VALUES (8, 1, 15, CAST(N'2022-08-29T21:14:50.8206052' AS DateTime2), 1, NULL, NULL, NULL, NULL)
INSERT [dbo].[UserUseCases] ([Id], [UserId], [UseCaseId], [CreatedAt], [IsActive], [DeletedAt], [DeletedBy], [UpdatedAt], [UpdatedBy]) VALUES (9, 1, 6, CAST(N'2022-08-29T21:14:50.8206031' AS DateTime2), 1, NULL, NULL, NULL, NULL)
INSERT [dbo].[UserUseCases] ([Id], [UserId], [UseCaseId], [CreatedAt], [IsActive], [DeletedAt], [DeletedBy], [UpdatedAt], [UpdatedBy]) VALUES (10, 1, 4, CAST(N'2022-08-29T21:14:50.8206029' AS DateTime2), 1, NULL, NULL, NULL, NULL)
INSERT [dbo].[UserUseCases] ([Id], [UserId], [UseCaseId], [CreatedAt], [IsActive], [DeletedAt], [DeletedBy], [UpdatedAt], [UpdatedBy]) VALUES (11, 1, 3, CAST(N'2022-08-29T21:14:50.8205757' AS DateTime2), 1, NULL, NULL, NULL, NULL)
INSERT [dbo].[UserUseCases] ([Id], [UserId], [UseCaseId], [CreatedAt], [IsActive], [DeletedAt], [DeletedBy], [UpdatedAt], [UpdatedBy]) VALUES (12, 1, 2, CAST(N'2022-08-29T21:14:50.8205756' AS DateTime2), 1, NULL, NULL, NULL, NULL)
INSERT [dbo].[UserUseCases] ([Id], [UserId], [UseCaseId], [CreatedAt], [IsActive], [DeletedAt], [DeletedBy], [UpdatedAt], [UpdatedBy]) VALUES (13, 1, 1, CAST(N'2022-08-29T21:14:50.8205754' AS DateTime2), 1, NULL, NULL, NULL, NULL)
INSERT [dbo].[UserUseCases] ([Id], [UserId], [UseCaseId], [CreatedAt], [IsActive], [DeletedAt], [DeletedBy], [UpdatedAt], [UpdatedBy]) VALUES (14, 1, 8, CAST(N'2022-08-29T21:14:50.8206036' AS DateTime2), 1, NULL, NULL, NULL, NULL)
INSERT [dbo].[UserUseCases] ([Id], [UserId], [UseCaseId], [CreatedAt], [IsActive], [DeletedAt], [DeletedBy], [UpdatedAt], [UpdatedBy]) VALUES (15, 1, 16, CAST(N'2022-08-29T21:14:50.8206055' AS DateTime2), 1, NULL, NULL, NULL, NULL)
SET IDENTITY_INSERT [dbo].[UserUseCases] OFF
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_Categories_Name]    Script Date: 10/14/2022 1:47:53 AM ******/
CREATE UNIQUE NONCLUSTERED INDEX [IX_Categories_Name] ON [dbo].[Categories]
(
	[Name] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_Ingredients_Name]    Script Date: 10/14/2022 1:47:53 AM ******/
CREATE UNIQUE NONCLUSTERED INDEX [IX_Ingredients_Name] ON [dbo].[Ingredients]
(
	[Name] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_OrderItems_OrderId]    Script Date: 10/14/2022 1:47:53 AM ******/
CREATE NONCLUSTERED INDEX [IX_OrderItems_OrderId] ON [dbo].[OrderItems]
(
	[OrderId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_Orders_UserId]    Script Date: 10/14/2022 1:47:53 AM ******/
CREATE NONCLUSTERED INDEX [IX_Orders_UserId] ON [dbo].[Orders]
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_Pricelists_SpecialtyId]    Script Date: 10/14/2022 1:47:53 AM ******/
CREATE NONCLUSTERED INDEX [IX_Pricelists_SpecialtyId] ON [dbo].[Pricelists]
(
	[SpecialtyId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_Specialities_CategoryId]    Script Date: 10/14/2022 1:47:53 AM ******/
CREATE NONCLUSTERED INDEX [IX_Specialities_CategoryId] ON [dbo].[Specialities]
(
	[CategoryId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_Specialities_Name]    Script Date: 10/14/2022 1:47:53 AM ******/
CREATE UNIQUE NONCLUSTERED INDEX [IX_Specialities_Name] ON [dbo].[Specialities]
(
	[Name] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_SpecialtyIngredients_IngredientId]    Script Date: 10/14/2022 1:47:53 AM ******/
CREATE NONCLUSTERED INDEX [IX_SpecialtyIngredients_IngredientId] ON [dbo].[SpecialtyIngredients]
(
	[IngredientId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_Users_Email]    Script Date: 10/14/2022 1:47:53 AM ******/
CREATE UNIQUE NONCLUSTERED INDEX [IX_Users_Email] ON [dbo].[Users]
(
	[Email] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_UserUseCases_UserId]    Script Date: 10/14/2022 1:47:53 AM ******/
CREATE NONCLUSTERED INDEX [IX_UserUseCases_UserId] ON [dbo].[UserUseCases]
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Categories] ADD  DEFAULT (CONVERT([bit],(1))) FOR [IsActive]
GO
ALTER TABLE [dbo].[Ingredients] ADD  DEFAULT (CONVERT([bit],(1))) FOR [IsActive]
GO
ALTER TABLE [dbo].[OrderItems] ADD  DEFAULT (CONVERT([bit],(1))) FOR [IsActive]
GO
ALTER TABLE [dbo].[Orders] ADD  DEFAULT (CONVERT([bit],(1))) FOR [IsActive]
GO
ALTER TABLE [dbo].[Pricelists] ADD  DEFAULT (CONVERT([bit],(1))) FOR [IsActive]
GO
ALTER TABLE [dbo].[Specialities] ADD  DEFAULT (CONVERT([bit],(1))) FOR [IsActive]
GO
ALTER TABLE [dbo].[Users] ADD  DEFAULT (CONVERT([bit],(1))) FOR [IsActive]
GO
ALTER TABLE [dbo].[OrderItems]  WITH CHECK ADD  CONSTRAINT [FK_OrderItems_Orders_OrderId] FOREIGN KEY([OrderId])
REFERENCES [dbo].[Orders] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[OrderItems] CHECK CONSTRAINT [FK_OrderItems_Orders_OrderId]
GO
ALTER TABLE [dbo].[OrderItems]  WITH CHECK ADD  CONSTRAINT [FK_OrderItems_Pricelists_PricelistId] FOREIGN KEY([PricelistId])
REFERENCES [dbo].[Pricelists] ([Id])
GO
ALTER TABLE [dbo].[OrderItems] CHECK CONSTRAINT [FK_OrderItems_Pricelists_PricelistId]
GO
ALTER TABLE [dbo].[Orders]  WITH CHECK ADD  CONSTRAINT [FK_Orders_Users_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[Users] ([Id])
GO
ALTER TABLE [dbo].[Orders] CHECK CONSTRAINT [FK_Orders_Users_UserId]
GO
ALTER TABLE [dbo].[Pricelists]  WITH CHECK ADD  CONSTRAINT [FK_Pricelists_Specialities_SpecialtyId] FOREIGN KEY([SpecialtyId])
REFERENCES [dbo].[Specialities] ([Id])
GO
ALTER TABLE [dbo].[Pricelists] CHECK CONSTRAINT [FK_Pricelists_Specialities_SpecialtyId]
GO
ALTER TABLE [dbo].[Specialities]  WITH CHECK ADD  CONSTRAINT [FK_Specialities_Categories_CategoryId] FOREIGN KEY([CategoryId])
REFERENCES [dbo].[Categories] ([Id])
GO
ALTER TABLE [dbo].[Specialities] CHECK CONSTRAINT [FK_Specialities_Categories_CategoryId]
GO
ALTER TABLE [dbo].[SpecialtyIngredients]  WITH CHECK ADD  CONSTRAINT [FK_SpecialtyIngredients_Ingredients_IngredientId] FOREIGN KEY([IngredientId])
REFERENCES [dbo].[Ingredients] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[SpecialtyIngredients] CHECK CONSTRAINT [FK_SpecialtyIngredients_Ingredients_IngredientId]
GO
ALTER TABLE [dbo].[SpecialtyIngredients]  WITH CHECK ADD  CONSTRAINT [FK_SpecialtyIngredients_Specialities_SpecialtyId] FOREIGN KEY([SpecialtyId])
REFERENCES [dbo].[Specialities] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[SpecialtyIngredients] CHECK CONSTRAINT [FK_SpecialtyIngredients_Specialities_SpecialtyId]
GO
ALTER TABLE [dbo].[UserUseCases]  WITH CHECK ADD  CONSTRAINT [FK_UserUseCases_Users_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[Users] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[UserUseCases] CHECK CONSTRAINT [FK_UserUseCases_Users_UserId]
GO
USE [master]
GO
ALTER DATABASE [resturantASP] SET  READ_WRITE 
GO
