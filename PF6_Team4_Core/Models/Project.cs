using System.ComponentModel.DataAnnotations.Schema;


namespace PF6_Team4_Core.Models
{
    public class Project
    {
        public int ProjectId { get; set; }
        public string Title { get; set; }
        [ForeignKey("CreatorId")]
        public int CreatorId { get; set; }
        public string Description { get; set; }
        public decimal TotalAmount { get; set; }
        public decimal CurrentAmount { get; set; }
        public Category category { get; set; } = Category.Software;
        //public DateTime CreationDate { get; set; } = DateTime.Now;
        //public List<RewardPackage> ProjectRewardPackages { get; set; }

    }
}
