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
    public class AgenciesController : ControllerBase
    {
        private readonly IAgencyService _agencyService;
        private readonly IMapper _mapper;

        public AgenciesController(IAgencyService agencyService, IMapper mapper)
        {
            _agencyService = agencyService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IEnumerable<AgencyResource>> GetAllAsync()
        {
            var agencies = await _agencyService.ListAsync();
            var resources = _mapper.Map<IEnumerable<Agency>, IEnumerable<AgencyResource>>(agencies);
            return resources;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdAsync(int id)
        {
            var result = await _agencyService.GetById(id);
        
            if (!result.Success)
                return BadRequest(result.Message);
            
            return Ok(result.Resource);
        }

        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody] SaveAgencyResource resource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());

            var agency = _mapper.Map<SaveAgencyResource, Agency>(resource);
            var result = await _agencyService.SaveAsync(agency);

            if (!result.Success)
                return BadRequest(result.Message);
            
            var agencyResource = _mapper.Map<Agency, AgencyResource>(result.Resource);

            return Ok(agencyResource);
        }
        
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAsync(int id, [FromBody] SaveAgencyResource resource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());
            
            var agency = _mapper.Map<SaveAgencyResource, Agency>(resource);

            var result = await _agencyService.UpdateAsync(id, agency);
            
            if (!result.Success)
                return BadRequest(result.Message);

            var agencyResource = _mapper.Map<Agency, AgencyResource>(result.Resource);

            return Ok(agencyResource);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var result = await _agencyService.DeleteAsync(id);

            if (!result.Success)
                return BadRequest(result.Message);
            
            var agencyResource = _mapper.Map<Agency, AgencyResource>(result.Resource);
            
            return Ok(agencyResource);
        }
    }
}