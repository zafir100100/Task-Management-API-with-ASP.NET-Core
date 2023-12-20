using Microsoft.EntityFrameworkCore;
using TaskManager.Models.Tables;

namespace TaskManager.Models
{
    public class TaskManagerDbContext : DbContext
    {
        public TaskManagerDbContext(DbContextOptions options) : base(options)
        {

        }
        public DbSet<UserTask> UserTasks { get; set; }
    }
}
