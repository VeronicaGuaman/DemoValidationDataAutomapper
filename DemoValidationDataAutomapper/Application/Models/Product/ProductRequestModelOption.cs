using System.ComponentModel.DataAnnotations;

namespace DemoValidationDataAutomapper.Application.Models.Product
{
    public class ProductRequestModelOption
    {
        [Required(ErrorMessage = "El nombre es Requerido")]
        [MaxLength(50, ErrorMessage = "El nombre no puede ser mayor a 50 caracteres")]
        [MinLength(3, ErrorMessage = "El nombre debe tener mínimo 3 caracteres")]
        //[CustomName(ErrorMessage = "El nombre solo puede contener letras")]
        public string Name { get; set; }

        [MaxLength(100, ErrorMessage = "La descripción no puede ser mayor a 100 caracteres")]
        public string? Description { get; set; }

        [Range(1, 1000000, ErrorMessage = "El precio debe estar entre 1 y 1000000")]
        [Required(ErrorMessage = "El precio es Requerido")]
        public decimal Price { get; set; }

        public int PersonId { get; set; }

        #region Validaciones personalizadas con dataAnnotations
        //Validación personalizada con dataAnottations
        public class CustomNameAttribute : ValidationAttribute
        {
            protected override ValidationResult IsValid(object value, ValidationContext validationContext)
            {
                var name = value as string;
                if (name.All(char.IsLetter))
                {
                    return ValidationResult.Success;
                }
                else
                {
                    return new ValidationResult("El nombre solo puede contener letras");
                }
            }
        }
        #endregion
    }
}
