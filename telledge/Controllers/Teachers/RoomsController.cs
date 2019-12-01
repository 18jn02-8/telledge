using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using telledge.Models;

namespace telledge.Controllers.Teachers
{
    public class RoomsController : Controller
    {
        // GET: Rooms
        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public ActionResult Create()
        {
            return View("//Create");

        }
		[HttpPost]
		public ActionResult Create(String name,String description,String tag,DateTime endScheduleTime,int maxExtendTime,int minGuaranteeTime,int fee)
		{
			Room ret = Room.Create(String name, String description, String tag, DateTime endScheduleTime, int maxExtendTime, int minGuaranteeTime, int fee)
			if(ret == true)
			{
				RedirectToAction("call", "Rooms");
			}
			else
			{
				return View("Create");
			}

		}
		public ActionResult index()
        {
            var model = Room.getRooms();
            return View("/Views/Teachers/Rooms/call.cshtml", model);
        }
    }
}