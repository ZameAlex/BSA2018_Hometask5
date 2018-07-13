using DAL.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Repository
{
    public class PilotRepository : BaseRepository<Pilot>
    {
        public PilotRepository(DataSource db):base(db)
        {

        }

        public void Update(int experience,int id)
        {
            Get(id).Experience = experience;
        }
    }
}
