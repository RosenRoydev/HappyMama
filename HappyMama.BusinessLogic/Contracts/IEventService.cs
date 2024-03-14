using HappyMama.BusinessLogic.ViewModels.Event;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;

namespace HappyMama.BusinessLogic.Contracts
{
    public interface IEventService
    {
        Task<IEnumerable<EventIndexViewModel>> AllEventsAsync();
       
        Task  AddEventAsync(AddEventFormModel model, string Id);
        Task<bool> ExistEventByIdAsync(int id);

       
        
    }
}
