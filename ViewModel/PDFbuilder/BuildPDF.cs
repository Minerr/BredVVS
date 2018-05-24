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

		public void InsertLine(float fontSize, PdfTextAlignment textAlignment, string text)
		{
			char specialCharBold = '*';
			string[] lines = text.Split(
					new string[] { "\r\n" }, 
					StringSplitOptions.RemoveEmptyEntries
				);

			//bool isBold = false;
			foreach(string line in lines)
			{
				_lines.Add(new PDFline(_numberOfLines, 1.25f, fontSize, Color.Black, textAlignment, false, line));
				_numberOfLines++;
			}
		}

		public void InsertNewSplitLine(int fontSize, string textLeft, string textRight)
		{

		}

		public void InsertNewTable(int fontSize, string[][] table)
		{

		}

		public void Save(string path)
		{

			//float pageMaxHeight = _currentPage.Canvas.ClientSize.Height;
			//float pageMaxWidth = _currentPage.Canvas.ClientSize.Width;

			//float currentPageHeight = 0;
			//int currentLineNumber = 0;

			//float prevLineHeight = 0;

			//foreach(PDFline line in _lines)
			//{
			//	if(line.LineNumber > currentLineNumber)
			//	{
			//		currentPageHeight += prevLineHeight;
			//		if(currentPageHeight >= pageMaxHeight)
			//		{
			//			_currentPage = _section.Pages.Add();
			//		}
			//	}

			//	float posY = currentPageHeight;
			//	float posX = 10;

			//	switch(line.TextAlignment)
			//	{
			//		case PdfTextAlignment.Right:
			//			posX = pageMaxWidth;
			//			break;
			//		case PdfTextAlignment.Center:
			//			posX = pageMaxWidth / 2;
			//			break;
			//	}

			//	_currentPage.Canvas.DrawString(line.Text, line.Font, line.Brush, posX, posY, line.TextFormat);
			//	currentLineNumber = line.LineNumber;

			//	prevLineHeight = line.LineHeight;
			//}

			//_path = path;
			//_pdf.SaveToFile(path, FileFormat.PDF);
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
