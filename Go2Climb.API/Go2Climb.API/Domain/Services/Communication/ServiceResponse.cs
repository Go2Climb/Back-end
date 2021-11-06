using Go2Climb.API.Domain.Models;

namespace Go2Climb.API.Domain.Services.Communication
{
    public class ServiceResponse : BaseResponse
    {
        public Service Service { get; private set; }
        public ServiceResponse(bool success, string message, Service service) : base(success, message)
        {
            Service = service;
        }
        public ServiceResponse(Service service) : this(true,string.Empty,service) {}
        public ServiceResponse(string message) : this(false,message,null) {}
    }
}