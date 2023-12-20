using OrderProcessingSystemDotnet.Models;
using OrderProcessingSystemDotnet.Models.Tables;

namespace OrderProcessingSystemDotnet.Interfaces
{
    public interface IUserTaskService
    {
        public Task<ResponseDto> GetTasks();
    }
}
