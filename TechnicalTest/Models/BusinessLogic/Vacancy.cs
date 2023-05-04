using System.ComponentModel.DataAnnotations;

namespace TechnicalTest.Models.BusinessLogic
{
    public class Vacancy
    {
        public int Id { get; set; }
        public string Area { get; set; }
        public double Salary { get; set; }
        public bool Active { get; set; }
    }

    public class VacancyCreate
    {
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        [RegularExpression(@"^[a-zA-Z'áéíóúÁÉÍÓÚ\s]*$", ErrorMessage = "El campo {0} debe contener solamente letras y el carácter ' (acento).")]
        public string Area { get; set; }
        [Required(ErrorMessage ="El campo {0} es obligatorio")]
        [RegularExpression(@"^[0-9]+(\.[0-9]*)?$", ErrorMessage = "El campo Precio debe ser un número decimal positivo.")]
        public double Salary { get; set; }
    }
}
