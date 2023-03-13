using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utilities;

namespace BreakingNews.Entities
{
	public class BaseEntity
	{
		public BaseEntity(LogManager logManager)
		{
			LogManager = logManager;
		}
		public LogManager LogManager;
	}
}
