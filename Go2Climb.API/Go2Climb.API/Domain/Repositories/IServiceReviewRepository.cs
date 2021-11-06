using System.Collections.Generic;
using System.Threading.Tasks;
using Go2Climb.API.Domain.Models;

namespace Go2Climb.API.Domain.Repositories
{
    public interface IServiceReviewRepository
    {
        Task<IEnumerable<ServiceReview>> ListAsync();
        Task<ServiceReview> FindByIdAsync(int id);
        //TODO: Implement the FindByService method
    //  Task<IEnumerable<ServiceReview>> FindByServiceId(int serviceId);
        Task AddAsync(ServiceReview serviceReview);
        void Remove(ServiceReview serviceReview);
    }
}