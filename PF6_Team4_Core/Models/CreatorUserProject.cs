﻿
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PF6_Team4_Core.Models
{
    public class CreatorUserProject
    {
        public int CreatorUserProjectId { get; set; }
        public User user { get; set; }
        public Project project { get; set; }
    }
}