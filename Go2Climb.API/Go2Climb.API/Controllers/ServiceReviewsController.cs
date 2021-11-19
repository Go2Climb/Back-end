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
    public class ServiceReviewsController : ControllerBase
    {
        private readonly IServiceReviewService _serviceReviewService;
        private readonly IMapper _mapper;

        public ServiceReviewsController(IServiceReviewService serviceReviewService, IMapper mapper)
        {
            _serviceReviewService = serviceReviewService;
            _mapper = mapper;
        }

        [HttpGet]
        [SwaggerOperation(
            Summary = "Get All ServiceReviews",
            Description = "Get All ServiceReviews already stored",
            Tags = new[] {"ServiceReviews"})]
        public async Task<IEnumerable<ServiceReview>> GetAllAsync()
        {
            var serviceReview = await _serviceReviewService.ListAsync();
            //TODO: RETURN SERVICE REVIEW RESOURCE
            return serviceReview;
        }
        
        [HttpGet("{id}")]
        [SwaggerOperation(
            Summary = "Get A ServiceReview by Id",
            Description = "Get A ServiceReview already stored by its Id")]
        public async Task<IActionResult> GetByIdAsync(int id)
        {
            var result = await _serviceReviewService.GetByIdAsync(id);
            
            if (!result.Success)
                return BadRequest(result.Message);
            
            return Ok(result.Resource);
        }

        [HttpPost]
        [SwaggerOperation(
            Summary = "Register a ServiceReview",
            Description = "Add a ServiceReview to the Database ")]
        public async Task<IActionResult> PostAsync([FromBody] SaveServiceReviewResource resource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());

            var serviceReview = _mapper.Map<SaveServiceReviewResource, ServiceReview>(resource);
            var result = await _serviceReviewService.SaveAsync(serviceReview);

            if (!result.Success)
                return BadRequest(result.Message);
            
            //TODO: Convert the response from AgencyReview to AgencyReviewResource

            return Ok(result.Resource);
        }

        [HttpDelete("{id}")]
        [SwaggerOperation(
            Summary = "Delete a ServiceReview",
            Description = "Remove a ServiceReview from the Database by its Id")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var result = await _serviceReviewService.DeleteAsync(id);

            if (!result.Success)
                return BadRequest(result.Message);
            
            //TODO: Convert the response from AgencyReview to AgencyReviewResource
            
            return Ok(result.Resource);
        }
    }
}