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
	public class MaarivManager : NewsFeedHandler
	{
		public MaarivManager(LogManager logManager) : base(logManager, NewsSources.Maariv)
		{
			LogManager.LogEvent("Maariv Manager initialized");
			Task.Run(GetLatestNewsAsync);
		}

		public override string ExtractDescriptionText(string description)
		{
			string descText = description;
			HtmlDocument doc = new HtmlDocument();
			doc.LoadHtml(description);
			return doc.DocumentNode.InnerText.Trim();
		}
	}
}

