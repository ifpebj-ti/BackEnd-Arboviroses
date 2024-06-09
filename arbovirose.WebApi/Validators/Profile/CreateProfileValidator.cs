using arbovirose.WebApi.Requestmodels.Profile;
using FluentValidation;

namespace arbovirose.WebApi.Validators.Profile
{
    public class CreateProfileValidator : AbstractValidator<CreateProfileRequest>
    {
        public CreateProfileValidator()
        {
            RuleFor(x => x.Office)
                .NotEmpty().WithMessage("O cargo não pode ser vazio")
                .NotNull().WithMessage("O cargo não pode ser nulo");
        }
    }
}
