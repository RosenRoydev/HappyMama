using HappyMama.BusinessLogic.Enums;
using HappyMama.BusinessLogic.ViewModels.Event;

namespace HappyMama.BusinessLogic.Contracts
{
    public interface IEventService
    {
        Task<AllEventsViewModel> AllEventsAsync(int currentPage = 1, int eventsPerPage = 3);
        Task<AllEventsViewModel>  AllEventsSortedAsync(string searchingWord = null, EventEnum eventsSort = EventEnum.DateLine,
            int currentPage = 1, int eventsPerPage = 1);
        Task  AddEventAsync(AddEventFormModel model, string Id);
        Task<bool> ExistEventByIdAsync(int id);
        Task<AddEventFormModel?> GetEventModelById(int id);
        Task EditEventAsync(int id,AddEventFormModel model);
        Task<bool> CorrectEditor(string Id);
       
        
    }
}
