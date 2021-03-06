USE [master]
GO
/****** Object:  Database [BookLibrary]    Script Date: 18.5.2017 г. 02:18:54 ч. ******/
CREATE DATABASE [BookLibrary]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'BookLibrary', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL12.MSSQLSERVER\MSSQL\DATA\BookLibrary.mdf' , SIZE = 5120KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'BookLibrary_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL12.MSSQLSERVER\MSSQL\DATA\BookLibrary_log.ldf' , SIZE = 1024KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [BookLibrary] SET COMPATIBILITY_LEVEL = 120
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [BookLibrary].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [BookLibrary] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [BookLibrary] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [BookLibrary] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [BookLibrary] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [BookLibrary] SET ARITHABORT OFF 
GO
ALTER DATABASE [BookLibrary] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [BookLibrary] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [BookLibrary] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [BookLibrary] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [BookLibrary] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [BookLibrary] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [BookLibrary] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [BookLibrary] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [BookLibrary] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [BookLibrary] SET  DISABLE_BROKER 
GO
ALTER DATABASE [BookLibrary] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [BookLibrary] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [BookLibrary] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [BookLibrary] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [BookLibrary] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [BookLibrary] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [BookLibrary] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [BookLibrary] SET RECOVERY FULL 
GO
ALTER DATABASE [BookLibrary] SET  MULTI_USER 
GO
ALTER DATABASE [BookLibrary] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [BookLibrary] SET DB_CHAINING OFF 
GO
ALTER DATABASE [BookLibrary] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [BookLibrary] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
ALTER DATABASE [BookLibrary] SET DELAYED_DURABILITY = DISABLED 
GO
EXEC sys.sp_db_vardecimal_storage_format N'BookLibrary', N'ON'
GO
USE [BookLibrary]
GO
/****** Object:  User [booklibrary]    Script Date: 18.5.2017 г. 02:18:54 ч. ******/
CREATE USER [booklibrary] FOR LOGIN [booklibrary] WITH DEFAULT_SCHEMA=[dbo]
GO
ALTER ROLE [db_owner] ADD MEMBER [booklibrary]
GO
/****** Object:  Table [dbo].[Authors]    Script Date: 18.5.2017 г. 02:18:54 ч. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Authors](
	[Id] [int] NOT NULL,
	[FirstName] [varchar](50) NOT NULL,
	[LastName] [varchar](50) NULL,
 CONSTRAINT [PK_Authors] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Books]    Script Date: 18.5.2017 г. 02:18:54 ч. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Books](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Title] [varchar](100) NOT NULL,
	[Description] [varchar](500) NULL,
	[Pages] [int] NOT NULL,
	[CreationDate] [datetime] NOT NULL,
	[PictureId] [int] NULL,
	[AuthorId] [int] NULL,
	[GenreId] [int] NULL,
 CONSTRAINT [PK_Books] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Genres]    Script Date: 18.5.2017 г. 02:18:54 ч. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Genres](
	[Id] [int] NOT NULL,
	[Name] [varchar](50) NOT NULL,
 CONSTRAINT [PK_Genres] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Pictures]    Script Date: 18.5.2017 г. 02:18:54 ч. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Pictures](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](50) NULL,
	[Width] [int] NULL,
	[Height] [int] NULL,
	[SizeMb] [int] NULL,
	[Url] [varchar](50) NULL,
 CONSTRAINT [PK_Pictures] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
ALTER TABLE [dbo].[Books]  WITH CHECK ADD  CONSTRAINT [FK_Books_Authors] FOREIGN KEY([AuthorId])
REFERENCES [dbo].[Authors] ([Id])
GO
ALTER TABLE [dbo].[Books] CHECK CONSTRAINT [FK_Books_Authors]
GO
ALTER TABLE [dbo].[Books]  WITH CHECK ADD  CONSTRAINT [FK_Books_Genres] FOREIGN KEY([GenreId])
REFERENCES [dbo].[Genres] ([Id])
GO
ALTER TABLE [dbo].[Books] CHECK CONSTRAINT [FK_Books_Genres]
GO
ALTER TABLE [dbo].[Books]  WITH CHECK ADD  CONSTRAINT [FK_Books_Pictures] FOREIGN KEY([PictureId])
REFERENCES [dbo].[Pictures] ([Id])
GO
ALTER TABLE [dbo].[Books] CHECK CONSTRAINT [FK_Books_Pictures]
GO
/****** Object:  StoredProcedure [dbo].[usp_InsertBook]    Script Date: 18.5.2017 г. 02:18:54 ч. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- datetime, @AuthorId int, @GenreId int, @PictureId int
--string Title { get; set; }
--        string Description { get; set; }
--        int Pages { get; set; }
--        DateTime CreationDate { get; set; }
--        int AuthorId { get; set; }
--        int GenreId { get; set; }
--        int PictureId { get; set; }


CREATE PROCEDURE [dbo].[usp_InsertBook]
	@Title varchar(50)
	,@Description varchar(500)
	,@Pages int
	,@CreationDate datetime
	,@AuthorId int
	,@GenreId int
	,@PictureId int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

	INSERT INTO Books ([Title], [Description], [Pages], [CreationDate], [AuthorId], [GenreId], [PictureId])
		VALUES (@Title, @Description, @Pages, @CreationDate, @AuthorId, @GenreId, @PictureId);		
END

GO
USE [master]
GO
ALTER DATABASE [BookLibrary] SET  READ_WRITE 
GO
