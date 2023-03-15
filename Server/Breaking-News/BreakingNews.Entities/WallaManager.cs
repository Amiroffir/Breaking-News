using BreakingNews.Data.Sql.Services;
using BreakingNews.Models;
using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Xml;
using Utilities;

namespace BreakingNews.Entities
{
	public class WallaManager : NewsFeedHandler
	{
		public WallaManager(LogManager logManager) : base(logManager, NewsSources.Walla)
		{
			LogManager.LogEvent("Walla Manager initialized");
			Task.Run(GetNewsFeedAsync);
		}

		public override List<Article> XmlDocHandler(XmlDocument xmlDoc, int maxArticles)
		{
			List<Article> mappedArticles = new List<Article>();
			XmlNodeList itemNodes = xmlDoc.SelectNodes("//item");

			// loop through the item nodes and extract them into Article properties with AutoMapper

			foreach (XmlNode item in itemNodes)
			{
				Article mappedArticle = new Article();

				// Map the XmlNode to an Article object
				mappedArticle = Mappers.ArticleMapper.Mapper.Map(item, mappedArticle);

				// Additional custom mapping
				mappedArticle.ImgUrl = ExtractImage(mappedArticle.ImgUrl);
				mappedArticle.Description = ExtractDescriptionText(mappedArticle.Description);
				mappedArticle.NewsSource = (int)NewsSources.Walla;

				// Add the article to the list
				mappedArticles.Add(mappedArticle);

				if (mappedArticles.Count() == 10)
				{
					break;
				}

			}
			// Todo: To send every article to another function that send to DB 
			// Or return list of 10 and handle it in the main function
			return mappedArticles;
		}
		public override string ExtractDescriptionText(string description)
		{
			HtmlDocument doc = new HtmlDocument();
			doc.LoadHtml(description);
			string innerText = doc.DocumentNode.SelectSingleNode("//p").InnerText;
			return innerText;
		}
	}
}

