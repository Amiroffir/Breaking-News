using BreakingMews.Models;
using BreakingNews.Entities;
using Microsoft.AspNetCore.Mvc;

namespace BreakingNews.WebApi.Controllers
{
	[ApiController]
	[Route("api/explore")]
	public class ExploreController : ControllerBase
	{

		[HttpPost("get")]
		public JsonResult GetTrending(List<Topic> selectedTopics)
		{
			try
			{
				return new JsonResult(MainManager.Instance.ArticlesManager.GetExploreNews(selectedTopics));
			}
			catch (Exception ex)
			{
				MainManager.Instance.LogManager.LogException(ex.Message, ex);
				return new JsonResult(ex.Message);
			}
		}
	}
}