using HappyMama.BusinessLogic.ViewModels.Event;

namespace HappyMama.BusinessLogic.Contracts
{
	public interface IEventService
    {
        Task<IEnumerable<EventIndexViewModel>> AllEventsAsync();
       
        Task  AddEventAsync(AddEventFormModel model, string Id);
        Task<bool> ExistEventByIdAsync(int id);
        Task<AddEventFormModel?> GetEventModelById(int id);
        Task EditEventAsync(int id,AddEventFormModel model);
        Task<bool> CorrectEditor(string Id);
       
        
    }
}
