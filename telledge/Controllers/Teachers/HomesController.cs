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
            return View("/Views/Teachers/Homes/mypage.cshtml", Teacher.currentUser());
        }
    }
}