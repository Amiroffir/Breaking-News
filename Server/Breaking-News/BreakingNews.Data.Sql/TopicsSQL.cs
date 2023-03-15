using AutoMapper;
using BreakingMews.Models;
using BreakingNews.DAL;
using BreakingNews.Data.Sql;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utilities;

namespace BreakingNews.Data.Sql
{
    public class TopicsSQL : BaseSQL
	{
		public TopicsSQL(LogManager logManager) : base(logManager) { }

		public List<Topic> GetTopics()
		{
			object topics;
			try
			{
				topics = SQLQuery.RunCommandResult("SELECT * FROM Topics", MapDataIntoTopics);
				return (List<Topic>)topics;
			}
			catch (Exception ex)
			{
				LogManager.LogException("Error in GetTopics: " + ex.Message,ex);
				return null;
			}				
		}


		private List<Topic> MapDataIntoTopics(SqlDataReader reader)
		{
			List<Topic> topicsList = new List<Topic>();
			
			while (reader.Read())
			{
				
				Topic topicToAdd = new Topic();
				Services.Mappers.TopicMapper.Mapper.Map(reader, topicToAdd); 
				topicsList.Add(topicToAdd);
			}
		return topicsList;
		}

		
		public List<Topic> GetTopicsBySource(int source)
		{
			object topics;
			try
			{
				topics = SQLQuery.RunCommandResult("GetTopicsByNewsSource " + "'" + source + "'", MapDataIntoTopics);
				return (List<Topic>)topics;
			}
			catch (Exception ex)
			{
				LogManager.LogException("Error in GetTopicsBySource: " + ex.Message, ex);
				return null;
			}

		}
	}
}

