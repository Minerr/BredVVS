using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Spire.Pdf;
using Spire.Pdf.Graphics;
using System.Drawing;
using Microsoft.Win32;

namespace ViewModel
{
	public class BuildPDF
	{
		private string _path;

		private PdfDocument _pdf;
		private PdfSection _section;
		private PdfPageBase _page;

		public BuildPDF()
		{
			_pdf = new PdfDocument();
			_section = _pdf.Sections.Add();
			_page = _section.Pages.Add();
		}

		public void InputText(string text, float fontSize)
		{
			PdfFont font = new PdfFont(PdfFontFamily.Helvetica, fontSize);
			PdfSolidBrush brush = new PdfSolidBrush(Color.Black);

			float posX = (_page.Size.Width / 2) - text.Length;
			float posY = 10;

			_page.Canvas.DrawString(text, font, brush, posX, posY);
		}

		public void Save(string path)
		{
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
