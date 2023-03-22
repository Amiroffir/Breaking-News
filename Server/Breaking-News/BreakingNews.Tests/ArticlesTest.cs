using BreakingMews.Models;
using BreakingNews.DAL;
using BreakingNews.Entities;
using BreakingNews.Models;
using System.Security.Cryptography;

namespace BreakingNews.Tests
{
	[TestFixture]
	public class ArticlesTest
	{
		public static string connectionString;
		public int MaxSelectedTopics;
		public List<Topic> selectedTopics;

		[SetUp]
		public void Setup()
		{
			connectionString = SQLQuery.GetConnectionString();
			MaxSelectedTopics = 3;
			selectedTopics = new List<Topic>();
			for (int i = 1; i < MaxSelectedTopics + 1; i++)
			{
				selectedTopics.Add(new Topic() { TopicID = i, TopicName = "Topic" + i.ToString() });
			}
		}

		[Test]
		public void GetArticlesTest()
		{
			// Act		
			List<Article> articles = MainManager.Instance.ArticlesManager.GetArticles(selectedTopics);

			List<Article> noArticles = MainManager.Instance.ArticlesManager.GetArticles(new List<Topic>()); // No topics selected at all

			List<Article> nullArticles = MainManager.Instance.ArticlesManager.GetArticles(null); // No topics selected at all

			// Assert
			Assert.That(articles, Is.Not.Empty);
			Assert.That(noArticles, Is.Empty);
			Assert.That(nullArticles, Is.Empty);
		}
		[Test]
		public void GetExploreNewsTest()
		{
			// Act
			List<Article> articles = MainManager.Instance.ArticlesManager.GetExploreNews(selectedTopics);

			List<Article> noArticles = MainManager.Instance.ArticlesManager.GetExploreNews(new List<Topic>()); // No topics selected at all

			List<Article> nullArticles = MainManager.Instance.ArticlesManager.GetArticles(null); // No topics selected at all

			// Assert
			Assert.That(articles, Is.Not.Empty);
			Assert.That(noArticles, Is.Empty);
			Assert.That(nullArticles, Is.Empty);
		}
		[Test]
		public void GetTrendingNewsTest()
		{
			// Act
			List<Article> articles = MainManager.Instance.ArticlesManager.GetTrendingNews(selectedTopics);

			List<Article> noArticles = MainManager.Instance.ArticlesManager.GetTrendingNews(new List<Topic>()); // No topics selected at all

			List<Article> nullArticles = MainManager.Instance.ArticlesManager.GetArticles(null); // No topics selected at all

			// Assert
			Assert.That(articles, Is.Not.Null);
			Assert.That(noArticles, Is.Empty);
			Assert.That(nullArticles, Is.Empty);
		}
		[Test]
		public void UpdatePopularity()
		{
			// Arrange
			int MaxId = (int)SQLQuery.RunCommandScalar("SELECT Top 1 id FROM Articles ORDER BY id DESC");
			int MinId = (int)SQLQuery.RunCommandScalar("SELECT Top 1 id FROM Articles ORDER BY id ASC");
			int randomID = RandomNumberGenerator.GetInt32(MinId, MaxId);
			
			//Act
			int preUpdate = (int)SQLQuery.RunCommandScalar("Select TimesClicked From Articles Where id =" + randomID + "");
			MainManager.Instance.ArticlesManager.UpdatePopularity(randomID);
			int afterUpdate = (int)SQLQuery.RunCommandScalar("Select TimesClicked From Articles Where id =" + randomID + "");

			//Assert
			Assert.That(afterUpdate - 1, Is.EqualTo(preUpdate)); // Check that the Article popularity is indeed increased by 1
		}
	}
}
