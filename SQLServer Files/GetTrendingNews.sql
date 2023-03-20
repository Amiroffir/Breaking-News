Alter procedure GetTrendingNews @topicIDS nvarchar(10)
AS
BEGIN
	declare @command nvarchar(1000)
	set @command = 
		'SELECT Top 10 * From Articles
		WHERE Topic IN ('+ @topicIDS + ') AND TimesClicked > 0
		ORDER BY TimesClicked DESC'
		
		EXEC sp_executesql @command
		END
	

	