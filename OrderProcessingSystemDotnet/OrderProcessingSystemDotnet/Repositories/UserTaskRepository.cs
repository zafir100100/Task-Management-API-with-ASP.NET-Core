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
                if (await _context.UserTasks.FirstOrDefaultAsync() == null)
                {
                    _responseDto.StatusCode = StatusCodes.Status404NotFound;
                    return _responseDto;
                }

                _responseDto.StatusCode = StatusCodes.Status200OK;
                _responseDto.Payload = await _context.UserTasks.ToListAsync();

                return _responseDto;
            }
            catch (Exception ex)
            {
                // Log or handle the exception as needed
                _responseDto.StatusCode = StatusCodes.Status500InternalServerError;
                _responseDto.Message = ex.Message;

                return _responseDto;
            }
        }

        // Method to create a new task
        public async Task<ResponseDto> CreateTask(UserTask newTask)
        {
            try
            {
                await _context.UserTasks.AddAsync(newTask);
                await _context.SaveChangesAsync();

                _responseDto.StatusCode = StatusCodes.Status201Created;

                return _responseDto;
            }
            catch (Exception ex)
            {
                // Log or handle the exception as needed
                _responseDto.StatusCode = StatusCodes.Status500InternalServerError;
                _responseDto.Message = ex.Message;

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
                    _responseDto.StatusCode = StatusCodes.Status404NotFound;
                    return _responseDto;
                }

                _context.UserTasks.Remove(taskToDelete);
                await _context.SaveChangesAsync();

                _responseDto.StatusCode = StatusCodes.Status204NoContent;

                return _responseDto;
            }
            catch (Exception ex)
            {
                // Log or handle the exception as needed
                _responseDto.StatusCode = StatusCodes.Status500InternalServerError;
                _responseDto.Message = ex.Message;

                return _responseDto;
            }
        }

        // Method to update an existing task
        public async Task<ResponseDto> UpdateTask(UserTask updatedTask)
        {
            try
            {
                var existingTask = await _context.UserTasks.FindAsync(updatedTask.UserTaskId);
                if (existingTask == null)
                {
                    _responseDto.StatusCode = StatusCodes.Status404NotFound;
                    return _responseDto;
                }

                existingTask.Title = updatedTask.Title;
                existingTask.Description = updatedTask.Description;
                existingTask.DueDate = updatedTask.DueDate;
                existingTask.Status = updatedTask.Status;

                await _context.SaveChangesAsync();

                _responseDto.StatusCode = StatusCodes.Status200OK;

                return _responseDto;
            }
            catch (Exception ex)
            {
                // Log or handle the exception as needed
                _responseDto.StatusCode = StatusCodes.Status500InternalServerError;
                _responseDto.Message = ex.Message;

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
                    _responseDto.StatusCode = StatusCodes.Status404NotFound;
                    return _responseDto;
                }

                _responseDto.StatusCode = StatusCodes.Status200OK;
                _responseDto.Payload = task;

                return _responseDto;
            }
            catch (Exception ex)
            {
                // Log or handle the exception as needed
                _responseDto.StatusCode = StatusCodes.Status500InternalServerError;
                _responseDto.Message = ex.Message;

                return _responseDto;
            }
        }
    }
}
