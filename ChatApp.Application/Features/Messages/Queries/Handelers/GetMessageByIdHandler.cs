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

namespace ChatApp.Application.Features.Messages.Queries.Handelers
{
    public class GetMessageByIdHandler : ResponseHandler, IRequestHandler<GetMessageByIdQuery, Response<GetMessageByIdDto>>
    {
        private readonly IMessageRepository _messageRepository;
        private readonly IMapper _mapper;

        public GetMessageByIdHandler(IMessageRepository messageRepository,IMapper mapper)
        {
            _messageRepository = messageRepository;
            _mapper = mapper;
        }
        public async Task<Response<GetMessageByIdDto>> Handle(GetMessageByIdQuery request, CancellationToken cancellationToken)
        {
            var message = await _messageRepository.GetByIdAsync(request.Id);

            if (message == null)
                throw new KeyNotFoundException("Message not found");

            var messageDto = _mapper.Map<GetMessageByIdDto>(message);

            return Success(messageDto);

        }
    }
}
