using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Go2Climb.API.Domain.Models;
using Go2Climb.API.Domain.Services;
using Go2Climb.API.Extensions;
using Go2Climb.API.Resources;
using Microsoft.AspNetCore.Mvc;

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
        public async Task<IEnumerable<ServiceReview>> GetAllAsync()
        {
            var serviceReview = await _serviceReviewService.ListAsync();
            return serviceReview;
        }
        
        [HttpGet("{id}")]
        public async Task<ServiceReview> GetByIdAsync(int id)
        {
            var serviceReview = await _serviceReviewService.GetByIdAsync(id);
            //TODO: Unhappy response
            
            return serviceReview;
        }

        [HttpPost]
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