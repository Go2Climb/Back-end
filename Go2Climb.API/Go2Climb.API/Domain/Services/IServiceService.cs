using System.Collections.Generic;
using System.Threading.Tasks;
using Go2Climb.API.Domain.Models;
using Go2Climb.API.Domain.Services.Communication;

namespace Go2Climb.API.Domain.Services
{
    public interface IServiceService
    {
        Task<IEnumerable<Service>> ListAsync();
        Task<ServiceResponse> GetById(int id);
        Task<IEnumerable<Service>> ListByName(string name);
        Task<IEnumerable<Service>> ListByAgencyIdAsync(int agencyId);
        Task<ServiceResponse> SaveAsync(Service service);
        Task<ServiceResponse> UpdateAsync(int id, Service service);
        Task<ServiceResponse> DeleteAsync(int id);
    }
}