using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModel.PDFbuilder
{
	internal class PDFdocument
	{
		public Queue<PDFelement> Content { get; }

		public PDFdocument()
		{
			Content = new Queue<PDFelement>();
		}

		public void AddLine(PDFline line)
		{
			Content.Enqueue(line);
		}

		public void AddTable(PDFtable table)
		{
			Content.Enqueue(table);
		}
		public void AddSplitLine(PDFsplitLine splitLine)
		{
			Content.Enqueue(splitLine);
		}
	}
}
