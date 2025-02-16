using EventEaseApp.Data;
using EventEaseApp.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EventEaseApp.Services
{
    public interface IEventService
    {
        Task<EventModel?> GetEventAsync(string eventName);
        Task<List<EventModel>> GetEventsAsync();
    }

    public class EventService : IEventService
    {
        public Task<List<EventModel>> GetEventsAsync()
        {
            return Task.FromResult(MockData.Events);
        }

        public Task<EventModel?> GetEventAsync(string eventName)
        {
            return Task.FromResult(MockData.Events.FirstOrDefault(e => e.Name == eventName));
        }
    }
}
