using FluentValidation;

namespace AtlanticProductDesing.Application.Features.People.Commands.CreatePerson
{
    public class CreatePersonCommandValidator : AbstractValidator<CreatePersonCommand>
    {
        public CreatePersonCommandValidator()
        {
            RuleFor(p => p.Name)
                .NotEmpty().WithMessage("El nombre es obligatorio.")
                .MaximumLength(100).WithMessage("El nombre no debe exceder los 100 caracteres.");

            RuleFor(p => p.LastName)
                .NotEmpty().WithMessage("El apellido es obligatorio.")
                .MaximumLength(100).WithMessage("El apellido no debe exceder los 100 caracteres.");

            RuleFor(p => p.DocumentId)
                .NotEmpty().WithMessage("El número de documento es obligatorio.")
                .MaximumLength(20).WithMessage("El número de documento no debe exceder los 20 caracteres.");

            RuleFor(p => p.DocumentType)
                .IsInEnum().WithMessage("El tipo de documento es inválido.");

            RuleFor(p => p.Sex)
                .MaximumLength(10).WithMessage("El campo sexo no debe exceder los 1 caracteres.")
                .Must(value => value == null || value == "M" || value == "F").WithMessage("El sexo debe ser 'M' o 'F'.");
        }
    }
}
