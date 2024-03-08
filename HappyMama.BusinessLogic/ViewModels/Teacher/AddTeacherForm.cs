using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static HappyMama.Infrastructure.Constants.DataValidationConstants;
using static HappyMama.BusinessLogic.Constants.ErrorMessagesConstants;

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
