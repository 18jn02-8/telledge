using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace telledge.Models
{
	public class Inquiry
	{
		//問い合わせID
		public int id { get; set; }
		//問い合わせ内容
		public String inquiryContent { get; set; }
		//問い合わせ時間
		public DateTime inquiryTime { get; set; }
		//送信者名
		public String senderName { get; set; }
		//送信内容
		public String senderContent { get; set; }
		//返信者ID
		public int? replierId { get; set; }
		//返信内容
		public string replierContent { get; set; }
		//問い合わせ返信有無
		public Boolean isReplied { get; set; }

		public bool create()
		{
			bool check = false;
			string cstr = ConfigurationManager.ConnectionStrings["Db"].ConnectionString;
			using (var connection = new SqlConnection(cstr))
			using (var command = connection.CreateCommand())
			{
				try
				{
					connection.Open();
					command.CommandText = "Insert Into Inquiry Values (@inquiryContent,@inquiryTime,@senderName,@senderContent,@replierId,@replierContent,@isReplied) ";
					command.Parameters.Add(new SqlParameter("@inquiryContent", inquiryContent));
					command.Parameters.Add(new SqlParameter("@inquiryTime", inquiryTime));
					command.Parameters.Add(new SqlParameter("@senderName", senderName));
					command.Parameters.Add(new SqlParameter("@senderContent", senderContent));
					command.Parameters.Add(new SqlParameter("@replierId", DBNull.Value));
					command.Parameters.Add(new SqlParameter("@replierContent", DBNull.Value));
					command.Parameters.Add(new SqlParameter("@isReplied", false));
					int cnt = command.ExecuteNonQuery();
					connection.Close();
					if (cnt != 0)
					{
						check = true;
					}
				}
				catch (SqlException e)
				{
					//入力情報が足りないメッセージを吐く
					return check;
				}
			}
			return check;
		}
		public bool delete()
		{
			bool check = false;
			string cstr = ConfigurationManager.ConnectionStrings["Db"].ConnectionString;
			using (SqlConnection connection = new SqlConnection(cstr))
			{
				String sql = "delete * from inquery where id = @id";
				SqlCommand command = new SqlCommand(sql, connection);
				connection.Open();
				command.Parameters.Add("@id", SqlDbType.Int);
				command.Parameters["@id"].Value = id;
				int cnt = command.ExecuteNonQuery();
				connection.Close();
				if (cnt != 0)
				{
					check = true;
				}

			}
			return check;
		}
	}
}