using System;

using System.Web;

using System.Data;

using System.Text;

using System.Security.Cryptography;
using System.Data.SqlClient;
using System.Configuration;
using telledge.Models;

namespace telledge.Models
{
    public class Section
    {
        public int roomId { get; set; }
        public int studentId { get; set; }
        public String request { get; set; }
        public int valuation { get; set; }
        public int order { get; set; }
        public DateTime beginTime { get; set; }
        public int talkTime { get; set; }

        public Room getRoom()
        {
            Room retRoom = null;
            string cstr = ConfigurationManager.ConnectionStrings["Db"].ConnectionString;
            using (SqlConnection connection = new SqlConnection(cstr))
            {
                if (retStudent.inactiveDate != null)
                {
                    return null;
                }
                string sql = "select * from Student where id = @id";
                SqlDataAdapter adapter = new SqlDataAdapter(sql, connection);
                adapter.SelectCommand.Parameters.Add("@id", SqlDbType.VarChar);
                DataSet ds = new DataSet();
                int cnt = adapter.Fill(ds, "Student");
                if (cnt != 0)
                {
                    retStudent = new Student();
                    DataTable dt = ds.Tables["Student"];
                    retStudent.passwordDigest = (Byte[])dt.Rows[0]["passwordDigest"];
                }

                byte[] input = Encoding.ASCII.GetBytes(password);
                SHA256 sha = new SHA256CryptoServiceProvider();
                byte[] hash_sha256 = sha.ComputeHash(input);
                if (retStudent.passwordDigest == hash_sha256)
                {
                    HttpContext.Current.Session["Student"] = retStudent;
                    return retStudent;
                }
                else
                {
                    return null;
                }
            }
        }
    }
}