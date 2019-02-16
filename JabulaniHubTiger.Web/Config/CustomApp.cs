using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JabulaniHubTiger.Web.Config
{
    public class CustomApp
    {
        public BicycleMicroservice BicycleMicroservice { get; set; }
    }

    public class BicycleMicroservice
    {
        public string Post { get; set; }
        public string Get { get; set; }
        public string Put { get; set; }
        public string Delete { get; set; }
        public string GetAll { get; set; }
    }
}
