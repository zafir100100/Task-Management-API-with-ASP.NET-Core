using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TaskManagementSystem.Interfaces;
using TaskManagementSystem.Models;
using TaskManagementSystem.Models.DTOs;
using TaskManagementSystem.Models.Tables;

namespace TaskManagementSystem.Repositories
{
    /// <summary>
    /// Repository for managing UserTask operations.
    /// </summary>
    public class UserTaskRepository : IUserTaskService
    {
        private ResponseDto _responseDto = new();
        private readonly TaskManagerDbContext _context;

        /// <summary>
        /// Initializes a new instance of the UserTaskRepository class.
        /// </summary>
        /// <param name="context">The TaskManagerDbContext used for database operations.</param>
        public UserTaskRepository(TaskManagerDbContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Retrieves a list of UserTasks asynchronously.
        /// </summary>
        /// <returns>
        /// A Task object representing the asynchronous operation, containing a ResponseDto with the list of tasks.
        /// </returns>
        public async Task<ResponseDto> GetTasks()
        {
            try
            {
                // Retrieve UserTasks from the database and order them by Id.
                List<UserTask> tasks = await _context.UserTasks.OrderBy(i => i.Id).ToListAsync();

                // Check if there are tasks available.
                if (tasks.Count > 0)
                {
                    _responseDto.Message = "Displaying the list of " + tasks.Count + " task(s).";
                    _responseDto.Payload = new
                    {
                        Output = tasks,
                        RowCount = tasks.Count
                    };
                    _responseDto.StatusCode = StatusCodes.Status200OK;

                    // Return the populated ResponseDto with task information.
                    return _responseDto;
                }
                else
                {
                    // No tasks found; provide a message indicating the need to create a task.
                    _responseDto.Message = "No task found. Please create one to view.";
                    _responseDto.StatusCode = StatusCodes.Status404NotFound;

                    // Return the ResponseDto with a 404 status code.
                    return _responseDto;
                }
            }
            catch (Exception ex)
            {
                // An exception occurred while fetching the task list; provide an error message.
                _responseDto.Message = "Unable to fetch task list. Something went wrong. Please try again later.";
                _responseDto.StatusCode = StatusCodes.Status500InternalServerError;

                // Populate Payload with exception details for troubleshooting.
                _responseDto.Payload = new
                {
                    ex.StackTrace,
                    ex.Message,
                    ex.InnerException,
                    ex.Source,
                    ex.Data
                };

                // Return the ResponseDto with a 500 status code and exception details.
                return _responseDto;
            }
        }

        /// <summary>
        /// Creates a new UserTask asynchronously.
        /// </summary>
        /// <param name="newTask">The UserTask object to be created and added to the database.</param>
        /// <returns>
        /// A Task object representing the asynchronous operation, containing a ResponseDto with details of the created task.
        /// </returns>
        public async Task<ResponseDto> CreateTask([FromBody] UserTask newTask)
        {
            try
            {
                // Add the new task to the database and save changes.
                _context.UserTasks.Add(newTask);
                await _context.SaveChangesAsync();

                // Set the response details for a successful creation.
                _responseDto.StatusCode = StatusCodes.Status201Created;
                _responseDto.Message = "Task created successfully.";

                // Return the ResponseDto indicating successful task creation.
                return _responseDto;
            }
            catch (Exception ex)
            {
                // Handle exceptions that may occur during the creation process.
                _responseDto.StatusCode = StatusCodes.Status500InternalServerError;
                _responseDto.Message = "Task creation failed. Something went wrong. Please try again later.";

                // Additional information about the exception for debugging or logging.
                _responseDto.Payload = new
                {
                    ex.StackTrace,
                    ex.Message,
                    ex.InnerException,
                    ex.Source,
                    ex.Data
                };

                // Return the ResponseDto with a 500 status code and exception details.
                return _responseDto;
            }
        }

        /// <summary>
        /// Deletes a UserTask by its ID asynchronously.
        /// </summary>
        /// <param name="taskId">The ID of the UserTask to be deleted.</param>
        /// <returns>
        /// A Task object representing the asynchronous operation, containing a ResponseDto indicating the result of the deletion.
        /// </returns>
        public async Task<ResponseDto> DeleteTask(uint taskId)
        {
            try
            {
                // check if task id is invalid
                if (taskId == 0)
                {
                    _responseDto.Message = "Invalid task id. Please provide a valid task id for the desired operation";
                    _responseDto.StatusCode = StatusCodes.Status400BadRequest;

                    // Return the ResponseDto with a 401 status code.
                    return _responseDto;
                }

                // Find the task to delete based on the provided taskId.
                var taskToDelete = await _context.UserTasks.FindAsync(taskId);

                // Check if the task exists.
                if (taskToDelete == null)
                {
                    _responseDto.Message = "No task found for the given criteria.";
                    _responseDto.StatusCode = StatusCodes.Status404NotFound;

                    // Return the ResponseDto with a 404 status code.
                    return _responseDto;
                }

                // Remove the task from the database and save changes.
                _context.UserTasks.Remove(taskToDelete);
                await _context.SaveChangesAsync();

                // Set the response details for a successful deletion.
                _responseDto.Message = "Task deletion successful";
                _responseDto.StatusCode = StatusCodes.Status200OK;

                // Return the ResponseDto indicating successful task deletion.
                return _responseDto;
            }
            catch (Exception ex)
            {
                // Log or handle the exception as needed.
                _responseDto.StatusCode = StatusCodes.Status500InternalServerError;
                _responseDto.Message = "Task deletion failed. Something went wrong. Please try again later.";

                // Additional information about the exception for debugging or logging.
                _responseDto.Payload = new
                {
                    ex.StackTrace,
                    ex.Message,
                    ex.InnerException,
                    ex.Source,
                    ex.Data
                };

                // Return the ResponseDto with a 500 status code and exception details.
                return _responseDto;
            }
        }

        /// <summary>
        /// Updates a UserTask asynchronously.
        /// </summary>
        /// <param name="updatedTask">The UserTask object with updated information.</param>
        /// <returns>
        /// A Task object representing the asynchronous operation, containing a ResponseDto indicating the result of the update.
        /// </returns>
        public async Task<ResponseDto> UpdateTask(UserTask updatedTask)
        {
            try
            {   
                // check if task id is invalid
                if (updatedTask.Id == 0)
                {
                    _responseDto.Message = "Invalid task id. Please provide a valid task id for the desired operation";
                    _responseDto.StatusCode = StatusCodes.Status400BadRequest;

                    // Return the ResponseDto with a 401 status code.
                    return _responseDto;
                }

                // Find the existing task in the database based on the provided taskId.
                var existingTask = await _context.UserTasks.FindAsync(updatedTask.Id);

                // Check if the task exists.
                if (existingTask == null)
                {
                    _responseDto.Message = "No task found for the given criteria.";
                    _responseDto.StatusCode = StatusCodes.Status404NotFound;

                    // Return the ResponseDto with a 404 status code.
                    return _responseDto;
                }

                // Update the existing task with the information from the updatedTask.
                existingTask.Title = updatedTask.Title;
                existingTask.Description = updatedTask.Description;
                existingTask.DueDate = updatedTask.DueDate;
                existingTask.Status = updatedTask.Status;

                // Save changes to the database.
                await _context.SaveChangesAsync();

                // Set the response details for a successful update.
                _responseDto.Message = "Task update successful";
                _responseDto.StatusCode = StatusCodes.Status200OK;

                // Return the ResponseDto indicating successful task update.
                return _responseDto;
            }
            catch (Exception ex)
            {
                // Log or handle the exception as needed.
                _responseDto.StatusCode = StatusCodes.Status500InternalServerError;
                _responseDto.Message = "Task update failed. Something went wrong. Please try again later.";

                // Additional information about the exception for debugging or logging.
                _responseDto.Payload = new
                {
                    ex.StackTrace,
                    ex.Message,
                    ex.InnerException,
                    ex.Source,
                    ex.Data
                };

                // Return the ResponseDto with a 500 status code and exception details.
                return _responseDto;
            }
        }

        /// <summary>
        /// Retrieves a UserTask by its ID asynchronously.
        /// </summary>
        /// <param name="taskId">The ID of the UserTask to be retrieved.</param>
        /// <returns>
        /// A Task object representing the asynchronous operation, containing a ResponseDto with details of the retrieved task.
        /// </returns>
        public async Task<ResponseDto> GetTaskById(uint taskId)
        {
            try
            {   
                // check if task id is invalid
                if (taskId == 0)
                {
                    _responseDto.Message = "Invalid task id. Please provide a valid task id for the desired operation";
                    _responseDto.StatusCode = StatusCodes.Status400BadRequest;

                    // Return the ResponseDto with a 401 status code.
                    return _responseDto;
                }

                // Find the task in the database based on the provided taskId.
                var task = await _context.UserTasks.FindAsync(taskId);

                // Check if the task exists.
                if (task == null)
                {
                    _responseDto.Message = "No task found for given criteria.";
                    _responseDto.StatusCode = StatusCodes.Status404NotFound;

                    // Return the ResponseDto with a 404 status code.
                    return _responseDto;
                }

                // Set the response details for a successful task retrieval.
                _responseDto.Message = "Fetching task successful";
                _responseDto.StatusCode = StatusCodes.Status200OK;
                _responseDto.Payload = new
                {
                    Output = task
                };

                // Return the ResponseDto indicating successful task retrieval.
                return _responseDto;
            }
            catch (Exception ex)
            {
                // Log or handle the exception as needed.
                _responseDto.StatusCode = StatusCodes.Status500InternalServerError;
                _responseDto.Message = "Task retrieval failed. Something went wrong. Please try again later.";

                // Additional information about the exception for debugging or logging.
                _responseDto.Payload = new
                {
                    ex.StackTrace,
                    ex.Message,
                    ex.InnerException,
                    ex.Source,
                    ex.Data
                };

                // Return the ResponseDto with a 500 status code and exception details.
                return _responseDto;
            }
        }
    }
}
