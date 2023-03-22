using BreakingMews.Models;
using BreakingNews.Data.Sql;
using Utilities;

namespace BreakingNews.Entities
{
	public class TopicsManager : BaseEntity
	{
		public TopicsManager(LogManager logManager) : base(logManager)
		{
			LogManager.LogEvent("Topics Manager initialized");
		}

		public List<Topic> GetOptionalTopics()
		{
			try
			{
				TopicsSQL topicsSQL = new TopicsSQL(LogManager);
				return topicsSQL.GetOptionalTopics();
			}
			catch (Exception ex)
			{
				LogManager.LogException(ex.Message, ex);
				throw;
			}
		}

		public List<Topic> GetTopicsBySource(NewsSources source)
		{
			try
			{
				TopicsSQL topicsSQL = new TopicsSQL(LogManager);
				return topicsSQL.GetTopicsBySource((int)source);
			}
			catch (Exception ex)
			{
				LogManager.LogException(ex.Message, ex);
				throw;
			}
		}
	}
}
