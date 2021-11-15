using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Go2Climb.API.Domain.Models;
using Go2Climb.API.Domain.Repositories;
using Go2Climb.API.Domain.Services;
using Go2Climb.API.Domain.Services.Communication;

namespace Go2Climb.API.Services
{
    public class HiredServiceService : IHiredServiceService
    {
        private readonly IHiredServiceRepository _hiredServiceRepository;
        private readonly IUnitOfWork _unitOfWork;

        public HiredServiceService(IHiredServiceRepository hiredServiceRepository, IUnitOfWork unitOfWork)
        {
            _hiredServiceRepository = hiredServiceRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<HiredService>> ListAsync()
        {
            return await _hiredServiceRepository.ListAsync();
        }

        public async Task<HideServiceResponse> SaveAsync(HiredService service)
        {
            try
            {
                await _hiredServiceRepository.AddAsync(service);
                await _unitOfWork.CompleteAsync();

                return new HideServiceResponse(service);
            }
            catch (Exception e)
            {
                return new HideServiceResponse($"An error occurred while register the hired service: {e.Message}");
            }
        }

        public async Task<HideServiceResponse> FindById(int id)
        {
            var existingCustomer = await _hiredServiceRepository.FindByIdAsync(id);

            if (existingCustomer == null)
                return new HideServiceResponse("Hired service not found.");

            return new HideServiceResponse(existingCustomer);
        }

        public async Task<HideServiceResponse> UpdateAsync(int id, HiredService service)
        {
            var existingHideService = await _hiredServiceRepository.FindByIdAsync(id);

            if (existingHideService == null)
                return new HideServiceResponse("Hired service not found.");

            existingHideService.Amount = service.Amount;
            existingHideService.Price = service.Price;
            existingHideService.ScheduledDate = service.ScheduledDate;
            existingHideService.Status = service.Status;

            try
            {
                _hiredServiceRepository.Update(existingHideService);
                await _unitOfWork.CompleteAsync();
                
                return new HideServiceResponse(existingHideService);
            }
            catch (Exception e)
            {
                return new HideServiceResponse($"An error occurred while updating the hired service: {e.Message}");
            }
        }

        public async Task<HideServiceResponse> DeleteAsync(int id)
        {
            var existingHideService = await _hiredServiceRepository.FindByIdAsync(id);

            if (existingHideService == null)
                return new HideServiceResponse("Hired service not found.");

            try
            {
                _hiredServiceRepository.Remove(existingHideService);
                await _unitOfWork.CompleteAsync();

                return new HideServiceResponse(existingHideService);
            }
            catch (Exception e)
            {
                return new HideServiceResponse($"An error occurred while deleting the hired service: {e.Message}");
            }
        }
    }
}