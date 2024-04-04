using HappyMama.Infrastructure.Data.DataModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using static HappyMama.Infrastructure.Constants.DataValidationConstants;
using static HappyMama.BusinessLogic.Constants.ErrorMessagesConstants;

namespace HappyMama.BusinessLogic.ViewModels.Forum
{
    public class AddThemeFormModel
    {
        public int Id { get; set; }


        [Required(ErrorMessage = RequiredField)]
        [StringLength(ThemeTitleMaxLength, 
            MinimumLength = ThemeTitleMinLength
            ,ErrorMessage = RequiredLength )]
       
        public string Title { get; set; } = string.Empty;

       
        public string CreatorId { get; set; } = string.Empty;

        [Required(ErrorMessage = RequiredField)] 
        public DateTime CreatedOn { get; set; }

        
        public ICollection<Post> Posts { get; set; } = new List<Post>();
    }
}
