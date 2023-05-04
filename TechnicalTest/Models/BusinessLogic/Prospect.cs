using System.ComponentModel.DataAnnotations;

namespace TechnicalTest.Models.BusinessLogic
{
    public class Prospect
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
    }

    public class ProspectCreate
    {
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        [RegularExpression(@"^[a-zA-Z'áéíóúÁÉÍÓÚ\s]*$", ErrorMessage = "El campo {0} debe contener solamente letras y el carácter ' (acento).")]
        public string Name { get; set; }
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        [EmailAddress(ErrorMessage = "El campo {0} debe tener un formato de correo electrónico válido.")]
        public string Email { get; set; }
    }

    public class ProspectUpdate : ProspectCreate
    {
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        [RegularExpression(@"^[1-9]\d*$", ErrorMessage = "El campo {0} debe ser un número entero positivo.")]
        public int Id { get; set; }
    }

    public class ProspectDelete
    {
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        [RegularExpression(@"^[1-9]\d*$", ErrorMessage = "El campo {0} debe ser un número entero positivo.")]
        public int Id { get; set; }
    }
}
