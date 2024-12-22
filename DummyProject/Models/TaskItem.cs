using System.ComponentModel.DataAnnotations;

namespace DummyProject.Models
{
    public class TaskItem
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string Status { get; set; } = "InProgress"; // Default status
        public int StoryPoints { get; set; }
        public string Priority { get; set; } = string.Empty;
        public DateTime DateAdded { get; set; } = DateTime.Now;
        public List<TaskProgress> Progress { get; set; } = [];
    }
}
