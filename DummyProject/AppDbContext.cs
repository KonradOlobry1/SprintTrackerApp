using DummyProject.Models;
using Microsoft.EntityFrameworkCore;

namespace DummyProject
{
    public class AppDbContext : DbContext
    {
        public DbSet<TaskItem> Tasks { get; set; }
        public DbSet<SprintItem> Sprints { get; set; }
        public DbSet<TaskProgress> TaskProgresses { get; set; }
        public DbSet<SprintTask> SprintTasks { get; set; } // 🔹 Many-to-Many table

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<SprintTask>()
                .HasKey(st => new { st.SprintId, st.TaskId });

            modelBuilder.Entity<SprintTask>()
                .HasOne(st => st.Sprint)
                .WithMany(s => s.SprintTasks)
                .HasForeignKey(st => st.SprintId);

            modelBuilder.Entity<SprintTask>()
                .HasOne(st => st.Task)
                .WithMany(t => t.SprintTasks)
                .HasForeignKey(st => st.TaskId);

            modelBuilder.Entity<TaskProgress>()
                .HasOne(tp => tp.TaskItem)
                .WithMany(t => t.Progress)
                .HasForeignKey(tp => tp.TaskItemId)
                .OnDelete(DeleteBehavior.Cascade); 
        }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var dbPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "sprintTracker.db");
            optionsBuilder.UseSqlite($"Data Source={dbPath}");
        }
    }
}
