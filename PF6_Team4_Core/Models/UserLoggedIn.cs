using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PF6_Team4_Core.Models
{
    public class UserLoggedIn
    {
        public int UserLoggedInId { get; set; }
        [ForeignKey ("UserId")]
        public int UserId { get; set; }
        public string Email { get; set; }
    }
}
