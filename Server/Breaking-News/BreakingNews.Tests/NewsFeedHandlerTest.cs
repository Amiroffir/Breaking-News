using BreakingNews.DAL;
using BreakingNews.Entities;
using BreakingNews.Models;
using System.Xml;

namespace BreakingNews.Tests
{
	[TestFixture]
	public class NewsFeedHandlerTest
	{
		public int topicID;
		public int maxArticles = 10;
		public static string connectionString;
		public string YnetXml = "https://www.ynet.co.il/Integration/StoryRss2.xml";
		public string WallaXml = "https://rss.walla.co.il/feed/1";
		public string MaarivXml = "https://www.maariv.co.il/Service/Rss/GetRssFeed?feec dId=1";
		public string MakoXml = "https://www.mako.co.il/rss/feeds/1";
		public int newsSourcesCount = Enum.GetValues(typeof(BaseEntity.NewsSources)).Length;
		public YnetManager ynetManager;
		public MaarivManager maarivManager;
		public MakoManager makoManager;
		public WallaManager wallaManager;

		[SetUp]
		public void Setup()
		{
			connectionString = SQLQuery.GetConnectionString();
			topicID = new Random().Next(1, 15);
			ynetManager = new YnetManager(MainManager.Instance.LogManager);
			maarivManager = new MaarivManager(MainManager.Instance.LogManager);
			makoManager = new MakoManager(MainManager.Instance.LogManager);
			wallaManager = new WallaManager(MainManager.Instance.LogManager);
		}

		public void XmlDocHandlerTest()
		{
			// Ynet 
			XmlDocument doc = new XmlDocument();
			doc.Load(YnetXml);
			List<Article> ynetArticles = ynetManager.XmlDocHandler(doc, maxArticles, topicID, (int)BaseEntity.NewsSources.Ynet);

			// Mako 
			XmlDocument doc2 = new XmlDocument();
			doc.Load(MakoXml);
			List<Article> makoArticles = makoManager.XmlDocHandler(doc, maxArticles, topicID, (int)BaseEntity.NewsSources.Mako);

			// Maariv 
			XmlDocument doc3 = new XmlDocument();
			doc.Load(MaarivXml);
			List<Article> maarivArticles = maarivManager.XmlDocHandler(doc, maxArticles, topicID, (int)BaseEntity.NewsSources.Maariv);

			// Walla 
			XmlDocument doc4 = new XmlDocument();
			doc.Load(WallaXml);
			List<Article> wallaArticles = wallaManager.XmlDocHandler(doc, maxArticles, topicID, (int)BaseEntity.NewsSources.Walla);

			// Assertions 
			Assert.That(ynetArticles, Is.Not.Null & Is.Not.Empty & Is.AtMost(maxArticles));
			Assert.That(makoArticles, Is.Not.Null & Is.Not.Empty & Is.AtMost(maxArticles));
			Assert.That(maarivArticles, Is.Not.Null & Is.Not.Empty & Is.AtMost(maxArticles));
			Assert.That(wallaArticles, Is.Not.Null & Is.Not.Empty & Is.AtMost(maxArticles));
		}

		public async void GetAllRSSFeedsTest()
		{
			List<List<Article>> ynetArticles = await ynetManager.GetAllRSSFeeds(BaseEntity.NewsSources.Ynet);
			List<List<Article>> makoArticles = await makoManager.GetAllRSSFeeds(BaseEntity.NewsSources.Mako);
			List<List<Article>> wallaArticles = await wallaManager.GetAllRSSFeeds(BaseEntity.NewsSources.Walla);
			List<List<Article>> maarivArticles = await maarivManager.GetAllRSSFeeds(BaseEntity.NewsSources.Maariv);

			// Assertions 
			Assert.That(ynetArticles, Is.Not.Null & Is.Not.Empty);
			Assert.That(makoArticles, Is.Not.Null & Is.Not.Empty);
			Assert.That(maarivArticles, Is.Not.Null & Is.Not.Empty);
			Assert.That(wallaArticles, Is.Not.Null & Is.Not.Empty);
		}
	}
}
