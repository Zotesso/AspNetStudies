using Microsoft.EntityFrameworkCore;
using TaskManagerExample.Data.Map;
using TaskManagerExample.Models;

namespace TaskManagerExample.Data
{
    public class TaskManagerDBContext : DbContext
    {
        public TaskManagerDBContext(DbContextOptions<TaskManagerDBContext> options) : base(options)
        {

        }

        public DbSet<UserModel> Users { get; set; }
        public DbSet<TaskModel> Tasks { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UserMap());
            modelBuilder.ApplyConfiguration(new TaskMap());
            base.OnModelCreating(modelBuilder);
        }
    }
}
