using System.ComponentModel.DataAnnotations;

namespace TaskManagerUI.Models
{
    public class TaskItem
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Description { get; set; } = string.Empty;

        public DateTime CreatedAt { get; set; } = DateTime.Now;

        [Required]
        public DateTime Deadline { get; set; }

        [Required]
        public string Status { get; set; } = "Pending"; // e.g., Pending, In Progress, Completed

        public int Priority { get; set; } = 1; // 1 = High, 2 = Medium, 3 = Low
    }
}
