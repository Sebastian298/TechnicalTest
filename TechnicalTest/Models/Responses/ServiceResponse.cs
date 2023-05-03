namespace TechnicalTest.Models.Responses
{
    public class ServiceResponse
    {
        public bool HasError { get; set; } = false;
        public string Message { get; set; }
        public dynamic Results { get; set; }
    }
}
