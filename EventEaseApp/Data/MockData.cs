using EventEaseApp.Models;
using System;
using System.Collections.Generic;

namespace EventEaseApp.Data
{
    public static class MockData
    {
        public static List<EventModel> Events = new List<EventModel>
        {
            new EventModel { Name = "Event 1", Date = DateTime.Now.AddDays(1), Location = "Location 1" },
            new EventModel { Name = "Event 2", Date = DateTime.Now.AddDays(2), Location = "Location 2" },
            new EventModel { Name = "Event 3", Date = DateTime.Now.AddDays(3), Location = "Location 3" }
        };
    }
}