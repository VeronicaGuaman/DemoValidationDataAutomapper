using DemoValidationDataAutomapper.Application.Models.Product;
using FluentValidation;

namespace DemoValidationDataAutomapper.Application.Validations
{
    public class ProductValidation : AbstractValidator<ProductRequestModel>
    {
        public ProductValidation()
        {
            RuleFor(x => x.Name).Cascade(CascadeMode.Continue)
                .NotEmpty().WithMessage("Ingrese un nombre")
                .NotNull().WithMessage("El Nombre es Requerido")
                .MaximumLength(50).WithMessage("El Nombre no debe contener más de 50 caracteres")
                .Matches(@"^[a-zA-Z\s]+$").WithMessage("El Nombre solo debe contener letras y espacios")
                .Must(BeAValidName).WithMessage("Ingrese un nombre válido");        //Must se utiliza para definir reglas de validación personalizadas
            RuleFor(x => x.Price)
                .NotEmpty().WithMessage("El precio es Requerido")
                .GreaterThan(0).WithMessage("El precio debe ser mayor a 0")
                .Must(x => x <= 10000).WithMessage("El precio debe ser menor a 10000");

            //Si la descripción no es nula, podemos realizar ás validaciones dentro
            When(x => x.Description != null, () =>
            {
                //Esta regla solo se aplica cuando la descripción es diferente de nula
                RuleFor(x => x.Description)
                    .MaximumLength(100).WithMessage("La descripción no debe contener más de 100 caracteres");
            });
        }

        //validación personalizada   
        private bool BeAValidName(string name)
        {
            name = name.Trim();             //quitar espacios en blanco
            name = name.Replace(" ", "");   //rempazar espacios en blanco
            name = name.Replace("_", "");   //rempazar guiones bajos
            return name.All(char.IsLetter); //validar que solo contenga letras
        }

        private bool BeAValidDate(DateTime date)
        {
            return date < DateTime.Now;
        }
    }
}
