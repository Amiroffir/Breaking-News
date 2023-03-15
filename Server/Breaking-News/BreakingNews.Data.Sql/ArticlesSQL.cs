using BreakingNews.DAL;
using BreakingNews.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utilities;

namespace BreakingNews.Data.Sql
{
	public class ArticlesSQL: BaseSQL
	{
		public ArticlesSQL(LogManager logManager) : base(logManager) { }

		public void InsertArticles(List<Article> articlesToDB)
		{
			foreach (Article article in articlesToDB)
			{
				string a; // To dubugging To delete
				try
				{
					// To dubugging To delete
					a = $"Insert into Articles (newsSource, [image], headline, [desc],link) values ({article.NewsSource},'{article.ImgUrl}','{article.Headline}','{article.Description}','{article.Link}')";
					SQLQuery.RunNonQuery($"Insert into Articles (newsSource, [image], headline, [desc],link) values ({article.NewsSource},'{article.ImgUrl}','{article.Headline.Replace("'", "")}','{article.Description.Replace("'","")}','{article.Link}')");
				}
				catch (Exception ex)
				{
					a = ""; // To dubugging To delete
					LogManager.LogException(ex.Message, ex);
					throw;
				}
			}
		}
	}
	
}
