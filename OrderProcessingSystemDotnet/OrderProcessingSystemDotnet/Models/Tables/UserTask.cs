using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace OrderProcessingSystemDotnet.Models.Tables
{
    // UserTask model representing a task in the Task Management System
    public class UserTask
    {
        // Unique identifier for the user task
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        // Title of the task
        [Required]
        public string Title { get; set; }

        // Description of the task
        public string Description { get; set; }

        // Due date for the task
        [Required]
        public DateTime DueDate { get; set; }

        // Status of the task (e.g., pending, completed)
        [EnumDataType(typeof(TaskStatus))]
        public TaskStatus Status { get; set; }

        // Foreign key for the User who owns the task
        [Required]
        public int UserId { get; set; }

        //// Navigation property to represent the associated user
        //[ForeignKey("UserId")]
        //public User User { get; set; }
    }

    // Enum representing the status of a task
    public enum TaskStatus
    {
        Pending,
        Completed
    }
}
