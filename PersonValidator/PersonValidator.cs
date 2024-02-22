using APIDemo.Models;
using FluentValidation;

namespace APIDemo.PersonValidator
{
    public class PersonValidator: AbstractValidator<PersonModel>
    {
        public PersonValidator() {
            RuleFor(PersonModel => PersonModel.Pname)
                .NotEmpty().WithMessage("Person name is not empty")
                 .NotNull().WithMessage("Person name is not null");
            RuleFor(PersonModel => PersonModel.Email)
                .NotEmpty().WithMessage("Person email is not empty")
                 .NotNull().WithMessage("Email is not null")
                 .EmailAddress().WithMessage("Email must be valid ");
            RuleFor(PersonModel => PersonModel.Contact).NotEmpty()
                 .NotNull().WithMessage("Person Contact is not null")
                 .Length(10).WithMessage("Contact no must 10 number");
        }

    }
}
