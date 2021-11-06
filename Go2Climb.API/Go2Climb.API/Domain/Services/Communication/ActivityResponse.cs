using Go2Climb.API.Domain.Models;

namespace Go2Climb.API.Domain.Services.Communication
{
    public class ActivityResponse : BaseResponse
    {
        public Activity Activity { get; private set; }

        public ActivityResponse(bool success, string message, Activity activity) : base(success, message)
        {
            Activity = activity;
        }
        
        public ActivityResponse(Activity activity) : this(true,string.Empty, activity) {}
        public ActivityResponse(string message) : this(false, message, null) {}
    }
}