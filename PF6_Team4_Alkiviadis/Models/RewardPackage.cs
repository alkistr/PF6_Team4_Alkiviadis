﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PF6_Team4_Alkiviadis.Models
{
    public class RewardPackage
    {
        int RewardPackageId { get; set; }
        decimal MaxAmountRoGetReward { get; set; }
        string RewardDescription { get; set; }
        DateTime CreationDate { get; set; }
    }
}
