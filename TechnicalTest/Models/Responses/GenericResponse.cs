namespace TechnicalTest.Models.Responses
{
    public class GenericResponse<T>
    {
        public int StatusCode { get; set; }
        public T Content { get; set; }
        public GenericResponseData Message { get; set; }
    }

    public class GenericResponseData
    {
        public string Type { get; set; }
        public string Title { get; set; }
        public string Message { get; set; }
        public string InnerException { get; set; }
    }
}
