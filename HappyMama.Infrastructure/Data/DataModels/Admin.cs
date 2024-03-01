using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static HappyMama.Infrastructure.Constants.DataValidationConstants;

namespace HappyMama.Infrastructure.Data.DataModels
{
    [Comment("Class for the admins")]
    public class Admin
    {
        [Key]
        [Comment("Admin identifier")]
        public int Id { get; set; }

        [Required]
        [MaxLength(NicknameMaxLength)]
        [Comment("Nickname of the admin")]
        public string Nickname { get; set; } = string.Empty;

        [Required]
        [ForeignKey(nameof(User))]
        [Comment("User Identifier")]
        public string UserId { get; set; } = string.Empty;

        [Comment("Navigation property")]
        public IdentityUser User { get; set; } = null!;

        [Comment("All themes created from the admin")]
        public ICollection<Theme> Theme { get; set; } = new HashSet<Theme>();

        [Comment("All post of the admin")]
        public ICollection<Post> Posts { get; set; } = new HashSet<Post>();

        [Comment("All news published by admin")]
        public ICollection<News> News { get; set; } = new HashSet<News>();
    }
}
