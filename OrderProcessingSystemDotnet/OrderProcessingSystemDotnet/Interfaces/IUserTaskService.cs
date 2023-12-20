using OrderProcessingSystemDotnet.Models;
using OrderProcessingSystemDotnet.Models.Tables;

namespace OrderProcessingSystemDotnet.Interfaces
{
    public interface IUserTaskService
    {
        public Task<ResponseDto> GetTasks();
        public Task<ResponseDto> CreateTask(UserTask newTask);
        public Task<ResponseDto> DeleteTask(int taskId);
        public Task<ResponseDto> UpdateTask(UserTask updatedTask);
        public Task<ResponseDto> GetTaskById(int taskId);
    }
}
