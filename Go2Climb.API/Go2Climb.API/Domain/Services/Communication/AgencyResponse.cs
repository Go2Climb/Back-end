using Go2Climb.API.Domain.Models;

namespace Go2Climb.API.Domain.Services.Communication
{
    public class AgencyResponse : BaseResponse
    {
        public Agency Agency { get; private set; }
        public AgencyResponse(bool success, string message, Agency agency) : base(success, message)
        {
            Agency = agency;
        }
        
        public AgencyResponse(Agency agency) : this(true,string.Empty, agency) {}
        
        public AgencyResponse(string message) : this(false,message,null){}
        
    }
}