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
        //TODO: Check this method
    //  Task<IEnumerable<AgencyReview>> FindByCategoryId(int categoryId);
    //  void Update(AgencyReview agencyReview);
        void Remove(AgencyReview agencyReview);
    }
}