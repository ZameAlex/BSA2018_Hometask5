using DAL.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Repository
{
    public class TicketRepository : BaseRepository<Ticket>
    {
        public TicketRepository(DataSource db) : base(db)
        {

        }
    }
}
