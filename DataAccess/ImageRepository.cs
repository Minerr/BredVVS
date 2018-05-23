using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;

namespace DataAccess
{
	public class ImageRepository : IRepository<Image>
	{
		public void Create(Image image)
		{
			throw new NotImplementedException();
		}

		public void Delete(Image image)
		{
			throw new NotImplementedException();
		}

		public Image Retrieve(int ID)
		{
			//string error == "";
			Image image = null;

			//SqlCommand command = new SqlCommand("spGetImageByID");
			//command.CommandType = CommandType.StoredProcedure;

			//command.Parameters.Add(new SqlParameter("@ID", ID));
			//SqlDataReader reader = DatabaseController.ExecuteReader(command);

			//try
			//{
			//	DateTime DateTime = Convert.ToDateTime(reader["DateTime"]);
			//	string GPSLocation = reader["GPSLocation"].ToString();
			//	string Description = reader["Description"].ToString();
			//	string employeeID = reader["EmployeeID"].ToString();
			//	string type = reader["Type"].ToString();

			//	image = new Image(DateTime, GPSLocation, Description, employeeID, type);
			//}
			//catch(Exception e)
			//{
			//	error = "ERROR! " + e.Message;
			//}

			return image;
		}

		public void Update(Image image)
		{
			throw new NotImplementedException();
		}
	}
}
