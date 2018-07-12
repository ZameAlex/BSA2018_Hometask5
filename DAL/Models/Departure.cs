using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Models
{
    public class Departure:Entity
    {
        public Flight Flight { get; set; }
        public DateTime Date { get; set; }
        public Crew Crew { get; set; }
        public Plane Plane { get; set; }
    }
}
