using System.Collections.Generic;
using System.Threading.Tasks;
using Go2Climb.API.Domain.Models;

namespace Go2Climb.API.Domain.Repositories
{
    public interface IServiceReviewRepository
    {
        Task<IEnumerable<ServiceReview>> ListAsync();
        Task<ServiceReview> FindByIdAsync(int id);
        //TODO: Check this method
    //  Task<IEnumerable<AgencyReview>> FindByCategoryId(int categoryId);
        Task AddAsync(ServiceReview serviceReview);
        void Remove(ServiceReview serviceReview);
    }
}