using System.ComponentModel.DataAnnotations;

namespace OrderProcessingSystemDotnet.Models.DTOs
{
    // DTO for the delete task request
    public class DeleteTaskRequestDto
    {
        // Unique identifier for the task to be deleted
        // Documentation: Represents the identifier of the task to be deleted.
        [Required]
        public uint Id { get; set; }
    }
}
