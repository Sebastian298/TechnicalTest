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

            var genericResponse = new GenericResponse<string>();
            genericResponse.StatusCode = 400;
            genericResponse.Content = errorSerialized;
            return new BadRequestObjectResult(genericResponse);
        }
    }
}
