using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OrderProcessingSystemDotnet.Interfaces;
using OrderProcessingSystemDotnet.Models;
using OrderProcessingSystemDotnet.Models.Tables;

namespace OrderProcessingSystemDotnet.Repositories
{
    public class UserTaskRepository : IUserTaskService
    {
        private ResponseDto _responseDto = new();
        private readonly TaskManagerDbContext _context;

        public UserTaskRepository(TaskManagerDbContext context)
        {
            _context = context;
        }

        // Method to get tasks without transactions and async
        public async Task<ResponseDto> GetTasks()
        {
            try
            {
                List<UserTask> tasks = await _context.UserTasks.OrderBy(i => i.Id).ToListAsync();
                if (tasks.Count > 0)
                {
                    _responseDto.Message = "Displaying the list of " + tasks.Count + " task(s).";
                    _responseDto.Payload = new
                    {
                        Output = tasks,
                        RowCount = tasks.Count
                    };
                    _responseDto.StatusCode = StatusCodes.Status200OK;
                    return _responseDto;
                }
                else
                {
                    _responseDto.Message = "No task found. Please create one to view.";
                    _responseDto.StatusCode = StatusCodes.Status404NotFound;
                    return _responseDto;
                }
            }
            catch (Exception ex)
            {
                _responseDto.Message = "Unable to fetch task list. Something went wrong. Please try again later.";
                _responseDto.StatusCode = StatusCodes.Status500InternalServerError;
                _responseDto.Payload = new
                {
                    ex.StackTrace,
                    ex.Message,
                    ex.InnerException,
                    ex.Source,
                    ex.Data
                };
                return _responseDto;
            }
        }

        // Method to create a new task
        public async Task<ResponseDto> CreateTask([FromBody] UserTask newTask)
        {
            try
            {
                // Add the new task to the database and save changes
                _context.UserTasks.Add(newTask);
                await _context.SaveChangesAsync();

                // Set the response details for a successful creation
                _responseDto.StatusCode = StatusCodes.Status201Created;
                _responseDto.Message = "Task created successfully.";

                return _responseDto;
            }
            catch (Exception ex)
            {
                // Handle exceptions that may occur during the creation process
                _responseDto.StatusCode = StatusCodes.Status500InternalServerError;
                _responseDto.Message = "Task creation failed. Something went wrong. Please try again later.";

                // Additional information about the exception for debugging or logging
                _responseDto.Payload = new
                {
                    ex.StackTrace,
                    ex.Message,
                    ex.InnerException,
                    ex.Source,
                    ex.Data
                };

                return _responseDto;
            }
        }

        // Method to delete a task by ID
        public async Task<ResponseDto> DeleteTask(int taskId)
        {
            try
            {
                var taskToDelete = await _context.UserTasks.FindAsync(taskId);

                if (taskToDelete == null)
                {
                    _responseDto.Message = "No task found for the given criteria.";
                    _responseDto.StatusCode = StatusCodes.Status404NotFound;
                    return _responseDto;
                }

                _context.UserTasks.Remove(taskToDelete);
                await _context.SaveChangesAsync();

                _responseDto.Message = "Task deletion successful";
                _responseDto.StatusCode = StatusCodes.Status200OK;
                return _responseDto;
            }
            catch (Exception ex)
            {
                // Log or handle the exception as needed
                _responseDto.StatusCode = StatusCodes.Status500InternalServerError;
                _responseDto.Message = "Task deletion failed. Something went wrong. Please try again later.";
                _responseDto.Payload = new
                {
                    ex.StackTrace,
                    ex.Message,
                    ex.InnerException,
                    ex.Source,
                    ex.Data
                };
                return _responseDto;
            }
        }

        // Method to update an existing task
        public async Task<ResponseDto> UpdateTask(UserTask updatedTask)
        {
            try
            {
                var existingTask = await _context.UserTasks.FindAsync(updatedTask.Id);
                if (existingTask == null)
                {
                    _responseDto.Message = "No task found for the given criteria.";
                    _responseDto.StatusCode = StatusCodes.Status404NotFound;
                    return _responseDto;
                }

                existingTask.Title = updatedTask.Title;
                existingTask.Description = updatedTask.Description;
                existingTask.DueDate = updatedTask.DueDate;
                existingTask.Status = updatedTask.Status;

                await _context.SaveChangesAsync();

                _responseDto.Message = "Task update successful";
                _responseDto.StatusCode = StatusCodes.Status200OK;

                return _responseDto;
            }
            catch (Exception ex)
            {
                // Log or handle the exception as needed
                _responseDto.StatusCode = StatusCodes.Status500InternalServerError;
                _responseDto.Message = "Task updated failed. Something went wrong. Please try again later.";
                _responseDto.Payload = new
                {
                    ex.StackTrace,
                    ex.Message,
                    ex.InnerException,
                    ex.Source,
                    ex.Data
                };
                return _responseDto;
            }
        }

        // Method to get a task by ID
        public async Task<ResponseDto> GetTaskById(int taskId)
        {
            try
            {
                var task = await _context.UserTasks.FindAsync(taskId);

                if (task == null)
                {
                    _responseDto.Message = "No task found for given criteria.";
                    _responseDto.StatusCode = StatusCodes.Status404NotFound;
                    return _responseDto;
                }

                _responseDto.Message = "Fetching task successful";
                _responseDto.StatusCode = StatusCodes.Status200OK;
                _responseDto.Payload = new
                {
                    Output = task
                };

                return _responseDto;
            }
            catch (Exception ex)
            {
                _responseDto.StatusCode = StatusCodes.Status500InternalServerError;
                _responseDto.Message = "Task retrieval failed. Something went wrong. Please try again later.";
                _responseDto.Payload = new
                {
                    ex.StackTrace,
                    ex.Message,
                    ex.InnerException,
                    ex.Source,
                    ex.Data
                };
                return _responseDto;
            }
        }
    }
}
