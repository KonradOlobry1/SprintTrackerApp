using System.ComponentModel.DataAnnotations;

namespace DummyProject.Models
{
    public class SprintItem
    {
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string Name { get; set; } = string.Empty;

        [Required]
        public DateTime StartDate { get; set; }

        [Required]
        public DateTime EndDate { get; set; }

        public List<SprintTask> SprintTasks { get; set; } = [];
    }
}