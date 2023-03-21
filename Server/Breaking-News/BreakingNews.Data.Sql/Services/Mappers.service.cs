using AutoMapper;
using BreakingMews.Models;
using BreakingNews.Models;
using System.Data.SqlClient;
using System.Xml;

namespace BreakingNews.Data.Sql.Services
{
    public static class Mappers
    {
		public static class TopicMapper
        {
            private static MapperConfiguration topicConfig = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<SqlDataReader, Topic>()
                    .ForMember(dest => dest.TopicID, opt => opt.MapFrom(src => src["topicIndex"]))
					.ForMember(dest => dest.TopicName, opt => opt.MapFrom(src => src["topicName"]))
                    .ForMember(dest => dest.NewsSource, opt => opt.MapFrom(src => src["newsSource"]))
                    .ForMember(dest => dest.RSSLink, opt => opt.MapFrom(src => src["RSSLink"]));
            });

            private static readonly IMapper readerToTopicMapper = topicConfig.CreateMapper();

			public static Topic Map(SqlDataReader reader)
			{
				return readerToTopicMapper.Map<SqlDataReader, Topic>(reader);
			}
		}

        public static class ArticleMapper
        {

			private static MapperConfiguration ArticleFromDBConfig = new MapperConfiguration(cfg =>
			{
				
				cfg.CreateMap<SqlDataReader, Article>()
				.ForMember(dest => dest.Id, opt => opt.MapFrom(src => src["id"]))
					.ForMember(dest => dest.NewsSource, opt => opt.MapFrom(src => src["newsSource"]))
					.ForMember(dest => dest.Headline, opt => opt.MapFrom(src => src["headline"]))
					.ForMember(dest => dest.ImgUrl, opt => opt.MapFrom(src => src["image"]))
					.ForMember(dest => dest.Description, opt => opt.MapFrom(src => src["desc"]))
					.ForMember(dest => dest.Link, opt => opt.MapFrom(src => src["link"]))
					.ForMember(dest => dest.TopicID, opt => opt.MapFrom(src => src["Topic"]));
			});
            
			private static MapperConfiguration XmlToArticleConfig = new MapperConfiguration(cfg =>
            {
                // Configure the mapping from XmlDocument to Article
                cfg.CreateMap<XmlNode, Article>()
                    .ForMember(dest => dest.ImgUrl, opt => opt.MapFrom(src => src.SelectSingleNode("description") != null ? (src.SelectSingleNode("description").InnerText) : null))
                    .ForMember(dest => dest.Headline, opt => opt.MapFrom(src => src.SelectSingleNode("title") != null ? src.SelectSingleNode("title").InnerText : null))
                    .ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.SelectSingleNode("description") != null ? (src.SelectSingleNode("description").InnerText) : null))
                    .ForMember(dest => dest.Link, opt => opt.MapFrom(src => src.SelectSingleNode("link") != null ? src.SelectSingleNode("link").InnerText : null));
            });
            
            // Create a mapper instance from the configuration
            private static readonly IMapper xmlToArticleMapper = XmlToArticleConfig.CreateMapper();
			private static readonly IMapper readerToArticleMapper = ArticleFromDBConfig.CreateMapper();

			public static Article Map(XmlNode node)
			{
				return xmlToArticleMapper.Map<XmlNode, Article>(node);
			}

			public static Article Map(SqlDataReader reader)
			{
				return readerToArticleMapper.Map<SqlDataReader, Article>(reader);
			}


		}
    }
}
