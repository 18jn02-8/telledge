using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace telledge.Models
{
    public class Student : Controller
    {
        public int id {get;set;}
        public String name { get; set;}
        public String mailaddress { get; set; }
        public String skypeid { get; set; }
        public int passworddigest { get; set; }


        public ActionResult Index()
        {
            return View();
        }

    }
}
