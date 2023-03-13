using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using Utilities;

namespace BreakingNews.Entities
{
	public class XmlManager : BaseEntity
	{
		public XmlManager(LogManager logManager) : base(logManager)
		{
			LogManager.LogEvent("XML Manager initialized");
		}
		public void XmlDocsHandler(List<XmlDocument> xmlDocuments, string source)
		{

		}
	}
}
