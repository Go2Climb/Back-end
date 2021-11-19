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
    [Produces("application/json")]
    [ApiController]
    [Route("/api/v1/[controller]")]
    public class AgencyReviewsController : ControllerBase
    {
        private readonly IAgencyReviewService _agencyReviewService;
        private readonly IMapper _mapper;

        public AgencyReviewsController(IAgencyReviewService agencyReviewService, IMapper mapper)
        {
            _agencyReviewService = agencyReviewService;
            _mapper = mapper;
        }
        [SwaggerOperation(
            Summary = "Get All AgencyReviews",
            Description = "Get All AgencyReviews already stored",
            Tags = new[] {"AgencyReviews"})]
        [HttpGet]
        public async Task<IEnumerable<AgencyReview>> GetAllAsync()
        {
            var agencyReviews = await _agencyReviewService.ListAsync();
            //TODO: RETURN AGENCY REVIEW RESOURCE
            return agencyReviews;
        }

        [HttpGet("{id}")]
        [SwaggerOperation(
            Summary = "Get AgencyReview by Id",
            Description = "Get and AgencyReview already stored by its Id")]
        public async Task<IActionResult> GetByIdAsync(int id)
        {
            var result = await _agencyReviewService.GetByIdAsync(id);
        
            if (!result.Success)
                return BadRequest(result.Message);
            
            return Ok(result.Resource);
        }

        [HttpPost]
        [SwaggerOperation(
            Summary = "Register an AgencyReview",
            Description = "Add an AgencyReview to the Database")]
        public async Task<IActionResult> PostAsync([FromBody] SaveAgencyReviewResource resource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());

            var agencyReview = _mapper.Map<SaveAgencyReviewResource, AgencyReview>(resource);
            var result = await _agencyReviewService.SaveAsync(agencyReview);

            if (!result.Success)
                return BadRequest(result.Message);
            
            //TODO: Convert the response from AgencyReview to AgencyReviewResource

            return Ok(result.Resource);
        }

        [HttpDelete("{id}")]
        [SwaggerOperation(
            Summary = "Delete An AgencyReview",
            Description = "Remove an Agency already stored by its Id")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var result = await _agencyReviewService.DeleteAsync(id);

            if (!result.Success)
                return BadRequest(result.Message);
            
            //TODO: Convert the response from AgencyReview to AgencyReviewResource
            
            return Ok(result.Resource);
        }
    }
}