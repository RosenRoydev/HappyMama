using System.ComponentModel.DataAnnotations;
using static HappyMama.Infrastructure.Constants.DataValidationConstants;
using static HappyMama.BusinessLogic.Constants.ErrorMessagesConstants;

namespace HappyMama.BusinessLogic.ViewModels.Parent
{
    public class AddParentFormModel
    {
        [Required(ErrorMessage = RequiredField)]
        [StringLength(FirstNameMaxLength, 
            MinimumLength = FirstNameMinLength,
            ErrorMessage = RequiredLength)]
        public string FirstName { get; set; } = string.Empty;

		[Required(ErrorMessage = RequiredField)]
		[StringLength(LastNameMaxLength,
		   MinimumLength = LastNameMinLength,
		   ErrorMessage = RequiredLength)]
		public string LastName { get; set; } = String.Empty;

        [Required(ErrorMessage = RequiredField)]
        [Range(AmountMinValue, 
            AmountMaxValue,
            ErrorMessage = NeededAmountRestrict)]
        public decimal Amount { get; set; }

        public bool IsApproved { get; set; }
    }
}