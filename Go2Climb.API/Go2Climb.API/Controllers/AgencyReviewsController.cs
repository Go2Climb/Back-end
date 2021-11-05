using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Go2Climb.API.Domain.Models;
using Go2Climb.API.Domain.Services;
using Microsoft.AspNetCore.Mvc;

namespace Go2Climb.API.Controllers
{
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

        [HttpGet]
        public async Task<IEnumerable<AgencyReview>> GetAllAsync()
        {
            var agencyReview = await _agencyReviewService.ListAsync();
            //TODO: Mapear el resultado del Get;
            return agencyReview;
        }

    }
}