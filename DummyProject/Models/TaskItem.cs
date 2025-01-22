using System.ComponentModel.DataAnnotations;

namespace DummyProject.Models
{
    public class TaskItem
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public TaskStatus Status { get; set; } = TaskStatus.Open; // Default status.
        public int StoryPoints { get; set; }
        public TaskPriority Priority { get; set; } = TaskPriority.P2; // Default priority.
        public DateTime DateAdded { get; set; } = DateTime.Now;
        public List<TaskProgress> Progress { get; set; } = [];
    }
}
