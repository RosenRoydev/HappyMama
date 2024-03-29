using System.ComponentModel.DataAnnotations;
using static HappyMama.Infrastructure.Constants.DataValidationConstants;
using static HappyMama.BusinessLogic.Constants.ErrorMessagesConstants;

namespace HappyMama.BusinessLogic.ViewModels.News
{
	public class NewsFormViewModel
	{
		[Key]
		public int Id { get; set; }

		[Required(ErrorMessage = RequiredField)]
		[StringLength(NewsTitleMaxLength
			,MinimumLength = NewsTitleMinLength
			,ErrorMessage = RequiredLength)]
		public string Title { get; set; } = string.Empty;

		[Required(ErrorMessage = RequiredField)]
		[StringLength(NewsDescriptionMaxLength
			, MinimumLength = NewsDescriptionMinLength
			, ErrorMessage = RequiredLength)]
		public string Description { get; set; } = string.Empty;

		[Required(ErrorMessage = RequiredField)]
		public DateTime CreatedOn { get; set; }

		
	}
}
