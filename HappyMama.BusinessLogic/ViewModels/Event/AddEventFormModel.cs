using HappyMama.BusinessLogic.CustomAttributes;
using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using static HappyMama.BusinessLogic.Constants.ErrorMessagesConstants;
using static HappyMama.Infrastructure.Constants.DataValidationConstants;

namespace HappyMama.BusinessLogic.ViewModels.Event;

public class AddEventFormModel
{
    [Key]
    
    public int Id { get; set; }

    [Required(ErrorMessage = RequiredField)]
    [StringLength(EventNameMaxLength
        ,MinimumLength = EventNameMinLength
        ,ErrorMessage = RequiredLength)]

    public string Name { get; set; } = string.Empty;

    [Required(ErrorMessage = RequiredField)]
    [StringLength(EventDescriptionMaxLength
        ,MinimumLength = EventDescriptionMinLength
        ,ErrorMessage = RequiredLength)]
  
    public string Description { get; set; } = string.Empty;

    [Required(ErrorMessage = RequiredField)]
    [Range(EventSumMin,
        EventSumMax,
        ErrorMessage = NeededAmountRestrict)]
    public decimal NeededAmount { get; set; } 

    [Required(ErrorMessage = RequiredField)]
    
    [Display(Name = "Last date for payment")]
    public DateTime DeadlineTime { get; set; } 

    

   // public ICollection<EventParent> Parents { get; set; } = new List<EventParent>();
}
