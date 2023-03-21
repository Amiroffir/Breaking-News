using HtmlAgilityPack;
using Utilities;

namespace BreakingNews.Entities
{
	public class MaarivManager : NewsFeedHandler
	{
		public MaarivManager(LogManager logManager) : base(logManager, NewsSources.Maariv)
		{
			LogManager.LogEvent("Maariv Manager initialized");
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
			return doc.DocumentNode.InnerText.Trim();
		}
	}
}

