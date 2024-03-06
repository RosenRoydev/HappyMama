using HappyMama.BusinessLogic.ViewModels.Event;

namespace HappyMama.BusinessLogic.Contracts
{
    public interface IEventService
    {
        Task<IEnumerable<EventIndexViewModel>> AllEventsAsync();
    }
}
