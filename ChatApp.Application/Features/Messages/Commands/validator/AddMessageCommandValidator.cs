using ChatApp.Application.Features.Messages.Commands.Models;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatApp.Application.Features.Messages.Commands.validator
{
    public class AddMessageCommandValidator : AbstractValidator<AddMessageCommand>
    {
        public AddMessageCommandValidator()
        {
            RuleFor(x => x.SenderId)
                .GreaterThan(0).WithMessage("SenderId is required");

            RuleFor(x => x.RecipientId)
                .GreaterThan(0).WithMessage("RecipientId is required")
                .NotEqual(x => x.SenderId)
                .WithMessage("You cannot send a message to yourself");

            RuleFor(x => x.Content)
                 .NotEmpty().WithMessage("Message content is required")
                 .MaximumLength(2000).WithMessage("Message is too long")
                 .Must(c => !string.IsNullOrWhiteSpace(c))
                 .WithMessage("Message cannot be empty or whitespace");

       
        }
    }
}
