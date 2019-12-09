using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using telledge.Models;

namespace telledge.Api
{
	public class ApiResult<Type>
	{
		public string message { get; set; }
		public Type contents { get; set; }
	}
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
		public ApiResult<Section> Delete(int room_id, int student_id, string api_key)
		{
			//ルームから退出する処理
			//if (Student.currentUser() == null) return RedirectToAction("create", "sessions");
			ApiResult<Section> result = new ApiResult<Section>();
			result.message = "Delete was successed!";
			Section section = new Section(); 
			section.studentId = student_id;
			section.roomId = room_id;
			section.delete();

			return result;
		}
	}
}