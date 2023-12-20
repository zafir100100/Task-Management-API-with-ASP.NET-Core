using OrderProcessingSystemDotnet.Models;
using OrderProcessingSystemDotnet.Models.Tables;

namespace OrderProcessingSystemDotnet.Interfaces
{
    public interface ICustomerService
    {
        public Task<ResponseDto> GetCustomers();
        public Task<ResponseDto> GetCustomer(int id);
        public Task<ResponseDto> PutCustomer(int id, Customer customer);
        public Task<ResponseDto> PostCustomer(Customer customer);
        public Task<ResponseDto> DeleteCustomer(int id);
    }
}
