using System.Collections.Generic;
using System.Threading.Tasks;
using Go2Climb.API.Domain.Models;
using Go2Climb.API.Domain.Services.Communication;
using Go2Climb.API.Resources;

namespace Go2Climb.API.Domain.Services
{
    public interface IAgencyService
    {
        Task<IEnumerable<Agency>> ListAsync();
        Task<Agency> GetByIdAsync(int id);
        Task RegisterAsync(SaveAgencyResource request);
        Task UpdateAsync(int id, SaveAgencyResource request);
        Task DeleteAsync(int id);
        Task<AgencyResponse> FindById(int id);
        
        Task<IEnumerable<Agency>> ListByName(string name);
        
    }
}