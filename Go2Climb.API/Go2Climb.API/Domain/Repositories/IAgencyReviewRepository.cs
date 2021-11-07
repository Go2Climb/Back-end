using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Go2Climb.API.Domain.Models;

namespace Go2Climb.API.Domain.Repositories
{
    public interface IAgencyReviewRepository
    {
        Task<IEnumerable<AgencyReview>> ListAsync();
        Task AddAsync(AgencyReview agencyReview);
        Task<AgencyReview> FindByIdAsync(int id);
        //TODO: Implement the FindByAgency method
        //  Task<IEnumerable<AgencyReview>> FindByAgencyId(int agencyId);
        void Remove(AgencyReview agencyReview);
    }
}