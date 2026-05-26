using ChatApp.Application.Common;
using ChatApp.Application.Features.Messages.Commands.Response;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatApp.Application.Features.Messages.Commands.Models
{
    public class UpdateMessageCommand: IRequest<Response<UpdateMessageDto>>
    {
        public int Id { get; set; }

        public string Content { get; set; } = string.Empty;
    }
}
