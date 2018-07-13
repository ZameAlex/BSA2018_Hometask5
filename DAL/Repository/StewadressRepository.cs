using DAL.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Repository
{
    public class StewadressRepository : BaseRepository<Stewadress>
    {
        public StewadressRepository(DataSource db):base(db)
        {

        }
    }
}
