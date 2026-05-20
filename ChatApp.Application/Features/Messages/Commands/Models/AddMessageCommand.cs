using ChatApp.Application.Common;
using ChatApp.Application.Features.Messages.Commands.Response;
using MediatR;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatApp.Application.Features.Messages.Commands.Models
{
    public class AddMessageCommand : IRequest<Response<AddMessageDto>>
    {
        public int SenderId { get; set; }
        public string SenderUserName { get; set; } = string.Empty;
        public string RecipientUserName { get; set; } = string.Empty;

        public int RecipientId { get; set; }

        public string Content { get; set; } = string.Empty;
    }
}
