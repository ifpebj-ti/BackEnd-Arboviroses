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
            RuleFor(x => x.Password)
                .NotEmpty().WithMessage("A senha não pode ser vazia")
                .NotNull().WithMessage("A senha não pode ser nula");
            RuleFor(x => x.UniqueCode)
                .NotEmpty().WithMessage("O código de acesso não pode ser vazia")
                .NotNull().WithMessage("O código de acesso não pode ser nula");
        }
    }
}
