using Chat.Service.Controllers.Messages.Entities;
using FluentValidation;

namespace Chat.Service.Validator;

public class SendMessageRequestValidator : AbstractValidator<SendMessageRequest>
{
    public SendMessageRequestValidator()
    {
        RuleFor(request => request.Text)
            .NotEmpty()
            .WithMessage("Text cannot be empty");
    }
}