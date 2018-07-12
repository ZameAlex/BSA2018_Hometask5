using DAL.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Repository
{
    public class TicketRepository : IRepository<Ticket>
    {
        public void Create(Ticket entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(Ticket entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Ticket> Get()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Ticket> Get(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(Ticket entity)
        {
            throw new NotImplementedException();
        }
    }
}
