using System.ComponentModel.DataAnnotations;

namespace Task_Manager_API.Models.DTO
{
    public class TaskManagerRequestDto
    {
        [Required]
        [MinLength(3,ErrorMessage= "Minimum Length Should be 3 characters")]
        [MaxLength(20, ErrorMessage= "Maximum Length Should not exceed 30 characters")]
        public string TaskName { get; set; }

        [MaxLength(100, ErrorMessage = "Maximum Length Should not exceed 100 characters")]
        public string? TaskDescription { get; set; }

        [Required]
        [Range(0.1,10)]
        public double TargetTimeinHours { get; set; }
    }
}
