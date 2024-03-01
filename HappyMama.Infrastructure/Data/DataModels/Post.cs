using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static HappyMama.Infrastructure.Constants.DataValidationConstants;
namespace HappyMama.Infrastructure.Data.DataModels
{
    [Comment("Forum Section - Posts")]
    public class Post
    {
        [Key]
        [Comment("Post Identifier")]
        public int Id { get; set; }

        [Required]
        [MaxLength(PostContentMaxLength)]
        [Comment("Post content")]
        public string Content { get; set; } = string.Empty;

        [Required]
        [Comment("Post date")]
        public DateTime CreatedOn { get; set; }

        [Required]
        [ForeignKey(nameof(CreatorId))]
        [Comment("Creator identifier")]
        public string CreatorId { get; set; } = string.Empty;

        [Required]
        [Comment("Navigation property for the Creator")]
        public IdentityUser Creator { get; set; } = null!;

        [Required]
        [Comment("Post identifier")]
        [ForeignKey(nameof(Theme))]
        public int ThemeId { get; set; }

        [Required]
        public Theme Theme { get; set; } = null!;
        


    }
}