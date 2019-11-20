using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace telledge.Models
{
    public class Section
    {
        public int roomId { get; set; }
        public int studentId { get; set; }
        public String request { get; set; }
        public int valuation { get; set; }
        public int order { get; set; }
        public DateTime beginTime { get; set; }
        public int talkTime { get; set; }
    }
}