using System;

namespace EventEaseApp
{
    public class AttendanceTracker
    {
        public int RegisteredParticipants { get; set; }
        public int AdditionalViewers { get; set; }
        public int TotalAttendance { get; set; }

        public AttendanceTracker(int registeredParticipants)
        {
            RegisteredParticipants = registeredParticipants;
            AdditionalViewers = GenerateRandomViewers();
            TotalAttendance = CalculateTotalAttendance();
        }

        private int GenerateRandomViewers()
        {
            Random random = new Random();
            return random.Next(0, 51); // Generates a random number between 0 and 50
        }

        private int CalculateTotalAttendance()
        {
            return RegisteredParticipants + AdditionalViewers;
        }

        public int GetRegisteredParticipants()
        {
            return RegisteredParticipants;
        }

        public int GetAdditionalViewers()
        {
            return AdditionalViewers;
        }

        public void SetRegisteredParticipants(int participants)
        {
            RegisteredParticipants = participants;
            TotalAttendance = CalculateTotalAttendance();
        }

        public void DisplayAttendance()
        {
            Console.WriteLine($"Registered Participants: {RegisteredParticipants}");
            Console.WriteLine($"Additional Viewers: {AdditionalViewers}");
            Console.WriteLine($"Total Attendance: {TotalAttendance}");
        }
    }
}
