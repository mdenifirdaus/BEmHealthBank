USE [master]
GO
/****** Object:  Database [UserDB]    Script Date: 03/05/2023 10:31:06 ******/
CREATE DATABASE [UserDB]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'UserDB', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL11.MSSQLSERVER\MSSQL\DATA\UserDB.mdf' , SIZE = 3072KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'UserDB_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL11.MSSQLSERVER\MSSQL\DATA\UserDB_log.ldf' , SIZE = 1024KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [UserDB] SET COMPATIBILITY_LEVEL = 110
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [UserDB].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [UserDB] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [UserDB] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [UserDB] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [UserDB] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [UserDB] SET ARITHABORT OFF 
GO
ALTER DATABASE [UserDB] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [UserDB] SET AUTO_CREATE_STATISTICS ON 
GO
ALTER DATABASE [UserDB] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [UserDB] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [UserDB] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [UserDB] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [UserDB] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [UserDB] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [UserDB] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [UserDB] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [UserDB] SET  DISABLE_BROKER 
GO
ALTER DATABASE [UserDB] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [UserDB] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [UserDB] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [UserDB] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [UserDB] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [UserDB] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [UserDB] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [UserDB] SET RECOVERY FULL 
GO
ALTER DATABASE [UserDB] SET  MULTI_USER 
GO
ALTER DATABASE [UserDB] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [UserDB] SET DB_CHAINING OFF 
GO
ALTER DATABASE [UserDB] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [UserDB] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
EXEC sys.sp_db_vardecimal_storage_format N'UserDB', N'ON'
GO
USE [UserDB]
GO
/****** Object:  Table [dbo].[Tbl_User]    Script Date: 03/05/2023 10:31:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Tbl_User](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[FullName] [varchar](50) NULL,
	[AddressName] [varchar](150) NULL,
	[BirthDate] [date] NULL,
	[Gender] [varchar](15) NULL,
	[ImageProfile] [varchar](50) NULL,
 CONSTRAINT [PK_Tbl_User] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Tbl_UserCredential]    Script Date: 03/05/2023 10:31:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Tbl_UserCredential](
	[UserName] [varchar](50) NULL,
	[UserPassword] [varchar](20) NULL,
	[UserEmail] [varchar](50) NULL,
	[UserPhone] [varchar](15) NULL,
	[ID] [int] IDENTITY(1,1) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
SET IDENTITY_INSERT [dbo].[Tbl_User] ON 

INSERT [dbo].[Tbl_User] ([ID], [FullName], [AddressName], [BirthDate], [Gender], [ImageProfile]) VALUES (1, N'M Deni Firdaus', N'Jakarta', CAST(0x191C0B00 AS Date), N'Laki-laki', NULL)
INSERT [dbo].[Tbl_User] ([ID], [FullName], [AddressName], [BirthDate], [Gender], [ImageProfile]) VALUES (2, N'Intan', N'SBY', CAST(0x3D160B00 AS Date), N'Perempuan', N'-')
INSERT [dbo].[Tbl_User] ([ID], [FullName], [AddressName], [BirthDate], [Gender], [ImageProfile]) VALUES (3, N'Ilyas', N'Jakarta', CAST(0x3D160B00 AS Date), N'Laki-laki', N'skenario1.jpg')
INSERT [dbo].[Tbl_User] ([ID], [FullName], [AddressName], [BirthDate], [Gender], [ImageProfile]) VALUES (4, N'Ilyasa', N'Jakarta', CAST(0x3D160B00 AS Date), N'Laki-laki', N'skenario1.jpg')
SET IDENTITY_INSERT [dbo].[Tbl_User] OFF
SET IDENTITY_INSERT [dbo].[Tbl_UserCredential] ON 

INSERT [dbo].[Tbl_UserCredential] ([UserName], [UserPassword], [UserEmail], [UserPhone], [ID]) VALUES (N'M Deni Firdaus', N'MDF123', N'mdeni.firdaus@yahoo.co.id', N'08973337107', 1)
INSERT [dbo].[Tbl_UserCredential] ([UserName], [UserPassword], [UserEmail], [UserPhone], [ID]) VALUES (N'Mr Dummy', N'Dum123', N'dummy@yahoo.com', N'08954537373', 2)
INSERT [dbo].[Tbl_UserCredential] ([UserName], [UserPassword], [UserEmail], [UserPhone], [ID]) VALUES (N'John', N'John123', N'john@yahoo.co.id', N'08964752734', 3)
SET IDENTITY_INSERT [dbo].[Tbl_UserCredential] OFF
USE [master]
GO
ALTER DATABASE [UserDB] SET  READ_WRITE 
GO
