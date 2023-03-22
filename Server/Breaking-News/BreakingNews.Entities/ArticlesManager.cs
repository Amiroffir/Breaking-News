using BreakingMews.Models;
using BreakingNews.Data.Sql;
using BreakingNews.Models;
using Utilities;

namespace BreakingNews.Entities
{
	public class ArticlesManager : BaseEntity
	{
		public ArticlesManager(LogManager logManager) : base(logManager)
		{
			LogManager.LogEvent("Articles Manager initialized");
		}

		public List<Article> GetArticles(List<Topic> selectedTopics)
		{
			try
			{
				if (!IsSelectedTopicsValid(selectedTopics))
				{
					LogManager.LogEvent("No topics selected");
					return new List<Article>();
				}
				// Extract the IDs from the selected topics
				List<int> topicIDS = selectedTopics.Select(t => t.TopicID).ToList();
				ArticlesSQL articlesSQL = new ArticlesSQL(LogManager);
				return articlesSQL.GetArticles(topicIDS);
			}
			catch (Exception ex)
			{
				LogManager.LogException(ex.Message, ex);
				throw;
			}

		}

		public List<Article> GetExploreNews(List<Topic> selectedTopics)
		{
			try
			{
				if (!IsSelectedTopicsValid(selectedTopics))
				{
					LogManager.LogEvent("No topics selected");
					return new List<Article>();
				}
				List<int> topicIDS = selectedTopics.Select(t => t.TopicID).ToList();
				ArticlesSQL articlesSQL = new ArticlesSQL(LogManager);
				return articlesSQL.GetExploreNews(topicIDS);
			}
			catch (Exception ex)
			{
				LogManager.LogException(ex.Message, ex);
				throw;
			}
		}

		public List<Article> GetTrendingNews(List<Topic> selectedTopics)
		{
			try
			{
				if (!IsSelectedTopicsValid(selectedTopics))
				{
					LogManager.LogEvent("No topics selected");
					return new List<Article>();
				}
				List<int> topicIDS = selectedTopics.Select(t => t.TopicID).ToList();
				ArticlesSQL articlesSQL = new ArticlesSQL(LogManager);
				return articlesSQL.GetTrendingNews(topicIDS);
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
				ArticlesSQL articlesSQL = new ArticlesSQL(LogManager);
				articlesSQL.UpdatePopularity(articleID);
			}
			catch (Exception ex)
			{
				LogManager.LogException(ex.Message, ex);
				throw;
			}
		}

		private bool IsSelectedTopicsValid(List<Topic> listToCheck)
		{
			if (listToCheck == null || listToCheck.Count == 0)
			{
				return false;
			}
			return true;
		}
	}
}
