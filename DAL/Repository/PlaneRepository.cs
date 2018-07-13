using DAL.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Repository
{
    public class PlaneRepository : BaseRepository<Plane>
    {
        public PlaneRepository(DataSource db):base(db)
        {
                
        }

        public void Update(TimeSpan expires,int id)
        {
            Get(id).Expired = expires;
        }
    }
}
