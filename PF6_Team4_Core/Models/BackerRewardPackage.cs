using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PF6_Team4_Core.Models
{
    public class BackerRewardPackage
    {
        public int BackerRewardPackageId { get; set; }
        public User user { get; set; }
        public RewardPackage rewardpackage { get; set; }        
    }
}
