/****** Object:  StoredProcedure [dbo].[usp_GetUserPermissionLevelByFunctionName]    Script Date: 2019/3/25 17:00:39 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[usp_GetUserPermissionLevelByFunctionName]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[usp_GetUserPermissionLevelByFunctionName]
GO
/****** Object:  StoredProcedure [dbo].[usp_GetUserPermissionLevel]    Script Date: 2019/3/25 17:00:39 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[usp_GetUserPermissionLevel]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[usp_GetUserPermissionLevel]
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_Table_4_Table_2]') AND parent_object_id = OBJECT_ID(N'[dbo].[Table_4]'))
ALTER TABLE [dbo].[Table_4] DROP CONSTRAINT [FK_Table_4_Table_2]
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_Common_SiteMap_Menu_Common_SiteMap_Menu]') AND parent_object_id = OBJECT_ID(N'[dbo].[Common_SiteMap_Menu]'))
ALTER TABLE [dbo].[Common_SiteMap_Menu] DROP CONSTRAINT [FK_Common_SiteMap_Menu_Common_SiteMap_Menu]
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_Common_Authen_RoleUser_Common_Authen_User]') AND parent_object_id = OBJECT_ID(N'[dbo].[Common_Authen_RoleUser]'))
ALTER TABLE [dbo].[Common_Authen_RoleUser] DROP CONSTRAINT [FK_Common_Authen_RoleUser_Common_Authen_User]
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_Common_Authen_RoleUser_Common_Authen_Role]') AND parent_object_id = OBJECT_ID(N'[dbo].[Common_Authen_RoleUser]'))
ALTER TABLE [dbo].[Common_Authen_RoleUser] DROP CONSTRAINT [FK_Common_Authen_RoleUser_Common_Authen_Role]
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_Common_Authen_RoleFunctionPermission_Common_Authen_Role]') AND parent_object_id = OBJECT_ID(N'[dbo].[Common_Authen_RoleFunctionPermission]'))
ALTER TABLE [dbo].[Common_Authen_RoleFunctionPermission] DROP CONSTRAINT [FK_Common_Authen_RoleFunctionPermission_Common_Authen_Role]
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_Common_Authen_RoleFunctionPermission_Common_Authen_FunctionPermissionLevel]') AND parent_object_id = OBJECT_ID(N'[dbo].[Common_Authen_RoleFunctionPermission]'))
ALTER TABLE [dbo].[Common_Authen_RoleFunctionPermission] DROP CONSTRAINT [FK_Common_Authen_RoleFunctionPermission_Common_Authen_FunctionPermissionLevel]
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_Common_Authen_ControllerActions_Common_Authen_FunctionPermissionLevel]') AND parent_object_id = OBJECT_ID(N'[dbo].[Common_Authen_ControllerActions]'))
ALTER TABLE [dbo].[Common_Authen_ControllerActions] DROP CONSTRAINT [FK_Common_Authen_ControllerActions_Common_Authen_FunctionPermissionLevel]
GO
/****** Object:  View [dbo].[vw_Authen_RolePermissions]    Script Date: 2019/3/25 17:00:39 ******/
IF  EXISTS (SELECT * FROM sys.views WHERE object_id = OBJECT_ID(N'[dbo].[vw_Authen_RolePermissions]'))
DROP VIEW [dbo].[vw_Authen_RolePermissions]
GO
/****** Object:  Table [dbo].[tbl_Sample]    Script Date: 2019/3/25 17:00:39 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[tbl_Sample]') AND type in (N'U'))
DROP TABLE [dbo].[tbl_Sample]
GO
/****** Object:  Table [dbo].[tbl_LogInfo]    Script Date: 2019/3/25 17:00:39 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[tbl_LogInfo]') AND type in (N'U'))
DROP TABLE [dbo].[tbl_LogInfo]
GO
/****** Object:  Table [dbo].[Table_5]    Script Date: 2019/3/25 17:00:39 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Table_5]') AND type in (N'U'))
DROP TABLE [dbo].[Table_5]
GO
/****** Object:  Table [dbo].[Table_4]    Script Date: 2019/3/25 17:00:39 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Table_4]') AND type in (N'U'))
DROP TABLE [dbo].[Table_4]
GO
/****** Object:  Table [dbo].[Table_3]    Script Date: 2019/3/25 17:00:39 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Table_3]') AND type in (N'U'))
DROP TABLE [dbo].[Table_3]
GO
/****** Object:  Table [dbo].[Table_2]    Script Date: 2019/3/25 17:00:39 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Table_2]') AND type in (N'U'))
DROP TABLE [dbo].[Table_2]
GO
/****** Object:  Table [dbo].[Table_1]    Script Date: 2019/3/25 17:00:39 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Table_1]') AND type in (N'U'))
DROP TABLE [dbo].[Table_1]
GO
/****** Object:  Table [dbo].[Common_SiteMap_Menu]    Script Date: 2019/3/25 17:00:39 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Common_SiteMap_Menu]') AND type in (N'U'))
DROP TABLE [dbo].[Common_SiteMap_Menu]
GO
/****** Object:  Table [dbo].[Common_Authen_User]    Script Date: 2019/3/25 17:00:39 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Common_Authen_User]') AND type in (N'U'))
DROP TABLE [dbo].[Common_Authen_User]
GO
/****** Object:  Table [dbo].[Common_Authen_RoleUser]    Script Date: 2019/3/25 17:00:39 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Common_Authen_RoleUser]') AND type in (N'U'))
DROP TABLE [dbo].[Common_Authen_RoleUser]
GO
/****** Object:  Table [dbo].[Common_Authen_RoleFunctionPermission]    Script Date: 2019/3/25 17:00:39 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Common_Authen_RoleFunctionPermission]') AND type in (N'U'))
DROP TABLE [dbo].[Common_Authen_RoleFunctionPermission]
GO
/****** Object:  Table [dbo].[Common_Authen_Role]    Script Date: 2019/3/25 17:00:39 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Common_Authen_Role]') AND type in (N'U'))
DROP TABLE [dbo].[Common_Authen_Role]
GO
/****** Object:  Table [dbo].[Common_Authen_FunctionPermissionLevel]    Script Date: 2019/3/25 17:00:39 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Common_Authen_FunctionPermissionLevel]') AND type in (N'U'))
DROP TABLE [dbo].[Common_Authen_FunctionPermissionLevel]
GO
/****** Object:  Table [dbo].[Common_Authen_ControllerActions]    Script Date: 2019/3/25 17:00:39 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Common_Authen_ControllerActions]') AND type in (N'U'))
DROP TABLE [dbo].[Common_Authen_ControllerActions]
GO
/****** Object:  User [EmsUser1]    Script Date: 2019/3/25 17:00:39 ******/
IF  EXISTS (SELECT * FROM sys.database_principals WHERE name = N'EmsUser1')
DROP USER [EmsUser1]
GO
/****** Object:  Database [EmsWebDB]    Script Date: 2019/3/25 17:00:39 ******/
IF  EXISTS (SELECT name FROM sys.databases WHERE name = N'EmsWebDB')
DROP DATABASE [EmsWebDB]
GO
/****** Object:  Database [EmsWebDB]    Script Date: 2019/3/25 17:00:39 ******/
IF NOT EXISTS (SELECT name FROM sys.databases WHERE name = N'EmsWebDB')
BEGIN
CREATE DATABASE [EmsWebDB] ON  PRIMARY 
( NAME = N'EmsWebDB', FILENAME = N'D:\Program Files\Microsoft SQL Server\MSSQL12.MSSQLSERVER\MSSQL\DATA\EmsWebDB.mdf' , SIZE = 5120KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'EmsWebDB_log', FILENAME = N'D:\Program Files\Microsoft SQL Server\MSSQL12.MSSQLSERVER\MSSQL\DATA\EmsWebDB_log.ldf' , SIZE = 9216KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
END

GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [EmsWebDB].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [EmsWebDB] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [EmsWebDB] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [EmsWebDB] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [EmsWebDB] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [EmsWebDB] SET ARITHABORT OFF 
GO
ALTER DATABASE [EmsWebDB] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [EmsWebDB] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [EmsWebDB] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [EmsWebDB] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [EmsWebDB] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [EmsWebDB] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [EmsWebDB] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [EmsWebDB] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [EmsWebDB] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [EmsWebDB] SET  ENABLE_BROKER 
GO
ALTER DATABASE [EmsWebDB] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [EmsWebDB] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [EmsWebDB] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [EmsWebDB] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [EmsWebDB] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [EmsWebDB] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [EmsWebDB] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [EmsWebDB] SET RECOVERY FULL 
GO
ALTER DATABASE [EmsWebDB] SET  MULTI_USER 
GO
ALTER DATABASE [EmsWebDB] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [EmsWebDB] SET DB_CHAINING OFF 
GO
EXEC sys.sp_db_vardecimal_storage_format N'EmsWebDB', N'ON'
GO
/****** Object:  User [EmsUser1]    Script Date: 2019/3/25 17:00:39 ******/
IF NOT EXISTS (SELECT * FROM sys.database_principals WHERE name = N'EmsUser1')
CREATE USER [EmsUser1] FOR LOGIN [EmsUser1] WITH DEFAULT_SCHEMA=[dbo]
GO
sys.sp_addrolemember @rolename = N'db_owner', @membername = N'EmsUser1'
GO
/****** Object:  Table [dbo].[Common_Authen_ControllerActions]    Script Date: 2019/3/25 17:00:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Common_Authen_ControllerActions]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[Common_Authen_ControllerActions](
	[ID] [int] NOT NULL,
	[PermissionLevelID] [int] NOT NULL,
	[Area] [varchar](100) NULL,
	[Controller] [varchar](100) NOT NULL,
	[ActionName] [varchar](100) NOT NULL,
	[HasActionPermission] [bit] NOT NULL,
	[Description] [nvarchar](200) NULL,
 CONSTRAINT [PK_Common_Authen_ControllerActions] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Common_Authen_FunctionPermissionLevel]    Script Date: 2019/3/25 17:00:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Common_Authen_FunctionPermissionLevel]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[Common_Authen_FunctionPermissionLevel](
	[ID] [int] NOT NULL,
	[FunctionName] [varchar](100) NOT NULL,
	[PermissionLevel] [varchar](50) NOT NULL,
	[Description] [varchar](200) NULL,
 CONSTRAINT [PK_Common_Authen_ControllerPermissionLevel] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Common_Authen_Role]    Script Date: 2019/3/25 17:00:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Common_Authen_Role]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[Common_Authen_Role](
	[RoleID] [int] NOT NULL,
	[RoleName] [nvarchar](20) NOT NULL,
	[Description] [nchar](200) NULL,
	[ShowFlag] [bit] NULL,
	[ResourceKey] [nvarchar](100) NULL,
	[CreatedDate] [datetime] NOT NULL,
	[CreatedBy] [nvarchar](50) NOT NULL,
	[UpdatedDate] [datetime] NULL,
	[UpdatedBy] [nvarchar](50) NULL,
 CONSTRAINT [PK_Common_Authen_Role] PRIMARY KEY CLUSTERED 
(
	[RoleID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
/****** Object:  Table [dbo].[Common_Authen_RoleFunctionPermission]    Script Date: 2019/3/25 17:00:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Common_Authen_RoleFunctionPermission]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[Common_Authen_RoleFunctionPermission](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[RoleID] [int] NOT NULL,
	[PermissionLevelID] [int] NOT NULL,
	[Description] [nvarchar](200) NULL,
 CONSTRAINT [PK_Common_Authen_RoleControllerPermission] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
/****** Object:  Table [dbo].[Common_Authen_RoleUser]    Script Date: 2019/3/25 17:00:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Common_Authen_RoleUser]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[Common_Authen_RoleUser](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[RoleID] [int] NOT NULL,
	[UserID] [int] NOT NULL,
	[Description] [nvarchar](200) NULL,
 CONSTRAINT [PK_Common_Authen_RoleUser] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
/****** Object:  Table [dbo].[Common_Authen_User]    Script Date: 2019/3/25 17:00:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Common_Authen_User]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[Common_Authen_User](
	[UserID] [int] IDENTITY(1,1) NOT NULL,
	[LogonName] [nvarchar](20) NOT NULL,
	[Password] [varchar](16) NOT NULL,
	[UserName] [nvarchar](20) NOT NULL,
	[Gender] [nvarchar](1) NOT NULL,
	[PhoneNumber] [varchar](20) NOT NULL,
	[EmailAddress] [varchar](30) NOT NULL,
	[IDNumber] [varchar](18) NULL,
	[DateOFBirth] [datetime] NULL,
	[Status] [int] NOT NULL,
	[CanDelete] [bit] NULL,
	[CreatedDate] [datetime] NOT NULL,
	[CreatedBy] [nvarchar](50) NOT NULL,
	[UpdatedDate] [datetime] NULL,
	[UpdatedBy] [nvarchar](50) NULL,
 CONSTRAINT [PK_tbl_User_1] PRIMARY KEY CLUSTERED 
(
	[UserID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Common_SiteMap_Menu]    Script Date: 2019/3/25 17:00:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Common_SiteMap_Menu]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[Common_SiteMap_Menu](
	[MenuID] [int] NOT NULL,
	[ParentID] [int] NULL,
	[ResourceKey] [nvarchar](100) NOT NULL,
	[Area] [varchar](100) NULL,
	[Controller] [varchar](100) NULL,
	[ActionName] [varchar](100) NULL,
	[RouteValues] [varchar](500) NULL,
	[IsSkip] [bit] NOT NULL,
	[DisplayOrder] [int] NOT NULL,
	[IsShow] [bit] NULL,
 CONSTRAINT [PK_Common_SiteMap_Menu] PRIMARY KEY CLUSTERED 
(
	[MenuID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Table_1]    Script Date: 2019/3/25 17:00:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Table_1]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[Table_1](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Table_1] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
/****** Object:  Table [dbo].[Table_2]    Script Date: 2019/3/25 17:00:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Table_2]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[Table_2](
	[ID] [nchar](10) NOT NULL,
	[Name1] [nchar](10) NULL,
 CONSTRAINT [PK_Table_2] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
/****** Object:  Table [dbo].[Table_3]    Script Date: 2019/3/25 17:00:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Table_3]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[Table_3](
	[ID] [nchar](10) NOT NULL,
	[Name] [nchar](10) NULL,
 CONSTRAINT [PK_Table_3] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
/****** Object:  Table [dbo].[Table_4]    Script Date: 2019/3/25 17:00:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Table_4]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[Table_4](
	[id] [nchar](10) NOT NULL,
	[name] [nchar](10) NULL,
	[pid] [nchar](10) NULL,
 CONSTRAINT [PK_Table_4] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
/****** Object:  Table [dbo].[Table_5]    Script Date: 2019/3/25 17:00:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Table_5]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[Table_5](
	[id] [nchar](10) NOT NULL,
	[name] [nchar](10) NULL,
 CONSTRAINT [PK_Table_5] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
/****** Object:  Table [dbo].[tbl_LogInfo]    Script Date: 2019/3/25 17:00:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[tbl_LogInfo]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[tbl_LogInfo](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[LogTime] [datetime] NOT NULL,
	[Thread] [nvarchar](max) NOT NULL,
	[LogLevel] [nvarchar](max) NULL,
	[Logger] [nvarchar](max) NULL,
	[Message] [nvarchar](max) NULL,
	[Exception] [nvarchar](max) NULL,
 CONSTRAINT [PK_tbl_LogInfo] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
END
GO
/****** Object:  Table [dbo].[tbl_Sample]    Script Date: 2019/3/25 17:00:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[tbl_Sample]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[tbl_Sample](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[Address] [nvarchar](50) NULL,
	[CreatedDate] [datetime] NULL,
	[CreatedBy] [nvarchar](100) NULL,
	[UpdatedDate] [datetime] NULL,
	[UpdatedBy] [nvarchar](100) NULL,
	[IsDeleted] [bit] NULL,
 CONSTRAINT [PK_tbl_Sample] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
/****** Object:  View [dbo].[vw_Authen_RolePermissions]    Script Date: 2019/3/25 17:00:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.views WHERE object_id = OBJECT_ID(N'[dbo].[vw_Authen_RolePermissions]'))
EXEC dbo.sp_executesql @statement = N'

CREATE VIEW [dbo].[vw_Authen_RolePermissions]
AS
SELECT    R.RoleID AS RoleID
		, R.RoleName
		, CA.Area
		, CA.Controller
		, CA.ActionName
		, CA.HasActionPermission
FROM    Common_Authen_RoleFunctionPermission AS RFP INNER JOIN
        Common_Authen_Role AS R ON RFP.RoleID = R.RoleID INNER JOIN
        Common_Authen_ControllerActions AS CA ON RFP.PermissionLevelID = CA.PermissionLevelID


' 
GO
INSERT [dbo].[Common_Authen_ControllerActions] ([ID], [PermissionLevelID], [Area], [Controller], [ActionName], [HasActionPermission], [Description]) VALUES (1001000, 10010, N'', N'Home1', N'Index', 0, N'Admin--没用，只到controller级，不作action级的权限控制')
INSERT [dbo].[Common_Authen_ControllerActions] ([ID], [PermissionLevelID], [Area], [Controller], [ActionName], [HasActionPermission], [Description]) VALUES (1001001, 10010, N'', N'Home1', N'Contact', 0, N'Admin')
INSERT [dbo].[Common_Authen_ControllerActions] ([ID], [PermissionLevelID], [Area], [Controller], [ActionName], [HasActionPermission], [Description]) VALUES (1001002, 10010, N'', N'Home1', N'About', 0, N'Admin')
INSERT [dbo].[Common_Authen_ControllerActions] ([ID], [PermissionLevelID], [Area], [Controller], [ActionName], [HasActionPermission], [Description]) VALUES (1001004, 10010, N'', N'Sample1', N'Index', 0, N'Admin')
INSERT [dbo].[Common_Authen_ControllerActions] ([ID], [PermissionLevelID], [Area], [Controller], [ActionName], [HasActionPermission], [Description]) VALUES (1001005, 10010, N'', N'Home1', N'MenuLevel2_1', 0, N'Admin')
INSERT [dbo].[Common_Authen_ControllerActions] ([ID], [PermissionLevelID], [Area], [Controller], [ActionName], [HasActionPermission], [Description]) VALUES (1001006, 10010, N'', N'Home1', N'MenuLevel2_2', 0, N'Admin')
INSERT [dbo].[Common_Authen_ControllerActions] ([ID], [PermissionLevelID], [Area], [Controller], [ActionName], [HasActionPermission], [Description]) VALUES (1001007, 10010, N'', N'Home1', N'MenuLevel2_3', 0, N'Admin')
INSERT [dbo].[Common_Authen_ControllerActions] ([ID], [PermissionLevelID], [Area], [Controller], [ActionName], [HasActionPermission], [Description]) VALUES (1001008, 10010, N'', N'Home1', N'MenuLevel3_1', 0, N'Admin')
INSERT [dbo].[Common_Authen_ControllerActions] ([ID], [PermissionLevelID], [Area], [Controller], [ActionName], [HasActionPermission], [Description]) VALUES (1001009, 10010, N'', N'Home1', N'MenuLevel3_2', 0, N'Admin')
INSERT [dbo].[Common_Authen_ControllerActions] ([ID], [PermissionLevelID], [Area], [Controller], [ActionName], [HasActionPermission], [Description]) VALUES (1001010, 10010, N'', N'Home', N'', 0, N'Admin--若user有controller权限，则里边所有action都有权限')
INSERT [dbo].[Common_Authen_ControllerActions] ([ID], [PermissionLevelID], [Area], [Controller], [ActionName], [HasActionPermission], [Description]) VALUES (1001011, 10010, N'', N'Sample', N'', 0, N'Admin')
INSERT [dbo].[Common_Authen_ControllerActions] ([ID], [PermissionLevelID], [Area], [Controller], [ActionName], [HasActionPermission], [Description]) VALUES (1001100, 10011, N'', N'Sample', N'', 0, N'Visitor')
INSERT [dbo].[Common_Authen_FunctionPermissionLevel] ([ID], [FunctionName], [PermissionLevel], [Description]) VALUES (10010, N'Admin', N'Admin', N'Admin')
INSERT [dbo].[Common_Authen_FunctionPermissionLevel] ([ID], [FunctionName], [PermissionLevel], [Description]) VALUES (10011, N'Visitor', N'Visitor', N'Visitor')
INSERT [dbo].[Common_Authen_Role] ([RoleID], [RoleName], [Description], [ShowFlag], [ResourceKey], [CreatedDate], [CreatedBy], [UpdatedDate], [UpdatedBy]) VALUES (1, N'Admin', N'Admin                                                                                                                                                                                                   ', 1, N'Common_Role_SystemAdmin', CAST(N'2014-07-18 00:00:00.000' AS DateTime), N'Wanghailin', NULL, NULL)
INSERT [dbo].[Common_Authen_Role] ([RoleID], [RoleName], [Description], [ShowFlag], [ResourceKey], [CreatedDate], [CreatedBy], [UpdatedDate], [UpdatedBy]) VALUES (2, N'Visitor', N'Visitor                                                                                                                                                                                                 ', 1, N'Commom_Role_Visitor', CAST(N'2014-07-18 00:00:00.000' AS DateTime), N'Wanghailin', NULL, NULL)
SET IDENTITY_INSERT [dbo].[Common_Authen_RoleFunctionPermission] ON 

INSERT [dbo].[Common_Authen_RoleFunctionPermission] ([ID], [RoleID], [PermissionLevelID], [Description]) VALUES (1, 1, 10010, N'Admin')
INSERT [dbo].[Common_Authen_RoleFunctionPermission] ([ID], [RoleID], [PermissionLevelID], [Description]) VALUES (5, 2, 10011, N'Visitor')
SET IDENTITY_INSERT [dbo].[Common_Authen_RoleFunctionPermission] OFF
SET IDENTITY_INSERT [dbo].[Common_Authen_RoleUser] ON 

INSERT [dbo].[Common_Authen_RoleUser] ([ID], [RoleID], [UserID], [Description]) VALUES (1, 1, 2, N'Admin')
INSERT [dbo].[Common_Authen_RoleUser] ([ID], [RoleID], [UserID], [Description]) VALUES (2, 2, 3, N'Visitor')
SET IDENTITY_INSERT [dbo].[Common_Authen_RoleUser] OFF
SET IDENTITY_INSERT [dbo].[Common_Authen_User] ON 

INSERT [dbo].[Common_Authen_User] ([UserID], [LogonName], [Password], [UserName], [Gender], [PhoneNumber], [EmailAddress], [IDNumber], [DateOFBirth], [Status], [CanDelete], [CreatedDate], [CreatedBy], [UpdatedDate], [UpdatedBy]) VALUES (2, N'zack', N'123456', N'Zack Huang', N'男', N'123456789', N'Zackhuang@apjcorp.com', N'1234567890', CAST(N'2014-04-01 00:00:00.000' AS DateTime), 1, 0, CAST(N'2014-08-14 00:00:00.000' AS DateTime), N'wanghailin', NULL, NULL)
INSERT [dbo].[Common_Authen_User] ([UserID], [LogonName], [Password], [UserName], [Gender], [PhoneNumber], [EmailAddress], [IDNumber], [DateOFBirth], [Status], [CanDelete], [CreatedDate], [CreatedBy], [UpdatedDate], [UpdatedBy]) VALUES (3, N'zack2', N'123456', N'Zack Huang', N'男', N'123456789', N'Zackhuang@apjcorp.com', N'1234567890', CAST(N'2014-04-01 00:00:00.000' AS DateTime), 1, 0, CAST(N'2014-08-14 00:00:00.000' AS DateTime), N'wanghailin', NULL, NULL)
SET IDENTITY_INSERT [dbo].[Common_Authen_User] OFF
INSERT [dbo].[Common_SiteMap_Menu] ([MenuID], [ParentID], [ResourceKey], [Area], [Controller], [ActionName], [RouteValues], [IsSkip], [DisplayOrder], [IsShow]) VALUES (1, NULL, N'Contact Async', NULL, N'Home', N'Contact', NULL, 0, 1, 1)
INSERT [dbo].[Common_SiteMap_Menu] ([MenuID], [ParentID], [ResourceKey], [Area], [Controller], [ActionName], [RouteValues], [IsSkip], [DisplayOrder], [IsShow]) VALUES (2, NULL, N'About', NULL, N'Home', N'About', NULL, 0, 2, 1)
INSERT [dbo].[Common_SiteMap_Menu] ([MenuID], [ParentID], [ResourceKey], [Area], [Controller], [ActionName], [RouteValues], [IsSkip], [DisplayOrder], [IsShow]) VALUES (3, NULL, N'Home', NULL, N'Home', N'Index', NULL, 0, 3, 1)
INSERT [dbo].[Common_SiteMap_Menu] ([MenuID], [ParentID], [ResourceKey], [Area], [Controller], [ActionName], [RouteValues], [IsSkip], [DisplayOrder], [IsShow]) VALUES (4, NULL, N'MultiLeveMenu', NULL, NULL, NULL, NULL, 0, 4, 1)
INSERT [dbo].[Common_SiteMap_Menu] ([MenuID], [ParentID], [ResourceKey], [Area], [Controller], [ActionName], [RouteValues], [IsSkip], [DisplayOrder], [IsShow]) VALUES (5, 4, N'Level2_1', NULL, N'Home', N'MenuLevel2_1', NULL, 0, 1, 1)
INSERT [dbo].[Common_SiteMap_Menu] ([MenuID], [ParentID], [ResourceKey], [Area], [Controller], [ActionName], [RouteValues], [IsSkip], [DisplayOrder], [IsShow]) VALUES (6, 4, N'Level2_2', NULL, N'Home', N'MenuLevel2_2', NULL, 0, 2, 1)
INSERT [dbo].[Common_SiteMap_Menu] ([MenuID], [ParentID], [ResourceKey], [Area], [Controller], [ActionName], [RouteValues], [IsSkip], [DisplayOrder], [IsShow]) VALUES (7, 4, N'Level2_3', NULL, N'Home', N'MenuLevel2_3', NULL, 0, 3, 1)
INSERT [dbo].[Common_SiteMap_Menu] ([MenuID], [ParentID], [ResourceKey], [Area], [Controller], [ActionName], [RouteValues], [IsSkip], [DisplayOrder], [IsShow]) VALUES (8, 6, N'Level3_1', NULL, N'Home', N'MenuLevel3_1', NULL, 0, 1, 1)
INSERT [dbo].[Common_SiteMap_Menu] ([MenuID], [ParentID], [ResourceKey], [Area], [Controller], [ActionName], [RouteValues], [IsSkip], [DisplayOrder], [IsShow]) VALUES (9, 6, N'Level3_2', NULL, N'Home', N'MenuLevel3_2', NULL, 0, 2, 1)
INSERT [dbo].[Common_SiteMap_Menu] ([MenuID], [ParentID], [ResourceKey], [Area], [Controller], [ActionName], [RouteValues], [IsSkip], [DisplayOrder], [IsShow]) VALUES (10, 6, N'Level3_3', NULL, N'Sample', N'Index', NULL, 0, 3, 1)
SET IDENTITY_INSERT [dbo].[Table_1] ON 

INSERT [dbo].[Table_1] ([ID], [Name]) VALUES (1, N'zack')
INSERT [dbo].[Table_1] ([ID], [Name]) VALUES (2, N'ansen')
SET IDENTITY_INSERT [dbo].[Table_1] OFF
INSERT [dbo].[Table_2] ([ID], [Name1]) VALUES (N'1         ', N'1         ')
INSERT [dbo].[Table_4] ([id], [name], [pid]) VALUES (N'1         ', N'dsds      ', N'1         ')
SET IDENTITY_INSERT [dbo].[tbl_Sample] ON 

INSERT [dbo].[tbl_Sample] ([ID], [Name], [Address], [CreatedDate], [CreatedBy], [UpdatedDate], [UpdatedBy], [IsDeleted]) VALUES (1, N'Zack', N'ZhuHai', NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[tbl_Sample] ([ID], [Name], [Address], [CreatedDate], [CreatedBy], [UpdatedDate], [UpdatedBy], [IsDeleted]) VALUES (2, N'Jason', N'NanJing', NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[tbl_Sample] ([ID], [Name], [Address], [CreatedDate], [CreatedBy], [UpdatedDate], [UpdatedBy], [IsDeleted]) VALUES (3, N'Benson', N'GZ', NULL, NULL, NULL, NULL, NULL)
SET IDENTITY_INSERT [dbo].[tbl_Sample] OFF
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_Common_Authen_ControllerActions_Common_Authen_FunctionPermissionLevel]') AND parent_object_id = OBJECT_ID(N'[dbo].[Common_Authen_ControllerActions]'))
ALTER TABLE [dbo].[Common_Authen_ControllerActions]  WITH CHECK ADD  CONSTRAINT [FK_Common_Authen_ControllerActions_Common_Authen_FunctionPermissionLevel] FOREIGN KEY([PermissionLevelID])
REFERENCES [dbo].[Common_Authen_FunctionPermissionLevel] ([ID])
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_Common_Authen_ControllerActions_Common_Authen_FunctionPermissionLevel]') AND parent_object_id = OBJECT_ID(N'[dbo].[Common_Authen_ControllerActions]'))
ALTER TABLE [dbo].[Common_Authen_ControllerActions] CHECK CONSTRAINT [FK_Common_Authen_ControllerActions_Common_Authen_FunctionPermissionLevel]
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_Common_Authen_RoleFunctionPermission_Common_Authen_FunctionPermissionLevel]') AND parent_object_id = OBJECT_ID(N'[dbo].[Common_Authen_RoleFunctionPermission]'))
ALTER TABLE [dbo].[Common_Authen_RoleFunctionPermission]  WITH CHECK ADD  CONSTRAINT [FK_Common_Authen_RoleFunctionPermission_Common_Authen_FunctionPermissionLevel] FOREIGN KEY([PermissionLevelID])
REFERENCES [dbo].[Common_Authen_FunctionPermissionLevel] ([ID])
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_Common_Authen_RoleFunctionPermission_Common_Authen_FunctionPermissionLevel]') AND parent_object_id = OBJECT_ID(N'[dbo].[Common_Authen_RoleFunctionPermission]'))
ALTER TABLE [dbo].[Common_Authen_RoleFunctionPermission] CHECK CONSTRAINT [FK_Common_Authen_RoleFunctionPermission_Common_Authen_FunctionPermissionLevel]
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_Common_Authen_RoleFunctionPermission_Common_Authen_Role]') AND parent_object_id = OBJECT_ID(N'[dbo].[Common_Authen_RoleFunctionPermission]'))
ALTER TABLE [dbo].[Common_Authen_RoleFunctionPermission]  WITH CHECK ADD  CONSTRAINT [FK_Common_Authen_RoleFunctionPermission_Common_Authen_Role] FOREIGN KEY([RoleID])
REFERENCES [dbo].[Common_Authen_Role] ([RoleID])
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_Common_Authen_RoleFunctionPermission_Common_Authen_Role]') AND parent_object_id = OBJECT_ID(N'[dbo].[Common_Authen_RoleFunctionPermission]'))
ALTER TABLE [dbo].[Common_Authen_RoleFunctionPermission] CHECK CONSTRAINT [FK_Common_Authen_RoleFunctionPermission_Common_Authen_Role]
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_Common_Authen_RoleUser_Common_Authen_Role]') AND parent_object_id = OBJECT_ID(N'[dbo].[Common_Authen_RoleUser]'))
ALTER TABLE [dbo].[Common_Authen_RoleUser]  WITH CHECK ADD  CONSTRAINT [FK_Common_Authen_RoleUser_Common_Authen_Role] FOREIGN KEY([RoleID])
REFERENCES [dbo].[Common_Authen_Role] ([RoleID])
ON DELETE CASCADE
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_Common_Authen_RoleUser_Common_Authen_Role]') AND parent_object_id = OBJECT_ID(N'[dbo].[Common_Authen_RoleUser]'))
ALTER TABLE [dbo].[Common_Authen_RoleUser] CHECK CONSTRAINT [FK_Common_Authen_RoleUser_Common_Authen_Role]
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_Common_Authen_RoleUser_Common_Authen_User]') AND parent_object_id = OBJECT_ID(N'[dbo].[Common_Authen_RoleUser]'))
ALTER TABLE [dbo].[Common_Authen_RoleUser]  WITH CHECK ADD  CONSTRAINT [FK_Common_Authen_RoleUser_Common_Authen_User] FOREIGN KEY([UserID])
REFERENCES [dbo].[Common_Authen_User] ([UserID])
ON DELETE CASCADE
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_Common_Authen_RoleUser_Common_Authen_User]') AND parent_object_id = OBJECT_ID(N'[dbo].[Common_Authen_RoleUser]'))
ALTER TABLE [dbo].[Common_Authen_RoleUser] CHECK CONSTRAINT [FK_Common_Authen_RoleUser_Common_Authen_User]
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_Common_SiteMap_Menu_Common_SiteMap_Menu]') AND parent_object_id = OBJECT_ID(N'[dbo].[Common_SiteMap_Menu]'))
ALTER TABLE [dbo].[Common_SiteMap_Menu]  WITH CHECK ADD  CONSTRAINT [FK_Common_SiteMap_Menu_Common_SiteMap_Menu] FOREIGN KEY([ParentID])
REFERENCES [dbo].[Common_SiteMap_Menu] ([MenuID])
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_Common_SiteMap_Menu_Common_SiteMap_Menu]') AND parent_object_id = OBJECT_ID(N'[dbo].[Common_SiteMap_Menu]'))
ALTER TABLE [dbo].[Common_SiteMap_Menu] CHECK CONSTRAINT [FK_Common_SiteMap_Menu_Common_SiteMap_Menu]
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_Table_4_Table_2]') AND parent_object_id = OBJECT_ID(N'[dbo].[Table_4]'))
ALTER TABLE [dbo].[Table_4]  WITH CHECK ADD  CONSTRAINT [FK_Table_4_Table_2] FOREIGN KEY([pid])
REFERENCES [dbo].[Table_2] ([ID])
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_Table_4_Table_2]') AND parent_object_id = OBJECT_ID(N'[dbo].[Table_4]'))
ALTER TABLE [dbo].[Table_4] CHECK CONSTRAINT [FK_Table_4_Table_2]
GO
/****** Object:  StoredProcedure [dbo].[usp_GetUserPermissionLevel]    Script Date: 2019/3/25 17:00:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[usp_GetUserPermissionLevel]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[usp_GetUserPermissionLevel] AS' 
END
GO


-- =============================================
-- Author:		Kimi Yang
-- Create date: 2013-06-18
-- Description:	Get the User's Permission Level by Function Name
-- =============================================
ALTER PROCEDURE [dbo].[usp_GetUserPermissionLevel]
	-- Add the parameters for the stored procedure here
	@UserID int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

	SELECT DISTINCT
		  FPL.[FunctionName]
		, FPL.[PermissionLevel] AS [LevelName]
	FROM [dbo].[Common_Authen_RoleFunctionPermission] AS RFP
	INNER JOIN [dbo].[Common_Authen_FunctionPermissionLevel] AS FPL
		ON RFP.[PermissionLevelID] = FPL.ID
	INNER JOIN [dbo].[Common_Authen_RoleUser] AS ARU
		ON ARU.[RoleID] = RFP.[RoleID]
	WHERE ARU.[UserID] = @UserID

END




GO
/****** Object:  StoredProcedure [dbo].[usp_GetUserPermissionLevelByFunctionName]    Script Date: 2019/3/25 17:00:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[usp_GetUserPermissionLevelByFunctionName]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[usp_GetUserPermissionLevelByFunctionName] AS' 
END
GO


-- =============================================
-- Author:		Zack
-- Create date: 2019-03-25
-- Description:	Get the User's Permission Level by Function Name
-- =============================================
ALTER PROCEDURE [dbo].[usp_GetUserPermissionLevelByFunctionName]
	-- Add the parameters for the stored procedure here
	@UserID int,
	@FunctionName varchar(100)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

	SELECT DISTINCT
		  FPL.[FunctionName]
		, FPL.[PermissionLevel] AS [LevelName]
	FROM [dbo].[Common_Authen_RoleFunctionPermission] AS RFP
	INNER JOIN [dbo].[Common_Authen_FunctionPermissionLevel] AS FPL
		ON RFP.[PermissionLevelID] = FPL.ID
	INNER JOIN [dbo].[Common_Authen_RoleUser] AS ARU
		ON ARU.[RoleID] = RFP.[RoleID]
	WHERE ARU.[UserID] = @UserID AND FPL.[FunctionName] = @FunctionName

END




GO
ALTER DATABASE [EmsWebDB] SET  READ_WRITE 
GO
