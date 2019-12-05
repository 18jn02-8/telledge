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
        [HttpGet]
        public ActionResult Create()
        {
            return View("/Views/Teachers/Rooms/Create.cshtml");


		}
        public ActionResult index()
        {
            var model = Room.getRooms();
            return View("/Views/Teachers/Rooms/index.cshtml", model);
        }
		public ActionResult call(int id)
		{
			var model = Room.find(id);
			return View("/Views/Teachers/Rooms/call.cshtml", model);
        }
		[HttpPost]
		public ActionResult Create(int teacherId,String roomName,String tag,String description,int worstTime,int extensionTime,int point,DateTime endScheduleTime, DateTime beginTime, DateTime endTime)
		{
			Room room = new Room();
			room.teacherId = teacherId;
			room.roomName = roomName;
			room.tag = tag;
			room.description = description;
			room.worstTime = worstTime;
			room.extensionTime = extensionTime;
			room.point = point;
			room.endScheduleTime = endScheduleTime;
			room.beginTime = beginTime;
			room.endTime = endTime;

			bool ret = room.create();
			if(ret == true)
			{
				return RedirectToAction("call", "Rooms");
			}
			else
			{
				return View("Create");
			}

		}
    }
}