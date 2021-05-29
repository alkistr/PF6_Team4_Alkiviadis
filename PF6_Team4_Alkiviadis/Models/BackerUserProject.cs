using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PF6_Team4_Alkiviadis.Models
{
    public class BackerUserProject
    {
        public int Id { get; set; }
        public User user { get; set; }
        public Project project { get; set; }
        public decimal AmountDonated { get; set; }
    }
}
