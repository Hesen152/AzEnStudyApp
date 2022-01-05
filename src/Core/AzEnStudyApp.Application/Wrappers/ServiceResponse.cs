namespace AzEnStudyApp.Application.Wrappers
{
    public class ServiceResponse<T>:BaseResponse
    {
        private T  Value { get; set; }
        public ServiceResponse(T value)
        {
            Value = value;

        }
        
    }
}