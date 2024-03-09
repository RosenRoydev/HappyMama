using System.ComponentModel.DataAnnotations;
using static HappyMama.BusinessLogic.Constants.ErrorMessagesConstants;
using static HappyMama.Infrastructure.Constants.DataValidationConstants;

namespace HappyMama.BusinessLogic.ViewModels.Teacher
{
	public class AddTeacherForm
    {
        [Required(ErrorMessage = RequiredField )]
        [StringLength(FirstNameMaxLength,
            MinimumLength = FirstNameMinLength,
            ErrorMessage = RequiredLength )]
        [Display(Name = "First Name")]
        public string FirstName {  get; set; } = string.Empty;

        [Required(ErrorMessage = RequiredField)]
        [StringLength(LastNameMaxLength,
           MinimumLength = LastNameMinLength,
           ErrorMessage = RequiredLength)]
        [Display(Name = "Last Name")]
        public string LastName { get; set; } = string.Empty;

    }
}
