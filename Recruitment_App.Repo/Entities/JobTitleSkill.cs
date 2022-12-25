using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Recruitment_App.Repo.Entities
{
    public class JobTitleSkill
    {
        public JobTitleSkill()
        {
            Skills = new Skill();
            JobTitles = new JobTitle();
        }

        [Key]
        public Guid Id { get; set; }
        public Guid JobTitleId { get; set; }
        public JobTitle JobTitles { get; set; }
        public int SkillId { get; set; }
        public Skill Skills { get; set; }
    }
}
