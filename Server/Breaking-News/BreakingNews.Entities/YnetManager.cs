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

		public override string ExtractDescriptionText(string description)
		{
			if (description == null || description == string.Empty)
			{
				return "";
			}

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
				return "";
			}
		}
	}
}

