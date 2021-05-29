using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PF6_Team4_Alkiviadis.Models
{
    public class RewardPackage
    {
        public int RewardPackageId { get; set; }
        public decimal MaxAmountRoGetReward { get; set; }
        public string RewardDescription { get; set; }
        public DateTime CreationDate { get; set; }
    }

}
