using BreakingMews.Models;
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
			TopicsManager = new TopicsManager(LogManager);
			ArticlesManager = new ArticlesManager(LogManager);
			YnetManager = new YnetManager(LogManager);
			WallaManager = new WallaManager(LogManager);
			MaarivManager = new MaarivManager(LogManager);
			MakoManager = new MakoManager(LogManager);
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
		public YnetManager YnetManager;
		public WallaManager WallaManager;
		public MaarivManager MaarivManager;
		public MakoManager MakoManager;
		public TopicsManager TopicsManager;
		public ArticlesManager ArticlesManager;
		public List<Topic> TopicsList;
		// Add all entities here
	}
}
