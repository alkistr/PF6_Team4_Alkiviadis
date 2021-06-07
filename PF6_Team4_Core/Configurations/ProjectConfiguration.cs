using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PF6_Team4_Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PF6_Team4_Core.Configurations
{
    class ProjectConfiguration : IEntityTypeConfiguration<Project>
    {
        public void Configure(EntityTypeBuilder<Project> builder)
        {
            builder.ToTable("Project");
            builder.Property(cus => cus.Title)
                .IsRequired()
                .HasMaxLength(50);
            builder.Property(cus => cus.Description)
                .IsRequired()
                .HasMaxLength(50);
            builder.Property(cus => cus.CurrentAmount)
                .IsRequired()
                .HasColumnType("decimal(20,2)");
            builder.Property(cus => cus.TotalAmount)
                .IsRequired()
                .HasColumnType("decimal(20,2)");
        }
    }
}