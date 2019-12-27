using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.Mvc;
using telledge.Models;

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
		[HttpPost]
		public ActionResult update(String oldPassword,String createPassword,String ConfirmationPassword)
		{
			Student student = Student.currentUser();
			byte[] input = Encoding.ASCII.GetBytes(oldPassword);
			SHA256 sha = new SHA256CryptoServiceProvider();
			byte[] HasholdPassword = sha.ComputeHash(input);
			if (student.passwordDigest == HasholdPassword)
			{
				if(createPassword == ConfirmationPassword)
				{
					if(createPassword != "")
					{
						student.setPassword(createPassword);
						student.Update();
						return RedirectToRoute("Student", new { controller = "Sessions", Action = "create"});
					}
				}
			}
			return View("/Views/Students/Passwords/edit.cshtml");
		}
    }
}