USE [BookLibrary]
GO

-- =============================================
-- Author:		<ATo,Alexander Toplijski>
-- Create date: <18.05.2017>
-- Description:	<for the Book Library inteview task,>
-- =============================================
IF NOT EXISTS (SELECT * FROM sys.objects WHERE type = 'P' AND OBJECT_ID = OBJECT_ID('dbo.usp_InsertBook'))
   EXEC('CREATE PROCEDURE [dbo].[usp_InsertBook] @Title varchar(50), @Description varchar(500), @Pages int, @CreationDate datetime, @AuthorId int, @GenreId int, @PictureId int AS BEGIN SET NOCOUNT ON; END')
GO

-- datetime, @AuthorId int, @GenreId int, @PictureId int
--string Title { get; set; }
--        string Description { get; set; }
--        int Pages { get; set; }
--        DateTime CreationDate { get; set; }
--        int AuthorId { get; set; }
--        int GenreId { get; set; }
--        int PictureId { get; set; }


ALTER PROCEDURE [dbo].[usp_InsertBook]
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



