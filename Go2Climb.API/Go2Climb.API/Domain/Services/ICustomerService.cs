using System.Collections.Generic;
using System.Threading.Tasks;
using Go2Climb.API.Domain.Models;
using Go2Climb.API.Domain.Services.Communication;

namespace Go2Climb.API.Domain.Services
{
    public interface ICustomerService
    {
        Task<IEnumerable<Customer>> ListAsync();
        Task<CustomerResponse> SaveAsync(Customer customer);
        Task<CustomerResponse> FindById(int id);
        Task<CustomerResponse> UpdateAsync(int id, Customer customer);
        Task<CustomerResponse> DeleteAsync(int id);

    }
}