namespace TaskManager.Web.Models
{
    public class AddTaskModel
    {
        public string TaskName { get; set; }

        public string? TaskDescription { get; set; }

        public double TargetTimeinHours { get; set; }
    }
}
