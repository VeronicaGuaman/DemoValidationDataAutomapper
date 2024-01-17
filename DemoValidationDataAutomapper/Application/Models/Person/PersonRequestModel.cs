using System.ComponentModel.DataAnnotations;

namespace DemoValidationDataAutomapper.Application.Models.Person
{
    public class PersonRequestModel
    {
        [Required(ErrorMessage = "El nombre es requerido.")]
        [MaxLength(50, ErrorMessage = "El nombre no puede exceder los 50 caracteres.")]
        [MinLength(3, ErrorMessage = "El nombre debe tener al menos 3 caracteres.")]
        [RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "El nombre solo puede contener letras.")]

        public required string Name { get; set; }

        [Required(ErrorMessage = "El apellido es requerido.")]
        [MaxLength(50, ErrorMessage = "El apellido no puede exceder los 50 caracteres.")]
        [MinLength(3, ErrorMessage = "El apellido debe tener al menos 3 caracteres.")]
        [RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "El apellido solo puede contener letras.")]
        public string? LastName { get; set; }

        [Required(ErrorMessage = "El correo electrónico es requerido.")]
        [EmailAddress(ErrorMessage = "El correo electrónico no es válido.")]
        [MaxLength(100, ErrorMessage = "El correo electrónico no puede exceder los 100 caracteres.")]
        [MinLength(5, ErrorMessage = "El correo electrónico debe tener al menos 5 caracteres.")]
        public string? Email { get; set; }

        [Required(ErrorMessage = "El número de teléfono es requerido.")]
        [Phone(ErrorMessage = "El número de teléfono no es válido.")]
        [RegularExpression(@"^\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})$", ErrorMessage = "El número de teléfono no es válido.")]
        [MaxLength(15, ErrorMessage = "El número de teléfono no puede exceder los 15 caracteres.")]
        public string? Phone { get; set; }

        [Required(ErrorMessage = "La fecha de creación es requerida.")]
        [DataType(DataType.Date, ErrorMessage = "La fecha de creación no es válida.")]
        [Range(typeof(DateTime), "1/1/1900", "12/31/2099", ErrorMessage = "La fecha de creación está fuera del rango permitido.")]
        public DateTime CreateDate { get; set; } = DateTime.Now;
    }
}
