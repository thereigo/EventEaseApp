using System;

namespace EventEaseApp.Models
{
    public class EventModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime Date { get; set; }
        public string Location { get; set; }
        public int RegisteredParticipants { get; set; }

        public EventModel()
        {
            RegisteredParticipants = 0; // Initialize to 0 by default
        }
    }
}
