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

        public async Task<List<SprintItem>> GetSprintsAsync() => await _context.Sprints.Include(static s => s.Tasks).ToListAsync();

        public async Task<SprintItem?> GetCurrentSprintsAsync()
        {
            DateTime dateToCheck = DateTime.Now;
            return await _context.Sprints.Include(static s => s.Tasks)
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
            var sprint = await _context.Sprints.Include(s => s.Tasks).FirstOrDefaultAsync(s => s.Id == sprintId);
            var task = await _context.Tasks.FindAsync(taskId);

            if (sprint != null && task != null)
            {
                sprint.Tasks.Add(task);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<List<TaskItem>> GetTasksForSprintAsync(int sprintId)
        {
            var sprint = await _context.Sprints.Include(s => s.Tasks).FirstOrDefaultAsync(s => s.Id == sprintId);
            return sprint?.Tasks.ToList() ?? new List<TaskItem>();
        }

        public int GetSprintDuration(SprintItem sprint)
        {
            return (sprint.EndDate - sprint.StartDate).Days + 1; // +1 to include both start and end dates
        }
    }
}
