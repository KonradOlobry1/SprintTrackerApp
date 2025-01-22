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
            var dbPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "sprintTracker.db");
            if (!File.Exists(dbPath))
            {
                File.Create(dbPath).Dispose();
            }
            optionsBuilder.UseSqlite($"Data Source={dbPath}");
        }
    }
}
