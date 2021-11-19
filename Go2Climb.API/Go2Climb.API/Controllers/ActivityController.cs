using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Go2Climb.API.Domain.Models;
using Go2Climb.API.Domain.Services;
using Go2Climb.API.Extensions;
using Go2Climb.API.Resources;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace Go2Climb.API.Controllers
{
    [ApiController]
    [Route("/api/v1/[controller]")]
    public class ActivitiesController : ControllerBase
    {
        private readonly IActivityService _activityService;
        private readonly IMapper _mapper;

        public ActivitiesController(IActivityService activityService, IMapper mapper)
        {
            _activityService = activityService;
            _mapper = mapper;
        }

        [HttpGet]
        [SwaggerOperation(
            Summary = "Get All Activities",
            Description = "Get All The Activities From The Database.",
            Tags= new[] {"Activities"})]
        public async Task<IEnumerable<ActivityResource>> GetAllAsync()
        {
            var activities = await _activityService.ListAsync();
            var resources = _mapper.Map<IEnumerable<Activity>, IEnumerable<ActivityResource>>(activities);
            return resources;
        }

        [HttpGet("{id}")]
        [SwaggerOperation(
            Summary = "Get Activity By Id",
            Description = "Get An Activity From The Database by its Id.")]
        public async Task<IActionResult> GetByIdAsync(int id)
        {
            var result = await _activityService.GetById(id);
        
            if (!result.Success)
                return BadRequest(result.Message);
            
            return Ok(result.Resource);
        }

        [HttpPost]
        [SwaggerOperation(
            Summary = "Register and Activity",
            Description = "Add an Activity to the Database.")]
        public async Task<IActionResult> PostAsync([FromBody] SaveActivityResource resource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());

            var activity = _mapper.Map<SaveActivityResource, Activity>(resource);
            var result = await _activityService.SaveAsync(activity);

            if (!result.Success)
                return BadRequest(result.Message);
            
            var activityResource = _mapper.Map<Activity, ActivityResource>(result.Resource);

            return Ok(activityResource);
        }
        
        [HttpPut("{id}")]
        [SwaggerOperation(
            Summary = "Update an Activity",
            Description = "Update an Activity From the Database by its Id.")]
        public async Task<IActionResult> PutAsync(int id, [FromBody] SaveActivityResource resource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());
            
            var activity = _mapper.Map<SaveActivityResource, Activity>(resource);

            var result = await _activityService.UpdateAsync(id, activity);
            
            if (!result.Success)
                return BadRequest(result.Message);

            var activityResource = _mapper.Map<Activity, ActivityResource>(result.Resource);

            return Ok(activityResource);
        }
        [HttpDelete("{id}")]
        [SwaggerOperation(
            Summary = "Delete an Activity",
            Description = "Remove an Activity from the Database by its Id")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var result = await _activityService.DeleteAsync(id);

            if (!result.Success)
                return BadRequest(result.Message);
            
            var activityResource = _mapper.Map<Activity, ActivityResource>(result.Resource);
            
            return Ok(activityResource);
        }
    }
}