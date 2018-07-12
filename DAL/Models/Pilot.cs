using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Models
{
    public class Pilot:Entity
    {
        public string Name { get; set; }
        public string LastName { get; set; }
        public DateTime Birthday { get; set; }
        public int Experience { get; set; }
    }
}
