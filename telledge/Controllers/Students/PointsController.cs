using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace telledge.Controllers.Students
{
    public class PointsController : Controller
    {
        // GET: Points
        public ActionResult Index()
        {
            return View();
        }
		[HttpGet]
		public ActionResult create()
		{
			return View("/Views/Students/points/create.cshtml");
		}
		[HttpPost]
		public ActionResult create(String cardNumber,DateTime validatedDate,String secureCode,int selectedPoint)
		{

		}
    }
}