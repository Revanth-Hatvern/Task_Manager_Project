namespace TaskManager.Web.Models.Dto
{
    public class TaskManagerDto
    {
        public int Id { get; set; }

        public string TaskName { get; set; }

        public string? TaskDescription { get; set; }

        public double TargetTimeinHours { get; set; }
    }
}
