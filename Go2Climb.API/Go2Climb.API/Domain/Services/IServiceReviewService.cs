using System.Collections.Generic;
using System.Threading.Tasks;
using Go2Climb.API.Domain.Models;
using Go2Climb.API.Domain.Services.Communication;

namespace Go2Climb.API.Domain.Services
{
    public interface IServiceReviewService
    {
        Task<IEnumerable<ServiceReview>> ListAsync();
        Task<ServiceReview> GetByIdAsync(int id);
        Task<ServiceReviewResponse> SaveAsync(ServiceReview serviceReview);
        Task<ServiceReviewResponse> DeleteAsync(int id);

        // TODO: Check this interface
        //  Task<IEnumerable<AgencyReview>> ListByServiceIdAsync(int serviceId);
    }
}