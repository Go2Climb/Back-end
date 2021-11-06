using System.Collections.Generic;
using System.Threading.Tasks;
using Go2Climb.API.Domain.Models;

namespace Go2Climb.API.Domain.Repositories
{
    public interface IServiceRepository
    {
        Task<IEnumerable<Service>> ListAsync();
        Task<IEnumerable<Service>> ListByAgencyId(int agencyId);
        Task<IEnumerable<Service>> ListByName(string name);
        Task<IEnumerable<Service>> ListById(int id);
        Task<Service> FindById(int id);
        Task AddAsync(Service service);
        void Update(Service service);
        void Remove(Service service);
    }
}