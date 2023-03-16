using BreakingMews.Models;
using BreakingNews.Entities;
using BreakingNews.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using System.Runtime.InteropServices.JavaScript;
using System.Text.Json;

namespace BreakingNews.WebApi.Controllers
{
	[ApiController]
	[Route("api/news-feed")]
	public class NewsFeedController : ControllerBase
	{

		[HttpPost("get")]
		public JsonResult GetNewsFeed(List<Topic> selectedTopics)
		{

			try
			{
				return new JsonResult(MainManager.Instance.ArticlesManager.GetArticles());
			}
			catch (Exception ex)
			{
				MainManager.Instance.LogManager.LogException(ex.Message, ex);
				return new JsonResult(ex.Message);
			}


		}


	}
}