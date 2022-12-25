using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Recruitment_App.Repo.Entities
{
    public class Applicant
    {
        [Key]
        public Guid Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Email { get; set; }
        [Required(ErrorMessage = "The Mobile Number is required")]
        [Display(Name = "Mobile Number")]
        public int MobileNumber { get; set; }

        [InverseProperty("Applicants")]
        public virtual ICollection<Application> Applications { get; set; } = default!;
    }
}
