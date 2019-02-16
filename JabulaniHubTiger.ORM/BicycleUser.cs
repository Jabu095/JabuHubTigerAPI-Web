using JabulaniHubTiger.Helper;
using System;
using System.Collections.Generic;
using System.Text;

namespace JabulaniHubTiger.ORM
{
   
    public class BicycleUser
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime DateOfBirth { get; set; }
        public Gender Gender { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime? UpdateOn { get; set; }
        public virtual ICollection<Booking> Bookings { get; set; }
    }
}
