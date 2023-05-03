namespace TechnicalTest.Models.Responses
{
    public class GenericResponse<T>
    {
        public int StatusCode { get; set; }
        public T? Content { get; set; }
    }
}
