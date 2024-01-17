using DemoValidationDataAutomapper.Application.Models.Person;
using DemoValidationDataAutomapper.Infrastructure.Data.Data;
using FluentValidation;
using Microsoft.EntityFrameworkCore;

namespace DemoValidationDataAutomapper.Application.Validations
{
    public class PersonValidate : AbstractValidator<PersonRequestModel>
    {
        public PersonValidate(DataContext context)
        {
            RuleFor(n => n.Name)
                .NotEmpty().WithMessage("El nombre es requerido")
                .MaximumLength(50).WithMessage("El nombre no puede tener más de 50 caracteres")
                .MustAsync( async (name, value, x) => {
                    return !(await context.Persons.AnyAsync(c => c.Name == value));
                    });
            
        }
    }
}
