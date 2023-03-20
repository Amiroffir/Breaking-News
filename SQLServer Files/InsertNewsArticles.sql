--- User defined Type that will be able to accept a table as a parameter
--CREATE TYPE dbo.NewsArticle AS TABLE
--(
--    NewsSource int,
--    Headline nvarchar(255),
--    Description nvarchar(max),
--    Link nvarchar(255),
--    ImgUrl nvarchar(255),
--    TopicID int
--);

-- Stored procedure that will accept a table as a parameter
alter PROCEDURE dbo.InsertNewsArticles

	@NewsArticles dbo.NewsArticle READONLY
	
    AS
    BEGIN
 CREATE table #temp (
 newsSource int,
 headline nvarchar(500), [desc] nvarchar(500), link nvarchar(500), [image] nvarchar(500), Topic int )

 INSERT INTO #temp (newsSource, headline, [desc], link, [image], Topic)
 SELECT NewsSource, Headline, [Description], Link, ImgUrl, TopicID FROM @NewsArticles

		INSERT INTO dbo.Articles (newsSource, headline, [desc], link, [image], Topic)
		SELECT newsSource, headline, [desc], link, [image],Topic
		FROM #temp WHERE NOT EXISTS (
		SELECT 1 
		FROM Articles
		WHERE Articles.link = #temp.link
		)

		drop table #temp
	END
    