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
        private readonly IAgencyReviewRepository _agencyReviewRepository;
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

        public async Task<AgencyReview> GetByIdAsync(int id)
        {
            return await _agencyReviewRepository.FindByIdAsync(id);
        }

        public async Task<AgencyReviewResponse> SaveAsync(AgencyReview agencyReview)
        {
            /*
            TODO: Validate CustomerId
            var existingCustomer = _customerRepository.FindByIdAsync(agencyReview.CustomerId);
            if (existingCustomer == null)
                return new AgencyReviewResponse("Customer is not exist.");
            TODO: Validate AgencyId
            var exitingAgency = _agencyRepository.FindByIdAsync(agencyReview.AgencyId);
            if (exitingAgency == null)
                return new AgencyReviewResponse("Agency is not exist.");
             */
            try
            {
                await _agencyReviewRepository.AddAsync(agencyReview);
                await _unitOfWork.CompleteAsync();

                return new AgencyReviewResponse(agencyReview);
            }
            catch (Exception e)
            {
                return new AgencyReviewResponse($"An error occurred while saving the agency review: {e.Message}");
            }
        }

        public async Task<AgencyReviewResponse> DeleteAsync(int id)
        {
            //Validate AgencyReview
            var existingAgencyReview = await _agencyReviewRepository.FindByIdAsync(id);

            if (existingAgencyReview == null)
                return new AgencyReviewResponse("Agency review not found.");

            try
            {
                _agencyReviewRepository.Remove(existingAgencyReview);
                await _unitOfWork.CompleteAsync();

                return new AgencyReviewResponse(existingAgencyReview);
            }
            catch (Exception e)
            {
                return new AgencyReviewResponse($"An error occurred while deleting the agency review: {e.Message}");
            }
        }
    }
}