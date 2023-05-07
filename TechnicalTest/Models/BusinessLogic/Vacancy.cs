using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace TechnicalTest.Models.BusinessLogic
{
    public class Vacancy
    {
        [JsonProperty(PropertyName ="Id")]
        public int Id { get; set; }
        [JsonProperty(PropertyName ="Area")]
        public string Area { get; set; }
        [JsonProperty(PropertyName ="Salario")]
        public double Salary { get; set; }
        [JsonProperty(PropertyName ="Activo")]
        public bool Active { get; set; }
    }

    public class VacancyCreate
    {
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        [RegularExpression(@"^[a-zA-Z'áéíóúÁÉÍÓÚ\s]*$", ErrorMessage = "El campo {0} debe contener solamente letras y el carácter ' (acento).")]
        public string Area { get; set; }
        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        [RegularExpression(@"^[0-9]+(\.[0-9]*)?$", ErrorMessage = "El campo {0} debe ser un número decimal positivo.")]
        public double Salary { get; set; }
    }

    public class VacancyUpdate : VacancyCreate
    {
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        public bool Active { get; set; }
    }

    public class VacancyActive
    {
        public int Id { get; set; }
        public string Area { get; set; }
    }
}
