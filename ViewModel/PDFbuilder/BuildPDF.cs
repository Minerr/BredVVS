using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Spire.Pdf;
using Spire.Pdf.Graphics;
using System.Drawing;
using Microsoft.Win32;
using Spire.Pdf.Tables;
using System.Data;

namespace ViewModel.PDFbuilder
{
	public class BuildPDF
	{
		public enum TextAlignment
		{
			Left,
			Center,
			Right
		}


		private const float LINE_SPACING = 1.25f;

		private float _pageMaxHeight;
		private float _pageMaxWidth;
		private float _pagePaddingLeft;

		private string _path;
		private int _elementCounter;

		private PDFdocument _document;

		private PdfDocument _spirePDF;
		private PdfSection _section;
		private PdfPageBase _currentPage;

		public BuildPDF()
		{
			_spirePDF = new PdfDocument();
			_section = _spirePDF.Sections.Add();
			_currentPage = _section.Pages.Add();
			_pageMaxHeight = _currentPage.Canvas.ClientSize.Height;
			_pageMaxWidth = _currentPage.Canvas.ClientSize.Width;
			_pagePaddingLeft = 10f;

			_elementCounter = 1;
			_document = new PDFdocument();
		}

		private PdfTextAlignment ConvertTextAlignment(TextAlignment textAlignment)
		{
			PdfTextAlignment result;

			switch(textAlignment)
			{
				case TextAlignment.Center:
					result = PdfTextAlignment.Center;
					break;
				case TextAlignment.Right:
					result = PdfTextAlignment.Right;
					break;
				default:
					result = PdfTextAlignment.Left;
					break;
			}

			return result;
		}

		public void InsertNewLine(float fontSize, TextAlignment textAlignment, string text)
		{
			//TODO: check for bold text
			_document.AddLine(new PDFline(_elementCounter, fontSize, LINE_SPACING, Color.Black, ConvertTextAlignment(textAlignment), false, text));
			_elementCounter++;
		}

		public void InsertNewLine(float fontSize, string text)
		{
			InsertNewLine(fontSize, TextAlignment.Left, text);
		}

		public void InsertNewSplitLine(float fontSize, string textLeft, string textRight)
		{
			PDFline leftLine = new PDFline(
				_elementCounter, fontSize, LINE_SPACING, Color.Black, PdfTextAlignment.Left, false, textLeft);
			PDFline rightLine = new PDFline(
				_elementCounter, fontSize, LINE_SPACING, Color.Black, PdfTextAlignment.Right, false, textRight);

			_document.AddSplitLine(new PDFsplitLine(leftLine, rightLine));

			_elementCounter++;
		}

		public void InsertNewTextBlock(float fontSize, TextAlignment textAlignment, string text)
		{
			//Split at newline
			string[] lines = text.Split(
					new string[] { "\r\n" },
					StringSplitOptions.RemoveEmptyEntries
				);

			foreach(string line in lines)
			{
				int lineLength = line.Length;
				int lineMaxLength = (int) _pageMaxWidth / (int) (fontSize / 2);

				if(lineLength >= lineMaxLength) // If line is longer than allowed, make a new line.
				{
					int numberOfDivisions = lineLength / lineMaxLength;
					for(int i = 0; i <= numberOfDivisions; i++)
					{
						int startIndex = lineMaxLength * i;
						string subLine = "";

						if(startIndex < lineLength - lineMaxLength)
						{
							subLine = line.Substring(startIndex, lineMaxLength);
						}
						else
						{
							subLine = line.Substring(lineMaxLength * i);
						}

						InsertNewLine(fontSize, textAlignment, subLine);
					}
				}
				else
				{
					InsertNewLine(fontSize, textAlignment, line);
				}
			}
		}

		public void InsertNewTable<T>(float fontSize, float cellPadding, List<string> headers, IEnumerable<T> list)
		{
			// Build string table:
			DataTable dataTable = new DataTable();

			// Start by building header string.
			foreach(string header in headers)
			{
				dataTable.Columns.Add(header);
			}

			// Then build a string for each item:
			foreach(T item in list)
			{
				dataTable.Rows.Add(item.ToString().Split(';'));
			}

			_document.AddTable(new PDFtable(_elementCounter, fontSize, cellPadding, Color.Black, dataTable));
			_elementCounter++;
		}

		public string Save(string path)
		{
			float currentPageHeight = _pagePaddingLeft;
			int prevElementCount = 0;
			int currentElementCount = 0;

			while(_document.Content.Count > 0)
			{
				PDFelement element = _document.Content.Dequeue();
				currentElementCount = element.ElementIndex;

				float posY = currentPageHeight;
				float posX = _pagePaddingLeft;

				if(element.GetType() == typeof(PDFline))
				{
					PDFline line = (PDFline) element;

					posX = GetElementHorizontalPosition(element.TextAlignment);
					_currentPage.Canvas.DrawString(line.Text, line.Font, line.Brush, posX, posY, line.TextFormat);
				}
				else if(element.GetType() == typeof(PDFsplitLine))
				{
					PDFsplitLine splitLine = (PDFsplitLine) element;

					PDFline leftLine = splitLine.LeftLine;
					PDFline rightLine = splitLine.RightLine;

					_currentPage.Canvas.DrawString(
							leftLine.Text, leftLine.Font, leftLine.Brush,
							GetElementHorizontalPosition(PdfTextAlignment.Left), posY,
							leftLine.TextFormat
						);
					_currentPage.Canvas.DrawString(
							rightLine.Text, rightLine.Font, rightLine.Brush,
							GetElementHorizontalPosition(PdfTextAlignment.Right), posY,
							rightLine.TextFormat
						);
				}
				else if(element.GetType() == typeof(PDFtable))
				{
					PDFtable table = (PDFtable) element;

					PdfTable spireTable = new PdfTable();
					spireTable.DataSource = table.Table;
					spireTable.BeginRowLayout += Table_BeginRowLayout;
					spireTable.Style.CellPadding = table.CellPadding;
					spireTable.Style.BorderPen = new PdfPen(table.Brush);
					spireTable.Style.HeaderStyle.StringFormat = new PdfStringFormat(table.TextAlignment);
					spireTable.Style.HeaderRowCount = 1;
					spireTable.Style.ShowHeader = true;
					spireTable.Style.HeaderStyle.BackgroundBrush = PdfBrushes.LightGray;


					foreach(PdfColumn column in spireTable.Columns)
					{
						column.StringFormat = new PdfStringFormat(table.TextAlignment, PdfVerticalAlignment.Middle);
					}

					spireTable.Draw(_currentPage, new PointF(posX, posY));
				}

				currentPageHeight += element.Height;
				if(currentPageHeight >= _pageMaxHeight)
				{
					_currentPage = _section.Pages.Add();
					currentPageHeight = 0;
				}

				prevElementCount = currentElementCount;
			}

			_path = path;
			_spirePDF.SaveToFile(path, FileFormat.PDF);

			return path;
		}

		private float GetElementHorizontalPosition(PdfTextAlignment textAlignment)
		{
			float posX = 0;
			switch(textAlignment)
			{
				case PdfTextAlignment.Right:
					posX = _pageMaxWidth;
					break;
				case PdfTextAlignment.Center:
					posX = _pageMaxWidth / 2;
					break;
			}
			return posX;
		}


		private static void Table_BeginRowLayout(object sender, BeginRowLayoutEventArgs args)
		{
			args.MinimalHeight = 15f;
		}
	}
}
