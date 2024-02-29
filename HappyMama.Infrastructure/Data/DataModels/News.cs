using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static HappyMama.Infrastructure.Constants.DataValidationConstants;
namespace HappyMama.Infrastructure.Data.DataModels
{
    [Comment("News section")]
    public class News
    {
        [Key]
        [Comment("News identifier")]
        public int Id { get; set; }

        [Required]
        [MaxLength(NewsTitleMaxLength)]
        [Comment("News title")]
        public string Title { get; set; } = string.Empty;

        [Required]
        [MaxLength(NewsDescriptionMaxLength)]
        [Comment("Description of the news")]
        public string Description { get; set; } = string.Empty;

        [Required]
        [Comment("Date of creating of the news")]
        public DateTime CreatedOn { get; set; }

        [Required]
        [ForeignKey(nameof(CreatorId))]
        [Comment("Creator Identifier")]
        public string CreatorId { get; set; } = string.Empty;

        [Comment("Navigation property for the creator")]
        public IdentityUser Creator { get; set; } = null!;

    }
}
