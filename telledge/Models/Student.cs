using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System;
using System.Collections.Generic;
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
            string cstr = ConfigurationManager.ConnectionStrings["Db"].ConnectionString;
            using (SqlConnection connection = new SqlConnection(cstr))
            {
                Student s = new Student();
                string sql = "select * from Student";
                byte[] input = Encoding.ASCII.GetBytes(password);
                SHA256 sha = new SHA256CryptoServiceProvider();
                byte[] hash_sha256 = sha.ComputeHash(input);
                if ( == hash_sha256)
                {
                    Session["Student"] = Student;
                }
                else
                {
                    return null;
                }
                if (inactiveDate != null)
                {
                    return null;
                }
            }
        }
    }
}
 //引数に渡されたメールアドレスを持つ生徒のパスワードダイジェストと引数の平文パスワードをSHA256でダイジェスト化したものを比較し、
        //等しければ対応するStudentクラスのオブジェクトを返しセッション変数名"Student"のセッションにオブジェクトを登録する。
        //等しくなければnullを返し、セッションへの登録は行わない。 また、退会日がnull以外の場合は無条件にnullを返す。
