using System.ComponentModel.DataAnnotations;

namespace DummyProject.Models
{
    public class TaskItem
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Title is required")]
        [StringLength(100, ErrorMessage = "Task title cannot exceed 100 characters")]
        public string Title { get; set; } = string.Empty;

        [StringLength(500, ErrorMessage = "Task Description cannot exceed 500 characters")]
        public string Description { get; set; } = string.Empty;
        public TaskStatus Status { get; set; } = TaskStatus.Open; // Default status.

        [Required(ErrorMessage = "Story points are required")]
        public int StoryPoints { get; set; }
        public TaskPriority Priority { get; set; } = TaskPriority.P2; // Default priority.
        public DateTime DateAdded { get; set; } = DateTime.Now;
        public List<TaskProgress> Progress { get; set; } = [];
    }
}
