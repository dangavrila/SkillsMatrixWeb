using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkillsMatrixWeb.Models
{
    public class SkillsMatrixDbContext : IdentityDbContext<UserProject>
    {
        private readonly IConfigurationRoot _config;

        public SkillsMatrixDbContext(IConfigurationRoot config, DbContextOptions options) : base(options)
        {
            _config = config;
        }

        public DbSet<Technology> Technologies { get; set; }
        public DbSet<TechnologyStack> TechnologyStacks { get; set; }
        public DbSet<TechnologiesInTechnologiesStack> TechnologiesInTechnologiesStacks { get; set; }
        public DbSet<Seat> Seats { get; set; }
        public DbSet<Project> Projects { get; set; }
        public DbSet<Skill> Skills { get; set; }
        public DbSet<TechnologysInSkill> TechnologysInSkills { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<EmployeeJobHistory> EmployeeJobHistories { get; set; }
        public DbSet<JobHistory> JobHistories { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);

            optionsBuilder.UseSqlServer(_config["ConnectionStrings:SkillsMatrixContextConnection"]);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TechnologiesInTechnologiesStack>()
                .HasKey(tts => new { tts.TechnologyId, tts.TechnologyStackId });

            modelBuilder.Entity<TechnologiesInTechnologiesStack>()
                .HasOne(tts => tts.Technology)
                .WithMany(t => t.TechnologiesInTechnologiesStacks)
                .HasForeignKey(tts => tts.TechnologyId);

            modelBuilder.Entity<TechnologiesInTechnologiesStack>()
                .HasOne(tts => tts.TechnologyStack)
                .WithMany(ts => ts.TechnologiesInTechnologiesStacks)
                .HasForeignKey(tts => tts.TechnologyStackId);

            modelBuilder.Entity<TechnologysInSkill>()
                .HasKey(ts => new { ts.TechnologyId, ts.SkillId });

            modelBuilder.Entity<TechnologysInSkill>()
                .HasOne(ts => ts.Technology)
                .WithMany(t => t.TechnologyInSkills)
                .HasForeignKey(ts => ts.TechnologyId);

            modelBuilder.Entity<TechnologysInSkill>()
                .HasOne(ts => ts.Skill)
                .WithMany(s => s.TechnologyInSkills)
                .HasForeignKey(ts => ts.SkillId);

            modelBuilder.Entity<EmployeeJobHistory>()
                .HasKey(ejh => new { ejh.EmployeeId, ejh.JobHistoryId });

            modelBuilder.Entity<EmployeeJobHistory>()
                .HasOne(ejh => ejh.Employee)
                .WithMany(e => e.EmployeeJobHistories)
                .HasForeignKey(ejh => ejh.EmployeeId);

            modelBuilder.Entity<EmployeeJobHistory>()
                .HasOne(ejh => ejh.JobHistory)
                .WithMany(jh => jh.EmployeeJobHistories)
                .HasForeignKey(ejh => ejh.JobHistoryId);
        }
    }
}
