using TaskManagementSystem.Models.DTOs;
using TaskManagementSystem.Models.Tables;

namespace TaskManagementSystem.Interfaces
{
    /// <summary>
    /// Represents the interface for managing user tasks in the Task Manager application.
    /// </summary>
    public interface IUserTaskService
    {
        /// <summary>
        /// Retrieves a list of tasks.
        /// </summary>
        /// <returns>A task representing the asynchronous operation with a response containing the tasks.</returns>
        /// <remarks>
        /// Documentation: Retrieves a list of tasks from the Task Manager application.
        /// </remarks>
        Task<ResponseDto> GetTasks();

        /// <summary>
        /// Creates a new task.
        /// </summary>
        /// <param name="newTask">The task to be created.</param>
        /// <returns>A task representing the asynchronous operation with a response indicating the result of the creation.</returns>
        /// <remarks>
        /// Documentation: Creates a new task in the Task Manager application.
        /// </remarks>
        Task<ResponseDto> CreateTask(UserTask newTask);

        /// <summary>
        /// Deletes a task by its unique identifier.
        /// </summary>
        /// <param name="taskId">The unique identifier of the task to be deleted.</param>
        /// <returns>A task representing the asynchronous operation with a response indicating the result of the deletion.</returns>
        /// <remarks>
        /// Documentation: Deletes a task in the Task Manager application based on its unique identifier.
        /// </remarks>
        Task<ResponseDto> DeleteTask(uint taskId);

        /// <summary>
        /// Updates an existing task.
        /// </summary>
        /// <param name="updatedTask">The task with updated information.</param>
        /// <returns>A task representing the asynchronous operation with a response indicating the result of the update.</returns>
        /// <remarks>
        /// Documentation: Updates an existing task in the Task Manager application.
        /// </remarks>
        Task<ResponseDto> UpdateTask(UserTask updatedTask);

        /// <summary>
        /// Retrieves a task by its unique identifier.
        /// </summary>
        /// <param name="taskId">The unique identifier of the task to be retrieved.</param>
        /// <returns>A task representing the asynchronous operation with a response containing the retrieved task.</returns>
        /// <remarks>
        /// Documentation: Retrieves a task from the Task Manager application based on its unique identifier.
        /// </remarks>
        Task<ResponseDto> GetTaskById(uint taskId);
    }
}
