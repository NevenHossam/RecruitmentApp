using System.ComponentModel.DataAnnotations;

namespace Recruitment_App.Repo.Validators
{
    [AttributeUsage(AttributeTargets.Field | AttributeTargets.Property)]
    public class DateGreaterThanTodayValidator : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            DateTime _date = Convert.ToDateTime(value);
            if (_date >= DateTime.Now)
                return ValidationResult.Success;
            else
                return new ValidationResult("Date should be greater than or equals today.");
        }
    }
}
