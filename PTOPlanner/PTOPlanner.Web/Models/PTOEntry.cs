using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PTOPlanner.Models
{
    public class PTOEntry
    {
        public int Id { get; set; }
        public int Hours { get; set; }
        public string Comments { get; set; }
    }
}