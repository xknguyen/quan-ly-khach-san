USE [KhachSan]
GO
/****** Object:  Table [dbo].[Abouts]    Script Date: 9/18/2017 9:55:55 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Abouts](
	[ID] [int] NOT NULL,
	[description] [nvarchar](200) NULL,
	[content] [nvarchar](4000) NULL,
	[active] [int] NULL,
 CONSTRAINT [PK_Abouts] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[AccountGroups]    Script Date: 9/18/2017 9:55:55 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[AccountGroups](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[groupPathID] [int] NULL,
	[accountID] [int] NULL,
	[active] [int] NULL,
	[description] [varchar](max) NULL,
 CONSTRAINT [PK_AccountGroups] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Accounts]    Script Date: 9/18/2017 9:55:55 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Accounts](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[accountName] [varchar](20) NULL,
	[password] [varchar](50) NULL,
	[fullName] [varchar](max) NULL,
	[imagePath] [varchar](max) NULL,
	[birthDay] [datetime] NULL,
	[phone] [varchar](max) NULL,
	[email] [varchar](max) NULL,
	[address] [varchar](max) NULL,
	[createDate] [datetime] NULL,
	[lastLogin] [datetime] NULL,
	[accountGroupID] [int] NULL,
	[active] [bit] NULL,
 CONSTRAINT [PK_Accounts] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Blogs]    Script Date: 9/18/2017 9:55:55 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Blogs](
	[ID] [int] NOT NULL,
	[title] [varchar](max) NULL,
	[content] [varchar](max) NULL,
	[active] [int] NULL,
	[accountID] [int] NULL,
	[shortDescription] [varchar](max) NULL,
	[date] [datetime] NULL,
 CONSTRAINT [PK_Blogs] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[BookingDetails]    Script Date: 9/18/2017 9:55:55 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[BookingDetails](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[bookingID] [int] NULL,
	[roomID] [int] NULL,
	[detailQuantity] [int] NULL,
	[detailPrice] [float] NULL,
	[bookingStart] [datetime] NULL,
	[bookingEnd] [datetime] NULL,
	[typeRoom] [varchar](max) NULL,
	[roomQuantity] [int] NULL,
 CONSTRAINT [PK_BookingDetails] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Bookings]    Script Date: 9/18/2017 9:55:55 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Bookings](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[custumerID] [int] NULL,
	[bookingDate] [datetime] NULL,
	[bookingStatus] [bit] NULL,
 CONSTRAINT [PK_Bookings] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[C__MigrationHistory]    Script Date: 9/18/2017 9:55:55 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[C__MigrationHistory](
	[MigrationId] [nvarchar](150) NOT NULL,
	[ContextKey] [nvarchar](300) NOT NULL,
	[Model] [varbinary](max) NOT NULL,
	[ProductVersion] [nvarchar](32) NOT NULL,
 CONSTRAINT [PK_C__MigrationHistory] PRIMARY KEY CLUSTERED 
(
	[MigrationId] ASC,
	[ContextKey] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Categories]    Script Date: 9/18/2017 9:55:55 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Categories](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[name] [varchar](max) NULL,
	[description] [varchar](max) NULL,
	[image] [varchar](max) NULL,
 CONSTRAINT [PK_Categories] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Customers]    Script Date: 9/18/2017 9:55:55 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Customers](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[fullName] [nvarchar](50) NULL,
	[address] [nvarchar](50) NULL,
	[phone] [varchar](max) NULL,
	[email] [varchar](max) NULL,
 CONSTRAINT [PK_Customers] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[GroupPaths]    Script Date: 9/18/2017 9:55:55 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[GroupPaths](
	[ID] [int] NOT NULL,
	[accountGroupID] [int] NULL,
	[pathID] [int] NULL,
 CONSTRAINT [PK_GroupPaths] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[MultiTemplates]    Script Date: 9/18/2017 9:55:55 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[MultiTemplates](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[description] [varchar](max) NULL,
	[active] [bit] NULL,
 CONSTRAINT [PK_MultiTemplates] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Paths]    Script Date: 9/18/2017 9:55:55 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Paths](
	[ID] [int] NOT NULL,
	[pathName] [varchar](max) NULL,
	[pathDescription] [varchar](max) NULL,
	[pathUrl] [varchar](max) NULL,
	[active] [bit] NULL,
 CONSTRAINT [PK_Paths] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Rooms]    Script Date: 9/18/2017 9:55:55 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Rooms](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[roomName] [varchar](max) NULL,
	[roomDescription] [varchar](max) NULL,
	[roomPrice] [float] NULL,
	[categoryID] [int] NULL,
	[roomQuantily] [int] NULL,
	[roomImage] [nvarchar](50) NULL,
 CONSTRAINT [PK_Rooms] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Sliders]    Script Date: 9/18/2017 9:55:55 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Sliders](
	[ID] [int] NOT NULL,
	[image_Name] [varchar](max) NULL,
	[image_Description] [varchar](max) NULL,
	[active1] [int] NULL,
 CONSTRAINT [PK_Sliders] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[sysdiagrams]    Script Date: 9/18/2017 9:55:55 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[sysdiagrams](
	[name] [nvarchar](128) NOT NULL,
	[principal_id] [int] NOT NULL,
	[diagram_id] [int] IDENTITY(1,1) NOT NULL,
	[version] [int] NULL,
	[definition] [varbinary](max) NULL,
 CONSTRAINT [PK_sysdiagrams] PRIMARY KEY CLUSTERED 
(
	[diagram_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
SET IDENTITY_INSERT [dbo].[Accounts] ON 

INSERT [dbo].[Accounts] ([ID], [accountName], [password], [fullName], [imagePath], [birthDay], [phone], [email], [address], [createDate], [lastLogin], [accountGroupID], [active]) VALUES (1, N'admin', N'123', N'Nguyen Van Nam', N'avatar.jpg', CAST(0x0000867000000000 AS DateTime), N'01655509342', N'duynamctk37@gmail.com', N'thanh hoa', NULL, CAST(0x0000A7F2009DD126 AS DateTime), NULL, 1)
SET IDENTITY_INSERT [dbo].[Accounts] OFF
SET IDENTITY_INSERT [dbo].[BookingDetails] ON 

INSERT [dbo].[BookingDetails] ([ID], [bookingID], [roomID], [detailQuantity], [detailPrice], [bookingStart], [bookingEnd], [typeRoom], [roomQuantity]) VALUES (17, 18, NULL, 56, NULL, CAST(0x0000A7F200000000 AS DateTime), CAST(0x0000A7F400000000 AS DateTime), N'Select a room', 6)
SET IDENTITY_INSERT [dbo].[BookingDetails] OFF
SET IDENTITY_INSERT [dbo].[Bookings] ON 

INSERT [dbo].[Bookings] ([ID], [custumerID], [bookingDate], [bookingStatus]) VALUES (18, 18, CAST(0x0000A7F2009DC08F AS DateTime), 0)
SET IDENTITY_INSERT [dbo].[Bookings] OFF
SET IDENTITY_INSERT [dbo].[Categories] ON 

INSERT [dbo].[Categories] ([ID], [name], [description], [image]) VALUES (1, N'Double Bedroom', N'Category 1', N'Category1')
INSERT [dbo].[Categories] ([ID], [name], [description], [image]) VALUES (2, N'King Size Bedroom', N'Category 2', N'Category2')
INSERT [dbo].[Categories] ([ID], [name], [description], [image]) VALUES (3, N'Single Room', N'Category 3', N'Category3')
SET IDENTITY_INSERT [dbo].[Categories] OFF
SET IDENTITY_INSERT [dbo].[Customers] ON 

INSERT [dbo].[Customers] ([ID], [fullName], [address], [phone], [email]) VALUES (18, N'ĐƯAÁDS', NULL, N'45445', NULL)
SET IDENTITY_INSERT [dbo].[Customers] OFF
SET IDENTITY_INSERT [dbo].[Rooms] ON 

INSERT [dbo].[Rooms] ([ID], [roomName], [roomDescription], [roomPrice], [categoryID], [roomQuantily], [roomImage]) VALUES (1, N'Phong So 1', N'phong 2 nguoi', 50, 1, 6, N'room-01.jpg')
INSERT [dbo].[Rooms] ([ID], [roomName], [roomDescription], [roomPrice], [categoryID], [roomQuantily], [roomImage]) VALUES (2, N'Phong So 2', N'Phong So 2', 60, 3, 6, N'room-05.jpg')
INSERT [dbo].[Rooms] ([ID], [roomName], [roomDescription], [roomPrice], [categoryID], [roomQuantily], [roomImage]) VALUES (3, N'Phong So 3', N'Phong So 3', 70, 2, 6, N'room-07.jpg')
SET IDENTITY_INSERT [dbo].[Rooms] OFF
ALTER TABLE [dbo].[AccountGroups]  WITH CHECK ADD  CONSTRAINT [FK_dbo_AccountGroup_dbo_Account_accountID] FOREIGN KEY([accountID])
REFERENCES [dbo].[Accounts] ([ID])
GO
ALTER TABLE [dbo].[AccountGroups] CHECK CONSTRAINT [FK_dbo_AccountGroup_dbo_Account_accountID]
GO
ALTER TABLE [dbo].[Blogs]  WITH CHECK ADD  CONSTRAINT [FK_dbo_Blog_dbo_Account_accountID] FOREIGN KEY([accountID])
REFERENCES [dbo].[Accounts] ([ID])
GO
ALTER TABLE [dbo].[Blogs] CHECK CONSTRAINT [FK_dbo_Blog_dbo_Account_accountID]
GO
ALTER TABLE [dbo].[BookingDetails]  WITH CHECK ADD  CONSTRAINT [FK_dbo_BookingDetail_dbo_Booking_bookingID] FOREIGN KEY([bookingID])
REFERENCES [dbo].[Bookings] ([ID])
GO
ALTER TABLE [dbo].[BookingDetails] CHECK CONSTRAINT [FK_dbo_BookingDetail_dbo_Booking_bookingID]
GO
ALTER TABLE [dbo].[BookingDetails]  WITH CHECK ADD  CONSTRAINT [FK_dbo_BookingDetail_dbo_Room_roomID] FOREIGN KEY([roomID])
REFERENCES [dbo].[Rooms] ([ID])
GO
ALTER TABLE [dbo].[BookingDetails] CHECK CONSTRAINT [FK_dbo_BookingDetail_dbo_Room_roomID]
GO
ALTER TABLE [dbo].[Bookings]  WITH CHECK ADD  CONSTRAINT [FK_dbo_Booking_dbo_Customer_custumerID] FOREIGN KEY([custumerID])
REFERENCES [dbo].[Customers] ([ID])
GO
ALTER TABLE [dbo].[Bookings] CHECK CONSTRAINT [FK_dbo_Booking_dbo_Customer_custumerID]
GO
ALTER TABLE [dbo].[GroupPaths]  WITH CHECK ADD  CONSTRAINT [FK_dbo_GroupPath_dbo_AccountGroup_accountGroupID] FOREIGN KEY([accountGroupID])
REFERENCES [dbo].[AccountGroups] ([ID])
GO
ALTER TABLE [dbo].[GroupPaths] CHECK CONSTRAINT [FK_dbo_GroupPath_dbo_AccountGroup_accountGroupID]
GO
ALTER TABLE [dbo].[GroupPaths]  WITH CHECK ADD  CONSTRAINT [FK_dbo_GroupPath_dbo_Path_accountGroupID] FOREIGN KEY([accountGroupID])
REFERENCES [dbo].[Paths] ([ID])
GO
ALTER TABLE [dbo].[GroupPaths] CHECK CONSTRAINT [FK_dbo_GroupPath_dbo_Path_accountGroupID]
GO
ALTER TABLE [dbo].[Rooms]  WITH CHECK ADD  CONSTRAINT [FK_dbo_Room_dbo_Category_categoryID] FOREIGN KEY([categoryID])
REFERENCES [dbo].[Categories] ([ID])
GO
ALTER TABLE [dbo].[Rooms] CHECK CONSTRAINT [FK_dbo_Room_dbo_Category_categoryID]
GO
