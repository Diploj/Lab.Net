using Chat.Service.Controllers.Users.Entities;
using FluentValidation;
namespace Chat.Service.Validator;

public class RegisterUserRequestValidator : AbstractValidator<RegisterUserRequest>
{
    public RegisterUserRequestValidator()
    {
        RuleFor(request => request.Email)
            .NotEmpty()
            .EmailAddress()
            .WithMessage("Email is required");
        RuleFor(request => request.PhoneNumber)
            .NotEmpty()
            .Matches("[+]7[0-9]{10}")
            .WithMessage("Phone number is required");
        RuleFor(request => request.Login)
            .NotEmpty()
            .MinimumLength(3)
            .MaximumLength(30)
            .WithMessage("Name is required");
    }
}