namespace Task_Manager_API.Models.DTO
{
    public class TaskManagerDto
    {
        public int Id { get; set; }

        public string TaskName { get; set; }

        public string? TaskDescription { get; set; }

        public double TargetTimeinHours { get; set; }
    }
}
