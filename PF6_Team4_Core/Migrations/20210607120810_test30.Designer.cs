﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using PF6_Team4_Core.Data;

namespace PF6_Team4_Core.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20210607120810_test30")]
    partial class test30
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.6")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("PF6_Team4_Core.Models.BackerUserProject", b =>
                {
                    b.Property<int>("BackerUserProjectId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<decimal>("AmountDonated")
                        .HasColumnType("decimal(20,2)");

                    b.Property<int>("ProjectId")
                        .HasColumnType("int");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("BackerUserProjectId");

                    b.ToTable("BackerUserProject");
                });

            modelBuilder.Entity("PF6_Team4_Core.Models.Options.BackerUserProjectOptions", b =>
                {
                    b.Property<int>("BackerUserProjectOptionsId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<decimal>("AmountDonated")
                        .HasColumnType("decimal(20,2)");

                    b.Property<int>("ProjectId")
                        .HasColumnType("int");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.Property<int?>("UserVMId")
                        .HasColumnType("int");

                    b.HasKey("BackerUserProjectOptionsId");

                    b.HasIndex("UserVMId");

                    b.ToTable("BackerUserProjectOptions");
                });

            modelBuilder.Entity("PF6_Team4_Core.Models.Project", b =>
                {
                    b.Property<int>("ProjectId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CreatorId")
                        .HasColumnType("int");

                    b.Property<decimal>("CurrentAmount")
                        .HasColumnType("decimal(20,2)");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<decimal>("TotalAmount")
                        .HasColumnType("decimal(20,2)");

                    b.Property<int>("category")
                        .HasColumnType("int");

                    b.HasKey("ProjectId");

                    b.ToTable("Project");
                });

            modelBuilder.Entity("PF6_Team4_Core.Models.ProjectRewardPackage", b =>
                {
                    b.Property<int>("ProjectRewardPackageId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("ProjectId")
                        .HasColumnType("int");

                    b.Property<int>("RewardPackageId")
                        .HasColumnType("int");

                    b.HasKey("ProjectRewardPackageId");

                    b.ToTable("ProjectRewardPackages");
                });

            modelBuilder.Entity("PF6_Team4_Core.Models.RewardPackage", b =>
                {
                    b.Property<int>("RewardPackageId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("CreationDate")
                        .HasColumnType("datetime2");

                    b.Property<decimal>("MaxAmountRoGetReward")
                        .HasColumnType("decimal(20,2)");

                    b.Property<int>("ProjectId")
                        .HasColumnType("int");

                    b.Property<string>("RewardDescription")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("RewardPackageName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("RewardPackageId");

                    b.HasIndex("ProjectId");

                    b.ToTable("RewardPackage");
                });

            modelBuilder.Entity("PF6_Team4_Core.Models.User", b =>
                {
                    b.Property<int>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Address")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreationDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("PF6_Team4_Core.Models.UserLoggedIn", b =>
                {
                    b.Property<int>("UserLoggedInId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("UserLoggedInId");

                    b.ToTable("UsersLoggedIn");
                });

            modelBuilder.Entity("PF6_Team4_Core.Options.ProjectOptions", b =>
                {
                    b.Property<int>("ProjectOptionsId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<decimal>("CurrentAmount")
                        .HasColumnType("decimal(20,2)");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<decimal>("TotalAmount")
                        .HasColumnType("decimal(20,2)");

                    b.Property<int?>("UserVMId")
                        .HasColumnType("int");

                    b.Property<int>("category")
                        .HasColumnType("int");

                    b.HasKey("ProjectOptionsId");

                    b.HasIndex("UserVMId");

                    b.ToTable("ProjectOptions");
                });

            modelBuilder.Entity("PF6_Team4_Core.ViewModels.UserVM", b =>
                {
                    b.Property<int>("UserVMId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("FirstName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserVMId");

                    b.ToTable("UsersVM");
                });

            modelBuilder.Entity("PF6_Team4_Core.Models.Options.BackerUserProjectOptions", b =>
                {
                    b.HasOne("PF6_Team4_Core.ViewModels.UserVM", null)
                        .WithMany("backeruserprojectsUserVM")
                        .HasForeignKey("UserVMId");
                });

            modelBuilder.Entity("PF6_Team4_Core.Models.RewardPackage", b =>
                {
                    b.HasOne("PF6_Team4_Core.Models.Project", null)
                        .WithMany("ProjectRewardPackages")
                        .HasForeignKey("ProjectId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("PF6_Team4_Core.Options.ProjectOptions", b =>
                {
                    b.HasOne("PF6_Team4_Core.ViewModels.UserVM", null)
                        .WithMany("projectsUserVM")
                        .HasForeignKey("UserVMId");
                });

            modelBuilder.Entity("PF6_Team4_Core.Models.Project", b =>
                {
                    b.Navigation("ProjectRewardPackages");
                });

            modelBuilder.Entity("PF6_Team4_Core.ViewModels.UserVM", b =>
                {
                    b.Navigation("backeruserprojectsUserVM");

                    b.Navigation("projectsUserVM");
                });
#pragma warning restore 612, 618
        }
    }
}
