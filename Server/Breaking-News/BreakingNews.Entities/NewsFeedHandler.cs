using BreakingNews.Data.Sql;
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


		public async Task GetNewsFeedAsync()
		{
			while (true)
			{
				List<XmlDocument> xmlDocs = await GetAllRSSFeeds(Source);
				List<Article> articlesToDB = XmlDocsHandler(xmlDocs);
				InsertArticlesToDB(articlesToDB);
				Thread.Sleep(3600000);
			}
		}

		private void InsertArticlesToDB(List<Article> articlesToDB)
		{
			ArticlesSQL articlesSQL = new ArticlesSQL(LogManager);
			articlesSQL.InsertArticles(articlesToDB);
		}

		public async Task<List<XmlDocument>> GetAllRSSFeeds(NewsSources src)
		{
			List<XmlDocument> xmlDocs = new List<XmlDocument>();
			var tasks = new List<Task<string>>();
			List<string> rssLinks = MainManager.Instance.TopicsManager.GetTopicsBySource(src).Select(x => x.RSSLink).ToList();

			foreach (var url in rssLinks)
			{
				tasks.Add(GetRSSFeed(url));
			}

			var results = await Task.WhenAll(tasks);
			foreach (var res in results)
			{
				XmlDocument xmlDoc = new XmlDocument();
				xmlDoc.LoadXml(res);
				xmlDocs.Add(xmlDoc);
			}

			return xmlDocs;
		}

		public async Task<string> GetRSSFeed(string url)
		{
			try
			{
				using (var client = new HttpClient())
				{
					var response = await client.GetAsync(url);
					if (response.IsSuccessStatusCode)
					{
						return await response.Content.ReadAsStringAsync();
					}
					else
					{
						Exception ex = new Exception();
						LogManager.LogException("Error - " + response.StatusCode, ex);
						throw ex;
					}
				}
			}
			catch (Exception ex)
			{
				LogManager.LogException(ex.Message, ex);
				return null;
			}
		}
		
		public List<Article> XmlDocsHandler(List<XmlDocument> xmlDocuments)
		{
			List<Article> articlesToDB = new List<Article>();
			
			foreach (XmlDocument xmlDoc in xmlDocuments)
			{
				List<Article> articlesToAdd = XmlDocHandler(xmlDoc, MaxArticlesItems);
				articlesToDB.AddRange(articlesToAdd);
			}
			return articlesToDB;
		}
		
		public abstract List<Article> XmlDocHandler(XmlDocument xmlDoc, int maxArticles);
		
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
			return null;
		}

		public virtual string ExtractDescriptionText(string description)
		{
			string descText = description;
			Match match = Regex.Match(descText, @"<div>(.*?)</div>");
			if (match.Success)
			{
				string stringToRemove = match.Groups[0].Value;
				int index = descText.IndexOf(stringToRemove);
				descText = descText.Remove(index, stringToRemove.Length);
				return descText;
			}
			else
			{
				return null;
			}
		}

	}
}
