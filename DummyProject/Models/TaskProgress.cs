using System.ComponentModel.DataAnnotations;

namespace DummyProject.Models
{
    public class TaskProgress
    {
        public int Id { get; set; }
        public int TaskItemId { get; set; }
        public int Day { get; set; }
        public int StoryPointsCompleted { get; set; }
        public string CompletedBy { get; set; } = string.Empty;
        public TaskItem TaskItem { get; set; } = null!;
    }
}
