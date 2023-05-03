using TechnicalTest.Models.Responses;

namespace TechnicalTest.Helpers
{
    public class MessageErrorBuilder
    {
        public static GenericResponseData GenerateError(string innerException)
        {
            return new GenericResponseData
            {
                Type="danger",
                Title="Error",
                Message="Error inesperado, intente de nuevo o contacte a sistemas",
                InnerException= innerException
            };
        }
    }
}
