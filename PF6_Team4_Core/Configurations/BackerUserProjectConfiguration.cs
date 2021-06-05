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
    class BackerUserProjectConfiguration : IEntityTypeConfiguration<BackerUserProject>
    {
        public void Configure(EntityTypeBuilder<BackerUserProject> builder)
        {
            builder.ToTable("BackerUserProject");
            //builder.Property(cus => cus.)
            //    .IsRequired()
            //    .HasMaxLength(50);
            //builder.Property(cus => cus.)
            //    .IsRequired()
            //    .HasMaxLength(50);
            builder.Property(cus => cus.AmountDonated)
                .IsRequired()
                .HasColumnType("decimal(20,2)");
        }
    }
}