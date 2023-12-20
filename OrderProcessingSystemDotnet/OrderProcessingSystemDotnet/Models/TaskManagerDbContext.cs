using Microsoft.EntityFrameworkCore;
using OrderProcessingSystemDotnet.Models.Tables;

namespace OrderProcessingSystemDotnet.Models
{
    public class TaskManagerDbContext : DbContext
    {
        public TaskManagerDbContext(DbContextOptions options) : base(options)
        {

        }
        public DbSet<UserTask> UserTasks { get; set; }
        public DbSet<Customer> Customers { get; set; }
    }
}
