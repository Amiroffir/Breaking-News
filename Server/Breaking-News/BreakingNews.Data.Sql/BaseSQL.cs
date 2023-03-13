using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utilities;

namespace BreakingNews.Data.Sql
{
	public class BaseSQL
	{
		public BaseSQL(LogManager logManager)
		{
			LogManager = logManager;
		}
		public LogManager LogManager;
	}
}
