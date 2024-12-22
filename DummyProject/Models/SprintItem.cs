using System.ComponentModel.DataAnnotations;

namespace DummyProject.Models
{
    public class SprintItem
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Sprint name is required")]
        [StringLength(100, ErrorMessage = "Sprint name cannot exceed 100 characters")]
        public string Name { get; set; } = string.Empty;

        [Required(ErrorMessage = "Start date is required")]
        public DateTime StartDate { get; set; }

        [Required(ErrorMessage = "End date is required")]
        [DateGreaterThan("StartDate", ErrorMessage = "End date must be after start date")]
        public DateTime EndDate { get; set; }
        public List<TaskItem> Tasks { get; set; } = [];
    }
}