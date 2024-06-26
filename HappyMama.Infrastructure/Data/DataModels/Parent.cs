﻿using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static HappyMama.Infrastructure.Constants.DataValidationConstants;

namespace HappyMama.Infrastructure.Data.DataModels
{
    [Comment("Class for parents")]
    public class Parent
    {
        [Key]
        [Comment("Parent identifier")]
        public int Id { get; set; }

        [Required]
        [MaxLength(FirstNameMaxLength)]
        [Comment("First name of the parent")]
        public string FirstName { get; set; } = string.Empty;

        [Required]
        [MaxLength(LastNameMaxLength)]
        [Comment("Last name of the parent")]
        public string LastName { get; set; } = string.Empty;

        [Required]
        [Column(TypeName = "Decimal(18,2)")]
        [Comment("Amount from where the parent can pay for events")]
        public decimal Amount { get; set; }

        [Required]
        [ForeignKey(nameof(User))]
        [Comment("User Identifier")]
        public string UserId { get; set; } = string.Empty;

        [Comment("Navigation property")]
        public IdentityUser User { get; set; } = null!;

        [Comment("Connection between events and payments for the events")]
        public ICollection<EventParent> Events { get; set; } = new HashSet<EventParent>();

        [Comment("All themes created from the parent")]
        public ICollection <Theme> Theme { get; set; } = new HashSet<Theme>();

        [Comment("All post of the parent")]
        public ICollection<Post> Posts { get; set; } = new HashSet<Post>();

        [Comment("The admin must approve the user")]
        public bool IsApproved { get; set; }

    }
}
