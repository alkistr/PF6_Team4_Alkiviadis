﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PF6_Team4_Core.Models
{
    public class RewardPackage
    {
        public int RewardPackageId { get; set; }
        public decimal MaxAmountToGetReward { get; set; }
        public string RewardDescription { get; set; }
        public string RewardPackageName { get; set; }

        public DateTime CreationDate { get; set; }
    }

}
