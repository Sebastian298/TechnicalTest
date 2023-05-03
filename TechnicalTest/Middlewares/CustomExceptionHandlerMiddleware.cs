using Newtonsoft.Json.Linq;
using System.Net;
using System.Reflection;
using System.Text.Json;
using TechnicalTest.Models.Responses;

namespace TechnicalTest.Middlewares
{
    public class CustomExceptionHandlerMiddleware
    {
        private readonly RequestDelegate _next;

        public CustomExceptionHandlerMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                var methodName = MethodBase.GetCurrentMethod()?.Name ?? "";
                var className = MethodBase.GetCurrentMethod()?.DeclaringType?.Name??"";
                dynamic response = new JObject();
                response.message = "Error inesperado, intente de nuevo o contacte a sistemas";
                response.exceptionMessage = ex.Message;
                response.functionName = methodName;
                response.className = className;
                var genericResponse = new GenericResponse<JObject>();
                genericResponse.StatusCode = 500;
                genericResponse.Content = response;
                context.Response.ContentType = "application/json";
                context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                await context.Response.WriteAsync(JsonSerializer.Serialize(genericResponse));
            }
        }
    }
}
