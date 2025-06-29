using FluentValidation;

namespace AtlanticProductDesing.Application.Features.People.Commands.UpdatePerson
{
    public class UpdatePersonValidator : AbstractValidator<UpdatePersonCommand>
    {
        public UpdatePersonValidator()
        {
            RuleFor(x => x.Id).NotEmpty().WithMessage("El ID es requerido.");
            RuleFor(x => x.Name).NotEmpty().WithMessage("El nombre es requerido.");
            RuleFor(x => x.LastName).NotEmpty().WithMessage("El apellido es requerido.");
            RuleFor(x => x.DocumentId).NotEmpty().WithMessage("El documento es requerido.");
            RuleFor(x => x.DocumentType).IsInEnum().WithMessage("El tipo de documento es inválido.");
            RuleFor(x => x.Birthdate).NotEmpty().WithMessage("La fecha de nacimiento es requerida.");
        }
    }
}
