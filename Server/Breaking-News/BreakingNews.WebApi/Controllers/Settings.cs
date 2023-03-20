using BreakingNews.Entities;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

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
				MainManager.Instance.LogManager.LogException(ex.Message,ex);
				return new JsonResult(ex.Message);
			}
			
		}

		// GET api/<ValuesController>/5
		[HttpGet("{id}")]
		public string Get(int id)
		{
			return "value";
		}

		// POST api/<ValuesController>
		[HttpPost]
		public void Post([FromBody] string value)
		{
		}

		// PUT api/<ValuesController>/5
		[HttpPut("{id}")]
		public void Put(int id, [FromBody] string value)
		{
		}

		// DELETE api/<ValuesController>/5
		[HttpDelete("{id}")]
		public void Delete(int id)
		{
		}
	}
}
