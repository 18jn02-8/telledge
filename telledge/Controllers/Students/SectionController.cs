using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using telledge.Models;

namespace telledge.Controllers.Students
{
	public class SectionController : ApiController
	{
		// GET api/<controller>
		public IEnumerable<string> Get()
		{
			return new string[] { "value1", "value2" };
		}

		// GET api/<controller>/5
		public string Get(int id)
		{
			return "value";
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
		public void Delete(int room_id, int student_id, string api_key)
		{
			//ルームから退出する処理
			if (Student.currentUser() == null) return RedirectToAction("create", "sessions");
			Section.delete(Student.currentUser().id, Section.KeyTarget.studentId);
			return RedirectToAction("index", "rooms");
		}
	}
}