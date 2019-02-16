using System;
using System.Collections.Generic;
using System.Text;

namespace JabulaniHubTiger.ORM
{
    public class Booking
    {
        public int BicycleId { get; set; }
        public Bicycle Bicycle { get; set; }
        public int BicycleUserId { get; set; }
        public BicycleUser BicycleUser { get; set; }
        public DateTime BookedOn { get; set; }
        public DateTime EndBookingOn { get; set; }
    }
}
