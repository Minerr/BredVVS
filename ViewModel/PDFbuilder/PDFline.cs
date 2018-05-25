using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Spire.Pdf;
using Spire.Pdf.Graphics;
using System.Drawing;

namespace ViewModel.PDFbuilder
{
	internal class PDFline : PDFelement
	{

		public string Text { get; set; }
		public PdfStringFormat TextFormat { get; set; }
		public bool IsBold { get; set; }

		public PDFline(int index, float fontSize, float lineSpacing, Color color, PdfTextAlignment textAlignment, bool isBold, string text) : base(index, fontSize, color, textAlignment)
		{
			Height = lineSpacing * fontSize;
			TextFormat = new PdfStringFormat(textAlignment);
			IsBold = isBold;
			Text = text;
		}
	}
}
