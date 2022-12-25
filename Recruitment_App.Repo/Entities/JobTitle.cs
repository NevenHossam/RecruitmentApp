using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Recruitment_App.Repo.Validators;

namespace Recruitment_App.Repo.Entities
{
    public class JobTitle
    {
        public JobTitle()
        {
            Skills = new List<JobTitleSkill>();
        }

        [Key]
        public Guid Id { get; set; }

        [Required]
        public string Name { get; set; }

        public string Description { get; set; }

        public string Responsibilities { get; set; }

        [Required]
        public int JobCategoryId { get; set; }

        [Required(ErrorMessage = "The Valid From Date is required")]
        [Display(Name = "Valid From")]
        [DateGreaterThanTodayValidator]
        public DateTime ValidityDurationFrom { get; set; }

        [Required(ErrorMessage = "The Valid To Date is required")]
        [Display(Name = "Valid To")]
        public DateTime ValidityDurationTo { get; set; }

        public bool IsDeleted { get; set; } = false;

        [Required(ErrorMessage = "The Maximum Applications Number is required")]
        [Display(Name = "Maximum Applications Number")]
        public int MaximumApplications { get; set; }

        [Display(Name = "Job Category")]
        public virtual JobCategory JobCategory { get; set; } = default!;

        [InverseProperty("JobTitles")]
        public virtual ICollection<JobTitleSkill> Skills { get; set; } = default!;

        [InverseProperty("JobTitles")]
        public virtual ICollection<Application> Applications { get; set; } = default!;

        [NotMapped]
        public List<int> SelectedSkillsIds { get; set; }
    }
}
