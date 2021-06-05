using System.ComponentModel.DataAnnotations.Schema;

namespace PF6_Team4_Core.Models
{
    public class ProjectRewardPackage
    {
        public int ProjectRewardPackageId { get; set; }

        [ForeignKey("RewardPackageId")]
        public int RewardPackageId { get; set; }

        [ForeignKey("ProjectId")]
        public int ProjectId { get; set; }

    }
}
