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
	public class MakoManager : NewsFeedHandler
	{
		public MakoManager(LogManager logManager) : base(logManager, NewsSources.Mako)
		{
			LogManager.LogEvent("Mako Manager initialized");
			Task.Run(GetLatestNewsAsync);
		}
	
		public override string ExtractDescriptionText(string description)
		{
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

