using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using telledge.Models;

namespace telledge.Controllers.Students
{
    public class RegistrationsController : Controller
    {
        // GET: Registrations
        public ActionResult deactivate()
        {
			if (Student.currentUser() == null) return RedirectToRoute("Student", new { controller = "Sessions", Action = "create" });
			return View("/Views/Students/Registrations/deactivate.cshtml");
		}

		[HttpPost]
		public ActionResult delete()
		{
			if (Student.currentUser() == null) return RedirectToRoute("Student", new { controller = "Sessions", Action = "create" });
			Student.currentUser().delete();
			Student.logout();
			return RedirectToAction("top", "Homes");
		}
		[HttpPost]
		public ActionResult create(String mailaddress,String password,String passwordConfirmation)
		{		
			if(password != "" && passwordConfirmation != "")
			{
				if(password == passwordConfirmation)
				{
					Student student = new Student();
					student.setPassword(password);
					student.mailaddress = mailaddress;
					student.create();
					return View("/Views/Students/Registrations/top.cshtml");
				}
			}
			return View("/Views/Students/Registrations/create.cshtml");
		}
		[HttpGet]
		public ActionResult create()
		{
			return View("/Views/Students/Registrations/create.cshtml");
		}
	}
}