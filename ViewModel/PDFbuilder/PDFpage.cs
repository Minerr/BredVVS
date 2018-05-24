using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModel.PDFbuilder
{
	internal class PDFpage
	{
		public int NumberOfLines { get; set; }

		public bool IsPageFull { get; set; }

		private List<PDFline> lines;

		public PDFpage()
		{
			NumberOfLines = 0;
			lines = new List<PDFline>();
		}

		public void AddLine(PDFline line)
		{



			lines.Add(line);
		}
	}
}
