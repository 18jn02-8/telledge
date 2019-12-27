using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace telledge.Controllers.Students
{
    public class PasswordsController : Controller
    {
        // GET: Passwords
        public ActionResult Index()
        {
            return View();
        }
		[HttpGet]
		public ActionResult edit()
		{
			return View("/Views/Students/Passwords/edit.cshtml");
		}
    }
}