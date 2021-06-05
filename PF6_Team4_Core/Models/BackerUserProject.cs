using System.ComponentModel.DataAnnotations.Schema;

namespace PF6_Team4_Core.Models
{
    public class BackerUserProject
    {
        public int BackerUserProjectId { get; set; }

        [ForeignKey("UserId")]
        public int UserId { get; set; }

        [ForeignKey("ProjectId")]
        public int ProjectId { get; set; }
        public decimal AmountDonated { get; set; }
    }
}
