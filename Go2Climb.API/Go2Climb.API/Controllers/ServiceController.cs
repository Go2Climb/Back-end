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
    public class ServicesController : ControllerBase
    {
        private readonly IServiceService _serviceService;
        private readonly IMapper _mapper;

        public ServicesController(IServiceService serviceService, IMapper mapper)
        {
            _serviceService = serviceService;
            _mapper = mapper;
        }
        [SwaggerOperation(
            Summary = "Get All Services",
            Description = "Get All Services already stored",
            Tags = new[] {"Services"})]
        [HttpGet]
        public async Task<IEnumerable<ServiceResource>> GetAllAsync()
        {
            var services = await _serviceService.ListAsync();
            var resources = _mapper.Map<IEnumerable<Service>, IEnumerable<ServiceResource>>(services);
            return resources;
        }

        [HttpGet("{id}")]
        [SwaggerOperation(
            Summary = "Get All Services",
            Description = "Get All Services already stored",
            Tags = new[] {"Services"})]
        public async Task<IActionResult> GetByIdAsync(int id)
        {
            var result = await _serviceService.GetById(id);
        
            if (!result.Success)
                return BadRequest(result.Message);
            
            return Ok(result.Resource);
        }
        [HttpGet("[controller]")]
        [SwaggerOperation(
            Summary = "Get All Services By Text",
            Description = "Get All Services Of Coincided By Text",
            Tags = new[] {"Services"})]
        public async Task<IEnumerable<ServiceResource>> ListByText(string text, int start, int limit)
        {
            var services = await _serviceService.ListByText(text, start, limit);
            var resources = _mapper.Map<IEnumerable<Service>, IEnumerable<ServiceResource>>(services);
            return resources;
        }

        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody] SaveServiceResource resource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());

            var service = _mapper.Map<SaveServiceResource, Service>(resource);
            var result = await _serviceService.SaveAsync(service);

            if (!result.Success)
                return BadRequest(result.Message);
            
            var serviceResource = _mapper.Map<Service, ServiceResource>(result.Resource);

            return Ok(serviceResource);
        }
        
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAsync(int id, [FromBody] SaveServiceResource resource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());
            
            var service = _mapper.Map<SaveServiceResource, Service>(resource);

            var result = await _serviceService.UpdateAsync(id, service);
            
            if (!result.Success)
                return BadRequest(result.Message);

            var serviceResource = _mapper.Map<Service, ServiceResource>(result.Resource);

            return Ok(serviceResource);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var result = await _serviceService.DeleteAsync(id);

            if (!result.Success)
                return BadRequest(result.Message);
            
            var serviceResource = _mapper.Map<Service, ServiceResource>(result.Resource);
            
            return Ok(serviceResource);
        }
    }
}