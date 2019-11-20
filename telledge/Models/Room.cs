using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace telledge.Models
{
    public class Room
    {
        //ルームID
        public int id { set; get; }
        //講師ID
        public int teacherId { set; get;}
        //ルーム名
        public String roomName { set; get; }
        //特徴を示すタグ
        public String tag { get; set; }
        //ルームに対する説明
        public String description { get; set; }
        //最低保障時間
        public int worstTime { get; set; }
        //最大延長時間
        public int extensionTime { get; set; }
        //通話に必要なポイント
        public int point { get; set; }
        //通話開始時刻
        public DateTime beginTime { get; set; }
        //通話終了時刻
        public DateTime endTime { get; set; }

        public bool isClosed()
        {
            if (endTime == null)
            {
                return ture;
            }
            else
            {
                return false;
            }
        }
        public Room[] getRooms()
        {
            Room[] retRooms = null;
            string cstr = ConfigurationManager.ConnectionStrings["Db"].ConnectionString;
            using (SqlConnection connection = new SqlConnection(cstr))
            {
                string sql = "select * from Room";
                
                int cnt = adapter.Fill(ds, "Room");
                while (cnt != 0)
                {
                    retRooms = new Room();
                    DataTable dt = ds.Tables["Room"];
                    retRooms.id = dt.Rows[0]["id"];
                    retRooms.teacherId = dt.Rows[0]["teacherId"];
                    retRooms.roomName = dt.Rows[0]["roomName"];
                    retRooms.tag = dt.Rows[0]["tag"];
                    retRooms.description = dt.Rows[0]["description"];
                    retRooms.worstTime = dt.Rows[0]["worstTime"];
                    retRooms.extensionTime = dt.Rows[0]["extensionTime"];
                    retRooms.point = dt.Rows[0]["point"];
                    retRooms.beginTime = dt.Rows[0]["beginTime"];
                    retRooms.endTime = dt.Rows[0]["endTime"];
                    return retRooms;

                }
            }
        }
    }
}
