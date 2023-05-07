using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System.ComponentModel.DataAnnotations;

namespace TechnicalTest.Models.BusinessLogic
{
    public class Interview
    {
        [JsonProperty(PropertyName = "Id")]
        public int Id { get; set; }
        [JsonProperty(PropertyName = "Vacante")]
        public string Vacancy { get; set; }
        [JsonProperty(PropertyName ="Candidato")]
        public string Prospect { get; set; }
        [JsonProperty(PropertyName ="Fecha Entrevista")]
        public DateTime InterviewDate { get; set; }
        [JsonProperty(PropertyName ="Notas")]
        public string Notes { get; set; }
        [JsonProperty(PropertyName ="Reclutado")]
        public bool Recruited { get; set; }
    }

    public class InterviewCreate
    {
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        [RegularExpression(@"^[1-9]\d*$", ErrorMessage = "El campo {0} debe ser un número entero positivo.")]
        public int VacancyId { get; set; }
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        [RegularExpression(@"^[1-9]\d*$", ErrorMessage = "El campo {0} debe ser un número entero positivo.")]
        public int ProspectId { get; set; }
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        public DateTime InterviewDate { get; set; }

        [RegularExpression(@"^[a-zA-Z'áéíóúÁÉÍÓÚ\s]*$", ErrorMessage = "El campo {0} debe contener solamente letras y el carácter ' (acento).")]
        public string Notes { get; set; }
    }

    public class InterviewUpdate
    {
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        public DateTime InterviewDate { get; set; }
        [RegularExpression(@"^[a-zA-Z'áéíóúÁÉÍÓÚ\s]*$", ErrorMessage = "El campo {0} debe contener solamente letras y el carácter ' (acento).")]
        public string Notes { get; set; }
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        public bool Recruited { get; set; }
    }
}
