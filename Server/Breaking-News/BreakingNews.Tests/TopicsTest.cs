using BreakingNews.Data.Sql;
using BreakingNews.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utilities;

namespace BreakingNews.Tests
{
	public class TopicsTest
	{
		
		
		[SetUp]
		public void Setup()
		{
			 
		}

		[Test]
		public void GetTopicsTest()
		{
			object obj = MainManager.Instance.TopicsManager.GetTopics();
			Assert.IsNotNull(obj);
		}
		
		[Test]
		public void GetTopicsBySource()
		{
			object obj = MainManager.Instance.TopicsManager.GetTopicsBySource("ynet");
			Assert.IsNotNull(obj);
		}
	}
}
