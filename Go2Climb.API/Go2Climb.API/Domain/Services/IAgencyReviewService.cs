using System.Collections.Generic;
using System.Threading.Tasks;
using Go2Climb.API.Domain.Models;
using Go2Climb.API.Domain.Services.Communication;

namespace Go2Climb.API.Domain.Services
{
    public interface IAgencyReviewService
    {
        Task<IEnumerable<AgencyReview>> ListAsync();
        Task<AgencyReviewResponse> SaveAsync(AgencyReview agencyReview);

        // TODO: Check this interface
        //  Task<IEnumerable<AgencyReview>> ListByAgencyIdAsync(int agencyId);
    }
}