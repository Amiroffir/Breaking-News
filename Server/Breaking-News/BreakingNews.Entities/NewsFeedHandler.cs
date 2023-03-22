using BreakingMews.Models;
using BreakingNews.Data.Sql;
using BreakingNews.Data.Sql.Services;
using BreakingNews.Models;
using System.Text.RegularExpressions;
using System.Xml;
using Utilities;

namespace BreakingNews.Entities
{
	public abstract class NewsFeedHandler : BaseEntity
	{
		public NewsFeedHandler(LogManager logManager, NewsSources source) : base(logManager)
		{
			LogManager.LogEvent("NewsFeedHandler initialized");
			Source = source;
		}

		const int MaxArticlesItems = 10; // max articles to be retrieved from each topic
		private NewsSources Source;

		public async Task GetLatestNewsAsync()
		{
			while (true)
			{
				try
				{
					List<List<Article>> articlesToDB = await GetAllRSSFeeds(Source);
					InsertArticlesToDB(articlesToDB);
					Thread.Sleep(3600000); // Thread sleeps for 1 hour
				}

				catch (Exception ex)
				{
					LogManager.LogException(ex.Message, ex);
				}

			}
		}

		/// <summary>
		/// Get all the articles from RSS links, then insert them into list of lists ordered by topic
		/// </summary>
		public async Task<List<List<Article>>> GetAllRSSFeeds(NewsSources src)
		{
			try
			{
				var parallelTasks = new List<Task<List<Article>>>(); // list of tasks to be executed in parallel
				List<Topic> topicsBySource = MainManager.Instance.TopicsManager.GetTopicsBySource(src).ToList(); // get all topics for the source

				foreach (Topic topic in topicsBySource)
				{
					parallelTasks.Add(GetRSSFeed(topic));
				}

				var results = await Task.WhenAll(parallelTasks);
				return results.ToList();
			}
			catch (Exception ex)
			{
				LogManager.LogException("Error in GetAllRSSFeeds: " + ex.Message, ex);
				return null;
			}
		}

		/// <summary>
		/// Get all the articles from RSS link by topic
		/// </summary>
		public async Task<List<Article>> GetRSSFeed(Topic topic)
		{
			try
			{
				using (var client = new HttpClient())
				{
					var response = await client.GetAsync(topic.RSSLink);
					if (response.IsSuccessStatusCode)
					{
						List<Article> articlesByTopic;
						XmlDocument xmlDoc = new XmlDocument();

						xmlDoc.LoadXml(await response.Content.ReadAsStringAsync());
						articlesByTopic = XmlDocHandler(xmlDoc, MaxArticlesItems, topic.TopicID, (int)Source);

						return articlesByTopic;
					}
					else
					{
						Exception ex = new Exception();
						LogManager.LogException("Error - " + response.StatusCode, ex);
						return null;
					}
				}
			}
			catch (Exception ex)
			{
				LogManager.LogException(ex.Message, ex);
				return null;
			}
		}

		/// <summary>
		///  Handle the XML document and return a list of articles
		///  </summary>
		public virtual List<Article> XmlDocHandler(XmlDocument xmlDoc, int maxArticles, int topicID, int srcID)
		{
			if (xmlDoc == null)
			{
				return null;
			}

			List<Article> mappedArticles = new List<Article>();
			XmlNodeList itemNodes = xmlDoc.SelectNodes("//item");

			// loop through the item nodes and extract them into Article properties with AutoMapper
			foreach (XmlNode item in itemNodes)
			{
				// Map the XmlNode to an Article object
				Article mappedArticle = Mappers.ArticleMapper.Map(item);

				// Additional custom mapping
				mappedArticle.ImgUrl = ExtractImage(mappedArticle.ImgUrl);
				mappedArticle.Description = ExtractDescriptionText(mappedArticle.Description);
				mappedArticle.NewsSource = srcID;
				mappedArticle.TopicID = topicID;

				// Add the article to the list
				mappedArticles.Add(mappedArticle);

				if (mappedArticles.Count() == 10)
				{
					break;
				}
			}
			return mappedArticles;
		}

		public virtual string ExtractImage(string Node)
		{
			if (Node != null)
			{
				string description = Node;
				// Regular expressions
				Match match = Regex.Match(description, @"<img.+?src=[\""'](.+?)[\""'].*?>");
				if (match.Success)
				{
					return match.Groups[1].Value;
				}
			}
			return "";
		}

		public abstract string ExtractDescriptionText(string description);

		private void InsertArticlesToDB(List<List<Article>> articlesToDB)
		{
			try
			{
				ArticlesSQL articlesSQL = new ArticlesSQL(LogManager);
				articlesSQL.InsertArticles(articlesToDB);
			}

			catch (Exception ex)
			{
				LogManager.LogException(ex.Message, ex);
			}
		}
	}
}
