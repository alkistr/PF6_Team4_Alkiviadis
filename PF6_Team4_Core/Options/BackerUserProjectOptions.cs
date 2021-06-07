using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace PF6_Team4_Core.Models.Options
{
    public class BackerUserProjectOptions
    {
        public int BackerUserProjectOptionsId { get; set; }

        [ForeignKey("UserId")]
        public int UserId { get; set; }

        [ForeignKey("ProjectId")]
        public int ProjectId { get; set; }
        public decimal AmountDonated { get; set; }
    }
}
