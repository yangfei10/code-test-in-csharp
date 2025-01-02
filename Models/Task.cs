namespace appointmentAPI.Models
{
    public class Task
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime ScheduledTime { get; set; }
        public string ScheduledLocation { get; set; }
        public string Members { get; set; }

        // Parameterless constructor
        public Task() { }

        // Constructor with parameters matching property names
        public Task(int id, string name, DateTime scheduledTime, string scheduledLocation, string members)
        {
            Id = id;
            Name = name;
            ScheduledTime = scheduledTime;
            ScheduledLocation = scheduledLocation;
            Members = members;
        }
    }

}
