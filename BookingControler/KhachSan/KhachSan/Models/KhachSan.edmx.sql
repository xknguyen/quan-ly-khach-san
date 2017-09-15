
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 09/14/2017 19:02:46
-- Generated from EDMX file: C:\Users\ngocp\Desktop\KhachSan\KhachSan\Models\KhachSan.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [KhachSan];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FK_dbo_AccountGroup_dbo_Account_accountID]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[AccountGroup] DROP CONSTRAINT [FK_dbo_AccountGroup_dbo_Account_accountID];
GO
IF OBJECT_ID(N'[dbo].[FK_dbo_Blog_dbo_Account_accountID]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Blog] DROP CONSTRAINT [FK_dbo_Blog_dbo_Account_accountID];
GO
IF OBJECT_ID(N'[dbo].[FK_dbo_Booking_dbo_Customer_custumerID]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Booking] DROP CONSTRAINT [FK_dbo_Booking_dbo_Customer_custumerID];
GO
IF OBJECT_ID(N'[dbo].[FK_dbo_BookingDetail_dbo_Booking_bookingID]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[BookingDetail] DROP CONSTRAINT [FK_dbo_BookingDetail_dbo_Booking_bookingID];
GO
IF OBJECT_ID(N'[dbo].[FK_dbo_BookingDetail_dbo_Room_roomID]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[BookingDetail] DROP CONSTRAINT [FK_dbo_BookingDetail_dbo_Room_roomID];
GO
IF OBJECT_ID(N'[dbo].[FK_dbo_GroupPath_dbo_AccountGroup_accountGroupID]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[GroupPath] DROP CONSTRAINT [FK_dbo_GroupPath_dbo_AccountGroup_accountGroupID];
GO
IF OBJECT_ID(N'[dbo].[FK_dbo_GroupPath_dbo_Path_accountGroupID]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[GroupPath] DROP CONSTRAINT [FK_dbo_GroupPath_dbo_Path_accountGroupID];
GO
IF OBJECT_ID(N'[dbo].[FK_dbo_Room_dbo_Category_categoryID]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Room] DROP CONSTRAINT [FK_dbo_Room_dbo_Category_categoryID];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[__MigrationHistory]', 'U') IS NOT NULL
    DROP TABLE [dbo].[__MigrationHistory];
GO
IF OBJECT_ID(N'[dbo].[About]', 'U') IS NOT NULL
    DROP TABLE [dbo].[About];
GO
IF OBJECT_ID(N'[dbo].[Account]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Account];
GO
IF OBJECT_ID(N'[dbo].[AccountGroup]', 'U') IS NOT NULL
    DROP TABLE [dbo].[AccountGroup];
GO
IF OBJECT_ID(N'[dbo].[Blog]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Blog];
GO
IF OBJECT_ID(N'[dbo].[Booking]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Booking];
GO
IF OBJECT_ID(N'[dbo].[BookingDetail]', 'U') IS NOT NULL
    DROP TABLE [dbo].[BookingDetail];
GO
IF OBJECT_ID(N'[dbo].[Category]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Category];
GO
IF OBJECT_ID(N'[dbo].[Customer]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Customer];
GO
IF OBJECT_ID(N'[dbo].[GroupPath]', 'U') IS NOT NULL
    DROP TABLE [dbo].[GroupPath];
GO
IF OBJECT_ID(N'[dbo].[MultiTemplate]', 'U') IS NOT NULL
    DROP TABLE [dbo].[MultiTemplate];
GO
IF OBJECT_ID(N'[dbo].[Path]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Path];
GO
IF OBJECT_ID(N'[dbo].[Room]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Room];
GO
IF OBJECT_ID(N'[dbo].[Slider]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Slider];
GO
IF OBJECT_ID(N'[dbo].[sysdiagrams]', 'U') IS NOT NULL
    DROP TABLE [dbo].[sysdiagrams];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'C__MigrationHistory'
CREATE TABLE [dbo].[C__MigrationHistory] (
    [MigrationId] nvarchar(150)  NOT NULL,
    [ContextKey] nvarchar(300)  NOT NULL,
    [Model] varbinary(max)  NOT NULL,
    [ProductVersion] nvarchar(32)  NOT NULL
);
GO

-- Creating table 'Abouts'
CREATE TABLE [dbo].[Abouts] (
    [ID] int  NOT NULL,
    [description] nvarchar(200)  NULL,
    [content] nvarchar(4000)  NULL,
    [active] int  NULL
);
GO

-- Creating table 'Accounts'
CREATE TABLE [dbo].[Accounts] (
    [ID] int IDENTITY(1,1) NOT NULL,
    [accountName] varchar(20)  NULL,
    [password] varchar(50)  NULL,
    [fullName] varchar(max)  NULL,
    [imagePath] varchar(max)  NULL,
    [birthDay] datetime  NULL,
    [phone] varchar(max)  NULL,
    [email] varchar(max)  NULL,
    [address] varchar(max)  NULL,
    [createDate] datetime  NULL,
    [lastLogin] datetime  NULL,
    [accountGroupID] int  NULL,
    [active] bit  NULL
);
GO

-- Creating table 'AccountGroups'
CREATE TABLE [dbo].[AccountGroups] (
    [ID] int IDENTITY(1,1) NOT NULL,
    [groupPathID] int  NULL,
    [accountID] int  NULL,
    [active] int  NULL,
    [description] varchar(max)  NULL
);
GO

-- Creating table 'Blogs'
CREATE TABLE [dbo].[Blogs] (
    [ID] int  NOT NULL,
    [title] varchar(max)  NULL,
    [content] varchar(max)  NULL,
    [active] int  NULL,
    [accountID] int  NULL,
    [shortDescription] varchar(max)  NULL,
    [date] datetime  NULL
);
GO

-- Creating table 'Bookings'
CREATE TABLE [dbo].[Bookings] (
    [ID] int IDENTITY(1,1) NOT NULL,
    [custumerID] int  NULL,
    [bookingDate] datetime  NULL,
    [bookingStatus] bit  NULL
);
GO

-- Creating table 'BookingDetails'
CREATE TABLE [dbo].[BookingDetails] (
    [ID] int IDENTITY(1,1) NOT NULL,
    [bookingID] int  NULL,
    [roomID] int  NULL,
    [detailQuantity] int  NULL,
    [detailPrice] float  NULL,
    [detailTotal] int  NULL,
    [bookingStart] datetime  NULL,
    [bookingEnd] datetime  NULL,
    [typeRoom] varchar(max)  NULL
);
GO

-- Creating table 'Categories'
CREATE TABLE [dbo].[Categories] (
    [ID] int IDENTITY(1,1) NOT NULL,
    [name] varchar(max)  NULL,
    [description] varchar(max)  NULL,
    [image] varchar(max)  NULL
);
GO

-- Creating table 'Customers'
CREATE TABLE [dbo].[Customers] (
    [ID] int IDENTITY(1,1) NOT NULL,
    [fullName] nvarchar(50)  NULL,
    [address] nvarchar(50)  NULL,
    [phone] varchar(max)  NULL,
    [email] varchar(max)  NULL
);
GO

-- Creating table 'GroupPaths'
CREATE TABLE [dbo].[GroupPaths] (
    [ID] int  NOT NULL,
    [accountGroupID] int  NULL,
    [pathID] int  NULL
);
GO

-- Creating table 'MultiTemplates'
CREATE TABLE [dbo].[MultiTemplates] (
    [ID] int IDENTITY(1,1) NOT NULL,
    [description] varchar(max)  NULL,
    [active] bit  NULL
);
GO

-- Creating table 'Paths'
CREATE TABLE [dbo].[Paths] (
    [ID] int  NOT NULL,
    [pathName] varchar(max)  NULL,
    [pathDescription] varchar(max)  NULL,
    [pathUrl] varchar(max)  NULL,
    [active] bit  NULL
);
GO

-- Creating table 'Rooms'
CREATE TABLE [dbo].[Rooms] (
    [ID] int IDENTITY(1,1) NOT NULL,
    [roomName] varchar(max)  NULL,
    [roomDescription] varchar(max)  NULL,
    [roomPrice] float  NULL,
    [categoryID] int  NULL,
    [roomQuantily] int  NULL,
    [roomImage] nvarchar(50)  NULL
);
GO

-- Creating table 'Sliders'
CREATE TABLE [dbo].[Sliders] (
    [ID] int  NOT NULL,
    [image_Name] varchar(max)  NULL,
    [image_Description] varchar(max)  NULL,
    [active1] int  NULL
);
GO

-- Creating table 'sysdiagrams'
CREATE TABLE [dbo].[sysdiagrams] (
    [name] nvarchar(128)  NOT NULL,
    [principal_id] int  NOT NULL,
    [diagram_id] int IDENTITY(1,1) NOT NULL,
    [version] int  NULL,
    [definition] varbinary(max)  NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [MigrationId], [ContextKey] in table 'C__MigrationHistory'
ALTER TABLE [dbo].[C__MigrationHistory]
ADD CONSTRAINT [PK_C__MigrationHistory]
    PRIMARY KEY CLUSTERED ([MigrationId], [ContextKey] ASC);
GO

-- Creating primary key on [ID] in table 'Abouts'
ALTER TABLE [dbo].[Abouts]
ADD CONSTRAINT [PK_Abouts]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- Creating primary key on [ID] in table 'Accounts'
ALTER TABLE [dbo].[Accounts]
ADD CONSTRAINT [PK_Accounts]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- Creating primary key on [ID] in table 'AccountGroups'
ALTER TABLE [dbo].[AccountGroups]
ADD CONSTRAINT [PK_AccountGroups]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- Creating primary key on [ID] in table 'Blogs'
ALTER TABLE [dbo].[Blogs]
ADD CONSTRAINT [PK_Blogs]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- Creating primary key on [ID] in table 'Bookings'
ALTER TABLE [dbo].[Bookings]
ADD CONSTRAINT [PK_Bookings]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- Creating primary key on [ID] in table 'BookingDetails'
ALTER TABLE [dbo].[BookingDetails]
ADD CONSTRAINT [PK_BookingDetails]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- Creating primary key on [ID] in table 'Categories'
ALTER TABLE [dbo].[Categories]
ADD CONSTRAINT [PK_Categories]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- Creating primary key on [ID] in table 'Customers'
ALTER TABLE [dbo].[Customers]
ADD CONSTRAINT [PK_Customers]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- Creating primary key on [ID] in table 'GroupPaths'
ALTER TABLE [dbo].[GroupPaths]
ADD CONSTRAINT [PK_GroupPaths]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- Creating primary key on [ID] in table 'MultiTemplates'
ALTER TABLE [dbo].[MultiTemplates]
ADD CONSTRAINT [PK_MultiTemplates]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- Creating primary key on [ID] in table 'Paths'
ALTER TABLE [dbo].[Paths]
ADD CONSTRAINT [PK_Paths]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- Creating primary key on [ID] in table 'Rooms'
ALTER TABLE [dbo].[Rooms]
ADD CONSTRAINT [PK_Rooms]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- Creating primary key on [ID] in table 'Sliders'
ALTER TABLE [dbo].[Sliders]
ADD CONSTRAINT [PK_Sliders]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- Creating primary key on [diagram_id] in table 'sysdiagrams'
ALTER TABLE [dbo].[sysdiagrams]
ADD CONSTRAINT [PK_sysdiagrams]
    PRIMARY KEY CLUSTERED ([diagram_id] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [accountID] in table 'AccountGroups'
ALTER TABLE [dbo].[AccountGroups]
ADD CONSTRAINT [FK_dbo_AccountGroup_dbo_Account_accountID]
    FOREIGN KEY ([accountID])
    REFERENCES [dbo].[Accounts]
        ([ID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_dbo_AccountGroup_dbo_Account_accountID'
CREATE INDEX [IX_FK_dbo_AccountGroup_dbo_Account_accountID]
ON [dbo].[AccountGroups]
    ([accountID]);
GO

-- Creating foreign key on [accountID] in table 'Blogs'
ALTER TABLE [dbo].[Blogs]
ADD CONSTRAINT [FK_dbo_Blog_dbo_Account_accountID]
    FOREIGN KEY ([accountID])
    REFERENCES [dbo].[Accounts]
        ([ID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_dbo_Blog_dbo_Account_accountID'
CREATE INDEX [IX_FK_dbo_Blog_dbo_Account_accountID]
ON [dbo].[Blogs]
    ([accountID]);
GO

-- Creating foreign key on [accountGroupID] in table 'GroupPaths'
ALTER TABLE [dbo].[GroupPaths]
ADD CONSTRAINT [FK_dbo_GroupPath_dbo_AccountGroup_accountGroupID]
    FOREIGN KEY ([accountGroupID])
    REFERENCES [dbo].[AccountGroups]
        ([ID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_dbo_GroupPath_dbo_AccountGroup_accountGroupID'
CREATE INDEX [IX_FK_dbo_GroupPath_dbo_AccountGroup_accountGroupID]
ON [dbo].[GroupPaths]
    ([accountGroupID]);
GO

-- Creating foreign key on [custumerID] in table 'Bookings'
ALTER TABLE [dbo].[Bookings]
ADD CONSTRAINT [FK_dbo_Booking_dbo_Customer_custumerID]
    FOREIGN KEY ([custumerID])
    REFERENCES [dbo].[Customers]
        ([ID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_dbo_Booking_dbo_Customer_custumerID'
CREATE INDEX [IX_FK_dbo_Booking_dbo_Customer_custumerID]
ON [dbo].[Bookings]
    ([custumerID]);
GO

-- Creating foreign key on [bookingID] in table 'BookingDetails'
ALTER TABLE [dbo].[BookingDetails]
ADD CONSTRAINT [FK_dbo_BookingDetail_dbo_Booking_bookingID]
    FOREIGN KEY ([bookingID])
    REFERENCES [dbo].[Bookings]
        ([ID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_dbo_BookingDetail_dbo_Booking_bookingID'
CREATE INDEX [IX_FK_dbo_BookingDetail_dbo_Booking_bookingID]
ON [dbo].[BookingDetails]
    ([bookingID]);
GO

-- Creating foreign key on [roomID] in table 'BookingDetails'
ALTER TABLE [dbo].[BookingDetails]
ADD CONSTRAINT [FK_dbo_BookingDetail_dbo_Room_roomID]
    FOREIGN KEY ([roomID])
    REFERENCES [dbo].[Rooms]
        ([ID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_dbo_BookingDetail_dbo_Room_roomID'
CREATE INDEX [IX_FK_dbo_BookingDetail_dbo_Room_roomID]
ON [dbo].[BookingDetails]
    ([roomID]);
GO

-- Creating foreign key on [categoryID] in table 'Rooms'
ALTER TABLE [dbo].[Rooms]
ADD CONSTRAINT [FK_dbo_Room_dbo_Category_categoryID]
    FOREIGN KEY ([categoryID])
    REFERENCES [dbo].[Categories]
        ([ID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_dbo_Room_dbo_Category_categoryID'
CREATE INDEX [IX_FK_dbo_Room_dbo_Category_categoryID]
ON [dbo].[Rooms]
    ([categoryID]);
GO

-- Creating foreign key on [accountGroupID] in table 'GroupPaths'
ALTER TABLE [dbo].[GroupPaths]
ADD CONSTRAINT [FK_dbo_GroupPath_dbo_Path_accountGroupID]
    FOREIGN KEY ([accountGroupID])
    REFERENCES [dbo].[Paths]
        ([ID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_dbo_GroupPath_dbo_Path_accountGroupID'
CREATE INDEX [IX_FK_dbo_GroupPath_dbo_Path_accountGroupID]
ON [dbo].[GroupPaths]
    ([accountGroupID]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------