using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PF6_Team4_Alkiviadis.Models.Options
{
    public class BackerUserProjectOptions
    {
        int BackerUserProjectId { get; set; }
        int UserId { get; set; }
        int ProjectId { get; set; }
        decimal AmountDonated { get; set; }
    }
}
