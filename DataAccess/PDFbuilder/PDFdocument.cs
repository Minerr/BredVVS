using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.PDFbuilder
{
	internal class PDFdocument
	{
		public Queue<PDFelement> Content { get; }

		public PDFdocument()
		{
			Content = new Queue<PDFelement>();
		}

		public void AddElement(PDFelement element)
		{
			Content.Enqueue(element);
		}
	}
}
