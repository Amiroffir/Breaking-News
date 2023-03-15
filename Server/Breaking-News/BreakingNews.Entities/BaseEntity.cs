using System.Xml;
using Utilities;

namespace BreakingNews.Entities
{
	public class BaseEntity
	{
		public BaseEntity(LogManager logManager)
		{
			LogManager = logManager;
			LogManager.LogEvent("Base entity initialized");
			
		}
		public LogManager LogManager;

		public enum NewsSources
		{
			Walla = 1,
			Maariv = 2,
			Ynet = 3,
			Mako = 4,
		}
	}
}
