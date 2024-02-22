using APIDemo.Models;
using FluentValidation;

namespace APIDemo.PersonValidator
{
    public class UserValidator : AbstractValidator<UserModel>
    {
        public UserValidator() {
            RuleFor(UserModel => UserModel.UserName)
                .NotEmpty().WithMessage("User name is not empty")
                 .NotNull().WithMessage("User name is not null");
            RuleFor(UserModel => UserModel.Email)
                .NotEmpty().WithMessage("User email is not empty")
                 .NotNull().WithMessage("Email is not null")
                 .EmailAddress().WithMessage("Email must be valid ");
            RuleFor(UserModel => UserModel.Password).NotEmpty()
                 .NotNull().WithMessage("Password is not null")
                 .InclusiveBetween("7","12").WithMessage("Password length between 8 - 12 characters")
                 .Matches("^(?=.*[a-z])(?=.*[A-Z])(?=.*\\d)(?=.*[^\\da-zA-Z]).{8,15}$\r\n").WithMessage("Password must be in alphanumeric");
            RuleFor(UserModel => UserModel.ConfirmPassword).NotEmpty()
                 .NotNull().WithMessage("ConfirmPassword is not null")
                 .Equal(p=>p.Password).WithMessage("confrim Password must be same AS password");
        }

    }
}
