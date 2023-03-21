using Utilities;

namespace BreakingNews.Data.Sql
{
	public class BaseSQL
	{
		public BaseSQL(LogManager logManager)
		{
			LogManager = logManager;
			LogManager.LogEvent("BaseSQL initialized");
		}
		public LogManager LogManager;
	}
}
