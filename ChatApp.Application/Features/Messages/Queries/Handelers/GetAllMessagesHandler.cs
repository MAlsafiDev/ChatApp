using AutoMapper;
using ChatApp.Application.Common;
using ChatApp.Application.Features.Messages.Queries.Models;
using ChatApp.Application.Features.Messages.Queries.Response;
using ChatApp.Application.Interfaces.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace ChatApp.Application.Features.Messages.Queries.Handelers
{
    public class GetAllMessagesHandler : ResponseHandler, IRequestHandler<GetAllMessagesQuery, Response<List<GetAllMessagesDto>>>
    {
        private readonly IMessageRepository _messageRepository;
        private readonly IMapper _mapper;

        public GetAllMessagesHandler(IMessageRepository messageRepository , IMapper mapper)
        {
            _messageRepository = messageRepository;
            _mapper = mapper;
        }
        public async Task<Response<List<GetAllMessagesDto>>> Handle(GetAllMessagesQuery request, CancellationToken cancellationToken)
        {
            var messages = await _messageRepository.GetAll().ToListAsync();

            var messagesDto = _mapper.Map<List<GetAllMessagesDto>>(messages);

            return Success(messagesDto);
        }
    }
}
