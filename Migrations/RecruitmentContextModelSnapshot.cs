﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using RecruitmentAPI.Data;

#nullable disable

namespace RecruitmentAPI.Migrations
{
    [DbContext(typeof(RecruitmentContext))]
    partial class RecruitmentContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.33")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("RecruitmentAPI.Models.Candidate", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<bool>("IsHired")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("YearsOfExperience")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Candidates");
                });

            modelBuilder.Entity("RecruitmentAPI.Models.InterviewFeedback", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int?>("CandidateId")
                        .HasColumnType("int");

                    b.Property<string>("Feedback")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Rating")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CandidateId");

                    b.ToTable("InterviewFeedbacks");
                });

            modelBuilder.Entity("Skill", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int?>("CandidateId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("CandidateId");

                    b.ToTable("Skill");
                });

            modelBuilder.Entity("RecruitmentAPI.Models.InterviewFeedback", b =>
                {
                    b.HasOne("RecruitmentAPI.Models.Candidate", "Candidate")
                        .WithMany("Feedbacks")
                        .HasForeignKey("CandidateId");

                    b.Navigation("Candidate");
                });

            modelBuilder.Entity("Skill", b =>
                {
                    b.HasOne("RecruitmentAPI.Models.Candidate", "Candidate")
                        .WithMany("Skills")
                        .HasForeignKey("CandidateId");

                    b.Navigation("Candidate");
                });

            modelBuilder.Entity("RecruitmentAPI.Models.Candidate", b =>
                {
                    b.Navigation("Feedbacks");

                    b.Navigation("Skills");
                });
#pragma warning restore 612, 618
        }
    }
}
