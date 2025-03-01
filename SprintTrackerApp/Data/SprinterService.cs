using DummyProject;
using DummyProject.Models;
using Microsoft.EntityFrameworkCore;

namespace SprintTrackerApp.Data
{
    public class SprintService
    {
        private readonly AppDbContext _context;

        public SprintService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<SprintItem>> GetSprintsAsync() => await _context.Sprints.Include(static s => s.SprintTasks).ToListAsync();

        public async Task<SprintItem?> GetCurrentSprintsAsync()
        {
            DateTime dateToCheck = DateTime.Now;
            return await _context.Sprints.Include(static s => s.SprintTasks)
                                         .Where(dt => dateToCheck >= dt.StartDate && dateToCheck < dt.EndDate)
                                         .FirstOrDefaultAsync();
        }

        public async Task AddSprintAsync(SprintItem sprint)
        {
            _context.Sprints.Add(sprint);
            await _context.SaveChangesAsync();
        }

        public async Task AddTaskToSprintAsync(int sprintId, int taskId)
        {
            var sprint = await _context.Sprints.Include(s => s.SprintTasks).FirstOrDefaultAsync(s => s.Id == sprintId);
            var task = await _context.Tasks.FindAsync(taskId);

            if (sprint != null && task != null)
            {
                var sprintTask = new SprintTask
                {
                    SprintId = sprintId,
                    TaskId = taskId,
                    Sprint = sprint,
                    Task = task
                };
                sprint.SprintTasks.Add(sprintTask);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<List<SprintTask>> GetTasksForSprintAsync(int sprintId)
        {
            var sprint = await _context.Sprints
                .Include(s => s.SprintTasks)
                .ThenInclude(st => st.Task)
                .FirstOrDefaultAsync(s => s.Id == sprintId);
            return sprint?.SprintTasks.ToList() ?? [];
        }

        public int GetSprintDuration(SprintItem sprint)
        {
            return (sprint.EndDate - sprint.StartDate).Days + 1;
        }
    }
}
