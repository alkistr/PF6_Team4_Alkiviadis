﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PF6_Team4_Core.Models.Options.ProjectOptions
{
    public class CreateProjectOptions
    {
        public int ProjectId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public decimal TotalAmount { get; set; }
        public decimal CurrentAmount { get; set; }
        public Category category { get; set; } = Category.Software;
        
    }
}
