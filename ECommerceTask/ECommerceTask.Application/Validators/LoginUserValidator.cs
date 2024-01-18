using ECommerceTask.Application.Command.UserCommands;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceTask.Application.Validators
{
    public class LoginUserValidator : AbstractValidator<LoginCommand>
    {
        public LoginUserValidator()
        {
            RuleFor(x => x.UsernameOrEmail).NotEmpty()
                .NotNull()
                .WithMessage("Password Mustn't Be Null Or Empty")
                .EmailAddress().WithMessage("Invalide Email Format");

            RuleFor(x => x.Password)
                .NotNull().NotEmpty()
                .MaximumLength(80)
                .MinimumLength(8)
                .WithMessage("Password Mustn't Be Null Or Empty");

        }
    }
}
