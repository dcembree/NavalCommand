USE [master]
GO

/****** Object:  Database [NavalCommandDb]    Script Date: 05/19/2017 00:45:04 ******/
CREATE DATABASE [NavalCommandDb] ON  PRIMARY 
( NAME = N'NavalCommandDb', FILENAME = N'c:\Program Files\Microsoft SQL Server\MSSQL10_50.SQLEXPRESS\MSSQL\DATA\NavalCommandDb.mdf' , SIZE = 2048KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'NavalCommandDb_log', FILENAME = N'c:\Program Files\Microsoft SQL Server\MSSQL10_50.SQLEXPRESS\MSSQL\DATA\NavalCommandDb_log.ldf' , SIZE = 1024KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO

ALTER DATABASE [NavalCommandDb] SET COMPATIBILITY_LEVEL = 100
GO

IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [NavalCommandDb].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO

ALTER DATABASE [NavalCommandDb] SET ANSI_NULL_DEFAULT OFF 
GO

ALTER DATABASE [NavalCommandDb] SET ANSI_NULLS OFF 
GO

ALTER DATABASE [NavalCommandDb] SET ANSI_PADDING OFF 
GO

ALTER DATABASE [NavalCommandDb] SET ANSI_WARNINGS OFF 
GO

ALTER DATABASE [NavalCommandDb] SET ARITHABORT OFF 
GO

ALTER DATABASE [NavalCommandDb] SET AUTO_CLOSE OFF 
GO

ALTER DATABASE [NavalCommandDb] SET AUTO_CREATE_STATISTICS ON 
GO

ALTER DATABASE [NavalCommandDb] SET AUTO_SHRINK OFF 
GO

ALTER DATABASE [NavalCommandDb] SET AUTO_UPDATE_STATISTICS ON 
GO

ALTER DATABASE [NavalCommandDb] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO

ALTER DATABASE [NavalCommandDb] SET CURSOR_DEFAULT  GLOBAL 
GO

ALTER DATABASE [NavalCommandDb] SET CONCAT_NULL_YIELDS_NULL OFF 
GO

ALTER DATABASE [NavalCommandDb] SET NUMERIC_ROUNDABORT OFF 
GO

ALTER DATABASE [NavalCommandDb] SET QUOTED_IDENTIFIER OFF 
GO

ALTER DATABASE [NavalCommandDb] SET RECURSIVE_TRIGGERS OFF 
GO

ALTER DATABASE [NavalCommandDb] SET  DISABLE_BROKER 
GO

ALTER DATABASE [NavalCommandDb] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO

ALTER DATABASE [NavalCommandDb] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO

ALTER DATABASE [NavalCommandDb] SET TRUSTWORTHY OFF 
GO

ALTER DATABASE [NavalCommandDb] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO

ALTER DATABASE [NavalCommandDb] SET PARAMETERIZATION SIMPLE 
GO

ALTER DATABASE [NavalCommandDb] SET READ_COMMITTED_SNAPSHOT OFF 
GO

ALTER DATABASE [NavalCommandDb] SET HONOR_BROKER_PRIORITY OFF 
GO

ALTER DATABASE [NavalCommandDb] SET  READ_WRITE 
GO

ALTER DATABASE [NavalCommandDb] SET RECOVERY SIMPLE 
GO

ALTER DATABASE [NavalCommandDb] SET  MULTI_USER 
GO

ALTER DATABASE [NavalCommandDb] SET PAGE_VERIFY CHECKSUM  
GO

ALTER DATABASE [NavalCommandDb] SET DB_CHAINING OFF 
GO


USE [NavalCommandDb]
GO
/****** Object:  Table [dbo].[Vessels]    Script Date: 05/20/2017 01:27:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Vessels](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[VesselClass] [nvarchar](50) NULL,
	[HomePort] [nvarchar](50) NULL,
	[CommissionDate] [datetime] NOT NULL,
	[DecommissionDate] [datetime] NULL,
	[HullConfiguration] [nvarchar](50) NULL,
	[HullStatus] [nvarchar](50) NULL,
	[DamageReport] [varchar](max) NULL,
	[DeploymentStatus] [nvarchar](50) NULL,
	[CrewComplement] [int] NOT NULL,
	[CurrentLongitude] [float] NOT NULL,
	[CurrentLatitude] [float] NOT NULL,
	[CurrentHeading] [float] NOT NULL,
	[CurrentSpeed] [float] NOT NULL,
	[CurrentDepth] [float] NOT NULL,
	[CurrentOrders] [nvarchar](50) NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO

INSERT [dbo].[Vessels] ([Name], [VesselClass], [HomePort], [CommissionDate], [DecommissionDate], [HullConfiguration], [HullStatus], [DamageReport], [DeploymentStatus], [CrewComplement], [CurrentLongitude], [CurrentLatitude], [CurrentHeading], [CurrentSpeed], [CurrentDepth], [CurrentOrders]) VALUES (N'Enterprise', N'Carrier', N'New York', CAST(0x00007A4600000000 AS DateTime), NULL, N'Version 3.2', N'Intact', N'', N'Deployed', 432, 40.65421, -72.21654, 56.615, 11.5654, 0, N'Patrol eastern seaboard')
INSERT [dbo].[Vessels] ([Name], [VesselClass], [HomePort], [CommissionDate], [DecommissionDate], [HullConfiguration], [HullStatus], [DamageReport], [DeploymentStatus], [CrewComplement], [CurrentLongitude], [CurrentLatitude], [CurrentHeading], [CurrentSpeed], [CurrentDepth], [CurrentOrders]) VALUES (N'Intrepid', N'Destroyer', N'Groton', CAST(0x000086A400000000 AS DateTime), NULL, N'Version 4.2', N'Intact', NULL, N'Deployed', 64, 35.034881, -72.032434, 32.12341, 24.245, 0, N'Return to base.')
INSERT [dbo].[Vessels] ([Name], [VesselClass], [HomePort], [CommissionDate], [DecommissionDate], [HullConfiguration], [HullStatus], [DamageReport], [DeploymentStatus], [CrewComplement], [CurrentLongitude], [CurrentLatitude], [CurrentHeading], [CurrentSpeed], [CurrentDepth], [CurrentOrders]) VALUES (N'Defiant', N'Cruiser', N'Los Angelos', CAST(0x00008BF500000000 AS DateTime), NULL, N'Version 2.4', N'Intact', NULL, N'Deployed', 165, 32.164684, -119.1685462, 245.5154, 18.5496, 0, N'Patrol western seaboard')
