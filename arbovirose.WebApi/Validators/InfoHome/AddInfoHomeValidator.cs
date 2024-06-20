using arbovirose.WebApi.Requestmodels.InfoHome;
using FluentValidation;

namespace arbovirose.WebApi.Validators.InfoHome
{
    public class AddInfoHomeValidator : AbstractValidator<AddInfoHomeRequest>
    {
        public AddInfoHomeValidator()
        {
            RuleFor(x => x.Title)
                .NotEmpty().WithMessage("O título não pode ser vazio")
                .NotNull().WithMessage("O título não pode ser nulo");
            RuleFor(x => x.Link)
                .NotEmpty().WithMessage("O link não pode ser vazio")
                .NotNull().WithMessage("O link não pode ser nulo");
            RuleFor(x => x.File)
                .NotEmpty().WithMessage("O arquivo não pode ser vazio")
                .NotNull().WithMessage("O arquivo não pode ser nulo");
        }
    }
}
