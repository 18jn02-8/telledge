﻿using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
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
        //通話終了予定時刻
        public DateTime endScheduleTime { get; set; }
        //通話開始時刻
        public DateTime beginTime { get; set; }
        //通話終了時刻
        public DateTime endTime { get; set; }

        public bool isClosed()
        {
            if (endTime == null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public void close()
        {
            DateTime dt = DateTime.Now;
            endTime = dt;
        }
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
                    command.CommandText = "Insert Into Room Values (@teacherId,@roomName,@tag,@description,@worstTime,@extensionTime,@point,@endScheduleTime,@beginTime,@endTime)";
                    command.Parameters.Add(new SqlParameter("@teacherId", teacherId));
                    command.Parameters.Add(new SqlParameter("@roomName", roomName));
                    command.Parameters.Add(new SqlParameter("@tag", tag));
                    command.Parameters.Add(new SqlParameter("@description", description));
                    command.Parameters.Add(new SqlParameter("@worstTime", worstTime));
                    command.Parameters.Add(new SqlParameter("@extensionTime", extensionTime));
                    command.Parameters.Add(new SqlParameter("@point", point));
                    command.Parameters.Add(new SqlParameter("@endScheduleTime", endScheduleTime));
                    command.Parameters.Add(new SqlParameter("@beginTime", beginTime));
                    command.Parameters.Add(new SqlParameter("@endTime",DBNull.Value));
                    int cnt = command.ExecuteNonQuery();
                    if (cnt != 0)
                    {
                        check = true;
                    }
                    connection.Close();
                }
                catch (SqlException e)
                {
                    //入力情報が足りないメッセージを吐く
                    return false;
                }
            }
            return check;
        }
        public static Room[] getRooms()
        {
            Room[] retRooms = null; //配列オブジェクトの参照先をnullとする
            string cstr = ConfigurationManager.ConnectionStrings["Db"].ConnectionString;
            using (SqlConnection connection = new SqlConnection(cstr))
            {
                string sql = "select * from Room";
                DataSet ds = new DataSet();
                SqlDataAdapter adapter = new SqlDataAdapter(sql, connection);
                int cnt = adapter.Fill(ds, "Room");
                DataTable dt = ds.Tables["Room"];
                if(cnt != 0) { 
                    retRooms = new Room[cnt];   //配列オブジェクトとして一件以上の要素を返すことが確定したためRoomインスタンスへの参照を保存する領域を生成する
                    for (int i = 0; i < cnt; i++)
                    {
                        retRooms[i] = new Room();   //引数なしコンストラクタで初期化し、戻したい値を格納する領域を生成する
                        retRooms[i].id = (int)dt.Rows[i]["id"];
                        retRooms[i].teacherId = (int)dt.Rows[i]["teacherId"];
                        retRooms[i].roomName = (String)dt.Rows[i]["roomName"];
                        retRooms[i].tag = (String)dt.Rows[i]["tag"];
                        retRooms[i].description = (String)dt.Rows[i]["description"];
                        retRooms[i].worstTime = (int)dt.Rows[i]["worstTime"];
                        retRooms[i].extensionTime = (int)dt.Rows[i]["extensionTime"];
                        retRooms[i].point = (int)dt.Rows[i]["point"];
                        retRooms[i].beginTime = (DateTime)dt.Rows[i]["beginTime"];
                        retRooms[i].endTime = (DateTime)dt.Rows[i]["endTime"];
                    }
                }
                return retRooms;
            }
        }
    }
}
