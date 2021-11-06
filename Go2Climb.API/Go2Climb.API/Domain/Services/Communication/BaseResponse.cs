namespace Go2Climb.API.Domain.Services.Communication
{
    public abstract class BaseResponse
    {
        protected BaseResponse(bool success, string message)
        {
            Success = success;
            Message = message;
        }
        
        public bool Success { get; protected set; }
        public string Message { get; protected set; }
    }
}