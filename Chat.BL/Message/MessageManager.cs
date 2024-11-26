using AutoMapper;
using Chat.BL.Message.Entities;
using Chat.DataAccess.Entities;
using Chat.Repository;

namespace Chat.BL.Message;

public class MessageManager : IMessageManager
{
    private readonly IRepository<MessageEntity> _messageRepository;
    private readonly IMapper _mapper;
    
    public MessageManager(IRepository<MessageEntity> messageRepository, IMapper mapper)
    {
        _messageRepository = messageRepository;
        _mapper = mapper;
    }
    
    public MessageModel CreateMessage(CreateMessageModel model)
    {
        var entity = _mapper.Map<MessageEntity>(model);

        _messageRepository.Save(entity); 

        return _mapper.Map<MessageModel>(entity);
    }

    public void DeleteMessage(int id)
    {
        try
        {
            var entity = _messageRepository.GetById(id);
            _messageRepository.Delete(entity);
        }
        catch (Exception e)
        {
            throw new Exception(e.Message);
        }
    }

    public MessageModel UpdateMessage(int id, UpdateMessageModel model)
    {
        var entity = _messageRepository.GetById(id);
        if (entity == null)
            throw new KeyNotFoundException();
        
        entity = _mapper.Map<MessageEntity>(model);
        entity = _messageRepository.Save(entity);
        return _mapper.Map<MessageModel>(entity);
    }
}