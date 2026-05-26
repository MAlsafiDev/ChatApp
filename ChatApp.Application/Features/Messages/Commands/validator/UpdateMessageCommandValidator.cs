using ChatApp.Application.Features.Messages.Commands.Models;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatApp.Application.Features.Messages.Commands.validator
{
    public class UpdateMessageCommandValidator: AbstractValidator<UpdateMessageCommand>
    {
        public UpdateMessageCommandValidator()
        {
            RuleFor(x => x.Id)
                .GreaterThan(0);

            RuleFor(x => x.Content)
                .NotEmpty()
                .MaximumLength(2000);
        }
    }
}
