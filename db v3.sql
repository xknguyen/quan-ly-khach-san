USE [master]
GO
/****** Object:  Database [KhachSan]    Script Date: 9/14/2017 11:42:08 AM ******/
CREATE DATABASE [KhachSan]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'KhachSan', FILENAME = N'c:\Program Files\Microsoft SQL Server\MSSQL11.SQLEXPRESS\MSSQL\DATA\KhachSan.mdf' , SIZE = 3072KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'KhachSan_log', FILENAME = N'c:\Program Files\Microsoft SQL Server\MSSQL11.SQLEXPRESS\MSSQL\DATA\KhachSan_log.ldf' , SIZE = 1024KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
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
/****** Object:  Table [dbo].[About]    Script Date: 9/14/2017 11:42:09 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[About](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[description] [nvarchar](200) NULL,
	[content] [nvarchar](4000) NULL,
	[active] [int] NULL,
 CONSTRAINT [PK_About] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Account]    Script Date: 9/14/2017 11:42:09 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Account](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[accountName] [nvarchar](500) NULL,
	[email] [nvarchar](500) NULL,
	[password] [nvarchar](500) NULL,
	[displayname] [nvarchar](500) NULL,
	[created] [date] NULL,
	[modified] [date] NULL,
	[phone] [text] NULL,
	[address] [nvarchar](200) NULL,
	[avatar] [ntext] NULL,
	[isadmin] [bit] NOT NULL,
	[lastLogin] [datetime] NULL,
	[accountGroupID] [int] NULL,
	[IPLast] [varchar](50) NULL,
	[IPCreated] [varchar](50) NULL,
	[active] [bit] NULL,
 CONSTRAINT [PK_Account_1] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[AccountGroup]    Script Date: 9/14/2017 11:42:09 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AccountGroup](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[groupPathID] [int] NULL,
	[accountID] [int] NULL,
	[active] [int] NULL,
	[description] [nvarchar](500) NULL,
 CONSTRAINT [PK_AccountGroup] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Blog]    Script Date: 9/14/2017 11:42:09 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Blog](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[title] [nvarchar](500) NULL,
	[content] [nvarchar](4000) NULL,
	[active] [bit] NULL,
	[accountID] [int] NULL,
	[shortDescription] [nvarchar](4000) NULL,
	[date] [date] NULL,
 CONSTRAINT [PK_Blog] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Booking]    Script Date: 9/14/2017 11:42:09 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Booking](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[custumerID] [int] NULL,
	[bookingDate] [date] NULL,
	[bookingStatus] [int] NULL,
 CONSTRAINT [PK_Booking] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[BookingDetail]    Script Date: 9/14/2017 11:42:09 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[BookingDetail](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[bookingID] [int] NULL,
	[roomID] [int] NULL,
	[detailQuantity] [int] NULL,
	[detailPrice] [float] NULL,
	[detailTotal] [int] NULL,
	[bookingStart] [date] NULL,
	[bookingEnd] [date] NULL,
 CONSTRAINT [PK_BookingDetail] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Category]    Script Date: 9/14/2017 11:42:09 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Category](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[name] [nvarchar](500) NULL,
	[description] [nvarchar](500) NULL,
	[image] [nvarchar](500) NULL,
 CONSTRAINT [PK_Category] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Customer]    Script Date: 9/14/2017 11:42:09 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Customer](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[fullName] [nvarchar](500) NULL,
	[address] [nvarchar](500) NULL,
	[phone] [varchar](50) NULL,
	[email] [nvarchar](500) NULL,
 CONSTRAINT [PK_Customer] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[GroupPath]    Script Date: 9/14/2017 11:42:09 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[GroupPath](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[accountGroupID] [int] NULL,
	[pathID] [int] NULL,
 CONSTRAINT [PK_GroupPath] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[MultiTemplate]    Script Date: 9/14/2017 11:42:09 AM ******/
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
/****** Object:  Table [dbo].[Paths]    Script Date: 9/14/2017 11:42:09 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Paths](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[pathName] [nvarchar](500) NULL,
	[pathDescription] [nvarchar](500) NULL,
	[pathUrl] [text] NULL,
	[active] [bit] NULL,
 CONSTRAINT [PK_Path] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Room]    Script Date: 9/14/2017 11:42:09 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Room](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[roomName] [nvarchar](500) NULL,
	[roomDescription] [nvarchar](500) NULL,
	[roomPrice] [float] NULL,
	[categoryID] [int] NULL,
	[roomQuantily] [int] NULL,
 CONSTRAINT [PK_Rom] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Slider]    Script Date: 9/14/2017 11:42:09 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Slider](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[image_Name] [nvarchar](500) NULL,
	[image_Description] [nvarchar](500) NULL,
	[image_Path] [nvarchar](100) NULL,
	[active] [int] NULL,
 CONSTRAINT [PK_Slider] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
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
ALTER TABLE [dbo].[Room]  WITH CHECK ADD  CONSTRAINT [FK_Room_Category] FOREIGN KEY([categoryID])
REFERENCES [dbo].[Category] ([ID])
GO
ALTER TABLE [dbo].[Room] CHECK CONSTRAINT [FK_Room_Category]
GO
USE [master]
GO
ALTER DATABASE [KhachSan] SET  READ_WRITE 
GO
