using JabulaniHubTiger.Repository.Bicycle;
using System;
using System.Collections.Generic;
using System.Text;

namespace JabulaniHubTiger.Service.Bicycle
{
    public class BicycleService : GenericService<ORM.Bicycle>, IBicycleService
    {
        public BicycleService(IBicycleRepository bicycleRepository) : base(bicycleRepository)
        {

        }
    }
}
