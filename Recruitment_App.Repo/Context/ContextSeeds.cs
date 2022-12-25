using Microsoft.Extensions.Logging;
using Recruitment_App.Repo.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Recruitment_App.Repo.Context
{
    public class ContextSeeds
    {
        public static async Task SeedAsync(RecruitmentContext recruitmentContext, ILogger<RecruitmentContext> logger)
        {
            if (!recruitmentContext.JobCategories.Any())
            {
                recruitmentContext.JobCategories.AddRange(GetPreconfiguredJobCategories());
                await recruitmentContext.SaveChangesAsync();
                logger.LogInformation("Seed database associated with context {RecruitmentContext}", typeof(RecruitmentContext).Name);
            }
            if (!recruitmentContext.Skills.Any())
            {
                recruitmentContext.Skills.AddRange(GetPreconfiguredSkills());
                await recruitmentContext.SaveChangesAsync();
                logger.LogInformation("Seed database associated with context {RecruitmentContext}", typeof(RecruitmentContext).Name);
            }
        }

        private static IEnumerable<JobCategory> GetPreconfiguredJobCategories()
        {
            return new List<JobCategory>
            {
                new JobCategory{JobCategoryName = "Development" },
                new JobCategory{JobCategoryName = "HR" },
                new JobCategory{JobCategoryName = "Markiting" },
            };
        }
        private static IEnumerable<Skill> GetPreconfiguredSkills()
        {
            return new List<Skill>
            {
                new Skill{SkillName = "Multitasking" },
                new Skill{SkillName = "Collaboration" },
                new Skill{SkillName = "Integrity" },
                new Skill{SkillName = "Management" },
            };
        }
    }
}
