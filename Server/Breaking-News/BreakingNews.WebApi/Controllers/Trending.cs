using BreakingMews.Models;
using BreakingNews.Entities;
using Microsoft.AspNetCore.Mvc;

namespace BreakingNews.WebApi.Controllers
{
	[ApiController]
	[Route("api/trending")]
	public class TrendingController : ControllerBase
	{

		[HttpPost("get")]
		public JsonResult GetTrending(List<Topic> selectedTopics)
		{
			try
			{
				return new JsonResult(MainManager.Instance.ArticlesManager.GetTrendingNews(selectedTopics));
			}
			catch (Exception ex)
			{
				MainManager.Instance.LogManager.LogException(ex.Message, ex);
				return new JsonResult(ex.Message);
			}
		}
	}
}