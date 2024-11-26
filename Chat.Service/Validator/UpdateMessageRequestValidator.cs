using Chat.Service.Controllers.Messages.Entities;
using FluentValidation;

namespace Chat.Service.Validator;

public class UpdateMessageRequestValidator : AbstractValidator<UpdateMessageRequest>
{
    public UpdateMessageRequestValidator()
    {
        RuleFor(request => request.Text)
            .NotEmpty()
            .WithMessage("Text cannot be empty");
    }
}