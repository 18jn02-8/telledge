using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using telledge.Models;

namespace telledge.Controllers.Students
{
    public class HomesController : Controller
    {
        // GET: Homes
        public ActionResult Index()
        {
            return View();
        }
		[HttpGet]
		public ActionResult edit()
		{
			return View("/Views/Students/Homes/edit.cshtml");
		}
		public ActionResult update(String mailaddress,String name,String imagePath,String skypeId)
		{
			Student student = new Student();
			student.passwordDigest = Student.currentUser().passwordDigest;//ログイン済みパスワードダイジェスト取得
			student.id = Student.currentUser().id;//ログイン済みのID取得
			student.mailaddress = mailaddress;
			student.name = name;
			student.profileImage = imagePath;
			student.skypeId = skypeId;
			bool check = student.Update();
			if(check == true)
			{
				return RedirectToRoute("Student", new { controller = "Homes", Action = "mypage"});
			}
			else
			{
				return View("/Views/Students/Homes/edit.cshtml");
			}
		}
    }
}