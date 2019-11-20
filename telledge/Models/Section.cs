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
                string sql = "select * from Room where roomId = @roomid";
                SqlDataAdapter adapter = new SqlDataAdapter(sql, connection);
                adapter.SelectCommand.Parameters.Add("@roomid", SqlDbType.Int);
                adapter.SelectCommand.Parameters["roomid"].Value = this.roomId;
                DataSet ds = new DataSet();
                int cnt = adapter.Fill(ds, "Room");
                if (cnt != 0)
                {
                    DataTable dt = ds.Tables["Room"];
                    retRoom = new Room();
                    retRoom.id = (int)dt.Rows[0]["id"];
                    retRoom.teacherId = (int)dt.Rows[0]["teacherId"];
                    retRoom.roomName = dt.Rows[0]["roomName"].ToString();
                    retRoom.tag = dt.Rows[0]["tag"].ToString();
                    retRoom.description = dt.Rows[0]["description"].ToString();
                    retRoom.worstTime = (int)dt.Rows[0]["worstTime"];
                    retRoom.extensionTime = (int)dt.Rows[0]["extensionTime"];
                    retRoom.point = (int)dt.Rows[0]["point"];
                    retRoom.beginTime = (DateTime)dt.Rows[0]["beginTime"];
                    retRoom.endTime = (DateTime)dt.Rows[0]["endTime"];
                }
            }
            return retRoom;
        }
    }
}