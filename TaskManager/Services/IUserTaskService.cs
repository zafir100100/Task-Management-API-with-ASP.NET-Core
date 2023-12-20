using TaskManager.Models;

namespace TaskManager.Services
{
    public interface IUserTaskService
    {
        public Task<ResponseDto> GetTasks();
    }
}
