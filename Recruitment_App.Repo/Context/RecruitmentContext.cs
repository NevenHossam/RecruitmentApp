using Microsoft.EntityFrameworkCore;
using Recruitment_App.Repo.Entities;

namespace Recruitment_App.Repo.Context
{
    public class RecruitmentContext : DbContext
    {
        public RecruitmentContext(DbContextOptions<RecruitmentContext> options) : base(options)
        {
        }

        public DbSet<JobTitle> JobTitles { set; get; }
        public DbSet<JobCategory> JobCategories { set; get; }
        public DbSet<Skill> Skills { set; get; }
        public DbSet<Applicant> Applicants { set; get; }
    }
}
