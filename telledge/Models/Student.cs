﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;
using System.Data.SqlClient;
using System.Configuration;

namespace telledge.Models
{
    public class Student
    {
        //生徒ID
        public int id { get; set; }
        //生徒名
        public String name { get; set;}
        //生徒メールアドレス
        public String mailaddress { get; set; }
        //生徒プロフィール画像
        public String profileImage { get; set; }
        //生徒スカイプID
        public String skypeId { get; set; }
        //パスワードダイジェスト
        public byte[] passwordDigest { get; set; }
        //二段階認証の有無
        public bool is2FA { get; set; }
        //ポイント
        public int point { get; set; }
        //生徒退会日
        public DateTime inactiveDate {get; set;}

        public static Student login(String mailaddress, String password) 
        {
            Student retStudent = null;
            string cstr = ConfigurationManager.ConnectionStrings["Db"].ConnectionString;
            using (SqlConnection connection = new SqlConnection(cstr))
            {
                if (retStudent.inactiveDate != null)
                {
                    return null;
                }
                string sql = "select * from Student where id = @id";
                SqlDataAdapter adapter = new SqlDataAdapter(sql,connection);
                adapter.SelectCommand.Parameters.Add("@id",SqlDbType.VarChar);
                DataSet ds = new DataSet();
                int cnt = adapter.Fill(ds,"Student");
                if(cnt != 0){
                    retStudent = new Student();
                    DataTable dt = ds.Tables["Student"];
                    retStudent.passwordDigest = (Byte[])dt.Rows[0]["passwordDigest"];
                    //retStudent.inactiveDate = (DateTime)dt.Rows[0]["inactiveDate"]; 
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

        public void setPassword(String passwordRow)
        {
            byte[] input = Encoding.ASCII.GetBytes(passwordRow);
            SHA256 sha = new SHA256CryptoServiceProvider();
            passwordDigest = sha.ComputeHash(input);
        }

        /*public static  Student currentUser()
        {
            Student s = new Student();
           (Student)Session["Student"];
        }*/
    }
}
 //引数に渡されたメールアドレスを持つ生徒のパスワードダイジェストと引数の平文パスワードをSHA256でダイジェスト化したものを比較し、
        //等しければ対応するStudentクラスのオブジェクトを返しセッション変数名"Student"のセッションにオブジェクトを登録する。
        //等しくなければnullを返し、セッションへの登録は行わない。 また、退会日がnull以外の場合は無条件にnullを返す。
