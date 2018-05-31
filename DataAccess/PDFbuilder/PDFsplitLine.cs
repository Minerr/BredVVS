using Spire.Pdf.Graphics;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.PDFbuilder
{
	internal class PDFsplitLine : PDFelement
	{
		public PDFline LeftLine { get; set; }
		public PDFline RightLine { get; set; }

		public PDFsplitLine(PDFline leftLine, PDFline rightLine) : 
			base(leftLine.ElementIndex, leftLine.FontSize, Color.Black, PdfTextAlignment.Left)
		{
			Height = leftLine.Height;
			LeftLine = leftLine;
			RightLine = rightLine;
		}
	}
}
