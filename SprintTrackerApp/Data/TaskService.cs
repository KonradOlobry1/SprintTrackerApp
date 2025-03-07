﻿using DummyProject;
using DummyProject.Models;
using Microsoft.EntityFrameworkCore;

namespace SprintTrackerApp.Data
{
    public class TaskService
    {
        private readonly AppDbContext _context;

        public TaskService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<TaskItem>> GetTasksAsync()
        {         
            return await _context.Tasks.ToListAsync();
        }

        public async Task AddTaskAsync(TaskItem task)
        {
            _context.Tasks.Add(task);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateTaskAsync(TaskItem task)
        {
            _context.Tasks.Update(task);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateTaskProgressAsync(TaskItem task, TaskProgress progress)
        {
            var existingProgress = await _context.TaskProgresses
                .FirstOrDefaultAsync(p => p.TaskItemId == task.Id && p.Day == progress.Day);

            if (existingProgress != null)
            {
                existingProgress.StoryPointsCompleted = progress.StoryPointsCompleted;
                existingProgress.CompletedBy = progress.CompletedBy;
                _context.TaskProgresses.Update(existingProgress);
            }
            else
            {
                task.Progress.Add(progress);
                _context.TaskProgresses.Add(progress);
            }

            await _context.SaveChangesAsync();
        }

        public async Task DeleteTaskAsync(TaskItem task)
        {
            _context.Tasks.Remove(task);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteTaskByIdAsync(int taskId)
        {
            var task = await _context.Tasks.FindAsync(taskId);
            if (task != null)
            {
                _context.Tasks.Remove(task);
                await _context.SaveChangesAsync();
            }
        }
    }
}
