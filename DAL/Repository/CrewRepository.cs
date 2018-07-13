using DAL.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Repository
{
    public class CrewRepository : BaseRepository<Crew>
    {
        public CrewRepository(DataSource db):base(db)
        {

        }
    }
}
