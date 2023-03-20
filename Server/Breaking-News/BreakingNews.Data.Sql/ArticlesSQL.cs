using BreakingMews.Models;
using BreakingNews.DAL;
using BreakingNews.Models;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using Utilities;

namespace BreakingNews.Data.Sql
{
	public class ArticlesSQL : BaseSQL
	{
		public ArticlesSQL(LogManager logManager) : base(logManager) { }
		
		public List<Article> GetArticles(List<int> selectedTopics)
		{

			string topicIDS = string.Join(",", selectedTopics);
			List<Article> articles = new List<Article>();
			try
			{
				
			articles =	(List<Article>)SQLQuery.RunCommandResult($"GetLatestNewsArticlesBySelectedTopics '{topicIDS}';", MapDataIntoArticles);
			}
			catch (Exception ex)
			{
				LogManager.LogException(ex.Message, ex);
			}
			return articles;
		}

		public void InsertArticles(List<List<Article>> articlesToDB)
		{

			DataTable table = ConvertToDataTable(articlesToDB);
			try
			{
				SQLQuery.RunNonQueryWithTVP("InsertNewsArticles", "@NewsArticles", table);
			}
			catch (Exception ex)
			{
				LogManager.LogException(ex.Message, ex);
				throw;
			}
		}

		public void UpdatePopularity(int articleID)
		{
			try
			{
				SQLQuery.RunNonQuery($"UpdateNewsArticlePopularity {articleID}");
			}
			catch (Exception ex)
			{
				LogManager.LogException(ex.Message, ex);
				throw;
			}
		}

		public List<Article> GetTrendingNews(List<int> topicIDS)
		{
			string topicIDSString = string.Join(",", topicIDS);
			List<Article> articles = new List<Article>();
			try
			{
				articles = (List<Article>)SQLQuery.RunCommandResult($"GetTrendingNews '{topicIDSString}'", MapDataIntoArticles);
			}
			catch (Exception ex)
			{
				LogManager.LogException(ex.Message, ex);
			}
			return articles;
		}

		private object MapDataIntoArticles(SqlDataReader reader)
		{
			List<Article> articlesList = new List<Article>();

			while (reader.Read())
			{

				Article articleToAdd = new Article();
				Services.Mappers.ArticleMapper.DBMapper.Map(reader, articleToAdd);
				articlesList.Add(articleToAdd);
			}
			return articlesList;
		}
		
		private DataTable ConvertToDataTable(List<List<Article>> articles)
		{
			// Create a new DataTable.
			DataTable table = new DataTable();
			table.Columns.Add("NewsSource", typeof(int));
			table.Columns.Add("Headline", typeof(string));
			table.Columns.Add("Description", typeof(string));
			table.Columns.Add("Link", typeof(string));
			table.Columns.Add("ImgUrl", typeof(string));
			table.Columns.Add("TopicID", typeof(int));

			foreach (List<Article> articlesByTopic in articles)
			{
				if (articlesByTopic != null)
				{
					foreach (Article article in articlesByTopic)
					{
						table.Rows.Add(article.NewsSource, article.Headline, article.Description, article.Link, article.ImgUrl, article.TopicID);
					}
				}
			}
			return table;
		}

		public List<Article> GetExploreNews(List<int> topicIDS)
		{
			string topicIDSString = string.Join(",", topicIDS);
			List<Article> articles = new List<Article>();
			try
			{
				articles = (List<Article>)SQLQuery.RunCommandResult($"GetExploreNews '{topicIDSString}'", MapDataIntoArticles);
			}
			catch (Exception ex)
			{
				LogManager.LogException(ex.Message, ex);
			}
			return articles;
		}
	}
}
