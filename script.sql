USE [master]
GO
/****** Object:  Database [app-database]    Script Date: 18/06/2022 11:37:10 pm ******/
CREATE DATABASE [app-database]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'app-database', FILENAME = N'C:\app-database.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'app-database_log', FILENAME = N'C:\app-database_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO
ALTER DATABASE [app-database] SET COMPATIBILITY_LEVEL = 130
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [app-database].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [app-database] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [app-database] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [app-database] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [app-database] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [app-database] SET ARITHABORT OFF 
GO
ALTER DATABASE [app-database] SET AUTO_CLOSE ON 
GO
ALTER DATABASE [app-database] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [app-database] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [app-database] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [app-database] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [app-database] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [app-database] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [app-database] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [app-database] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [app-database] SET  ENABLE_BROKER 
GO
ALTER DATABASE [app-database] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [app-database] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [app-database] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [app-database] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [app-database] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [app-database] SET READ_COMMITTED_SNAPSHOT ON 
GO
ALTER DATABASE [app-database] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [app-database] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [app-database] SET  MULTI_USER 
GO
ALTER DATABASE [app-database] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [app-database] SET DB_CHAINING OFF 
GO
ALTER DATABASE [app-database] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [app-database] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [app-database] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [app-database] SET QUERY_STORE = OFF
GO
USE [app-database]
GO
ALTER DATABASE SCOPED CONFIGURATION SET LEGACY_CARDINALITY_ESTIMATION = OFF;
GO
ALTER DATABASE SCOPED CONFIGURATION SET MAXDOP = 0;
GO
ALTER DATABASE SCOPED CONFIGURATION SET PARAMETER_SNIFFING = ON;
GO
ALTER DATABASE SCOPED CONFIGURATION SET QUERY_OPTIMIZER_HOTFIXES = OFF;
GO
USE [app-database]
GO
/****** Object:  Table [dbo].[__EFMigrationsHistory]    Script Date: 18/06/2022 11:37:10 pm ******/
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
/****** Object:  Table [dbo].[AspNetRoleClaims]    Script Date: 18/06/2022 11:37:10 pm ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetRoleClaims](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[RoleId] [nvarchar](450) NOT NULL,
	[ClaimType] [nvarchar](max) NULL,
	[ClaimValue] [nvarchar](max) NULL,
 CONSTRAINT [PK_AspNetRoleClaims] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetRoles]    Script Date: 18/06/2022 11:37:10 pm ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetRoles](
	[Id] [nvarchar](450) NOT NULL,
	[Name] [nvarchar](256) NULL,
	[NormalizedName] [nvarchar](256) NULL,
	[ConcurrencyStamp] [nvarchar](max) NULL,
 CONSTRAINT [PK_AspNetRoles] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetUserClaims]    Script Date: 18/06/2022 11:37:10 pm ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUserClaims](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[UserId] [nvarchar](450) NOT NULL,
	[ClaimType] [nvarchar](max) NULL,
	[ClaimValue] [nvarchar](max) NULL,
 CONSTRAINT [PK_AspNetUserClaims] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetUserLogins]    Script Date: 18/06/2022 11:37:10 pm ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUserLogins](
	[LoginProvider] [nvarchar](450) NOT NULL,
	[ProviderKey] [nvarchar](450) NOT NULL,
	[ProviderDisplayName] [nvarchar](max) NULL,
	[UserId] [nvarchar](450) NOT NULL,
 CONSTRAINT [PK_AspNetUserLogins] PRIMARY KEY CLUSTERED 
(
	[LoginProvider] ASC,
	[ProviderKey] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetUserRoles]    Script Date: 18/06/2022 11:37:10 pm ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUserRoles](
	[UserId] [nvarchar](450) NOT NULL,
	[RoleId] [nvarchar](450) NOT NULL,
 CONSTRAINT [PK_AspNetUserRoles] PRIMARY KEY CLUSTERED 
(
	[UserId] ASC,
	[RoleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetUsers]    Script Date: 18/06/2022 11:37:10 pm ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUsers](
	[Id] [nvarchar](450) NOT NULL,
	[UserName] [nvarchar](256) NULL,
	[NormalizedUserName] [nvarchar](256) NULL,
	[Email] [nvarchar](256) NULL,
	[NormalizedEmail] [nvarchar](256) NULL,
	[EmailConfirmed] [bit] NOT NULL,
	[PasswordHash] [nvarchar](max) NULL,
	[SecurityStamp] [nvarchar](max) NULL,
	[ConcurrencyStamp] [nvarchar](max) NULL,
	[PhoneNumber] [nvarchar](max) NULL,
	[PhoneNumberConfirmed] [bit] NOT NULL,
	[TwoFactorEnabled] [bit] NOT NULL,
	[LockoutEnd] [datetimeoffset](7) NULL,
	[LockoutEnabled] [bit] NOT NULL,
	[AccessFailedCount] [int] NOT NULL,
 CONSTRAINT [PK_AspNetUsers] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetUserTokens]    Script Date: 18/06/2022 11:37:10 pm ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUserTokens](
	[UserId] [nvarchar](450) NOT NULL,
	[LoginProvider] [nvarchar](450) NOT NULL,
	[Name] [nvarchar](450) NOT NULL,
	[Value] [nvarchar](max) NULL,
 CONSTRAINT [PK_AspNetUserTokens] PRIMARY KEY CLUSTERED 
(
	[UserId] ASC,
	[LoginProvider] ASC,
	[Name] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Comment]    Script Date: 18/06/2022 11:37:10 pm ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Comment](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Value] [nvarchar](max) NULL,
	[CreatedOn] [datetime2](7) NULL,
	[UpdatedOn] [datetime2](7) NULL,
	[MovieId] [int] NOT NULL,
	[CreatedBy] [nvarchar](max) NULL,
	[UpdatedBy] [nvarchar](max) NULL,
 CONSTRAINT [PK_Comment] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20220407221840_InitializeData', N'6.0.3')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20220407222347_UpdateData', N'6.0.3')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20220408073445_UpdateData2', N'6.0.3')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20220408073550_UpdateData2', N'6.0.3')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20220408205255_Authentication', N'6.0.3')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20220423125326_UpdatedCommentModel', N'6.0.3')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20220423160214_UpdatedCommentModel1', N'6.0.3')
INSERT [dbo].[AspNetUsers] ([Id], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [EmailConfirmed], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount]) VALUES (N'452505a5-980f-43aa-9529-8bd47a5cda43', N'testuser', N'TESTUSER', N'test@tmdbapi.com', N'TEST@TMDBAPI.COM', 0, N'AQAAAAEAACcQAAAAEJkA1P6eB+HwkOAbylDvlGasi/BW/m2R/QHjqKkPWafWoVhJxrhOFOFpztzLnm1G1Q==', N'5QF27QMGDV35MLNUUP3G4V6N7AR5T5FM', N'931304e9-eba3-4914-8b79-fb0cf3e3d4d1', NULL, 0, 0, NULL, 1, 0)
INSERT [dbo].[AspNetUsers] ([Id], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [EmailConfirmed], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount]) VALUES (N'd8208615-893c-494c-9dc8-15ee80782a35', N'TestUser2', N'TESTUSER2', N'testuser2@example.com', N'TESTUSER2@EXAMPLE.COM', 0, N'AQAAAAEAACcQAAAAEFAvhibY8oPFRbTNduWr56LKh1IhLRnf/o2PzfC9bubkpf/+2ixo1tI75epC09X3DQ==', N'A4GHB3NVHLWYVS7JRJU6EVJVR5QSYBYK', N'd0d042b5-aec4-4e1a-a889-fda29720dea7', NULL, 0, 0, NULL, 1, 0)
SET IDENTITY_INSERT [dbo].[Comment] ON 

INSERT [dbo].[Comment] ([Id], [Value], [CreatedOn], [UpdatedOn], [MovieId], [CreatedBy], [UpdatedBy]) VALUES (89, N'fsd sdfsd dfds', CAST(N'2022-04-30T16:02:23.2899981' AS DateTime2), CAST(N'2022-04-30T16:01:22.9530000' AS DateTime2), 881, N'testuser', N'testuser')
INSERT [dbo].[Comment] ([Id], [Value], [CreatedOn], [UpdatedOn], [MovieId], [CreatedBy], [UpdatedBy]) VALUES (187, N'dfsf', CAST(N'2022-05-04T10:45:25.0410987' AS DateTime2), CAST(N'2022-05-04T10:43:34.2340000' AS DateTime2), 730154, N'testuser', N'testuser')
INSERT [dbo].[Comment] ([Id], [Value], [CreatedOn], [UpdatedOn], [MovieId], [CreatedBy], [UpdatedBy]) VALUES (188, N'sdfds', CAST(N'2022-05-04T10:45:27.9667203' AS DateTime2), CAST(N'2022-05-04T10:43:34.2340000' AS DateTime2), 730154, N'testuser', N'testuser')
INSERT [dbo].[Comment] ([Id], [Value], [CreatedOn], [UpdatedOn], [MovieId], [CreatedBy], [UpdatedBy]) VALUES (190, N'sdf', CAST(N'2022-05-04T10:49:23.0904213' AS DateTime2), CAST(N'2022-05-04T10:48:57.5830000' AS DateTime2), 730154, N'testuser', N'testuser')
INSERT [dbo].[Comment] ([Id], [Value], [CreatedOn], [UpdatedOn], [MovieId], [CreatedBy], [UpdatedBy]) VALUES (191, NULL, CAST(N'2022-05-04T10:49:24.9215581' AS DateTime2), CAST(N'2022-05-04T10:48:57.5830000' AS DateTime2), 730154, N'testuser', N'testuser')
INSERT [dbo].[Comment] ([Id], [Value], [CreatedOn], [UpdatedOn], [MovieId], [CreatedBy], [UpdatedBy]) VALUES (192, NULL, CAST(N'2022-05-04T10:49:26.2327690' AS DateTime2), CAST(N'2022-05-04T10:48:57.5830000' AS DateTime2), 730154, N'testuser', N'testuser')
INSERT [dbo].[Comment] ([Id], [Value], [CreatedOn], [UpdatedOn], [MovieId], [CreatedBy], [UpdatedBy]) VALUES (193, N'', CAST(N'2022-05-04T10:49:41.3169576' AS DateTime2), CAST(N'2022-05-04T10:49:38.4250000' AS DateTime2), 730154, N'testuser', N'testuser')
INSERT [dbo].[Comment] ([Id], [Value], [CreatedOn], [UpdatedOn], [MovieId], [CreatedBy], [UpdatedBy]) VALUES (194, NULL, CAST(N'2022-05-04T10:49:42.0388215' AS DateTime2), CAST(N'2022-05-04T10:49:38.4250000' AS DateTime2), 730154, N'testuser', N'testuser')
INSERT [dbo].[Comment] ([Id], [Value], [CreatedOn], [UpdatedOn], [MovieId], [CreatedBy], [UpdatedBy]) VALUES (195, NULL, CAST(N'2022-05-04T10:49:43.4654278' AS DateTime2), CAST(N'2022-05-04T10:49:38.4250000' AS DateTime2), 730154, N'testuser', N'testuser')
INSERT [dbo].[Comment] ([Id], [Value], [CreatedOn], [UpdatedOn], [MovieId], [CreatedBy], [UpdatedBy]) VALUES (1197, N'dsfdsfd', CAST(N'2022-05-10T01:11:43.8338062' AS DateTime2), CAST(N'2022-05-10T01:11:43.8338104' AS DateTime2), 939243, N'testuser', N'testuser')
INSERT [dbo].[Comment] ([Id], [Value], [CreatedOn], [UpdatedOn], [MovieId], [CreatedBy], [UpdatedBy]) VALUES (1214, N'dfsdf', CAST(N'2022-05-12T22:05:11.0127197' AS DateTime2), CAST(N'2022-05-12T22:05:11.0127202' AS DateTime2), 497, N'TestUser2', N'TestUser2')
INSERT [dbo].[Comment] ([Id], [Value], [CreatedOn], [UpdatedOn], [MovieId], [CreatedBy], [UpdatedBy]) VALUES (1216, N'cxcxv', CAST(N'2022-05-13T00:12:47.1485916' AS DateTime2), CAST(N'2022-05-13T00:12:47.1485938' AS DateTime2), 389, N'TestUser2', N'TestUser2')
INSERT [dbo].[Comment] ([Id], [Value], [CreatedOn], [UpdatedOn], [MovieId], [CreatedBy], [UpdatedBy]) VALUES (1217, N'sdfds', CAST(N'2022-05-13T00:13:05.6023911' AS DateTime2), CAST(N'2022-05-13T00:13:05.6023933' AS DateTime2), 389, N'TestUser2', N'TestUser2')
INSERT [dbo].[Comment] ([Id], [Value], [CreatedOn], [UpdatedOn], [MovieId], [CreatedBy], [UpdatedBy]) VALUES (1218, N'sdfdsffd', CAST(N'2022-05-13T00:14:40.1922795' AS DateTime2), CAST(N'2022-05-13T00:14:40.1922811' AS DateTime2), 389, N'TestUser2', N'TestUser2')
INSERT [dbo].[Comment] ([Id], [Value], [CreatedOn], [UpdatedOn], [MovieId], [CreatedBy], [UpdatedBy]) VALUES (1219, N'sdffds', CAST(N'2022-05-13T00:15:39.6177360' AS DateTime2), CAST(N'2022-05-13T00:15:39.6177373' AS DateTime2), 389, N'TestUser2', N'TestUser2')
INSERT [dbo].[Comment] ([Id], [Value], [CreatedOn], [UpdatedOn], [MovieId], [CreatedBy], [UpdatedBy]) VALUES (1220, N'sdfdsf', CAST(N'2022-05-13T00:17:52.1413849' AS DateTime2), CAST(N'2022-05-13T00:17:52.1413865' AS DateTime2), 389, N'TestUser2', N'TestUser2')
INSERT [dbo].[Comment] ([Id], [Value], [CreatedOn], [UpdatedOn], [MovieId], [CreatedBy], [UpdatedBy]) VALUES (1221, N'dsfdsfdsf', CAST(N'2022-05-13T00:17:59.6419946' AS DateTime2), CAST(N'2022-05-13T00:17:59.6419983' AS DateTime2), 389, N'TestUser2', N'TestUser2')
INSERT [dbo].[Comment] ([Id], [Value], [CreatedOn], [UpdatedOn], [MovieId], [CreatedBy], [UpdatedBy]) VALUES (1222, N'vcvxcv', CAST(N'2022-05-13T00:19:55.7606984' AS DateTime2), CAST(N'2022-05-13T00:19:55.7607006' AS DateTime2), 389, N'TestUser2', N'TestUser2')
INSERT [dbo].[Comment] ([Id], [Value], [CreatedOn], [UpdatedOn], [MovieId], [CreatedBy], [UpdatedBy]) VALUES (1223, N'dssd sdds', CAST(N'2022-05-13T00:57:04.6138125' AS DateTime2), CAST(N'2022-05-13T00:57:04.6138147' AS DateTime2), 389, N'TestUser2', N'TestUser2')
INSERT [dbo].[Comment] ([Id], [Value], [CreatedOn], [UpdatedOn], [MovieId], [CreatedBy], [UpdatedBy]) VALUES (1229, N'dsfsd dsfsd sddsf sdds dscds sddssd', CAST(N'2022-05-14T16:34:37.0244842' AS DateTime2), CAST(N'2022-05-14T16:34:37.0244860' AS DateTime2), 238, N'TestUser2', N'TestUser2')
INSERT [dbo].[Comment] ([Id], [Value], [CreatedOn], [UpdatedOn], [MovieId], [CreatedBy], [UpdatedBy]) VALUES (1230, N'dsds dss sdds', CAST(N'2022-05-14T16:35:39.8062780' AS DateTime2), CAST(N'2022-05-14T16:35:39.8062797' AS DateTime2), 238, N'TestUser2', N'TestUser2')
INSERT [dbo].[Comment] ([Id], [Value], [CreatedOn], [UpdatedOn], [MovieId], [CreatedBy], [UpdatedBy]) VALUES (1231, N'dsds sds dssdd', CAST(N'2022-05-14T16:36:24.1878115' AS DateTime2), CAST(N'2022-05-14T16:36:24.1878131' AS DateTime2), 238, N'TestUser2', N'TestUser2')
INSERT [dbo].[Comment] ([Id], [Value], [CreatedOn], [UpdatedOn], [MovieId], [CreatedBy], [UpdatedBy]) VALUES (1234, N'sdfsd sds dsds dsd dsds dsds', CAST(N'2022-05-14T16:41:18.1631720' AS DateTime2), CAST(N'2022-05-14T16:41:18.1631734' AS DateTime2), 238, N'TestUser2', N'TestUser2')
INSERT [dbo].[Comment] ([Id], [Value], [CreatedOn], [UpdatedOn], [MovieId], [CreatedBy], [UpdatedBy]) VALUES (1238, N'dsfdsfs dsfds', CAST(N'2022-05-14T18:02:24.6571336' AS DateTime2), CAST(N'2022-05-14T18:02:24.6571346' AS DateTime2), 155, N'TestUser2', N'TestUser2')
INSERT [dbo].[Comment] ([Id], [Value], [CreatedOn], [UpdatedOn], [MovieId], [CreatedBy], [UpdatedBy]) VALUES (1258, N'hi this is me', CAST(N'2022-05-28T23:06:10.0818075' AS DateTime2), CAST(N'2022-05-28T23:06:10.0818093' AS DateTime2), 19404, N'testuser', N'testuser')
INSERT [dbo].[Comment] ([Id], [Value], [CreatedOn], [UpdatedOn], [MovieId], [CreatedBy], [UpdatedBy]) VALUES (1259, N'dfdsfdsfds gassan', CAST(N'2022-05-28T23:06:13.6392276' AS DateTime2), CAST(N'2022-05-28T23:06:13.6392280' AS DateTime2), 19404, N'testuser', N'testuser')
INSERT [dbo].[Comment] ([Id], [Value], [CreatedOn], [UpdatedOn], [MovieId], [CreatedBy], [UpdatedBy]) VALUES (1260, N'dssddsdsdssdsdddddddddddddddddddd', CAST(N'2022-05-28T23:06:21.2840303' AS DateTime2), CAST(N'2022-05-28T23:06:21.2840307' AS DateTime2), 19404, N'testuser', N'testuser')
INSERT [dbo].[Comment] ([Id], [Value], [CreatedOn], [UpdatedOn], [MovieId], [CreatedBy], [UpdatedBy]) VALUES (1273, N'dssd', CAST(N'2022-05-29T15:22:31.6356413' AS DateTime2), CAST(N'2022-05-29T15:22:31.6356422' AS DateTime2), 115929, N'testuser', N'testuser')
INSERT [dbo].[Comment] ([Id], [Value], [CreatedOn], [UpdatedOn], [MovieId], [CreatedBy], [UpdatedBy]) VALUES (1274, N'dsfdsf', CAST(N'2022-05-29T15:28:14.0780326' AS DateTime2), CAST(N'2022-05-29T15:28:14.0780339' AS DateTime2), 115929, N'testuser', N'testuser')
INSERT [dbo].[Comment] ([Id], [Value], [CreatedOn], [UpdatedOn], [MovieId], [CreatedBy], [UpdatedBy]) VALUES (1277, N'fdsdsf dsf', CAST(N'2022-05-29T17:27:10.1086933' AS DateTime2), CAST(N'2022-05-29T17:27:10.1086945' AS DateTime2), 115929, N'testuser', N'testuser')
INSERT [dbo].[Comment] ([Id], [Value], [CreatedOn], [UpdatedOn], [MovieId], [CreatedBy], [UpdatedBy]) VALUES (1279, N'dsdsds', CAST(N'2022-06-02T00:41:07.9506982' AS DateTime2), CAST(N'2022-06-02T00:41:07.9507015' AS DateTime2), 77338, N'testuser', N'testuser')
INSERT [dbo].[Comment] ([Id], [Value], [CreatedOn], [UpdatedOn], [MovieId], [CreatedBy], [UpdatedBy]) VALUES (1280, N'dssd', CAST(N'2022-06-02T00:41:13.7515031' AS DateTime2), CAST(N'2022-06-02T00:41:13.7515078' AS DateTime2), 77338, N'testuser', N'testuser')
INSERT [dbo].[Comment] ([Id], [Value], [CreatedOn], [UpdatedOn], [MovieId], [CreatedBy], [UpdatedBy]) VALUES (1281, N'dsdssd', CAST(N'2022-06-02T00:41:15.7486008' AS DateTime2), CAST(N'2022-06-02T00:41:15.7486028' AS DateTime2), 77338, N'testuser', N'testuser')
INSERT [dbo].[Comment] ([Id], [Value], [CreatedOn], [UpdatedOn], [MovieId], [CreatedBy], [UpdatedBy]) VALUES (1282, N'sdsd', CAST(N'2022-06-02T00:46:06.8743178' AS DateTime2), CAST(N'2022-06-02T00:46:06.8743204' AS DateTime2), 9544, N'testuser', N'testuser')
INSERT [dbo].[Comment] ([Id], [Value], [CreatedOn], [UpdatedOn], [MovieId], [CreatedBy], [UpdatedBy]) VALUES (1285, N'dsds', CAST(N'2022-06-02T15:33:52.3625004' AS DateTime2), CAST(N'2022-06-02T15:33:52.3625016' AS DateTime2), 752623, N'TestUser2', N'TestUser2')
INSERT [dbo].[Comment] ([Id], [Value], [CreatedOn], [UpdatedOn], [MovieId], [CreatedBy], [UpdatedBy]) VALUES (1289, N'sdfsdf', CAST(N'2022-06-12T18:51:50.9873849' AS DateTime2), CAST(N'2022-06-12T18:51:50.9873859' AS DateTime2), 680, N'testuser', N'testuser')
INSERT [dbo].[Comment] ([Id], [Value], [CreatedOn], [UpdatedOn], [MovieId], [CreatedBy], [UpdatedBy]) VALUES (1290, N'dsds', CAST(N'2022-06-12T18:59:42.7319832' AS DateTime2), CAST(N'2022-06-12T18:59:42.7319839' AS DateTime2), 680, N'TestUser2', N'TestUser2')
INSERT [dbo].[Comment] ([Id], [Value], [CreatedOn], [UpdatedOn], [MovieId], [CreatedBy], [UpdatedBy]) VALUES (1292, N'123 qayyum', CAST(N'2022-06-17T18:08:47.6959876' AS DateTime2), CAST(N'2022-06-17T18:08:47.6959901' AS DateTime2), 335, N'testuser', N'testuser')
SET IDENTITY_INSERT [dbo].[Comment] OFF
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_AspNetRoleClaims_RoleId]    Script Date: 18/06/2022 11:37:10 pm ******/
CREATE NONCLUSTERED INDEX [IX_AspNetRoleClaims_RoleId] ON [dbo].[AspNetRoleClaims]
(
	[RoleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [RoleNameIndex]    Script Date: 18/06/2022 11:37:10 pm ******/
CREATE UNIQUE NONCLUSTERED INDEX [RoleNameIndex] ON [dbo].[AspNetRoles]
(
	[NormalizedName] ASC
)
WHERE ([NormalizedName] IS NOT NULL)
WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_AspNetUserClaims_UserId]    Script Date: 18/06/2022 11:37:10 pm ******/
CREATE NONCLUSTERED INDEX [IX_AspNetUserClaims_UserId] ON [dbo].[AspNetUserClaims]
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_AspNetUserLogins_UserId]    Script Date: 18/06/2022 11:37:10 pm ******/
CREATE NONCLUSTERED INDEX [IX_AspNetUserLogins_UserId] ON [dbo].[AspNetUserLogins]
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_AspNetUserRoles_RoleId]    Script Date: 18/06/2022 11:37:10 pm ******/
CREATE NONCLUSTERED INDEX [IX_AspNetUserRoles_RoleId] ON [dbo].[AspNetUserRoles]
(
	[RoleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [EmailIndex]    Script Date: 18/06/2022 11:37:10 pm ******/
CREATE NONCLUSTERED INDEX [EmailIndex] ON [dbo].[AspNetUsers]
(
	[NormalizedEmail] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [UserNameIndex]    Script Date: 18/06/2022 11:37:10 pm ******/
CREATE UNIQUE NONCLUSTERED INDEX [UserNameIndex] ON [dbo].[AspNetUsers]
(
	[NormalizedUserName] ASC
)
WHERE ([NormalizedUserName] IS NOT NULL)
WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Comment] ADD  DEFAULT ((0)) FOR [MovieId]
GO
ALTER TABLE [dbo].[AspNetRoleClaims]  WITH CHECK ADD  CONSTRAINT [FK_AspNetRoleClaims_AspNetRoles_RoleId] FOREIGN KEY([RoleId])
REFERENCES [dbo].[AspNetRoles] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetRoleClaims] CHECK CONSTRAINT [FK_AspNetRoleClaims_AspNetRoles_RoleId]
GO
ALTER TABLE [dbo].[AspNetUserClaims]  WITH CHECK ADD  CONSTRAINT [FK_AspNetUserClaims_AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserClaims] CHECK CONSTRAINT [FK_AspNetUserClaims_AspNetUsers_UserId]
GO
ALTER TABLE [dbo].[AspNetUserLogins]  WITH CHECK ADD  CONSTRAINT [FK_AspNetUserLogins_AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserLogins] CHECK CONSTRAINT [FK_AspNetUserLogins_AspNetUsers_UserId]
GO
ALTER TABLE [dbo].[AspNetUserRoles]  WITH CHECK ADD  CONSTRAINT [FK_AspNetUserRoles_AspNetRoles_RoleId] FOREIGN KEY([RoleId])
REFERENCES [dbo].[AspNetRoles] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserRoles] CHECK CONSTRAINT [FK_AspNetUserRoles_AspNetRoles_RoleId]
GO
ALTER TABLE [dbo].[AspNetUserRoles]  WITH CHECK ADD  CONSTRAINT [FK_AspNetUserRoles_AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserRoles] CHECK CONSTRAINT [FK_AspNetUserRoles_AspNetUsers_UserId]
GO
ALTER TABLE [dbo].[AspNetUserTokens]  WITH CHECK ADD  CONSTRAINT [FK_AspNetUserTokens_AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserTokens] CHECK CONSTRAINT [FK_AspNetUserTokens_AspNetUsers_UserId]
GO
USE [master]
GO
ALTER DATABASE [app-database] SET  READ_WRITE 
GO
