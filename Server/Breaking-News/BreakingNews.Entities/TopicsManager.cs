using BreakingMews.Models;
using BreakingNews.Data.Sql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
			TopicsSQL topicsSQL = new TopicsSQL(LogManager);
			return topicsSQL.GetOptionalTopics();
		}

		
		public List<Topic> GetTopicsBySource(NewsSources source)
		{
			TopicsSQL topicsSQL = new TopicsSQL(LogManager);
			return topicsSQL.GetTopicsBySource((int)source);
		}

	}
}
