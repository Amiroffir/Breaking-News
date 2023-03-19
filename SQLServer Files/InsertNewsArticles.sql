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
CREATE PROCEDURE dbo.InsertNewsArticles
	@NewsArticles dbo.NewsArticle READONLY
    AS
    BEGIN
		INSERT INTO dbo.Articles (newsSource, headline, [desc], link, [image], Topic)
		SELECT NewsSource, Headline, [Description], Link, ImgUrl, TopicID
		FROM @NewsArticles
	END
    