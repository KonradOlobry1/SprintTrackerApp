using DummyProject.Models;
using Microsoft.EntityFrameworkCore;

namespace DummyProject
{
    public class AppDbContext : DbContext
    {
        public DbSet<TaskItem> Tasks { get; set; }
        public DbSet<SprintItem> Sprints { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<SprintItem>()
                .HasMany(s => s.Tasks)
                .WithMany();

            base.OnModelCreating(modelBuilder);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite($"Data Source=C:\\Users\\Konrad\\source\\repos\\SprintTrackerApp\\DummyProject\\sprintTracker.db");
        }
    }
}
