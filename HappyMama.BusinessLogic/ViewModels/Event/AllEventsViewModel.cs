using HappyMama.BusinessLogic.Enums;

namespace HappyMama.BusinessLogic.ViewModels.Event
{
    public class AllEventsViewModel
	{
		public int EventsCount {  get; set; }

		public ICollection<EventIndexViewModel> Events { get; set; } = new List<EventIndexViewModel>();

        public int CurrentPage { get; set; }

        public int TotalPages { get; set; }

        public string SearchTerm { get; set; } = string.Empty;

        public EventEnum Sorting { get; set; }

    }
}
