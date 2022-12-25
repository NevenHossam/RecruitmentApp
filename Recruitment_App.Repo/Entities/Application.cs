using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Recruitment_App.Repo.Entities
{
    public class Application
    {
        [Key]
        public Guid Id { get; set; }
        public Guid ApplicantsId { get; set; }
        public Applicant Applicants { get; set; }
        public Guid JobTitlesId { get; set; }
        public JobTitle JobTitles { get; set; }
        public DateTime CreatedOn { get; set; }
    }
}
