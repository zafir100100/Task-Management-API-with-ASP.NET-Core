using Microsoft.EntityFrameworkCore;
using OrderProcessingSystemDotnet.Interfaces;
using OrderProcessingSystemDotnet.Models;
using OrderProcessingSystemDotnet.Models.Tables;

namespace OrderProcessingSystemDotnet.Repositories
{
    public class CustomerRepository: ICustomerService
    {
        private ResponseDto _responseDto = new();
        private readonly TaskManagerDbContext _context;
        public CustomerRepository(TaskManagerDbContext context)
        {
            _context = context;
        }
        public async Task<ResponseDto> GetCustomers()
        {
            if (_context.Customers == null)
            {
                _responseDto.StatusCode = StatusCodes.Status404NotFound;
                return _responseDto;
            }
            _responseDto.StatusCode = StatusCodes.Status200OK;
            _responseDto.Payload = await _context.Customers.ToListAsync();
            return _responseDto;
        }

        public async Task<ResponseDto> GetCustomer(int id)
        {
            if (_context.Customers == null)
            {
                _responseDto.StatusCode = StatusCodes.Status404NotFound;
                return _responseDto;
            }
            var customer = await _context.Customers.FindAsync(id);

            if (customer == null)
            {
                _responseDto.StatusCode = StatusCodes.Status404NotFound;
                return _responseDto;
            }

            _responseDto.StatusCode = StatusCodes.Status200OK;
            _responseDto.Payload = customer;
            return _responseDto;
        }

        public async Task<ResponseDto> PutCustomer(int id, Customer customer)
        {
            if (id != customer.Id)
            {
                _responseDto.StatusCode = StatusCodes.Status400BadRequest;
                return _responseDto;
            }

            _context.Entry(customer).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CustomerExists(id))
                {
                    _responseDto.StatusCode = StatusCodes.Status404NotFound;
                    return _responseDto;
                }
                else
                {
                    throw;
                }
            }

            _responseDto.StatusCode = StatusCodes.Status204NoContent;
            return _responseDto;
        }

        public async Task<ResponseDto> PostCustomer(Customer customer)
        {
            if (_context.Customers == null)
            {
                _responseDto.StatusCode = StatusCodes.Status400BadRequest;
                _responseDto.Message = "Entity set 'OpsApiDbContext.Customers'  is null.";
                return _responseDto;
            }
            _context.Customers.Add(customer);
            await _context.SaveChangesAsync();

            _responseDto.StatusCode = StatusCodes.Status201Created;
            return _responseDto;
        }

        public async Task<ResponseDto> DeleteCustomer(int id)
        {
            if (_context.Customers == null)
            {
                _responseDto.StatusCode = StatusCodes.Status404NotFound;
                return _responseDto;
            }
            var customer = await _context.Customers.FindAsync(id);
            if (customer == null)
            {
                _responseDto.StatusCode = StatusCodes.Status404NotFound;
                return _responseDto;
            }

            _context.Customers.Remove(customer);
            await _context.SaveChangesAsync();

            _responseDto.StatusCode = StatusCodes.Status204NoContent;
            return _responseDto;
        }

        private bool CustomerExists(int id)
        {
            return (_context.Customers?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
