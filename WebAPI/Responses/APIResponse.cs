namespace WebAPI.Responses
{
    public class APIResponse<T>
    {
        public bool IsSuccess { get; set; }
        public string Message { get; set; }
        public T Data { get; set; }
        public static APIResponse<T> Success (string message="Success",T data=default)
        {
            return new APIResponse<T>
            {
                IsSuccess = true,
                Message = message,
                Data = data
            };
        }
        public static APIResponse<T> Failure(string message = "Failed")
        {
            return new APIResponse<T>
            {
                IsSuccess = false,
                Message = message,
            };
        }
    }
}
