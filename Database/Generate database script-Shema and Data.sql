USE [master]
GO
/****** Object:  Database [BookLibrary]    Script Date: 18.5.2017 г. 11:34:53 ч. ******/
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
/****** Object:  User [booklibrary]    Script Date: 18.5.2017 г. 11:34:53 ч. ******/
CREATE USER [booklibrary] FOR LOGIN [booklibrary] WITH DEFAULT_SCHEMA=[dbo]
GO
ALTER ROLE [db_owner] ADD MEMBER [booklibrary]
GO
/****** Object:  Table [dbo].[Authors]    Script Date: 18.5.2017 г. 11:34:53 ч. ******/
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
/****** Object:  Table [dbo].[Books]    Script Date: 18.5.2017 г. 11:34:53 ч. ******/
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
/****** Object:  Table [dbo].[Genres]    Script Date: 18.5.2017 г. 11:34:53 ч. ******/
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
/****** Object:  Table [dbo].[Pictures]    Script Date: 18.5.2017 г. 11:34:53 ч. ******/
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
	[Url] [varchar](500) NULL,
 CONSTRAINT [PK_Pictures] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
INSERT [dbo].[Authors] ([Id], [FirstName], [LastName]) VALUES (1, N'Stephen', N'King')
INSERT [dbo].[Authors] ([Id], [FirstName], [LastName]) VALUES (2, N'Steave', N'Jobs')
INSERT [dbo].[Authors] ([Id], [FirstName], [LastName]) VALUES (3, N'Mark', N'Antony')
SET IDENTITY_INSERT [dbo].[Books] ON 

INSERT [dbo].[Books] ([Id], [Title], [Description], [Pages], [CreationDate], [PictureId], [AuthorId], [GenreId]) VALUES (1, N'Misery', N'Misery is a 1987 psychological horror thriller novel by Stephen King. The novel was nominated for the World Fantasy Award for Best Novel in 1988,[1] and was later made into a Hollywood film and an off-Broadway play of the same name.', 111, CAST(N'2017-05-17 21:05:59.000' AS DateTime), 1, 1, 2)
INSERT [dbo].[Books] ([Id], [Title], [Description], [Pages], [CreationDate], [PictureId], [AuthorId], [GenreId]) VALUES (2, N'Steve Jobs', N'Steve Jobs is the authorized self-titled biography book of Steve Jobs. The book was written at the request of Jobs by Walter Isaacson, a former executive at CNN and TIME who has written best-selling', 555, CAST(N'2017-05-17 22:23:01.000' AS DateTime), 4, 2, 3)
INSERT [dbo].[Books] ([Id], [Title], [Description], [Pages], [CreationDate], [PictureId], [AuthorId], [GenreId]) VALUES (8, N'The Comedy Book', N'Best comedy books of all time (clockwise from left): Evelyn Waugh; cover of Stella Gibbons''s Cold Comfort Farm, Helen Fielding author of Bridget Jones''s Diary; Rabelais''s Gargantua and Pantagruel', 222, CAST(N'2017-05-18 10:41:55.000' AS DateTime), 5, 3, 1)
SET IDENTITY_INSERT [dbo].[Books] OFF
INSERT [dbo].[Genres] ([Id], [Name]) VALUES (1, N'Comedy')
INSERT [dbo].[Genres] ([Id], [Name]) VALUES (2, N'Horror')
INSERT [dbo].[Genres] ([Id], [Name]) VALUES (3, N'Biography')
INSERT [dbo].[Genres] ([Id], [Name]) VALUES (4, N'Classics')
SET IDENTITY_INSERT [dbo].[Pictures] ON 

INSERT [dbo].[Pictures] ([Id], [Name], [Width], [Height], [SizeMb], [Url]) VALUES (1, N'Misery Cover', 100, 150, 3, N'http://localhost:60020/Uploads/Covers/Stephen_King_Misery_cover.jpg')
INSERT [dbo].[Pictures] ([Id], [Name], [Width], [Height], [SizeMb], [Url]) VALUES (4, N'Steve Jobs cover', 100, 150, 2, N'http://localhost:60020/Uploads/Covers/Setve Jobs Cover.jpg')
INSERT [dbo].[Pictures] ([Id], [Name], [Width], [Height], [SizeMb], [Url]) VALUES (5, N'The Comedy Book Cover', 100, 150, 4, N'http://localhost:60020/Uploads/Covers/The Comedy Book Cover.jpg')
SET IDENTITY_INSERT [dbo].[Pictures] OFF
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
/****** Object:  StoredProcedure [dbo].[usp_InsertBook]    Script Date: 18.5.2017 г. 11:34:53 ч. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

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
