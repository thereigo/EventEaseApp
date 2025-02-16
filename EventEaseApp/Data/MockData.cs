using EventEaseApp.Models;
using System;
using System.Collections.Generic;

namespace EventEaseApp.Data
{
    public static class MockData
    {
        public static List<EventModel> Events = GenerateEvents(1000);
        public static Dictionary<string, List<ParticipantModel>> EventParticipants = GenerateEventParticipants();

        public static List<EventModel> GenerateEvents(int numberOfEvents)
        {
            var events = new List<EventModel>();
            var random = new Random();
            var locations = new[] { "New York", "Los Angeles", "Chicago", "Houston", "Phoenix" };
            var eventNames = new[] { "Tech Conference 2024", "Marketing Summit", "AI Expo", "Startup Weekend", "Design Workshop", "Global Leadership Summit", "FinTech Forum", "Healthcare Innovation Conference", "Renewable Energy Expo", "Cybersecurity Symposium" };
            for (int i = 1; i <= numberOfEvents; i++)
            {
                events.Add(new EventModel
                {
                    Name = $"{eventNames[random.Next(eventNames.Length)]} {i}",
                    Date = DateTime.Now.AddDays(random.Next(1, 365)),
                    Location = locations[random.Next(locations.Length)]
                });
            }
            return events;
        }

        public static List<ParticipantModel> GenerateParticipants(int numberOfParticipants)
        {
            var participants = new List<ParticipantModel>();
            var random = new Random();
            var firstNames = new[] { "John", "Jane", "Alex", "Chris", "Pat" };
            var lastNames = new[] { "Smith", "Johnson", "Williams", "Jones", "Brown" };
            for (int i = 1; i <= numberOfParticipants; i++)
            {
                participants.Add(new ParticipantModel
                {
                    Name = $"{firstNames[random.Next(firstNames.Length)]} {lastNames[random.Next(lastNames.Length)]}"
                });
            }
            return participants;
        }

        public static Dictionary<string, List<ParticipantModel>> GenerateEventParticipants()
        {
            var eventParticipants = new Dictionary<string, List<ParticipantModel>>();
            var random = new Random();
            foreach (var eventModel in Events)
            {
                var participants = GenerateParticipants(random.Next(1, 20));
                eventParticipants[eventModel.Name] = participants;
            }
            return eventParticipants;
        }
    }
}