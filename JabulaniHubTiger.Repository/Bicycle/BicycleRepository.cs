using JabulaniHubTiger.Repository.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace JabulaniHubTiger.Repository.Bicycle
{
    public class BicycleRepository : GenericRepository<ORM.Bicycle>, IBicycleRepository
    {
        public BicycleRepository(ApplicationDbContext DbContext) : base(DbContext)
        {

        }


    }
}
