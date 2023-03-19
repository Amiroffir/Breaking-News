using System.Xml;

namespace BreakingNews.Models
{
	public class Article
	{
		public int Id { get; set; }
		public int TopicID { get; set; }
		public int NewsSource { get; set; }
		public string ImgUrl { get; set; }
		public string Headline { get; set; }
		public string Description { get; set; }
		public string Link { get; set; }
	}
}
