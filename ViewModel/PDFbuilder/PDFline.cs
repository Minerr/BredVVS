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
	internal class PDFline : IComparable<PDFline>
	{

		public string Text { get; set; }
		public PdfFont Font { get; set; }
		public PdfSolidBrush Brush { get; set; }
		public PdfStringFormat TextFormat { get; set; }
		public PdfTextAlignment TextAlignment { get; set; }
		public int LineNumber { get; set; }
		public float LineHeight { get; set; }
		public bool IsBold { get; set; }

		public PDFline(int lineNumber, float lineSpacing, float fontSize, Color color, PdfTextAlignment textAlignment, bool isBold, string text)
		{
			LineNumber = lineNumber;
			LineHeight = lineSpacing * fontSize;
			Font = new PdfFont(PdfFontFamily.Helvetica, fontSize);
			Brush = new PdfSolidBrush(color);
			TextFormat = new PdfStringFormat(textAlignment);
			TextAlignment = textAlignment;
			IsBold = isBold;
			Text = text;
		}

		public int CompareTo(PDFline other)
		{
			int result = 0;

			if(other.LineNumber < LineNumber)
			{
				result = 1;
			}
			else if(other.LineNumber > LineNumber)
			{
				result = -1;
			}

			return result;
		}
	}
}
