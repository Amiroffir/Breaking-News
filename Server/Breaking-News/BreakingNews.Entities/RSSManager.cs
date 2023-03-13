using BreakingMews.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Xml;
using Utilities;

namespace BreakingNews.Entities
{
	public class RSSManager : BaseEntity
	{
		public RSSManager(LogManager logManager) : base(logManager)
		{
			LogManager.LogEvent("RSS Manager initialized");
			Task.Run(GetNewsFeed);
		}

		public async Task GetNewsFeed()
		{
			while (true)
			{
				LogManager.LogEvent("Hourly News Scan is started");
				List<XmlDocument> xmlDocs = await GetAllRSSFeeds();
				Thread.Sleep(3600000);
			}
		}

		public async Task<List<XmlDocument>> GetAllRSSFeeds()
		{
			List<XmlDocument> xmlDocs = new List<XmlDocument>();
			var urls = new List<string> { "https://rss.walla.co.il/feed/156", "https://rss.walla.co.il/feed/151", "https://rss.walla.co.il/feed/4712" };

			var tasks = new List<Task<string>>();
			foreach (var url in urls)
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
	}
}

