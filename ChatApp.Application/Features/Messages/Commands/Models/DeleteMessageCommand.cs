using ChatApp.Application.Common;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatApp.Application.Features.Messages.Commands.Models
{
    public class DeleteMessageCommand: IRequest<Response<string>>
    {
        public int Id { get; set; }

        public DeleteMessageCommand(int id)
        {
            Id = id;
        }
    }
}
