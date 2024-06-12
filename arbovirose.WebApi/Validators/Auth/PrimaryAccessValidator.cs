using arbovirose.WebApi.Requestmodels.Auth;
using FluentValidation;

namespace arbovirose.WebApi.Validators.Auth
{
    public class PrimaryAccessValidator : AbstractValidator<PrimaryAccessRequest>
    {
        public PrimaryAccessValidator()
        {
            RuleFor(x => x.Email)
                .NotEmpty().WithMessage("O email não pode ser vazio")
                .NotNull().WithMessage("O email não pode ser nulo");
            RuleFor(x => x.NewPassword)
                .NotEmpty().WithMessage("A nova senha não pode ser vazia")
                .NotNull().WithMessage("A nova senha não pode ser nula");
            RuleFor(x => x.DefaultPassword)
                .NotEmpty().WithMessage("A senha padrão não pode ser vazia")
                .NotNull().WithMessage("O A senha padrão não pode ser nula");
        }
    }
}
