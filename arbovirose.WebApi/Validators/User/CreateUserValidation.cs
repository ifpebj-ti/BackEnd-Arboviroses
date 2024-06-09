using arbovirose.WebApi.Requestmodels.User;
using FluentValidation;

namespace arbovirose.WebApi.Validators.User
{
    public class CreateUserValidator : AbstractValidator<CreateUserRequest>
    {
        public CreateUserValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("O nome não pode ser vazio")
                .NotNull().WithMessage("O nome não pode ser nulo");
            RuleFor(x => x.Email)
                .EmailAddress().WithMessage("O E-mail deve ser um E-mail válido")
                .NotEmpty().WithMessage("O email não pode ser vazio")
                .NotNull().WithMessage("O email não pode ser nulo");
            RuleFor(x => x.ProfileId)
                .NotEmpty().WithMessage("O id do perfil não pode ser vazio")
                .NotNull().WithMessage("O id do perfil não pode ser nulo");
        }
    }
}
