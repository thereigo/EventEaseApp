using EventEaseApp.Data;

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
                    if (participant.Name != null && !registeredParticipants.Contains(participant.Name))
                    {
                        registeredParticipants.Add(participant.Name);
                    }
                }
            }
        }

        [Fact]
        public void TestLargeData()
        {
            List<string> dataList = new List<string>();
            for (int i = 0; i < 1000; i++)
            {
                dataList.Add("Item " + i);
            }

            Assert.Contains("Item 500", dataList);
            Assert.DoesNotContain("NonExistent Item", dataList);
        }
    }
}