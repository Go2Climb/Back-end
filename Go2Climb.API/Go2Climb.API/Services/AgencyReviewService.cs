using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Go2Climb.API.Domain.Models;
using Go2Climb.API.Domain.Repositories;
using Go2Climb.API.Domain.Services;
using Go2Climb.API.Domain.Services.Communication;

namespace Go2Climb.API.Services
{
    public class AgencyReviewService : IAgencyReviewService
    {
        private readonly  IAgencyReviewRepository _agencyReviewRepository;
        private readonly IUnitOfWork _unitOfWork;

        public AgencyReviewService(IAgencyReviewRepository agencyReviewRepository, IUnitOfWork unitOfWork)
        {
            _agencyReviewRepository = agencyReviewRepository;
            _unitOfWork = unitOfWork;
        }
        public async Task<IEnumerable<AgencyReview>> ListAsync()
        {
            return await _agencyReviewRepository.ListAsync();
        }

        public async Task<AgencyReviewResponse> SaveAsync(AgencyReview agencyReview)
        {
            //TODO: Validate CustomerId
            //TODO: Validate AgencyId

            try
            {
                await _agencyReviewRepository.AddAsync(agencyReview);
                await _unitOfWork.CompleteAsync();

                return new AgencyReviewResponse(agencyReview);
            }
            catch (Exception e)
            {
                return new AgencyReviewResponse($"An error occurred while saving the product: {e.Message}");
            }

        }
    }
}