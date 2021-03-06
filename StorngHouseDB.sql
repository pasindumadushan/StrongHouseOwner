USE [master]
GO
/****** Object:  Database [StrongHouseDB]    Script Date: 07/01/2021 16:51:08 ******/
CREATE DATABASE [StrongHouseDB]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'StrongHouseDB', FILENAME = N'C:\Users\pasindu\StrongHouseDB.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'StrongHouseDB_log', FILENAME = N'C:\Users\pasindu\StrongHouseDB_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO
ALTER DATABASE [StrongHouseDB] SET COMPATIBILITY_LEVEL = 130
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [StrongHouseDB].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [StrongHouseDB] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [StrongHouseDB] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [StrongHouseDB] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [StrongHouseDB] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [StrongHouseDB] SET ARITHABORT OFF 
GO
ALTER DATABASE [StrongHouseDB] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [StrongHouseDB] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [StrongHouseDB] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [StrongHouseDB] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [StrongHouseDB] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [StrongHouseDB] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [StrongHouseDB] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [StrongHouseDB] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [StrongHouseDB] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [StrongHouseDB] SET  DISABLE_BROKER 
GO
ALTER DATABASE [StrongHouseDB] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [StrongHouseDB] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [StrongHouseDB] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [StrongHouseDB] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [StrongHouseDB] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [StrongHouseDB] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [StrongHouseDB] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [StrongHouseDB] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [StrongHouseDB] SET  MULTI_USER 
GO
ALTER DATABASE [StrongHouseDB] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [StrongHouseDB] SET DB_CHAINING OFF 
GO
ALTER DATABASE [StrongHouseDB] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [StrongHouseDB] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [StrongHouseDB] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [StrongHouseDB] SET QUERY_STORE = OFF
GO
USE [StrongHouseDB]
GO
ALTER DATABASE SCOPED CONFIGURATION SET LEGACY_CARDINALITY_ESTIMATION = OFF;
GO
ALTER DATABASE SCOPED CONFIGURATION SET MAXDOP = 0;
GO
ALTER DATABASE SCOPED CONFIGURATION SET PARAMETER_SNIFFING = ON;
GO
ALTER DATABASE SCOPED CONFIGURATION SET QUERY_OPTIMIZER_HOTFIXES = OFF;
GO
USE [StrongHouseDB]
GO
/****** Object:  Table [dbo].[Comment]    Script Date: 07/01/2021 16:51:08 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Comment](
	[CommentId] [int] IDENTITY(1,1) NOT NULL,
	[UserRefId] [int] NULL,
	[Comment] [varchar](200) NULL,
	[CommentDateTime] [datetime] NULL,
 CONSTRAINT [PK_Comment] PRIMARY KEY CLUSTERED 
(
	[CommentId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[HouseDetails]    Script Date: 07/01/2021 16:51:08 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[HouseDetails](
	[HouseId] [int] IDENTITY(1,1) NOT NULL,
	[UserRefId] [int] NULL,
	[HouseName] [nvarchar](50) NULL,
	[HouseAddress] [nvarchar](300) NULL,
	[HouseAdditionalInformation] [nvarchar](max) NULL,
	[NumberOfFloors] [int] NULL,
	[FloorArea] [decimal](8, 2) NULL,
	[LandArea] [decimal](8, 2) NULL,
	[NumberOfLivingRooms] [int] NULL,
	[NumberOfDiningRooms] [int] NULL,
	[NumberOfBedRooms] [int] NULL,
	[NumberOfWashRooms] [int] NULL,
	[NumberOfKitchens] [int] NULL,
	[NumberOfStoreRooms] [int] NULL,
	[NumberOfGarages] [int] NULL,
	[EstimatedValue] [numeric](10, 2) NULL,
	[HouseImagePath] [nvarchar](max) NULL,
 CONSTRAINT [PK_HouseDetails] PRIMARY KEY CLUSTERED 
(
	[HouseId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Plan]    Script Date: 07/01/2021 16:51:08 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Plan](
	[PlanId] [int] IDENTITY(1,1) NOT NULL,
	[TypeOfPlan] [nvarchar](50) NULL,
	[PlanDetails] [nvarchar](max) NULL,
	[PlanImagePath] [nvarchar](max) NULL,
 CONSTRAINT [PK_Plan] PRIMARY KEY CLUSTERED 
(
	[PlanId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Reply]    Script Date: 07/01/2021 16:51:08 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Reply](
	[ReplyId] [int] IDENTITY(1,1) NOT NULL,
	[UserRefId] [int] NULL,
	[CommentRefId] [int] NULL,
	[Reply] [varchar](200) NULL,
	[ReplyDateTime] [datetime] NULL,
 CONSTRAINT [PK_Reply] PRIMARY KEY CLUSTERED 
(
	[ReplyId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[StoredCeiling]    Script Date: 07/01/2021 16:51:08 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[StoredCeiling](
	[CeilingId] [int] IDENTITY(1,1) NOT NULL,
	[HouseRefId] [int] NOT NULL,
	[StoredTypeOfCeilingRefId] [int] NULL,
	[StoredTypeOfCeilingSampleRefId] [int] NULL,
	[CeilingName] [nvarchar](50) NOT NULL,
	[CeilingCategory] [nvarchar](50) NOT NULL,
	[CeilingType] [nvarchar](50) NOT NULL,
	[TypeOfPartition] [nvarchar](50) NOT NULL,
	[CeilingArea] [decimal](7, 2) NOT NULL,
	[CeilingSampleName] [nvarchar](50) NULL,
	[CeilingSampleCode] [nvarchar](50) NULL,
	[CeilingSampleBrand] [nvarchar](50) NULL,
	[CeilingSampleHight] [decimal](7, 2) NULL,
	[CeilingSampleWidth] [decimal](7, 2) NULL,
	[CeilingMililiters] [decimal](7, 2) NULL,
	[CeilingSamplePrice] [decimal](7, 2) NULL,
	[CeilingSampleMinAmount] [decimal](15, 2) NULL,
	[CeilingSampleTotalCost] [decimal](15, 2) NULL,
	[SampleImagePath] [nvarchar](max) NULL,
 CONSTRAINT [PK_StoredCeiling_1] PRIMARY KEY CLUSTERED 
(
	[CeilingId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[StoredFlooring]    Script Date: 07/01/2021 16:51:08 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[StoredFlooring](
	[FlooringId] [int] IDENTITY(1,1) NOT NULL,
	[HouseRefId] [int] NOT NULL,
	[StoredTypeOfFlooringRefId] [int] NULL,
	[StoredTypeOfFlooringSampleRefId] [int] NULL,
	[FlooringName] [nvarchar](50) NOT NULL,
	[FlooringCategory] [nvarchar](50) NOT NULL,
	[FlooringType] [nvarchar](50) NOT NULL,
	[TypeOfPartition] [nvarchar](50) NOT NULL,
	[FlooringArea] [decimal](7, 2) NOT NULL,
	[FlooringSampleName] [nvarchar](50) NULL,
	[FlooringSampleCode] [nvarchar](50) NULL,
	[FlooringSampleBrand] [nvarchar](50) NULL,
	[FlooringSampleHight] [decimal](7, 2) NULL,
	[FlooringSampleWidth] [decimal](7, 2) NULL,
	[FlooringMililiters] [decimal](7, 2) NULL,
	[FlooringSamplePrice] [decimal](7, 2) NULL,
	[FlooringSampleMinAmount] [decimal](15, 2) NULL,
	[FlooringSampleTotalCost] [decimal](15, 2) NULL,
	[SampleImagePath] [nvarchar](max) NULL,
 CONSTRAINT [PK_StoredFlooring] PRIMARY KEY CLUSTERED 
(
	[FlooringId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[StoredPlan]    Script Date: 07/01/2021 16:51:08 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[StoredPlan](
	[StoredPlanId] [int] IDENTITY(1,1) NOT NULL,
	[StoredPlanRefId] [int] NULL,
	[HouseRefId] [int] NULL,
	[TypeOfPlan] [nvarchar](50) NULL,
	[PlanName] [nvarchar](50) NULL,
	[Scale] [nvarchar](50) NULL,
	[DrawnBy] [nvarchar](max) NULL,
	[AdditionalInformation] [nvarchar](max) NULL,
	[StoredPlanImagePath] [nvarchar](max) NULL,
 CONSTRAINT [PK_StoredPlan] PRIMARY KEY CLUSTERED 
(
	[StoredPlanId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[StoredWalling]    Script Date: 07/01/2021 16:51:08 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[StoredWalling](
	[WallingId] [int] IDENTITY(1,1) NOT NULL,
	[HouseRefId] [int] NULL,
	[StoredTypeOfWallingRefId] [int] NULL,
	[StoredTypeOfWallingSampleRefId] [int] NULL,
	[WallingName] [nvarchar](50) NOT NULL,
	[WallingCategory] [nvarchar](50) NOT NULL,
	[WallingType] [nvarchar](50) NOT NULL,
	[TypeOfPartition] [nvarchar](50) NOT NULL,
	[WallingArea] [decimal](7, 2) NOT NULL,
	[WallingSampleName] [nvarchar](50) NULL,
	[WallingSampleCode] [nvarchar](50) NULL,
	[WallingSampleBrand] [nvarchar](50) NULL,
	[WallingSampleHight] [decimal](7, 2) NULL,
	[WallingSampleWidth] [decimal](7, 2) NULL,
	[WallingMililiters] [decimal](7, 2) NULL,
	[WallingSamplePrice] [decimal](7, 2) NULL,
	[WallingSampleMinAmount] [decimal](15, 2) NULL,
	[WallingSampleTotalCost] [decimal](15, 2) NULL,
	[SampleImagePath] [nvarchar](max) NULL,
 CONSTRAINT [PK_StoredWalling] PRIMARY KEY CLUSTERED 
(
	[WallingId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TypeOfCeiling]    Script Date: 07/01/2021 16:51:08 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TypeOfCeiling](
	[CeilingTypeId] [int] IDENTITY(1,1) NOT NULL,
	[CeilingTypeCategory] [nvarchar](50) NOT NULL,
	[CeilingType] [nvarchar](50) NULL,
	[CeilingTypeDetails] [nvarchar](max) NULL,
	[CeilingTypeDeletion] [int] NULL,
	[CeilingTypeAdvantage] [nvarchar](max) NULL,
	[CeilingTypeDisadvantage] [nvarchar](max) NULL,
	[CeilingTypeBestUse] [nvarchar](max) NULL,
	[CeilingTypeReinstall] [nvarchar](max) NULL,
	[CeilingTypeImage] [nvarchar](max) NULL,
 CONSTRAINT [PK_TypeOfCeiling] PRIMARY KEY CLUSTERED 
(
	[CeilingTypeId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TypeOfCeilingSample]    Script Date: 07/01/2021 16:51:08 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TypeOfCeilingSample](
	[CeilingTypeSampleId] [int] IDENTITY(1,1) NOT NULL,
	[TypeOfCeilingRefId] [int] NOT NULL,
	[ShopRefId] [int] NULL,
	[CeilingTypeSampleCode] [nvarchar](50) NULL,
	[CeilingTypeSampleName] [nvarchar](50) NOT NULL,
	[CeilingTypeSampleSizeHeight] [int] NOT NULL,
	[CeilingTypeSampleSizeWidth] [int] NOT NULL,
	[CeilingTypeSamplePrice] [decimal](10, 2) NULL,
	[CeilingTypeSampleImagePath] [nvarchar](max) NULL,
 CONSTRAINT [PK_TypeOfCeilingSample] PRIMARY KEY CLUSTERED 
(
	[CeilingTypeSampleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TypeOfFlooring]    Script Date: 07/01/2021 16:51:08 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TypeOfFlooring](
	[FlooringTypeId] [int] IDENTITY(1,1) NOT NULL,
	[FlooringTypeCategory] [nvarchar](100) NOT NULL,
	[FlooringType] [nvarchar](100) NULL,
	[FlooringTypeDetails] [nvarchar](max) NULL,
	[FlooringTypeDeletion] [int] NULL,
	[FlooringTypeAdvantage] [nvarchar](max) NULL,
	[FlooringTypeDisadvantage] [nvarchar](max) NULL,
	[FlooringTypeBestUse] [nvarchar](max) NULL,
	[FlooringTypeReinstall] [nvarchar](max) NULL,
	[FlooringTypeImage] [nvarchar](max) NULL,
 CONSTRAINT [PK_TypeOfFlooring] PRIMARY KEY CLUSTERED 
(
	[FlooringTypeId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TypeOfFlooringSample]    Script Date: 07/01/2021 16:51:08 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TypeOfFlooringSample](
	[FlooringTypeSampleId] [int] IDENTITY(1,1) NOT NULL,
	[TypeOfFlooringRefId] [int] NOT NULL,
	[ShopRefId] [int] NULL,
	[FlooringTypeSampleCode] [nvarchar](50) NULL,
	[FlooringTypeSampleName] [nvarchar](50) NOT NULL,
	[FlooringTypeSampleSizeHeight] [int] NOT NULL,
	[FlooringTypeSampleSizeWidth] [int] NOT NULL,
	[FlooringTypeSamplePrice] [decimal](10, 2) NULL,
	[FlooringTypeSampleImagePath] [nvarchar](max) NULL,
 CONSTRAINT [PK_TypeOfFlooringSample] PRIMARY KEY CLUSTERED 
(
	[FlooringTypeSampleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TypeOfWalling]    Script Date: 07/01/2021 16:51:08 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TypeOfWalling](
	[WallingTypeId] [int] IDENTITY(1,1) NOT NULL,
	[WallingTypeCategory] [nvarchar](100) NOT NULL,
	[WallingType] [nvarchar](100) NULL,
	[WallingTypeDetails] [nvarchar](max) NULL,
	[WallingTypeDeletion] [int] NULL,
	[WallingTypeAdvantage] [nvarchar](max) NULL,
	[WallingTypeDisadvantage] [nvarchar](max) NULL,
	[WallingTypeBestUse] [nvarchar](max) NULL,
	[WallingTypeReinstall] [nvarchar](max) NULL,
	[WallingTypeImage] [nvarchar](max) NULL,
 CONSTRAINT [PK_TypeOfWalling] PRIMARY KEY CLUSTERED 
(
	[WallingTypeId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TypeOfWallingSample]    Script Date: 07/01/2021 16:51:08 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TypeOfWallingSample](
	[WallingTypeSampleId] [int] IDENTITY(1,1) NOT NULL,
	[TypeOfWallingRefId] [int] NOT NULL,
	[ShopRefId] [int] NULL,
	[WallingTypeSampleCode] [nvarchar](50) NULL,
	[WallingTypeSampleName] [nvarchar](50) NULL,
	[WallingTypeBrand] [nvarchar](50) NULL,
	[WallingTypeSampleSizeHeight] [int] NULL,
	[WallingTypeSampleSizeWidth] [int] NULL,
	[WallingMilliliters] [int] NULL,
	[WallingTypeSamplePrice] [decimal](10, 2) NULL,
	[WallingTypeSampleImagePath] [nvarchar](max) NULL,
 CONSTRAINT [PK_TypeOfWallingSample] PRIMARY KEY CLUSTERED 
(
	[WallingTypeSampleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[UserRegistration]    Script Date: 07/01/2021 16:51:08 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UserRegistration](
	[UserId] [int] IDENTITY(1,1) NOT NULL,
	[UserName] [nvarchar](10) NOT NULL,
	[UserMail] [nvarchar](30) NOT NULL,
	[UserAge] [int] NOT NULL,
	[UserPassword] [nvarchar](100) NOT NULL,
	[UserAddress] [nvarchar](max) NULL,
	[UserPhoneNumber] [nvarchar](10) NULL,
	[UserType] [int] NOT NULL,
 CONSTRAINT [PK_UserRegistration] PRIMARY KEY CLUSTERED 
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
ALTER TABLE [dbo].[Comment]  WITH CHECK ADD  CONSTRAINT [FK_UserRefIdFK_UserIdPK3] FOREIGN KEY([UserRefId])
REFERENCES [dbo].[UserRegistration] ([UserId])
GO
ALTER TABLE [dbo].[Comment] CHECK CONSTRAINT [FK_UserRefIdFK_UserIdPK3]
GO
ALTER TABLE [dbo].[HouseDetails]  WITH CHECK ADD  CONSTRAINT [FK_UserRefIdFK_UserIdPK] FOREIGN KEY([UserRefId])
REFERENCES [dbo].[UserRegistration] ([UserId])
GO
ALTER TABLE [dbo].[HouseDetails] CHECK CONSTRAINT [FK_UserRefIdFK_UserIdPK]
GO
ALTER TABLE [dbo].[Reply]  WITH CHECK ADD  CONSTRAINT [FK_CommentRefIdFK_CommentIdPK] FOREIGN KEY([CommentRefId])
REFERENCES [dbo].[Comment] ([CommentId])
GO
ALTER TABLE [dbo].[Reply] CHECK CONSTRAINT [FK_CommentRefIdFK_CommentIdPK]
GO
ALTER TABLE [dbo].[Reply]  WITH CHECK ADD  CONSTRAINT [FK_UserRefIdFK_UserIdPK2] FOREIGN KEY([UserRefId])
REFERENCES [dbo].[UserRegistration] ([UserId])
GO
ALTER TABLE [dbo].[Reply] CHECK CONSTRAINT [FK_UserRefIdFK_UserIdPK2]
GO
ALTER TABLE [dbo].[StoredCeiling]  WITH CHECK ADD  CONSTRAINT [FK_StoredCeilingFK_HouseDetailsPK] FOREIGN KEY([HouseRefId])
REFERENCES [dbo].[HouseDetails] ([HouseId])
GO
ALTER TABLE [dbo].[StoredCeiling] CHECK CONSTRAINT [FK_StoredCeilingFK_HouseDetailsPK]
GO
ALTER TABLE [dbo].[StoredFlooring]  WITH CHECK ADD  CONSTRAINT [FK_HouseRefIdFK_HouseDetailsPK] FOREIGN KEY([HouseRefId])
REFERENCES [dbo].[HouseDetails] ([HouseId])
GO
ALTER TABLE [dbo].[StoredFlooring] CHECK CONSTRAINT [FK_HouseRefIdFK_HouseDetailsPK]
GO
ALTER TABLE [dbo].[StoredPlan]  WITH NOCHECK ADD  CONSTRAINT [FK_HouseRefIdFK_HouseIdPK] FOREIGN KEY([HouseRefId])
REFERENCES [dbo].[HouseDetails] ([HouseId])
GO
ALTER TABLE [dbo].[StoredPlan] CHECK CONSTRAINT [FK_HouseRefIdFK_HouseIdPK]
GO
ALTER TABLE [dbo].[StoredPlan]  WITH CHECK ADD  CONSTRAINT [FK_StoredPlanRefIdFK_PlanIdPK] FOREIGN KEY([StoredPlanRefId])
REFERENCES [dbo].[Plan] ([PlanId])
GO
ALTER TABLE [dbo].[StoredPlan] CHECK CONSTRAINT [FK_StoredPlanRefIdFK_PlanIdPK]
GO
ALTER TABLE [dbo].[StoredWalling]  WITH CHECK ADD  CONSTRAINT [FK_StoredWallingFK_HouseDetailsPK] FOREIGN KEY([HouseRefId])
REFERENCES [dbo].[HouseDetails] ([HouseId])
GO
ALTER TABLE [dbo].[StoredWalling] CHECK CONSTRAINT [FK_StoredWallingFK_HouseDetailsPK]
GO
ALTER TABLE [dbo].[TypeOfCeilingSample]  WITH CHECK ADD  CONSTRAINT [FK_TypeOfCeilingSampleFK_TypeOfCeilingPK] FOREIGN KEY([TypeOfCeilingRefId])
REFERENCES [dbo].[TypeOfCeiling] ([CeilingTypeId])
GO
ALTER TABLE [dbo].[TypeOfCeilingSample] CHECK CONSTRAINT [FK_TypeOfCeilingSampleFK_TypeOfCeilingPK]
GO
ALTER TABLE [dbo].[TypeOfFlooringSample]  WITH CHECK ADD  CONSTRAINT [FK_TypeOfFlooringSampleFK_TypeOfFlooringPK] FOREIGN KEY([TypeOfFlooringRefId])
REFERENCES [dbo].[TypeOfFlooring] ([FlooringTypeId])
GO
ALTER TABLE [dbo].[TypeOfFlooringSample] CHECK CONSTRAINT [FK_TypeOfFlooringSampleFK_TypeOfFlooringPK]
GO
ALTER TABLE [dbo].[TypeOfWallingSample]  WITH CHECK ADD  CONSTRAINT [FK_TypeOfWallingSampleFK_TypeOfWallingPK] FOREIGN KEY([TypeOfWallingRefId])
REFERENCES [dbo].[TypeOfWalling] ([WallingTypeId])
GO
ALTER TABLE [dbo].[TypeOfWallingSample] CHECK CONSTRAINT [FK_TypeOfWallingSampleFK_TypeOfWallingPK]
GO
USE [master]
GO
ALTER DATABASE [StrongHouseDB] SET  READ_WRITE 
GO
