using System.Collections.Generic;
using System.Threading.Tasks;
using Go2Climb.API.Domain.Models;

namespace Go2Climb.API.Domain.Repositories
{
    public interface IAgencyRepository
    {
        Task<IEnumerable<Agency>> ListAsync();
        Task<IEnumerable<Agency>> ListById(int id);
        Task<IEnumerable<Agency>> ListByName(string name);
        Task<Agency> FindById(int id);
        Task AddAsync(Agency agency);
        void Update(Agency agency);
        void Remove(Agency agency);
    }
}