using BreakingMews.Models;
using BreakingNews.DAL;
using BreakingNews.Data.Sql.Services;
using System.Data.SqlClient;
using Utilities;

namespace BreakingNews.Data.Sql
{
	public class TopicsSQL : BaseSQL
	{
		public TopicsSQL(LogManager logManager) : base(logManager) { }

		public List<Topic> GetOptionalTopics()
		{
			List<Topic> topics = new List<Topic>();
			try
			{
				topics = (List<Topic>)SQLQuery.RunCommandResult("SELECT * FROM TopicsIndex", GetTopicsIndex);
				LogManager.LogEvent("Optional Topics retrieved successfully");
				return topics;
			}
			catch (Exception ex)
			{
				LogManager.LogException("Error in GetOptionalTopics: " + ex.Message, ex);
				throw;
			}
		}

		public List<Topic> GetTopicsBySource(int source)
		{
			List<Topic> topics = new List<Topic>();
			try
			{
				topics = (List<Topic>)SQLQuery.RunCommandResult("GetTopicsByNewsSource " + "'" + source + "'", MapDataIntoTopics);
				LogManager.LogEvent("Topics by sourceID: " + source + " retrieved successfully");
				return topics;
			}
			catch (Exception ex)
			{
				LogManager.LogException("Error in GetTopicsBySource: " + ex.Message, ex);
				throw;
			}
		}
		private List<Topic> MapDataIntoTopics(SqlDataReader reader)
		{
			List<Topic> topicsList = new List<Topic>();

			while (reader.Read())
			{
				Topic topicToAdd = Mappers.TopicMapper.Map(reader);
				topicsList.Add(topicToAdd);
			}
			return topicsList;
		}
		private List<Topic> GetTopicsIndex(SqlDataReader reader)
		{
			List<Topic> topicsList = new List<Topic>();

			while (reader.Read())
			{
				Topic topicToAdd = new Topic();
				int idIndex = reader.GetOrdinal("id");
				int nameIndex = reader.GetOrdinal("topicName");
				topicToAdd.TopicID = reader.GetInt32(idIndex);
				topicToAdd.TopicName = reader.GetString(nameIndex);
				topicsList.Add(topicToAdd);
			}
			return topicsList;
		}
	}
}

