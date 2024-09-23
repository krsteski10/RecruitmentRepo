using Microsoft.EntityFrameworkCore;
using RecruitmentAPI.Models;

namespace RecruitmentAPI.Data
{
    public class RecruitmentContext : DbContext
    {
        public RecruitmentContext(DbContextOptions<RecruitmentContext> options) : base(options) { }

        public DbSet<Candidate> Candidates { get; set; }
        public DbSet<InterviewFeedback> InterviewFeedbacks { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Candidate>()
                .HasMany(c => c.Skills)
                .WithOne(s => s.Candidate)
                .HasForeignKey(s => s.CandidateId);

            modelBuilder.Entity<Skill>()
                .HasOne(s => s.Candidate)
                .WithMany(c => c.Skills)
                .HasForeignKey(s => s.CandidateId)
                .IsRequired(false);  // Mark the relationship as optional

            modelBuilder.Entity<InterviewFeedback>()
                .HasOne(f => f.Candidate)
                .WithMany(c => c.Feedbacks)
                .HasForeignKey(f => f.CandidateId)
                .IsRequired(false);  // Mark the relationship as optional
        }
    }
}