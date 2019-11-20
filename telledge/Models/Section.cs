﻿using System;

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

        public Student getStudent()
        {
            Student retStudent = null;
            string cstr = ConfigurationManager.ConnectionStrings["Db"].ConnectionString;
            using (SqlConnection connection = new SqlConnection(cstr))
            {
                string sql = "select * from Student where roomId = @roomid";
                SqlDataAdapter adapter = new SqlDataAdapter(sql, connection);
                adapter.SelectCommand.Parameters.Add("@id", SqlDbType.VarChar);
                DataSet ds = new DataSet();
                int cnt = adapter.Fill(ds, "Student");
                if (cnt != 0)
                {
                    DataTable dt = ds.Tables["Student"];
                    retStudent = new Student();
                    retStudent.id = (int)dt.Rows[0]["id"];
                    retStudent.inactiveDate = (DateTime)dt.Rows[0]["inactiveDate"];
                    retStudent.is2FA = (bool)dt.Rows[0]["is2FA"];
                    retStudent.mailaddress = dt.Rows[0]["mailaddress"].ToString();
                    retStudent.name = dt.Rows[0]["name"].ToString();
                    retStudent.passwordDigest = (byte[])dt.Rows[0]["passwordDigest"];
                    retStudent.point = (int)dt.Rows[0]["point"];
                    retStudent.profileImage = dt.Rows[0]["profileImage"].ToString();
                    retStudent.skypeId = dt.Rows[0]["skypeId"].ToString();
                }
            }
            return retStudent;
        }
    }
}