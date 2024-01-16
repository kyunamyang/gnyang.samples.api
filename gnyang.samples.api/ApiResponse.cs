namespace gnyang.samples.api
{
    public class ApiResponse<T> where T : class
    {
        public bool Success { get; set; }
        public int Code { get; set; }
        public required string Message { get; set; }
        public T? Result { get; set; }
    }
}