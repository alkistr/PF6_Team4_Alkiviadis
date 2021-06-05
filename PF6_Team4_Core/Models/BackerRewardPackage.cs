using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace PF6_Team4_Core.Models
{
    public class BackerRewardPackage
    {
        public int BackerRewardPackageId { get; set; }

        [ForeignKey("UserId")]
        public int UserId { get; set; }

        [ForeignKey("RewardpackageId")]
        public int RewardpackageId { get; set; } 
    }
}
