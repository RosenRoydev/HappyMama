using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HappyMama.Infrastructure.Data.DataModels
{
    [Comment("Mapping table between parents and events because of payments")]
    public class EventParent
    {
        [Required]
        [ForeignKey(nameof(Event))]
        [Comment("Event Identifier")]
        public int EventId { get; set; }

        [Required]
        [Comment("Navigation property for Event")]
        public Event Event { get; set; } = null!;

        [Required]
        [ForeignKey(nameof(User))]
        [Comment("Parent identifier")]
        public int ParentId { get; set; }

        [Required]
        [Comment("Navigation property for Parent Id")]
        public Parent User { get; set; } = null!;

    }
}