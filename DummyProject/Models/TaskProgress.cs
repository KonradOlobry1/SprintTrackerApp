namespace DummyProject.Models
{
    public class TaskProgress
    {
        public int Id { get; set; }
        public int Day { get; set; }
        public int StoryPointsCompleted { get; set; }
        public string CompletedBy { get; set; } = string.Empty;
    }
}
