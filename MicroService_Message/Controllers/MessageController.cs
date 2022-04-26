using MicroService_Message.Interfaces;
using MicroService_Message.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MicroService_Message.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MessageController : ControllerBase
    {
        private readonly IMessageRepository _messageRepository;

        public MessageController(IMessageRepository messageRepository)
        {
            _messageRepository = messageRepository;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var message = await _messageRepository.GetAllMessagesAsync();
            return Ok(message);
        }

        [HttpPost("add")]
        public async Task<IActionResult> Post(Message message)
        {
            await _messageRepository.AddNewMessage(message);
            return CreatedAtAction(nameof(Get), new {id = message.Id}, message);
        }
    }
}
