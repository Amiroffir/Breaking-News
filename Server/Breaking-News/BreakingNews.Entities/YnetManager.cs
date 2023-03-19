using BreakingNews.Data.Sql.Services;
using BreakingNews.Models;
using System.Text.RegularExpressions;
using System.Xml;
using Utilities;

namespace BreakingNews.Entities
{
	public class YnetManager : NewsFeedHandler
	{
		public YnetManager(LogManager logManager) : base(logManager, NewsSources.Ynet)
		{
	
			LogManager.LogEvent("Ynet Manager initialized");
			Task.Run(GetLatestNewsAsync);
		}

		//public override List<Article> XmlDocHandler(XmlDocument xmlDoc, int maxArticles,int topicID)
		//{
		//	if (xmlDoc == null)
		//	{
		//		return null;
		//	}
			
		//	List<Article> mappedArticles = new List<Article>();
		//	XmlNodeList itemNodes = xmlDoc.SelectNodes("//item");
			
		//	// loop through the item nodes and extract them into Article properties with AutoMapper
		//	foreach (XmlNode item in itemNodes)
		//	{
		//		Article mappedArticle = new Article();

		//		// Map the XmlNode to an Article object
		//		mappedArticle = Mappers.ArticleMapper.Mapper.Map(item, mappedArticle);

		//		// Additional custom mapping
		//		mappedArticle.ImgUrl = ExtractImage(mappedArticle.ImgUrl);
		//		mappedArticle.Description = ExtractDescriptionText(mappedArticle.Description);
		//		mappedArticle.NewsSource = (int)NewsSources.Ynet;
		//		mappedArticle.TopicID = topicID;

		//		// Add the article to the list
		//		mappedArticles.Add(mappedArticle);

		//		if (mappedArticles.Count() == 10)
		//		{
		//			break; 
		//		}
		//	}		
		//	return mappedArticles;
		//}
		
		public override string ExtractDescriptionText(string description)
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

