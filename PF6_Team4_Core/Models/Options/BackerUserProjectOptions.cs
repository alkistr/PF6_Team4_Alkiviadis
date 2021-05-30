using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PF6_Team4_Core.Models.Options
{
    public class BackerUserProjectOptions
    {
        public int BackerUserProjectId { get; set; }
        public int UserId { get; set; }
        public int ProjectId { get; set; }
        public decimal AmountDonated { get; set; }
    }
}
