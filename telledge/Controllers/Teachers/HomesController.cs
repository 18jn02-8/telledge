using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using telledge.Models;

namespace telledge.Controllers.Teachers
{
    public class HomesController : Controller
    {
        // GET: Homes
        public ActionResult mypage()
        {
			if (Teacher.currentUser() == null) return RedirectToRoute("Teacher", new { controller = "Sessions", Action = "create" });
            return View("/Views/Teachers/Homes/mypage.cshtml", Teacher.currentUser());

		}

		public ActionResult update(String imagePath ,String mailaddress ,String name, String nationality, int sex, String intoroduction)
		{

		}

		public ActionResult edit()
		{
			return View("/Views/Teacher/Homes/edit.cshtml");
		}
    }
}