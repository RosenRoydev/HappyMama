using System.ComponentModel.DataAnnotations;

namespace HappyMama.BusinessLogic.ViewModels
{
    public class EventIndexViewModel
    {
        
        

            public int Id { get; set; }
            public string Name { get; set; } = string.Empty;
            public string Description { get; set; } = string.Empty;
            public string NeededAmount { get; set; } = string.Empty;

            [Display(Name = "Time Deadline")]
            public string DeadTime { get; set; } = string.Empty;
            public string CreatorId { get; set; } = string.Empty;
            public string Creator { get; set; } = string.Empty;

            //public ICollection ParentsAlreadyPaid


        
    }
}
