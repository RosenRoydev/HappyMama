using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static HappyMama.Infrastructure.Constants.DataValidationConstants;

namespace HappyMama.Infrastructure.Data.DataModels
{
    [Comment("Events for collecting money")]
    public class Event
    {
        [Key]
        [Comment("EventIdentifier")]
        public int Id { get; set; }

        [Required]
        [MaxLength(EventNameMaxLength)]
        [Comment("EventName")]
        public string Name { get; set; } = string.Empty;

        [Required]
        [MaxLength(EventDescriptionMaxLength)]
        [Comment("Event Description")]
        public string Description { get; set; } = string.Empty;

        [Required]
        
        [Column(TypeName = "decimal(18,2)")]
        [Comment("Needed money for the event")]
        public decimal NeededAmount { get; set; }

        [Required]
        [Comment("The last date when the parents can pay for the event")]
        public DateTime DeadTime { get; set; }

        [Required]
        [ForeignKey(nameof(CreatorId))]
        [Comment("Creator identifier")]
        public string CreatorId { get; set; } = string.Empty;

        [Comment("Navigation property for the Creator")]
        public IdentityUser Creator { get; set; } = null!;

        [Comment("Collection for parents who already paid")]
        public ICollection<EventParent> Parents { get; set; } = new List<EventParent>();
    }
}
