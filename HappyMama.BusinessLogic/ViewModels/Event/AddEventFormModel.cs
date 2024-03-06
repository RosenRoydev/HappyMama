using HappyMama.Infrastructure.Data.DataModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static HappyMama.Infrastructure.Constants.DataValidationConstants;
using static HappyMama.BusinessLogic.Constants.ErrorMessagesConstants;

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
    [Range(typeof(decimal), EventSumMin
        ,EventSumMax,
        ConvertValueInInvariantCulture = true,
        ErrorMessage = NeededAmountRestrict)]    
    public decimal NeededAmount { get; set; }

    [Required(ErrorMessage = RequiredField)]

    //To do  custom model binder for date format
    public string DeadTime { get; set; } = string.Empty;

    public string Creator { get; set; } = null!;

   // public ICollection<EventParent> Parents { get; set; } = new List<EventParent>();
}
