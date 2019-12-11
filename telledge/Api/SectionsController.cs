using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using telledge.Models;

namespace telledge.Api
{
	public class SectionsController : ApiController
	{
		// GET api/<controller>

		public IEnumerable<string> Get()
		{
			return new string[] { "value1", "value2" };
		}

		// GET api/<controller>/5
		public Section Get(int studentId, int roomId)
		{
			return Section.find(roomId, studentId);
		}

		// POST api/<controller>
		public void Post([FromBody]string value)
		{
		}

		// PUT api/<controller>/5
		public void Put(int id, [FromBody]string value)
		{
		}

		// DELETE api/<controller>/5
		public String Delete(int roomId, int studentId)
		{
			//ルームから退出する処理
			//if (Student.currentUser() == null) return RedirectToAction("create", "sessions");
			String message;
			
			Section section = new Section(); 
			section.studentId = studentId;
			section.roomId = roomId;
			if (section.delete() == true)
			{
				message = "Delete was successed!";
			}
			else
			{
				message = "Delete was failed...\n" +
					"There are parameters\n" +
					 "roomId: " + roomId + "\n" +
					 "studentId: " + studentId;
			}

			return message;
		}
	}
}