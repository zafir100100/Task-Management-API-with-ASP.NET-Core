using Microsoft.EntityFrameworkCore;
using TaskManagementSystem.Models.Tables;

namespace TaskManagementSystem.Models
{
    /// <summary>
    /// Represents the database context for the Task Manager application.
    /// </summary>
    public class TaskManagerDbContext : DbContext
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="TaskManagerDbContext"/> class.
        /// </summary>
        /// <param name="options">The options to be used by the context.</param>
        /// <remarks>
        /// Documentation: Initializes a new instance of the <see cref="TaskManagerDbContext"/> class.
        /// </remarks>
        public TaskManagerDbContext(DbContextOptions options) : base(options)
        {

        }

        /// <summary>
        /// Gets or sets the DbSet for UserTasks in the database.
        /// </summary>
        /// <remarks>
        /// Documentation: Represents the database table for UserTasks in the Task Manager application.
        /// </remarks>
        public DbSet<UserTask> UserTasks { get; set; }
    }
}
