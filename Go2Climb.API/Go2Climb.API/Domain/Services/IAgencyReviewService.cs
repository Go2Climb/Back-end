using System.Collections.Generic;
using System.Threading.Tasks;
using Go2Climb.API.Domain.Models;

namespace Go2Climb.API.Domain.Services
{
    public interface IAgencyReviewService
    {
        Task<IEnumerable<AgencyReview>> ListAsync();
        // TODO: Check this interface
    //  Task<IEnumerable<AgencyReview>> ListByAgencyIdAsync(int agencyId);
    }
}