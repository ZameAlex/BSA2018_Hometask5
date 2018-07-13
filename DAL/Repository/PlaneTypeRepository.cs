using DAL.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Repository
{
    public class PlaneTypeRepository : BaseRepository<PlaneType>
    {
        public PlaneTypeRepository(DataSource db):base(db)
        {

        }

    }
}
