using HtmlAgilityPack;
using Utilities;

namespace BreakingNews.Entities
{
	public class WallaManager : NewsFeedHandler
	{
		public WallaManager(LogManager logManager) : base(logManager, NewsSources.Walla)
		{
			LogManager.LogEvent("Walla Manager initialized");
			Task.Run(GetLatestNewsAsync);
		}

		public override string ExtractDescriptionText(string description)
		{
			if (description == null || description == string.Empty)
			{
				return "";
			}

			HtmlDocument doc = new HtmlDocument();
			doc.LoadHtml(description);
			string innerText = doc.DocumentNode.SelectSingleNode("//p").InnerText;

			// Handle the case where the description is too long
			if (innerText.Length > 255)
			{
				innerText = innerText.Substring(0, 255);
			}
			return innerText;
		}
	}
}

