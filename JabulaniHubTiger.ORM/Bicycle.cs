using JabulaniHubTiger.Helper;
using System;
using System.Collections.Generic;
using System.Text;

namespace JabulaniHubTiger.ORM
{
    public class Bicycle
    {
        public int Id { get; set; }
        public string Model { get; set; }
        public DateTime CreatedOn { get; set; }
        public BicyleCondition BicyleCondition { get; set; }
        public DateTime? UpdatedOn { get; set; }
        public virtual ICollection<Booking> Bookings { get; set; }
    }
}
