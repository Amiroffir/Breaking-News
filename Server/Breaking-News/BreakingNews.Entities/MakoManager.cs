using System.Text.RegularExpressions;
using Utilities;

namespace BreakingNews.Entities
{
	public class MakoManager : NewsFeedHandler
	{
		public MakoManager(LogManager logManager) : base(logManager, NewsSources.Mako)
		{
			LogManager.LogEvent("Mako Manager initialized");
			Task.Run(GetLatestNewsAsync);
		}

		public override string ExtractDescriptionText(string description)
		{
			if (description == null || description == string.Empty)
			{
				return "";
			}
			string descText = description;
			Match match = Regex.Match(descText, @"<p>(.*?)</p>");
			if (match.Success)
			{
				string stringToRemove = match.Groups[0].Value;
				int index = descText.IndexOf(stringToRemove);
				descText = descText.Remove(index, stringToRemove.Length);
				return descText;
			}
			else
			{
				return "";
			}
		}
	}
}

