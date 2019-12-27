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
			Student student = Student.currentUser();
			if(mailaddress == "")//未入力であれば、現在のメールアドレスを保持する。
			{
				mailaddress = student.mailaddress;
			}
			if(name == "")//未入力であれば、現在の名前を保持する。
			{
				name = student.name;
			}
			if(imagePath == "")//未入力であれば、現在の画像パスを保持する。
			{
				imagePath = student.profileImage;
			}
			if(skypeId == "")//未入力であれば、現在のスカイプIDを保持する。
			{
				skypeId = student.skypeId;
			}
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