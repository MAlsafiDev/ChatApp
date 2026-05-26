using ChatApp.Application.Common;
using ChatApp.Application.Features.Messages.Queries.Response;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatApp.Application.Features.Messages.Queries.Models
{
    public class GetAllMessagesQuery: IRequest<Response<List<GetAllMessagesDto>>>
    {
    }

}
