namespace API.Errors
{
    public class ApiResponse
    {
        public ApiResponse(int statusCode,string message = null)
        {
            StatusCode = statusCode;
            Message = message ?? GetDefaultMessageForStatusCode(statusCode);
        }

        private string GetDefaultMessageForStatusCode(int statusCode)
        {
            return statusCode switch
            {
                400 => "you have made a bad request",
                401 => "you are not authorized",
                404 => "Resource not found",
                500 => "Server error",
                _ => null
            };
        }
        
        public int StatusCode { get; set; }
        public string Message { get; set; }
    }
}