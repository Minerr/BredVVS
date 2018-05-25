using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Spire.Pdf.Graphics;

namespace ViewModel.PDFbuilder
{
	internal abstract class PDFelement
	{
		public float Height { get; set; }
		public float FontSize { get; set; }
		public PdfFont Font { get; set; }
		public PdfTextAlignment TextAlignment { get; set; }
		public PdfBrush Brush { get; set; }
		public int ElementIndex { get; set; }

		public PDFelement(int index, float fontSize, Color color, PdfTextAlignment textAlignment)
		{
			Brush = new PdfSolidBrush(color);
			ElementIndex = index;
			FontSize = fontSize;
			Font = new PdfFont(PdfFontFamily.Helvetica, fontSize);
			TextAlignment = textAlignment;
		}
	}
}
