﻿using System.Collections.Generic;
using System.Threading.Tasks;
using Go2Climb.API.Domain.Models;
using Go2Climb.API.Domain.Services.Communication;

namespace Go2Climb.API.Domain.Services
{
    public interface IActivityService
    {
        Task<IEnumerable<Activity>> ListAsync();
        Task<IEnumerable<Activity>> ListById(int id);
        Task<IEnumerable<Activity>> ListByServiceIdAsync(int serviceId);
        Task<ActivityResponse> SaveAsync(Activity activity, int serviceId);
        Task<ActivityResponse> UpdateAsync(int id, Activity activity);
        Task<ActivityResponse> DeleteAsync(int id);
    }
}