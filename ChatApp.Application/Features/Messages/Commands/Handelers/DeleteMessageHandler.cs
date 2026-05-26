using AutoMapper;
using ChatApp.Application.Common;
using ChatApp.Application.Features.Messages.Commands.Models;
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
    public class DeleteMessageHandler : ResponseHandler, IRequestHandler<DeleteMessageCommand, Response<string>>
    {
        private readonly IMessageRepository _messageRepository;
        private readonly IUnitOfWork _unitOfWork;

        public DeleteMessageHandler(IMessageRepository messageRepository,IUnitOfWork unitOfWork)
        {
            _messageRepository = messageRepository;
            _unitOfWork = unitOfWork;
        }
        public async Task<Response<string>> Handle(DeleteMessageCommand request, CancellationToken cancellationToken)
        {
            var message = await _messageRepository.GetByIdAsync(request.Id);
            if (message == null) 
                throw new KeyNotFoundException("Message not found");
           await _messageRepository.SoftDeleteAsync(message);
           await _unitOfWork.SaveChangesAsync();

            return Deleted<string>();



        }
    }
}
