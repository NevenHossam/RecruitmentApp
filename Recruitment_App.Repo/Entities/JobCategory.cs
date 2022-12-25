using System.ComponentModel.DataAnnotations;

namespace Recruitment_App.Repo.Entities
{
    public class JobCategory
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public String JobCategoryName { get; set; }

        public virtual ICollection<JobTitle> JobTitles { get; set; } = default!;
    }
}
