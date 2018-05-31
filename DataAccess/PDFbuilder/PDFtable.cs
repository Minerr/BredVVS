using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using Spire.Pdf.Graphics;
using System.Data;

namespace DataAccess.PDFbuilder
{
	internal class PDFtable : PDFelement
	{
		public DataTable Table { get; set; }
		public float CellPadding { get; set; }

		public PDFtable(int index, float fontSize, float cellPadding, Color color, DataTable table) : 
			base(index, fontSize, color, PdfTextAlignment.Center)
		{
			Height = table.Rows.Count * (fontSize + (cellPadding * 2));
			Table = table;
			CellPadding = cellPadding;
		}

	}
}
