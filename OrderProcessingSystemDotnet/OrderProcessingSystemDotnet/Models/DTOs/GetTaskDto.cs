using System.ComponentModel.DataAnnotations;

namespace TaskManagementSystem.Models.DTOs
{
    // DTO for the get task request
    public class GetTaskDto
    {
        // Unique identifier for the task to be retrieved
        // Documentation: Represents the identifier of the task to be retrieved.
        [Required]
        public uint Id { get; set; }
    }
}
