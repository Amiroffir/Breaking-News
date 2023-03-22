using BreakingMews.Models;
using BreakingNews.DAL;
using BreakingNews.Entities;

namespace BreakingNews.Tests
{
	[TestFixture]
	public class TopicsTest
	{
		public static string connectionString;

		[SetUp]
		public void Setup()
		{
			connectionString = SQLQuery.GetConnectionString();
		}

		[Test]
		public void GetOptionalTopicsTest()
		{
			// Act
			List<Topic> topics = MainManager.Instance.TopicsManager.GetOptionalTopics();

			// Assert
			Assert.IsNotNull(topics);
		}
		[Test]
		public void GetTopicsBySourceTest()
		{
			// Arrange
			List<Topic> YnetTopics = MainManager.Instance.TopicsManager.GetTopicsBySource(BaseEntity.NewsSources.Ynet);
			List<Topic> WallaTopics = MainManager.Instance.TopicsManager.GetTopicsBySource(BaseEntity.NewsSources.Walla);
			List<Topic> MaarivTopics = MainManager.Instance.TopicsManager.GetTopicsBySource(BaseEntity.NewsSources.Maariv);
			List<Topic> MakoTopics = MainManager.Instance.TopicsManager.GetTopicsBySource(BaseEntity.NewsSources.Mako);

			// Assert
			Assert.That(YnetTopics, Is.Not.Empty);
			Assert.That(WallaTopics, Is.Not.Empty);
			Assert.That(MaarivTopics, Is.Not.Empty);
			Assert.That(MakoTopics, Is.Not.Empty);
		}
	}
}
