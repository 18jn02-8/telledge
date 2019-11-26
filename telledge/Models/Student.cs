using System;

using System.Web;

using System.Data;
using System.Data.SqlClient;
using System.Text;

using System.Security.Cryptography;

using System.Configuration;
using System.Linq;

namespace telledge.Models
{
    public class Student
    {
        //生徒ID
        public int id { get; set; }
        //生徒名
        public String name { get; set; }
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
        public DateTime? inactiveDate {get; set;}

        public bool logout()
        {
            bool ret;
            if (ret = HttpContext.Current.Session["Student"] != null) HttpContext.Current.Session["Student"] = null;
            return ret;
        }

        public static Student login(String mailaddress, String password)
        {
            Student retStudent = null;
            string cstr = ConfigurationManager.ConnectionStrings["Db"].ConnectionString;
            using (SqlConnection connection = new SqlConnection(cstr))
            {
                string sql = "select * from Student where mailaddress = @mailaddress";
                SqlDataAdapter adapter = new SqlDataAdapter(sql, connection);
                adapter.SelectCommand.Parameters.Add("@mailaddress", SqlDbType.VarChar);
                adapter.SelectCommand.Parameters["@mailaddress"].Value = mailaddress;
                DataSet ds = new DataSet();
                int cnt = adapter.Fill(ds, "Student");
                if (cnt != 0)
                {
                    
                    DataTable dt = ds.Tables["Student"];
                    Byte[] passwordDigest = (Byte[])dt.Rows[0]["passwordDigest"];
                    if (retStudent.inactiveDate == null)
                    {
                        byte[] input = Encoding.ASCII.GetBytes(password);
                        SHA256 sha = new SHA256CryptoServiceProvider();
                        byte[] hash_sha256 = sha.ComputeHash(input);
                        if (passwordDigest.SequenceEqual(hash_sha256))
                        {
                            retStudent = new Student();
                            retStudent.id = (int)dt.Rows[0]["id"];
                            retStudent.name = dt.Rows[0]["name"].ToString();
                            retStudent.mailaddress = dt.Rows[0]["mailaddress"].ToString();
                            retStudent.profileImage = dt.Rows[0]["profileImage"].ToString();
                            retStudent.skypeId = dt.Rows[0]["skypeId"].ToString();
                            retStudent.passwordDigest = (Byte[])dt.Rows[0]["passwordDigest"];
                            retStudent.is2FA = (bool)dt.Rows[0]["is2FA"];
                            retStudent.point = (int)dt.Rows[0]["point"];
                            if (dt.Rows[0]["inactiveDate"] != DBNull.Value)
                            {
                                retStudent.inactiveDate = DateTime.Parse(dt.Rows[0]["inactiveDate"].ToString());
                            }
                            HttpContext.Current.Session["Student"] = retStudent;
                        }
                    }
                }
            }
            return retStudent;
        }
        public void setPassword(String passwordRow)
        {
            byte[] input = Encoding.ASCII.GetBytes(passwordRow);
            SHA256 sha = new SHA256CryptoServiceProvider();
            passwordDigest = sha.ComputeHash(input);
        }

        public static Student currentUser()
        {
            return (Student)HttpContext.Current.Session["Student"];
        }
        public bool create()
        {
            bool check = false;
            string cstr = ConfigurationManager.ConnectionStrings["Db"].ConnectionString;
            using (var connection = new SqlConnection(cstr))
            {
                try
                {
                    String sql = "Insert Into Student ( name , mailaddress , profileImage , skypeId , passwordDigest , is2FA , point , inactiveDate) Values ( @name , @mailaddress , @profileImage , @skypeId , @passwordDigest , @is2FA , @point , @inactiveDate) ";
                    SqlCommand command = new SqlCommand(sql, connection);
                    command.Parameters.Add("@name", SqlDbType.VarChar);
                    command.Parameters["@name"].Value = name;
                    command.Parameters.Add("@mailaddress", SqlDbType.VarChar);
                    command.Parameters["@mailaddress"].Value = mailaddress;
                    command.Parameters.Add("@profileImage", SqlDbType.VarChar);
                    command.Parameters["@profileImage"].Value = profileImage;
                    command.Parameters.Add("@skypeId", SqlDbType.VarChar);
                    command.Parameters["@skypeId"].Value = skypeId;
                    command.Parameters.Add("@passwordDigest", SqlDbType.VarBinary);
                    command.Parameters["@passwordDigest"].Value = passwordDigest;
                    command.Parameters.Add("@is2FA", SqlDbType.Bit);
                    command.Parameters["@is2FA"].Value = is2FA;
                    command.Parameters.Add("@point", SqlDbType.Int);
                    command.Parameters["@point"].Value = point;
                    command.Parameters.Add("@inactiveDate", SqlDbType.Date);
                    command.Parameters["@inactiveDate"].Value = DBNull.Value;
                    connection.Open();
                    int cnt = command.ExecuteNonQuery();
                    connection.Close();
                    if (cnt != 0)
                    {
                        check = true;
                    }
                }catch(SqlException e){
                    //入力情報が足りないメッセージを吐く
                    return false;
                }
            }
            return check;
        }
    }
}
 //引数に渡されたメールアドレスを持つ生徒のパスワードダイジェストと引数の平文パスワードをSHA256でダイジェスト化したものを比較し、
        //等しければ対応するStudentクラスのオブジェクトを返しセッション変数名"Student"のセッションにオブジェクトを登録する。
        //等しくなければnullを返し、セッションへの登録は行わない。 また、退会日がnull以外の場合は無条件にnullを返す。
