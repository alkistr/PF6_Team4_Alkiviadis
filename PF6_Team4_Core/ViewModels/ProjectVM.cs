using PF6_Team4_Core.Models.Options;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PF6_Team4_Core.ViewModels
{
    public class ProjectVM
    {
        public int ProjectId { get; set; }
        [ForeignKey("UserVMId")]
        public int UserVMId { get; set; }
        public List<RewardPackageOptions> rewardpackageProjectVM { get; set; }
        //public List<BackerUserProject> backeruserprojectsUserVM { get; set; }
    }
}
