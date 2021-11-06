using System.Collections.Generic;
using System.Threading.Tasks;
using Go2Climb.API.Domain.Models;

namespace Go2Climb.API.Domain.Repositories
{
    public interface IHiredServiceRepository
    {
        Task<IEnumerable<HiredService>> ListAsync();
        Task AddAsync(HiredService service);
        Task<HiredService> FindByIdAsync(int id);
        void Update(HiredService service);
        void Remove(HiredService service);
    }
}