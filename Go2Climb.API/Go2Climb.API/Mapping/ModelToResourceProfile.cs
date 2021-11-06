using AutoMapper;
using Go2Climb.API.Domain.Models;
using Go2Climb.API.Resources;

namespace Go2Climb.API.Mapping
{
    public class ModelToResourceProfile : Profile
    {
        public ModelToResourceProfile()
        {
            CreateMap<Activity, ActivityResource>();
            CreateMap<Agency, AgencyResource>();
            CreateMap<Service, ServiceResource>();
        }
    }
}