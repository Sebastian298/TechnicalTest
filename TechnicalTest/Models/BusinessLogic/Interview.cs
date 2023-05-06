using System.ComponentModel.DataAnnotations;

namespace TechnicalTest.Models.BusinessLogic
{
    public class Interview
    {
        public int Id { get; set; }
        public string Vacancy { get; set; }
        public string Prospect { get; set; }
        public DateTime InterviewDate { get; set; }
        public string Notes { get; set; }
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
}
