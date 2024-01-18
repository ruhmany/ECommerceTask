using ECommerceTask.Application.Command.UserCommands;
using FluentValidation;

namespace ECommerceTask.Application.Validators
{
    internal class RegisterUserValidation : AbstractValidator<RegisterUserCommand>
    {
        public RegisterUserValidation()
        {
            RuleFor(auc => auc.Username)
                .NotEmpty()
                .NotNull()
                .MaximumLength(80)
                .MinimumLength(8)
                .WithMessage("Username Mustn't Be Null Or Empty");
            RuleFor(auc => auc.Email)
                .NotEmpty()
                .NotNull()
                .EmailAddress().WithMessage("Invalide Email Format");

            RuleFor(x => x.Password)
                .NotEmpty()
                .MaximumLength(80)
                .MinimumLength(8)
                .WithMessage("Password must not be empty");

            RuleFor(x => x.ConfirmPassword)
                .NotEmpty()
                .MaximumLength(80)
                .MinimumLength(8)
                .WithMessage("ConfirmPassword must not be empty");
            RuleFor(x => x)
                .Must(x => x.Password == x.ConfirmPassword)
                .WithMessage("Password and Confirm Password Must Be Same");
        }
    }
}
