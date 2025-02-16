using EventEaseApp.Data;
using EventEaseApp.Models;
using System.Linq;
using Xunit;

namespace EventEaseApp.Tests
{
    public class LargeDataTest
    {
        [Fact]
        public void TestLargeNumberOfEventsAndParticipants()
        {
            var events = MockData.GenerateEvents(1000);
            Assert.Equal(1000, events.Count);

            foreach (var eventModel in events)
            {
                var participants = MockData.GenerateParticipants(1000);
                Assert.Equal(1000, participants.Count);

                foreach (var participant in participants)
                {
                    // Simulate registration
                    var registeredParticipants = new List<string>();
                    if (!registeredParticipants.Contains(participant.Name))
                    {
                        registeredParticipants.Add(participant.Name);
                    }
                }
            }
        }
    }
}
