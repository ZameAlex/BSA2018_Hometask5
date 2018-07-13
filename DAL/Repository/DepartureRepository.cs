using DAL.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Repository
{
    public class DepartureRepository : BaseRepository<Departure>
    {

        public DepartureRepository(DataSource db):base(db)
        {
                
        }

        public void Update(DateTime date, int id)
        {
            Get(id).Date = date;
        }
    }
}
