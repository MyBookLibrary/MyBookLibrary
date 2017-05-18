USE [BookLibrary]
GO

INSERT INTO [dbo].[Books]
           ([Title]
           ,[Description]
           ,[Pages]
           ,[CreationDate]
           ,[PictureId]
           ,[AuthorId]
           ,[GenreId])
     VALUES
			('Misery', varchar(100),>
           ,<'Misery is a 1987 psychological horror thriller novel by Stephen King. The novel was nominated for the World Fantasy Award for Best Novel in 1988,[1] and was later made into a Hollywood film and an off-Broadway play of the same name.', varchar(500),>
           ,<111, int,>
           ,<'2017-05-17 21:05:59.000', datetime,>
           ,<1, int,>
           ,<1, int,>
           ,<2, int,>)
		   
INSERT INTO [dbo].[Books]
           ([Title]
           ,[Description]
           ,[Pages]
           ,[CreationDate]
           ,[PictureId]
           ,[AuthorId]
           ,[GenreId])
     VALUES
			('Steve Jobs', varchar(100),>
           ,<'Steve Jobs is the authorized self-titled biography book of Steve Jobs. The book was written at the request of Jobs by Walter Isaacson, a former executive at CNN and TIME who has written best-selling', varchar(500),>
           ,<555, int,>
           ,<'2017-05-17 22:23:01.000', datetime,>
           ,<4, int,>
           ,<2, int,>
           ,<3, int,>)

INSERT INTO [dbo].[Books]
           ([Title]
           ,[Description]
           ,[Pages]
           ,[CreationDate]
           ,[PictureId]
           ,[AuthorId]
           ,[GenreId])
     VALUES
			('The Comedy Book', varchar(100),>
           ,<'Best comedy books of all time (clockwise from left): Evelyn Waugh; cover of Stella Gibbonss Cold Comfort Farm, Helen Fielding author of Bridget Jones Diary; Rabelaiss Gargantua and Pantagruel', varchar(500),>
           ,<222, int,>
           ,<'2017-05-18 10:41:55.000', datetime,>
           ,<5, int,>
           ,<3, int,>
           ,<1, int,>)
		   
GO


