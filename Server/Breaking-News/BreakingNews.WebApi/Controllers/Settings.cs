using BreakingNews.Entities;
using Microsoft.AspNetCore.Mvc;

namespace BreakingNews.WebApi.Controllers
{
	[Route("api/settings")]
	[ApiController]
	public class Settings : ControllerBase
	{
		// GET: api/<ValuesController>
		[HttpGet("get-topics")]
		public JsonResult GetOptionalTopics()
		{
			try
			{
				return new JsonResult(MainManager.Instance.TopicsManager.GetOptionalTopics());
			}
			catch (Exception ex)
			{
				MainManager.Instance.LogManager.LogException(ex.Message, ex);
				return new JsonResult(ex.Message);
			}
		}
	}
}
