using System.ComponentModel.DataAnnotations;

namespace HappyMama.BusinessLogic.ViewModels.Event
{
    public class EventIndexViewModel
    {

        public const int EventsPerPage = 3;
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string NeededAmount { get; set; } = string.Empty;

        [Display(Name = "Last day for payment")]
        public string DeadLineTime { get; set; } = string.Empty;
        public string CreatorId { get; set; } = string.Empty;
        public string Creator { get; set; } = string.Empty;

   

        //public ICollection ParentsAlreadyPaid



    }
}
