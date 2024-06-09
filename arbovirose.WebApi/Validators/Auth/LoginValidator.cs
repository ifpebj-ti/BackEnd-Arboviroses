using arbovirose.WebApi.Requestmodels.Auth;
using FluentValidation;

namespace arbovirose.WebApi.Validators.Auth
{
    public class LoginValidator : AbstractValidator<LoginRequest>
    {
        public LoginValidator()
        {
            RuleFor(x => x.Email)
                .NotEmpty().WithMessage("O email não pode ser vazio")
                .NotNull().WithMessage("O email não pode ser nulo");
            RuleFor(x => x.Password)
                .NotEmpty().WithMessage("A senha não pode ser vazia")
                .NotNull().WithMessage("A senha não pode ser nula");
        }
    }
}
