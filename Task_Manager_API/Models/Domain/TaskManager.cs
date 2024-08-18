namespace Task_Manager_API.Models.Domain
{
    public class TaskManager
    {
        public int Id { get; set; }

        public string TaskName { get; set; }

        public string? TaskDescription { get; set; }

        public double TargetTimeinHours {  get; set; }

    }
}
