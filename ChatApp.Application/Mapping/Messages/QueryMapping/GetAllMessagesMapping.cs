
using ChatApp.Application.Features.Messages.Commands.Models;
using ChatApp.Application.Features.Messages.Commands.Response;
using ChatApp.Application.Features.Messages.Queries.Models;
using ChatApp.Application.Features.Messages.Queries.Response;
using ChatApp.Domain.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatApp.Application.Mapping.Messages
{
   public partial class MessageProfile
    {
        public void GetAllMessagesMapping()
        {
            CreateMap<GetAllMessagesQuery, Message>();

            CreateMap<Message, GetAllMessagesDto>();
        }

    }
}
