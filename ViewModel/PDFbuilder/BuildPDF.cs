using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Spire.Pdf;
using Spire.Pdf.Graphics;
using System.Drawing;
using Microsoft.Win32;

namespace ViewModel.PDFbuilder
{
	public enum TextAlignment
	{
		Left = 0,
		Middle = 1,
		Right = 2
	}

	public class BuildPDF
	{
		private float _pageMaxHeight;
		private float _pageMaxWidth;

		private string _path;

		private int _numberOfLines;
		private List<PDFline> _lines;

		private PdfDocument _pdf;
		private PdfSection _section;
		private PdfPageBase _currentPage;

		public BuildPDF()
		{
			_pdf = new PdfDocument();
			_section = _pdf.Sections.Add();
			_currentPage = _section.Pages.Add();
			_pageMaxHeight = _currentPage.Canvas.ClientSize.Height;
			_pageMaxWidth = _currentPage.Canvas.ClientSize.Width;

			_numberOfLines = 0;
			_lines = new List<PDFline>();
		}

		//PdfTextAlignment pdfTextAlignment;
		//	switch(textAlignment)
		//	{
		//		case TextAlignment.Right:
		//			pdfTextAlignment = PdfTextAlignment.Right;
		//			break;
		//		case TextAlignment.Middle:
		//			pdfTextAlignment = PdfTextAlignment.Center;
		//			break;
		//		default:
		//			pdfTextAlignment = PdfTextAlignment.Left;
		//			break;
		//	}

		public void InsertLine(float fontSize, TextAlignment textAlignment, string text)
		{
			//PdfTextAlignment PDFtextAlignment = (int)textAlignment;

			//int charCount = 0;

			//bool isPrevCharSpecial = false;
			//foreach(char c in text)
			//{
			//	if(isPrevCharSpecial)
			//	{
			//		if(c == 'R')
			//		{
			//			// New line and start the rest with right align.
			//			textAlignment = PdfTextAlignment.Right;
			//		}

			//		if(c == 'C')
			//		{
			//			// New line and start the rest with center align.
			//			textAlignment = PdfTextAlignment.Center;
			//		}

			//		if(c == 'B')
			//		{
			//			// New line and make the next word bold
			//		}
			//	}
			//	else
			//	{
			//		if(c == '*')
			//		{
			//			isPrevCharSpecial = true;
			//		}

			//		charCount++;
			//	}

			//}


			//_lines.Add(new PDFline(_numberOfLines, lineSpacing, fontSize, Color.Black, pdfTextAlignment, text));

			//_numberOfLines++;
		}

		public void InsertNewSplitLine(int fontSize, string textLeft, string textRight)
		{

		}

		public void InsertNewTable(int fontSize, string[][] table)
		{

		}

		public void Save(string path)
		{

			float pageMaxHeight = _currentPage.Canvas.ClientSize.Height;
			float pageMaxWidth = _currentPage.Canvas.ClientSize.Width;

			float currentPageHeight = 0;
			int currentLineNumber = 0;

			float prevLineHeight = 0;

			foreach(PDFline line in _lines)
			{
				if(line.LineNumber > currentLineNumber)
				{
					currentPageHeight += prevLineHeight;
					if(currentPageHeight >= pageMaxHeight)
					{
						_currentPage = _section.Pages.Add();
					}
				}

				float posY = currentPageHeight;
				float posX = 10;

				switch(line.TextAlignment)
				{
					case PdfTextAlignment.Right:
						posX = pageMaxWidth;
						break;
					case PdfTextAlignment.Center:
						posX = pageMaxWidth / 2;
						break;
				}

				currentPage.Canvas.DrawString(line.Text, line.Font, line.Brush, posX, posY, line.TextFormat);
				currentLineNumber = line.LineNumber;

				prevLineHeight = line.LineHeight;
			}

			_path = path;
			_pdf.SaveToFile(path, FileFormat.PDF);
		}

		public void Open()
		{
			if(!string.IsNullOrEmpty(_path))
			{
				System.Diagnostics.Process.Start(_path);
			}
		}
	}
}
