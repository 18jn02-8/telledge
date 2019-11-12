﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace telledge.Models
{
    public class Student : Controller
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
        public int passwordDigest { get; set; }

        //二段階認証の有無
        public bool is2FA { get; set; }

        //ポイント
        public int point { get; set; }

        //生徒退会日
        public DateTime inactiveDate {get; set;}
    }
}
