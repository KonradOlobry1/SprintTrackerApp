using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DummyProject.Models
{
    public class SprintTask
    {
        public int SprintId { get; set; }
        public SprintItem Sprint { get; set; } = null!;
        public int TaskId { get; set; }
        public TaskItem Task { get; set; } = null!;
    }
}
