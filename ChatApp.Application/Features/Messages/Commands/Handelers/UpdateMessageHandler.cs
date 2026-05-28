using AutoMapper;
using ChatApp.Application.Common;
using ChatApp.Application.Features.Messages.Commands.Models;
using ChatApp.Application.Features.Messages.Commands.Response;
using ChatApp.Application.Interfaces.IUnitOfWork;
using ChatApp.Application.Interfaces.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatApp.Application.Features.Messages.Commands.Handelers
{
    public class UpdateMessageHandler : ResponseHandler, IRequestHandler<UpdateMessageCommand, Response<UpdateMessageDto>>
    {
        private readonly IMessageRepository _messageRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public UpdateMessageHandler(IMessageRepository messageRepository,IUnitOfWork unitOfWork, IMapper mapper)
        {
            _messageRepository = messageRepository;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<Response<UpdateMessageDto>> Handle(UpdateMessageCommand request, CancellationToken cancellationToken)
        {
            var message = await _messageRepository.GetByIdAsync(request.Id);
            if (message == null)
                return NotFound<UpdateMessageDto>("Message not found");
            message.Content = request.Content;

          await _messageRepository.UpdateIncludeAsync(message,nameof(message.Content));
            await _unitOfWork.SaveChangesAsync();
            var messageDto = _mapper.Map<UpdateMessageDto>(message);
            return Success(messageDto, "Message Updated Successfully");


        }
    }
}
