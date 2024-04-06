using HappyMama.Infrastructure.Data.DataModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static HappyMama.Infrastructure.Constants.DataValidationConstants;
using static HappyMama.BusinessLogic.Constants.ErrorMessagesConstants;

namespace HappyMama.BusinessLogic.ViewModels.Forum
{
	public class AddPostFormModel
	{
		[Required(ErrorMessage = RequiredField)]
		[StringLength(PostContentMaxLength
			,MinimumLength = PostContentMinLength
			,ErrorMessage = RequiredLength)]
		[Comment("Post content")]
		public string Content { get; set; } = string.Empty;

		[Required(ErrorMessage = RequiredField)]

		public DateTime CreatedOn { get; set; } = DateTime.UtcNow;

		[Required(ErrorMessage = RequiredField)]
		
		public string CreatorId { get; set; } = string.Empty;


		[Required(ErrorMessage = RequiredField)]
		
		public int ThemeId { get; set; }
	}
}
