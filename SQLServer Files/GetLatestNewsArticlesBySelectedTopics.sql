
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
