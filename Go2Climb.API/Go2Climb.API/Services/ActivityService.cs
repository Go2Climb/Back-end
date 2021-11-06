using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Go2Climb.API.Domain.Models;
using Go2Climb.API.Domain.Repositories;
using Go2Climb.API.Domain.Services;
using Go2Climb.API.Domain.Services.Communication;

namespace Go2Climb.API.Services
{
    public class ActivityService : IActivityService
    {
        private readonly IServiceRepository _serviceRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IActivityRepository _activityRepository;

        public ActivityService(IServiceRepository serviceRepository, IUnitOfWork unitOfWork, IActivityRepository activityRepository)
        {
            _serviceRepository = serviceRepository;
            _unitOfWork = unitOfWork;
            _activityRepository = activityRepository;
        }

        public async Task<IEnumerable<Activity>> ListAsync()
        {
            return await _activityRepository.ListAsync();
        }

        public async Task<IEnumerable<Activity>> ListById(int id)
        {
            return await _activityRepository.ListById(id);
        }

        public async Task<IEnumerable<Activity>> ListByServiceIdAsync(int serviceId)
        {
            return await _activityRepository.ListById(serviceId);
        }

        public async Task<ActivityResponse> SaveAsync(Activity activity, int serviceId)
        {
            var existingService = await _serviceRepository.FindById(serviceId);
            if (existingService == null)
                return new ActivityResponse("Activity not found");
            activity.Service = existingService;
            try
            {
                await _activityRepository.AddAsync(activity);
                await _unitOfWork.CompleteAsync();
                return new ActivityResponse(activity);
            }
            catch (Exception e)
            {
                return new ActivityResponse($"An error occurred while saving the activity: {e.Message}");
            }
        }

        public async Task<ActivityResponse> UpdateAsync(int id, Activity activity)
        {
            var existingActivity = await _activityRepository.FindById(id);
            if (existingActivity == null)
                return new ActivityResponse("Activity not found");
            existingActivity.Name = activity.Name;
            existingActivity.Description = activity.Description;
            try
            {
                _activityRepository.Update(existingActivity);
                await _unitOfWork.CompleteAsync();
                return new ActivityResponse(existingActivity);
            }
            catch (Exception e)
            {
                return new ActivityResponse($"An error occurred while updating the Activity: {e.Message}");
            }
        }

        public async Task<ActivityResponse> DeleteAsync(int id)
        {
            var existingActivity = await _activityRepository.FindById(id);
            if (existingActivity == null)
                return new ActivityResponse("Activity not found");
            try
            {
                _activityRepository.Remove(existingActivity);
                await _unitOfWork.CompleteAsync();
                return new ActivityResponse(existingActivity);
            }
            catch (Exception e)
            {
                return new ActivityResponse($"An error occurred while deleting the Activity: {e.Message}");
            }
        }
    }
}