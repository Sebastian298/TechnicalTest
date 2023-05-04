using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using TechnicalTest.Models.Responses;

namespace TechnicalTest.Attributes
{
    public class ModelStateValidator
    {
        public static IActionResult ValidModelState(ActionContext context)
        {
            var modelStateEntries = context.ModelState.Where(x => x.Value?.Errors.Count > 0);

            var errorSerialized = string.Join(" | ", modelStateEntries.Select(x => x.Value?.Errors.FirstOrDefault()?.ErrorMessage));
            dynamic response = new JObject();
            response.title = "";
            response.type = "warning";
            response.message = "Verifique el formato de entrada";
            response.exceptionMessage = errorSerialized;
            var genericResponse = new GenericResponse<JObject>
            {
                StatusCode = 400,
                Content = response
            };

            return new BadRequestObjectResult(genericResponse);
        }
    }
}
