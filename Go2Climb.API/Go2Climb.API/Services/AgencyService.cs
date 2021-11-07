using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Go2Climb.API.Domain.Models;
using Go2Climb.API.Domain.Repositories;
using Go2Climb.API.Domain.Services;
using Go2Climb.API.Domain.Services.Communication;

namespace Go2Climb.API.Services
{
    public class AgencyService : IAgencyService
    {
        private readonly IAgencyRepository _agencyRepository;
        private readonly IUnitOfWork _unitOfWork;

        public AgencyService(IAgencyRepository agencyRepository, IUnitOfWork unitOfWork)
        {
            _agencyRepository = agencyRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<Agency>> ListAsync()
        {
            return await _agencyRepository.ListAsync();
        }

        public async Task<AgencyResponse> GetById(int id)
        {
            var existingAgency = _agencyRepository.FindById(id);
            if (existingAgency.Result == null)
                return new AgencyResponse("The agency does not exist.");
            
            return new AgencyResponse(existingAgency.Result);
        }

        public async Task<IEnumerable<Agency>> ListByName(string name)
        {
            return await _agencyRepository.ListByName(name);
        }

        public async Task<AgencyResponse> SaveAsync(Agency agency)
        {
            try
            {
                await _agencyRepository.AddAsync(agency);
                await _unitOfWork.CompleteAsync();

                return new AgencyResponse(agency);
            }
            catch (Exception e)
            {
                return new AgencyResponse($"An error occurred while saving the customer: {e.Message}");
            }
        }

        public async Task<AgencyResponse> UpdateAsync(int id, Agency agency)
        {
            var existingAgency = await _agencyRepository.FindById(id);
            if (existingAgency == null)
                return new AgencyResponse("Agency not found");
            existingAgency.Name = agency.Name;
            existingAgency.Description = agency.Description;
            existingAgency.Location = agency.Location;
            existingAgency.Email = agency.Email;
            existingAgency.PhoneNumber = agency.PhoneNumber;
            try
            {
                _agencyRepository.Update(existingAgency);
                await _unitOfWork.CompleteAsync();
                return new AgencyResponse(existingAgency);
            }
            catch (Exception e)
            {
                return new AgencyResponse($"An error occurred while updating the Agency: {e.Message}");
            }
        }

        public async Task<AgencyResponse> DeleteAsync(int id)
        {
            var existingAgency = await _agencyRepository.FindById(id);
            if (existingAgency == null)
                return new AgencyResponse("Agency not found");
            try
            {
                _agencyRepository.Remove(existingAgency);
                await _unitOfWork.CompleteAsync();
                return new AgencyResponse(existingAgency);
            }
            catch (Exception e)
            {
                return new AgencyResponse($"An error occurred while deleting the Agency: {e.Message}");
            }
        }
    }
}