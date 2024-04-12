using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static HappyMama.Infrastructure.Constants.DataValidationConstants;

namespace HappyMama.Infrastructure.Data.DataModels
{
    [Comment("Class for teachers")]
    public class Teacher
    {
        [Key]
        [Comment("Teacher identifier")]
        public int Id { get; set; }

        [Required]
        [MaxLength(FirstNameMaxLength)]
        [Comment("First name of the teacher")]
        public string FirstName {  get; set; } = string.Empty;

        [Required]
        [MaxLength(LastNameMaxLength)]
        [Comment("Last name of the teacher")]
        public string LastName { get; set; } = string.Empty;

        [Required]
        [ForeignKey(nameof(User))]
        [Comment("User Identifier")]
        public string UserId { get; set; } = string.Empty;

        [Comment("Navigation property")]
        public IdentityUser User { get; set; } = null!;

        [Comment("All news that teacher published")]
        public ICollection<News> News { get; set; } = new HashSet<News>();

        [Comment("All events that teacher published")]
        public ICollection<Event> Events { get; set; } = new HashSet<Event>();

        [Comment("All themes created from the teacher")]
        public ICollection<Theme> Themes { get; set; } = new HashSet<Theme>();

        [Comment("All post of the teacher")]
        public ICollection<Post> Posts { get; set; } = new HashSet<Post>();

        [Comment("The admin must approve the user")]
        public bool IsApproved { get; set; }


    }
}
