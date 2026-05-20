using AutoMapper;
using ChatApp.Application.Common;
using ChatApp.Application.Features.Messages.Commands.Models;
using ChatApp.Application.Features.Messages.Commands.Response;
using ChatApp.Application.Interfaces.IUnitOfWork;
using ChatApp.Application.Interfaces.Repositories;
using ChatApp.Domain.Entites;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatApp.Application.Features.Messages.Commands.Handelers
{
    public class AddMessageHandler : ResponseHandler, IRequestHandler<AddMessageCommand, Response<AddMessageDto>>
    {
        private readonly IMessageRepository _messageRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public AddMessageHandler(IMessageRepository messageRepository , IUnitOfWork unitOfWork ,IMapper mapper)
        {
            _messageRepository = messageRepository;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<Response<AddMessageDto>> Handle(AddMessageCommand request, CancellationToken cancellationToken)
        {

            var message = _mapper.Map<Message>(request);

            await _messageRepository.AddAsync(message);

            await _unitOfWork.SaveChangesAsync();

            var messageDto = _mapper.Map<AddMessageDto>(message);

            return Created(messageDto);

        }
    }
}
