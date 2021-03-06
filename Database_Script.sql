USE [master]
GO
-- sql 2019
/****** Object:  Database [MyEShop]    Script Date: 7/15/2022 10:59:14 PM ******/
CREATE DATABASE [MyEShop]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'MyEShop', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\MyEShop.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'MyEShop_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\MyEShop_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [MyEShop] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [MyEShop].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [MyEShop] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [MyEShop] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [MyEShop] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [MyEShop] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [MyEShop] SET ARITHABORT OFF 
GO
ALTER DATABASE [MyEShop] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [MyEShop] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [MyEShop] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [MyEShop] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [MyEShop] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [MyEShop] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [MyEShop] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [MyEShop] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [MyEShop] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [MyEShop] SET  ENABLE_BROKER 
GO
ALTER DATABASE [MyEShop] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [MyEShop] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [MyEShop] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [MyEShop] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [MyEShop] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [MyEShop] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [MyEShop] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [MyEShop] SET RECOVERY FULL 
GO
ALTER DATABASE [MyEShop] SET  MULTI_USER 
GO
ALTER DATABASE [MyEShop] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [MyEShop] SET DB_CHAINING OFF 
GO
ALTER DATABASE [MyEShop] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [MyEShop] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [MyEShop] SET DELAYED_DURABILITY = DISABLED 
GO
EXEC sys.sp_db_vardecimal_storage_format N'MyEShop', N'ON'
GO
ALTER DATABASE [MyEShop] SET QUERY_STORE = OFF
GO
USE [MyEShop]
GO
/****** Object:  Table [dbo].[Features]    Script Date: 7/15/2022 10:59:15 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Features](
	[FeatureID] [int] IDENTITY(1,1) NOT NULL,
	[FeatureTitle] [nvarchar](150) NOT NULL,
 CONSTRAINT [PK_Features] PRIMARY KEY CLUSTERED 
(
	[FeatureID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Product_Features]    Script Date: 7/15/2022 10:59:15 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Product_Features](
	[PF_ID] [int] IDENTITY(1,1) NOT NULL,
	[ProductID] [int] NOT NULL,
	[FeatureID] [int] NOT NULL,
	[Value] [nvarchar](20) NULL,
 CONSTRAINT [PK_ProductFeatures] PRIMARY KEY CLUSTERED 
(
	[PF_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Product_Galleries]    Script Date: 7/15/2022 10:59:15 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Product_Galleries](
	[GalleryID] [int] IDENTITY(1,1) NOT NULL,
	[ProductID] [int] NOT NULL,
	[ImageName] [varchar](50) NOT NULL,
	[Title] [nvarchar](150) NULL,
 CONSTRAINT [PK_GalleryID] PRIMARY KEY CLUSTERED 
(
	[GalleryID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Product_Selected_Groups]    Script Date: 7/15/2022 10:59:15 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Product_Selected_Groups](
	[PG_ID] [int] IDENTITY(1,1) NOT NULL,
	[ProductID] [int] NOT NULL,
	[GroupID] [int] NOT NULL,
 CONSTRAINT [PK_PG_ID] PRIMARY KEY CLUSTERED 
(
	[PG_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Product_Tags]    Script Date: 7/15/2022 10:59:15 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Product_Tags](
	[TagID] [int] IDENTITY(1,1) NOT NULL,
	[ProductID] [int] NOT NULL,
	[Tag] [nvarchar](250) NOT NULL,
 CONSTRAINT [PK_TagID] PRIMARY KEY CLUSTERED 
(
	[TagID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ProductGroups]    Script Date: 7/15/2022 10:59:15 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ProductGroups](
	[GroupID] [int] IDENTITY(1,1) NOT NULL,
	[GroupTitle] [nvarchar](400) NOT NULL,
	[ParentID] [int] NULL,
 CONSTRAINT [PK_ProductGroups] PRIMARY KEY CLUSTERED 
(
	[GroupID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Products]    Script Date: 7/15/2022 10:59:15 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Products](
	[ProductID] [int] IDENTITY(1,1) NOT NULL,
	[Title] [nvarchar](350) NOT NULL,
	[ShortDescription] [nvarchar](500) NOT NULL,
	[Text] [nvarchar](max) NOT NULL,
	[Price] [int] NOT NULL,
	[ImageName] [varchar](50) NOT NULL,
	[CreateDate] [datetime] NOT NULL,
 CONSTRAINT [PK_Products] PRIMARY KEY CLUSTERED 
(
	[ProductID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Roles]    Script Date: 7/15/2022 10:59:15 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Roles](
	[RoleID] [int] NOT NULL,
	[RoleTitle] [nvarchar](250) NOT NULL,
	[RoleName] [varchar](150) NOT NULL,
 CONSTRAINT [PK_Roles] PRIMARY KEY CLUSTERED 
(
	[RoleID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Users]    Script Date: 7/15/2022 10:59:15 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Users](
	[UserID] [int] IDENTITY(1,1) NOT NULL,
	[RoleID] [int] NOT NULL,
	[UserName] [nvarchar](250) NOT NULL,
	[Email] [nvarchar](250) NOT NULL,
	[Password] [varchar](200) NOT NULL,
	[ActiveCode] [varchar](50) NOT NULL,
	[IsActive] [bit] NOT NULL,
	[RegisterDate] [datetime] NOT NULL,
 CONSTRAINT [PK_Users] PRIMARY KEY CLUSTERED 
(
	[UserID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Features] ON 

INSERT [dbo].[Features] ([FeatureID], [FeatureTitle]) VALUES (2, N'ابعاد')
INSERT [dbo].[Features] ([FeatureID], [FeatureTitle]) VALUES (4, N'بلوتوث')
INSERT [dbo].[Features] ([FeatureID], [FeatureTitle]) VALUES (3, N'رنگ')
INSERT [dbo].[Features] ([FeatureID], [FeatureTitle]) VALUES (1, N'وزن')
SET IDENTITY_INSERT [dbo].[Features] OFF
SET IDENTITY_INSERT [dbo].[Product_Features] ON 

INSERT [dbo].[Product_Features] ([PF_ID], [ProductID], [FeatureID], [Value]) VALUES (3, 1, 4, N'بله')
INSERT [dbo].[Product_Features] ([PF_ID], [ProductID], [FeatureID], [Value]) VALUES (5, 2, 2, N'hjmhjm')
SET IDENTITY_INSERT [dbo].[Product_Features] OFF
SET IDENTITY_INSERT [dbo].[Product_Galleries] ON 

INSERT [dbo].[Product_Galleries] ([GalleryID], [ProductID], [ImageName], [Title]) VALUES (3, 2, N'901a01b9-7c9d-468d-89ea-feb2677a25e0.jpg', N'sdfsdf')
SET IDENTITY_INSERT [dbo].[Product_Galleries] OFF
SET IDENTITY_INSERT [dbo].[Product_Selected_Groups] ON 

INSERT [dbo].[Product_Selected_Groups] ([PG_ID], [ProductID], [GroupID]) VALUES (1, 1, 6)
INSERT [dbo].[Product_Selected_Groups] ([PG_ID], [ProductID], [GroupID]) VALUES (2, 1, 7)
INSERT [dbo].[Product_Selected_Groups] ([PG_ID], [ProductID], [GroupID]) VALUES (7, 2, 6)
INSERT [dbo].[Product_Selected_Groups] ([PG_ID], [ProductID], [GroupID]) VALUES (8, 2, 7)
SET IDENTITY_INSERT [dbo].[Product_Selected_Groups] OFF
SET IDENTITY_INSERT [dbo].[Product_Tags] ON 

INSERT [dbo].[Product_Tags] ([TagID], [ProductID], [Tag]) VALUES (1, 1, N'ماگ')
INSERT [dbo].[Product_Tags] ([TagID], [ProductID], [Tag]) VALUES (9, 2, N'ehsan')
INSERT [dbo].[Product_Tags] ([TagID], [ProductID], [Tag]) VALUES (10, 2, N'amir')
SET IDENTITY_INSERT [dbo].[Product_Tags] OFF
SET IDENTITY_INSERT [dbo].[ProductGroups] ON 

INSERT [dbo].[ProductGroups] ([GroupID], [GroupTitle], [ParentID]) VALUES (1, N'الکترونیک', NULL)
INSERT [dbo].[ProductGroups] ([GroupID], [GroupTitle], [ParentID]) VALUES (2, N'صوتی و تصویری', 1)
INSERT [dbo].[ProductGroups] ([GroupID], [GroupTitle], [ParentID]) VALUES (3, N'تلویزیون', 1)
INSERT [dbo].[ProductGroups] ([GroupID], [GroupTitle], [ParentID]) VALUES (5, N'لوازم شخصی', NULL)
INSERT [dbo].[ProductGroups] ([GroupID], [GroupTitle], [ParentID]) VALUES (6, N'مسواک', 5)
INSERT [dbo].[ProductGroups] ([GroupID], [GroupTitle], [ParentID]) VALUES (7, N'حوله', 5)
INSERT [dbo].[ProductGroups] ([GroupID], [GroupTitle], [ParentID]) VALUES (12, N'لوازم ورزشی', NULL)
SET IDENTITY_INSERT [dbo].[ProductGroups] OFF
SET IDENTITY_INSERT [dbo].[Products] ON 

INSERT [dbo].[Products] ([ProductID], [Title], [ShortDescription], [Text], [Price], [ImageName], [CreateDate]) VALUES (1, N'لیوان', N'تست', N'<p>ماگ های دست ساز فقط یه نمونه در هر نوبت از ان ساخته میشود&nbsp;</p>
', 180000, N'images.jpg', CAST(N'2022-07-11T02:22:36.377' AS DateTime))
INSERT [dbo].[Products] ([ProductID], [Title], [ShortDescription], [Text], [Price], [ImageName], [CreateDate]) VALUES (2, N'test', N'test...', N'<p>test..............................horraaa</p>
', 200000, N'e14b1dfe-eaf8-471d-b1a9-8bdd7079b613.jpg', CAST(N'2022-07-11T15:57:51.000' AS DateTime))
SET IDENTITY_INSERT [dbo].[Products] OFF
INSERT [dbo].[Roles] ([RoleID], [RoleTitle], [RoleName]) VALUES (1, N'کاربران عادي', N'user')
INSERT [dbo].[Roles] ([RoleID], [RoleTitle], [RoleName]) VALUES (2, N'مدير کل سيستم', N'admin')
SET IDENTITY_INSERT [dbo].[Users] ON 

INSERT [dbo].[Users] ([UserID], [RoleID], [UserName], [Email], [Password], [ActiveCode], [IsActive], [RegisterDate]) VALUES (5, 2, N'Admin', N'ehsansz73@hotmail.com', N'202CB962AC59075B964B07152D234B70', N'470f69d7-a65b-4ba8-a04b-526456d75982', 1, CAST(N'2022-07-07T19:50:54.290' AS DateTime))
INSERT [dbo].[Users] ([UserID], [RoleID], [UserName], [Email], [Password], [ActiveCode], [IsActive], [RegisterDate]) VALUES (6, 1, N'Ehsan', N'e.seyedzadeh73@gmaile.com', N'202CB962AC59075B964B07152D234B70', N'eba4d097-8616-4400-952b-508fd5f9a391', 1, CAST(N'2022-07-07T21:16:04.840' AS DateTime))
SET IDENTITY_INSERT [dbo].[Users] OFF
SET ANSI_PADDING ON
GO
/****** Object:  Index [UK_Features]    Script Date: 7/15/2022 10:59:15 PM ******/
ALTER TABLE [dbo].[Features] ADD  CONSTRAINT [UK_Features] UNIQUE NONCLUSTERED 
(
	[FeatureTitle] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [UK_UserName]    Script Date: 7/15/2022 10:59:15 PM ******/
ALTER TABLE [dbo].[Users] ADD  CONSTRAINT [UK_UserName] UNIQUE NONCLUSTERED 
(
	[UserName] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Product_Features]  WITH CHECK ADD  CONSTRAINT [FK_ProductFeatures_Features] FOREIGN KEY([FeatureID])
REFERENCES [dbo].[Features] ([FeatureID])
GO
ALTER TABLE [dbo].[Product_Features] CHECK CONSTRAINT [FK_ProductFeatures_Features]
GO
ALTER TABLE [dbo].[Product_Features]  WITH CHECK ADD  CONSTRAINT [FK_ProductFeatures_Products] FOREIGN KEY([ProductID])
REFERENCES [dbo].[Products] ([ProductID])
GO
ALTER TABLE [dbo].[Product_Features] CHECK CONSTRAINT [FK_ProductFeatures_Products]
GO
ALTER TABLE [dbo].[Product_Galleries]  WITH CHECK ADD  CONSTRAINT [FK_Product_Galleries_Products] FOREIGN KEY([ProductID])
REFERENCES [dbo].[Products] ([ProductID])
GO
ALTER TABLE [dbo].[Product_Galleries] CHECK CONSTRAINT [FK_Product_Galleries_Products]
GO
ALTER TABLE [dbo].[Product_Selected_Groups]  WITH CHECK ADD  CONSTRAINT [FK_Prodct_Selected_Groups_Products] FOREIGN KEY([ProductID])
REFERENCES [dbo].[Products] ([ProductID])
GO
ALTER TABLE [dbo].[Product_Selected_Groups] CHECK CONSTRAINT [FK_Prodct_Selected_Groups_Products]
GO
ALTER TABLE [dbo].[Product_Selected_Groups]  WITH CHECK ADD  CONSTRAINT [FK_Product_Selected_Groups_ProductGroups] FOREIGN KEY([GroupID])
REFERENCES [dbo].[ProductGroups] ([GroupID])
GO
ALTER TABLE [dbo].[Product_Selected_Groups] CHECK CONSTRAINT [FK_Product_Selected_Groups_ProductGroups]
GO
ALTER TABLE [dbo].[Product_Tags]  WITH CHECK ADD  CONSTRAINT [FK_Product__Tags_Products] FOREIGN KEY([ProductID])
REFERENCES [dbo].[Products] ([ProductID])
GO
ALTER TABLE [dbo].[Product_Tags] CHECK CONSTRAINT [FK_Product__Tags_Products]
GO
ALTER TABLE [dbo].[ProductGroups]  WITH CHECK ADD  CONSTRAINT [FK_ProductGroups] FOREIGN KEY([ParentID])
REFERENCES [dbo].[ProductGroups] ([GroupID])
GO
ALTER TABLE [dbo].[ProductGroups] CHECK CONSTRAINT [FK_ProductGroups]
GO
ALTER TABLE [dbo].[Users]  WITH CHECK ADD  CONSTRAINT [FK_Users_Roles] FOREIGN KEY([RoleID])
REFERENCES [dbo].[Roles] ([RoleID])
GO
ALTER TABLE [dbo].[Users] CHECK CONSTRAINT [FK_Users_Roles]
GO
USE [master]
GO
ALTER DATABASE [MyEShop] SET  READ_WRITE 
GO
