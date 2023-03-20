--select * from Articles
--select * from Topics
--select * from TopicsIndex


--delete from Articles where id > 500

Alter procedure GetLatestNewsArticlesBySelectedTopics @topicIDS nvarchar(20)
AS 
BEGIN
declare @command nvarchar(1000)
set @command = 'SELECT *
FROM (
  SELECT *, ROW_NUMBER() OVER (PARTITION BY newsSource, Topic ORDER BY id DESC) AS RowNum
  FROM Articles
  WHERE Topic IN ('+ @topicIDS + ')
) AS subquery
WHERE subquery.RowNum <= 10'

EXEC sp_executesql @command
END

Exec GetLatestNewsArticlesBySelectedTopics '1,3'






SELECT *
FROM (
  SELECT *, ROW_NUMBER() OVER (PARTITION BY newsSource ORDER BY id DESC) AS RowNum
  FROM Articles
  WHERE Topic IN ('+ @topicIDS + ')
) AS subquery
WHERE subquery.RowNum <= 10;
END


EXEC GetLatestNewsArticlesBySelectedTopics '1,2,5'


SET NOCOUNT ON;
	DECLARE @sql nvarchar(1000)
	SET @sql = 'SELECT * FROM Articles WHERE Topic IN (' + @topicIDS + ') ORDER BY id DESC'
	EXEC sp_executesql @sql