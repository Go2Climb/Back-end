using System.Collections.Generic;
using System.Threading.Tasks;
using Go2Climb.API.Domain.Models;
using Go2Climb.API.Domain.Repositories;
using Go2Climb.API.Domain.Services;

namespace Go2Climb.API.Services
{
    public class AgencyReviewService : IAgencyReviewService
    {
        private readonly  IAgencyReviewRepository _agencyReviewRepository;

        public AgencyReviewService(IAgencyReviewRepository agencyReviewRepository)
        {
            _agencyReviewRepository = agencyReviewRepository;
        }
        public async Task<IEnumerable<AgencyReview>> ListAsync()
        {
            return await _agencyReviewRepository.ListAsync();
        }
    }
}