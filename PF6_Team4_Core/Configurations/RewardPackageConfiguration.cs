using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PF6_Team4_Core.Models;


namespace PF6_Team4_Core.Configurations
{
    class RewardPackageConfiguration : IEntityTypeConfiguration<RewardPackage>
    {
        public void Configure(EntityTypeBuilder<RewardPackage> builder)
        {
            builder.ToTable("RewardPackage");
            builder.Property(cus => cus.RewardDescription)
                .IsRequired()
                .HasMaxLength(50);
            builder.Property(cus => cus.RewardPackageName)
                .IsRequired()
                .HasMaxLength(50);
            builder.Property(cus => cus.MaxAmountRoGetReward)
                .IsRequired()
                .HasColumnType("decimal(20,2)");
        }
    }
}
