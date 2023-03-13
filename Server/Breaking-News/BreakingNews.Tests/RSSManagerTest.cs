using BreakingNews.Entities;

namespace BreakingNews.Tests
{
	public class RSSManagerTest
	{
		[SetUp]
		public void Setup()
		{

		}

		[Test]
		public async Task Test()
		{
			await MainManager.Instance.RSSManager.GetNewsFeed();
		}
	}
}