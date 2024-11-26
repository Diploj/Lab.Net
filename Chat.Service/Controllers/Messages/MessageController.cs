using AutoMapper;
using Chat.BL.Message;
using Chat.BL.Message.Entities;
using Chat.Service.Controllers.Messages.Entities;
using Chat.Service.Validator;
using Microsoft.AspNetCore.Mvc;

namespace Chat.Service.Controllers.Messages;

[ApiController]
[Route("[controller]")]
public class MessageController : ControllerBase
{
    private readonly IMapper _mapper;
    private readonly ILogger _logger;
    private readonly IMessageManager _messageManager;
    private readonly IMessageProvider _messageProvider;

    public MessageController(IMapper mapper, ILogger logger, IMessageManager messageManager,
        IMessageProvider messageProvider)
    {
        _mapper = mapper;
        _logger = logger;
        _messageManager = messageManager;
        _messageProvider = messageProvider;
    }

    [HttpPost("send")]
    public IActionResult Send([FromBody] SendMessageRequest request)
    {
        var validationResult = new SendMessageRequestValidator().Validate(request);
        if (validationResult.IsValid)
        {
            try
            {
                var createMessageModel = _mapper.Map<CreateMessageModel>(request);
                var messageModel = _messageManager.CreateMessage(createMessageModel);
                return Ok(new MessageListResponse
                {
                    Messages = [messageModel]
                });
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message);
                return BadRequest(e.Message);
            }
        }
        _logger.LogError(validationResult.ToString());
        return BadRequest(validationResult.ToString());
    }

    [HttpPost("update")]
    public IActionResult UpdateUser([FromBody] UpdateMessageRequest request)
    {
        var validationResult = new UpdateMessageRequestValidator().Validate(request);
        if (validationResult.IsValid)
        {
            var updateMessageModel = _mapper.Map<UpdateMessageModel>(request);
            try
            {
                var messageModel = _messageManager.UpdateMessage(request.Id,updateMessageModel);
                return Ok(new MessageListResponse
                {
                    Messages = [messageModel]
                });
            }
            catch (Exception e)
            {
                return BadRequest("ERROR");
            }
        }

        _logger.LogError(validationResult.ToString());
        return BadRequest(validationResult.ToString());
    }
    
    [HttpGet]
    public IActionResult GetAllUsers()
    {
        try
        {
            var messages = _messageProvider.GetMessages();
            return Ok(new MessageListResponse
            {
                Messages = messages.ToList()
            });
        }
        catch (Exception e)
        {
            _logger.LogError(e.ToString());
            return BadRequest("ERROR");
        }
    }
    
    [HttpGet]
    [Route("filter")]
    public IActionResult GetFilteredUsers([FromQuery] MessageFilter filter)
    {
        try
        {
            var messageFilterModel = _mapper.Map<FilterMessageModel>(filter);
            var users = _messageProvider.GetMessages(messageFilterModel);
            return Ok(new MessageListResponse
            {
                Messages = users.ToList()
            });
        }
        catch (Exception e)
        {
            _logger.LogError(e.ToString());
            return BadRequest("ERROR"); 
        }
    }
    
    [HttpGet]
    [Route("info")]
    public IActionResult GetUserInfo([FromQuery] int id)
    {
        try
        {
            var userModel = _messageProvider.GetMessageInfo(id);
            return Ok(new MessageListResponse()
            {
                Messages = [userModel]
            });
        }

        catch (Exception e)
        {
            _logger.LogError(e.ToString());
            return BadRequest("ERROR");
        }
    }
}