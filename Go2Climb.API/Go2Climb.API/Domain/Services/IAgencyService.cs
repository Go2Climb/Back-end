using System.Collections.Generic;
using System.Threading.Tasks;
using Go2Climb.API.Domain.Models;
using Go2Climb.API.Domain.Services.Communication;

namespace Go2Climb.API.Domain.Services
{
    public interface IAgencyService
    {
        Task<IEnumerable<Agency>> ListAsync();
        Task<AgencyResponse> GetById(int id);
        Task<IEnumerable<Agency>> ListByName(string name);
        Task<AgencyResponse> SaveAsync(Agency agency);
        Task<AgencyResponse> UpdateAsync(int id, Agency agency);
        Task<AgencyResponse> DeleteAsync(int id);
    }
}