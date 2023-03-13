using BreakingMews.Models;
using BreakingNews.Models;
using System.Collections.Generic;
using Utilities;

namespace BreakingNews.Entities
{
	public class MainManager
	{

		private static readonly MainManager _instance = new MainManager();

		private MainManager()
		{
			Init();
		}

		private void Init()
		{
			LogManager = new LogManager();
			LogManager.Init(LogManager.LogType.File);
			RSSManager = new RSSManager(LogManager);
			XmlManager = new XmlManager(LogManager);
			TopicsList = new List<Topic>();



			// Init all managers here with the log manager in the constructor
		}



		public static MainManager Instance
		{
			get
			{
				return _instance;
			}
		}

		public LogManager LogManager;
		public RSSManager RSSManager;
		public XmlManager XmlManager;
		public List<Topic> TopicsList;
		// Add all entities here
	}
}
