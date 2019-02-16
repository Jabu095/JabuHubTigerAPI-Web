using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace JabulaniHubTiger.Helper
{
    public enum BicyleCondition
    {
        good = 1, bad = 2, worse = 3
    }

    public enum Gender
    {
        male = 1,
        female = 2,
        other = 3
    }
    public class BicycleRequestViewModel
    {
        public int Id { get; set; }
        [Required]
        public string Model { get; set; }
        [Required]
        public BicyleCondition BicyleCondition { get; set; }
        [Required]
        public DateTime CreatedOn { get; set; }
    }
}
