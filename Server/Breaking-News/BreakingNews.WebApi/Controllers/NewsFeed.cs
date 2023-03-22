using BreakingMews.Models;
using BreakingNews.Entities;
using Microsoft.AspNetCore.Mvc;

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
				return new JsonResult(MainManager.Instance.ArticlesManager.GetArticles(selectedTopics));
			}
			catch (Exception ex)
			{
				MainManager.Instance.LogManager.LogException(ex.Message, ex);
				return new JsonResult(ex.Message);
			}
		}

		[HttpPut("update-popularity/{articleID}")]
		public JsonResult UpdatePopularity(int articleID)
		{
			try
			{
				MainManager.Instance.ArticlesManager.UpdatePopularity(articleID);
				return new JsonResult("OK");
			}
			catch (Exception ex)
			{
				MainManager.Instance.LogManager.LogException(ex.Message, ex);
				return new JsonResult(ex.Message);
			}
		}
	}
}