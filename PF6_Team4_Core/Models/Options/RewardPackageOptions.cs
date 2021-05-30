using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PF6_Team4_Core.Models.Options
{
    public class RewardPackageOptions
    {
        public decimal MaxAmountRoGetReward { get; set; }
        public string RewardDescription { get; set; }
        public string RewardPackageName { get; set; }
        public DateTime CreationDate { get; set; }

    }
}
