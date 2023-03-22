namespace BreakingMews.Models
{
	public record Topic
	{
		public int TopicID { get; set; }
		public string TopicName { get; set; }
		public string? NewsSource { get; set; }
		public string? RSSLink { get; set; }
	}
}
