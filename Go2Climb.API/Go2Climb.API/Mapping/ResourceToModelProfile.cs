using Go2Climb.API.Domain.Services.Communication;
using AutoMapper;
using Go2Climb.API.Domain.Models;
using Go2Climb.API.Resources;

namespace Go2Climb.API.Mapping
{
    public class ResourceToModelProfile : Profile
    {
        public ResourceToModelProfile()
        {

            CreateMap<SaveActivityResource, Activity>();
            CreateMap<SaveAgencyResource, Agency>();
            CreateMap<SaveServiceResource, Service>();

            CreateMap<SaveCustomerResourse, Customer>();
            CreateMap<SaveHiredServiceResource, HiredService>();

            CreateMap<SaveAgencyReviewResource, AgencyReview>();
            CreateMap<SaveServiceReviewResource, ServiceReview>();

        }
    }
}