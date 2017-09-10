USE [KhachSan]
GO
/****** Object:  Database [KhachSan]    Script Date: 9/7/2017 8:29:12 AM ******/
CREATE DATABASE [KhachSan]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'KhacSan', FILENAME = N'c:\Program Files\Microsoft SQL Server\MSSQL11.SQLEXPRESS\MSSQL\DATA\KhacSan.mdf' , SIZE = 3072KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'KhacSan_log', FILENAME = N'c:\Program Files\Microsoft SQL Server\MSSQL11.SQLEXPRESS\MSSQL\DATA\KhacSan_log.ldf' , SIZE = 1024KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [KhachSan] SET COMPATIBILITY_LEVEL = 110
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [KhachSan].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [KhachSan] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [KhachSan] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [KhachSan] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [KhachSan] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [KhachSan] SET ARITHABORT OFF 
GO
ALTER DATABASE [KhachSan] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [KhachSan] SET AUTO_CREATE_STATISTICS ON 
GO
ALTER DATABASE [KhachSan] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [KhachSan] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [KhachSan] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [KhachSan] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [KhachSan] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [KhachSan] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [KhachSan] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [KhachSan] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [KhachSan] SET  DISABLE_BROKER 
GO
ALTER DATABASE [KhachSan] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [KhachSan] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [KhachSan] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [KhachSan] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [KhachSan] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [KhachSan] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [KhachSan] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [KhachSan] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [KhachSan] SET  MULTI_USER 
GO
ALTER DATABASE [KhachSan] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [KhachSan] SET DB_CHAINING OFF 
GO
ALTER DATABASE [KhachSan] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [KhachSan] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
USE [KhachSan]
GO
/****** Object:  Table [dbo].[About]    Script Date: 9/7/2017 8:29:12 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[About](
	[ID] [int] NOT NULL,
	[description] [nvarchar](200) NULL,
	[content] [nvarchar](4000) NULL,
	[active] [int] NULL,
 CONSTRAINT [PK_About] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Account]    Script Date: 9/7/2017 8:29:12 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Account](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[accountName] [nvarchar](50) NULL,
	[email] [nvarchar](50) NULL,
	[password] [nvarchar](50) NULL,
	[displayname] [nvarchar](50) NULL,
	[created] [datetime] NULL,
	[modified] [datetime] NULL,
	[phone] [text] NULL,
	[address] [nvarchar](200) NULL,
	[avatar] [ntext] NULL,
	[isadmin] [bit] NOT NULL,
	[lastLogin] [datetime] NULL,
	[accountGroupID] [int] NULL,
	[IPLast] [varchar](50) NULL,
	[IPCreated] [varchar](50) NULL,
 CONSTRAINT [PK_Account_1] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[AccountGroup]    Script Date: 9/7/2017 8:29:12 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AccountGroup](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[groupPathID] [int] NULL,
	[accountID] [int] NULL,
	[active] [int] NULL,
	[description] [text] NULL,
 CONSTRAINT [PK_AccountGroup] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Blog]    Script Date: 9/7/2017 8:29:12 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Blog](
	[ID] [int] NOT NULL,
	[title] [text] NULL,
	[content] [text] NULL,
	[active] [int] NULL,
	[accountID] [int] NULL,
	[shortDescription] [text] NULL,
	[date] [date] NULL,
 CONSTRAINT [PK_Blog] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Booking]    Script Date: 9/7/2017 8:29:12 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Booking](
	[ID] [int] NOT NULL,
	[custumerID] [int] NULL,
	[bookingDate] [datetime] NULL,
	[bookingStatus] [int] NULL,
 CONSTRAINT [PK_Booking] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[BookingDetail]    Script Date: 9/7/2017 8:29:12 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[BookingDetail](
	[ID] [int] NOT NULL,
	[bookingID] [int] NULL,
	[roomID] [int] NULL,
	[detailQuantity] [int] NULL,
	[detailPrice] [float] NULL,
	[detailTotal] [int] NULL,
	[bookingStart] [datetime] NULL,
	[bookingEnd] [datetime] NULL,
 CONSTRAINT [PK_BookingDetail] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Category]    Script Date: 9/7/2017 8:29:12 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Category](
	[ID] [int] NOT NULL,
	[name] [text] NULL,
	[description] [text] NULL,
	[image] [text] NULL,
 CONSTRAINT [PK_Category] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Customer]    Script Date: 9/7/2017 8:29:12 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Customer](
	[ID] [int] NOT NULL,
	[fullName] [text] NULL,
	[address] [text] NULL,
	[phone] [text] NULL,
	[email] [text] NULL,
 CONSTRAINT [PK_Customer] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[GroupPath]    Script Date: 9/7/2017 8:29:12 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[GroupPath](
	[ID] [int] NOT NULL,
	[accountGroupID] [int] NULL,
	[pathID] [int] NULL,
 CONSTRAINT [PK_GroupPath] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[MultiTemplate]    Script Date: 9/7/2017 8:29:12 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[MultiTemplate](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[description] [text] NULL,
	[active] [bit] NULL,
 CONSTRAINT [PK_MultiTemplate] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Path]    Script Date: 9/7/2017 8:29:12 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Path](
	[ID] [int] NOT NULL,
	[pathName] [text] NULL,
	[pathDescription] [text] NULL,
	[pathUrl] [text] NULL,
	[active] [bit] NULL,
 CONSTRAINT [PK_Path] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Room]    Script Date: 9/7/2017 8:29:12 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Room](
	[ID] [int] NOT NULL,
	[roomName] [text] NULL,
	[roomDescription] [text] NULL,
	[roomPrice] [float] NULL,
	[categoryID] [int] NULL,
	[roomQuantily] [int] NULL,
 CONSTRAINT [PK_Rom] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Slider]    Script Date: 9/7/2017 8:29:12 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Slider](
	[ID] [int] NOT NULL,
	[image_Name] [text] NULL,
	[image_Description] [text] NULL,
	[active1] [int] NULL,
 CONSTRAINT [PK_Slider] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET IDENTITY_INSERT [dbo].[Account] ON 

INSERT [dbo].[Account] ([ID], [accountName], [email], [password], [displayname], [created], [modified], [phone], [address], [avatar], [isadmin], [lastLogin], [accountGroupID], [IPLast], [IPCreated]) VALUES (1, N'Cuong', N'abc@gmail.com', NULL, N'asdfghjkl', NULL, NULL, NULL, NULL, N'parallax-01.jpg', 0, NULL, NULL, NULL, NULL)
INSERT [dbo].[Account] ([ID], [accountName], [email], [password], [displayname], [created], [modified], [phone], [address], [avatar], [isadmin], [lastLogin], [accountGroupID], [IPLast], [IPCreated]) VALUES (2, N'xyz', N'abcd@gamil.com', NULL, NULL, NULL, NULL, NULL, NULL, N'blog-img.jpg', 0, NULL, NULL, NULL, NULL)
INSERT [dbo].[Account] ([ID], [accountName], [email], [password], [displayname], [created], [modified], [phone], [address], [avatar], [isadmin], [lastLogin], [accountGroupID], [IPLast], [IPCreated]) VALUES (3, N'nguyen van aaaa', N'anc@gmail.com', NULL, N'aaaa', NULL, NULL, NULL, NULL, N'slide2.jpg', 0, NULL, NULL, NULL, NULL)
SET IDENTITY_INSERT [dbo].[Account] OFF
SET IDENTITY_INSERT [dbo].[AccountGroup] ON 

INSERT [dbo].[AccountGroup] ([ID], [groupPathID], [accountID], [active], [description]) VALUES (1, 1, 1, 1, N'nhom admin')
SET IDENTITY_INSERT [dbo].[AccountGroup] OFF
ALTER TABLE [dbo].[Account] ADD  CONSTRAINT [DF_Account_IsAdmin]  DEFAULT ((0)) FOR [isadmin]
GO
ALTER TABLE [dbo].[Booking]  WITH CHECK ADD  CONSTRAINT [FK_Booking_Customer] FOREIGN KEY([custumerID])
REFERENCES [dbo].[Customer] ([ID])
GO
ALTER TABLE [dbo].[Booking] CHECK CONSTRAINT [FK_Booking_Customer]
GO
ALTER TABLE [dbo].[BookingDetail]  WITH CHECK ADD  CONSTRAINT [FK_BookingDetail_Booking] FOREIGN KEY([bookingID])
REFERENCES [dbo].[Booking] ([ID])
GO
ALTER TABLE [dbo].[BookingDetail] CHECK CONSTRAINT [FK_BookingDetail_Booking]
GO
ALTER TABLE [dbo].[BookingDetail]  WITH CHECK ADD  CONSTRAINT [FK_BookingDetail_Room] FOREIGN KEY([roomID])
REFERENCES [dbo].[Room] ([ID])
GO
ALTER TABLE [dbo].[BookingDetail] CHECK CONSTRAINT [FK_BookingDetail_Room]
GO
ALTER TABLE [dbo].[GroupPath]  WITH CHECK ADD  CONSTRAINT [FK_GroupPath_AccountGroup] FOREIGN KEY([accountGroupID])
REFERENCES [dbo].[AccountGroup] ([ID])
GO
ALTER TABLE [dbo].[GroupPath] CHECK CONSTRAINT [FK_GroupPath_AccountGroup]
GO
ALTER TABLE [dbo].[GroupPath]  WITH CHECK ADD  CONSTRAINT [FK_GroupPath_Path] FOREIGN KEY([accountGroupID])
REFERENCES [dbo].[Path] ([ID])
GO
ALTER TABLE [dbo].[GroupPath] CHECK CONSTRAINT [FK_GroupPath_Path]
GO
ALTER TABLE [dbo].[Room]  WITH CHECK ADD  CONSTRAINT [FK_Room_Category] FOREIGN KEY([categoryID])
REFERENCES [dbo].[Category] ([ID])
GO
ALTER TABLE [dbo].[Room] CHECK CONSTRAINT [FK_Room_Category]
GO
USE [master]
GO
ALTER DATABASE [KhachSan] SET  READ_WRITE 
GO
