using BreakingMews.Models;
using BreakingNews.Data.Sql;
using BreakingNews.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utilities;

namespace BreakingNews.Entities
{
	public class ArticlesManager:BaseEntity
	{
		public ArticlesManager(LogManager logManager) : base(logManager)
		{
			LogManager.LogEvent("Articles Manager initialized");
		}

		public List<Article> GetArticles(List<Topic> selectedTopics)
		{
			// Extract the IDs from the selected topics
			List<int> topicIDS = selectedTopics.Select(t => t.TopicID).ToList();
			ArticlesSQL articlesSQL = new ArticlesSQL(LogManager);
			return articlesSQL.GetArticles(topicIDS);
			
		}

		public List<Article> GetExploreNews(List<Topic> selectedTopics)
		{
			// Extract the IDs from the selected topics
			List<int> topicIDS = selectedTopics.Select(t => t.TopicID).ToList();
			ArticlesSQL articlesSQL = new ArticlesSQL(LogManager);
			return articlesSQL.GetExploreNews(topicIDS);
		}

		public List<Article> GetTrendingNews(List<Topic> selectedTopics)
		{
			// Extract the IDs from the selected topics
			List<int> topicIDS = selectedTopics.Select(t => t.TopicID).ToList();
			ArticlesSQL articlesSQL = new ArticlesSQL(LogManager);
			return articlesSQL.GetTrendingNews(topicIDS);
		}

		public void UpdatePopularity(int articleID)
		{
			ArticlesSQL articlesSQL = new ArticlesSQL(LogManager);
			articlesSQL.UpdatePopularity(articleID);
		}
	}
}
