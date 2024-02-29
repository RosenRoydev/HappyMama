using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using static HappyMama.Infrastructure.Constants.DataValidationConstants;

namespace HappyMama.Infrastructure.Data.DataModels
{
    [Comment("Forum Section - Theme creating")]
    public class Theme
    {
        [Key]
        [Comment("PostIdentifier")]
        public int Id { get; set; }

        [Required]
        [MaxLength(ThemeTitleMaxLength)]
        [Comment("ThemeTitle")]
        public string Title { get; set; } = string.Empty;

        [Required]
        [Comment("Creting date of the theme for discussion")]
        public DateTime CreatedOn { get; set; }

        [Comment("All post for this theme")]
        public ICollection<Post> Posts { get; set; } = new List<Post>();


    }
}
