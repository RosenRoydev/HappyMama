using HappyMama.BusinessLogic.ViewModels;

namespace HappyMama.BusinessLogic.Contracts
{
    public interface IEventService
    {
        Task<IEnumerable<EventIndexViewModel>> AllEventsAsync();
    }
}
