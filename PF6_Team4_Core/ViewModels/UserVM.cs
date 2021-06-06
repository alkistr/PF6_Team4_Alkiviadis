using PF6_Team4_Core.Models;
using PF6_Team4_Core.Models.Options;
using PF6_Team4_Core.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PF6_Team4_Core.ViewModels
{
    public class UserVM
    {
        public int UserVMId {get; set;}
        public string FirstName { get; set; }
        public List<ProjectOptions> projectsUserVM { get; set; }
        public List<BackerUserProjectOptions> backeruserprojectsUserVM { get; set; }
    }
}
