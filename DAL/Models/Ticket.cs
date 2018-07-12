using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Models
{
    public class Ticket:Entity
    {
        public Flight Flight { get; set; }
        public decimal Price { get; set; }
    }
}
