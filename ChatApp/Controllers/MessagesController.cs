using ChatApp.Application.Features.Messages.Commands.Models;
using ChatApp.Application.Features.Messages.Queries.Models;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ChatApp.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MessagesController : ControllerBase
    {
        private readonly IMediator _mediator;

        public MessagesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]

        public async Task<IActionResult> GetMessages()
        {
            var response = await _mediator.Send(new GetAllMessagesQuery());
            return Ok(response);
        }

        [HttpGet("{id}")]

        public async Task<IActionResult> GetMessageById(int id)
        {
            var response = await _mediator.Send(new GetMessageByIdQuery(id));
            return Ok(response);
        }

        [HttpPost]
        public async Task<IActionResult> AddMessage (AddMessageCommand command)
        {
            var response = await _mediator.Send(command);
            return Ok(response);
        }

        [HttpPut]
        public async Task<IActionResult> Update(int Id, UpdateMessageCommand command)
        {
            if (Id != command.Id) return BadRequest("ID missmatch");

            var response = await _mediator.Send(command);

            return Ok(response);
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteMessage(DeleteMessageCommand command)
        {
            var response = await _mediator.Send(command);
            return Ok(response);
        }

    }
}
