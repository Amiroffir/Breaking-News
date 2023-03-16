using BreakingNews.Data.Sql;
using BreakingNews.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utilities;

namespace BreakingNews.Entities
{
	public class ArticlesManager:BaseEntity
	{
		public ArticlesManager(LogManager logManager) : base(logManager)
		{
			LogManager.LogEvent("Articles Manager initialized");
		}

		public List<Article> GetArticles()
		{
			ArticlesSQL articlesSQL = new ArticlesSQL(LogManager);
			return articlesSQL.GetArticles();
			
		}
	}
}
