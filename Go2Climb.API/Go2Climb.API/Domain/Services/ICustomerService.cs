using System.Collections.Generic;
using System.Threading.Tasks;
using Go2Climb.API.Domain.Models;
using Go2Climb.API.Domain.Services.Communication;
using Go2Climb.API.Security.Domain.Services.Communication;

namespace Go2Climb.API.Domain.Services
{
    public interface ICustomerService
    {
        Task<AuthenticateResponse> Authenticate(AuthenticateRequest request);
        Task<Customer> GetByIdAsync(int id);
        Task RegisterAsync(RegisterCustomerRequest request);
        Task UpdateAsync(int id, UpdateCustomerRequest request);
        Task DeleteAsync(int id);
        Task<IEnumerable<Customer>> ListAsync();
        Task<CustomerResponse> SaveAsync(Customer customer);
        Task<CustomerResponse> FindById(int id);
        Task<CustomerResponse> UpdateAsync(int id, Customer customer);

    }
}