using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Recruitment_App.Repo.Entities
{
    public class Skill
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string SkillName { get; set; }

        [InverseProperty("Skills")]
        public virtual ICollection<JobTitleSkill> JobTitles { get; set; } = default!;
    }
}
