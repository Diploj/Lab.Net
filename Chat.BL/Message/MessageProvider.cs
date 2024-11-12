using AutoMapper;
using Chat.BL.Message.Entities;
using Chat.DataAccess.Entities;
using Chat.Repository;

namespace Chat.BL.User;

public class MessageProvider: IMessageProvider
{
    private readonly IRepository<MessageEntity> _messageRepository;
    private readonly IMapper _mapper;
    
    public MessageProvider(IRepository<MessageEntity> messageRepository, IMapper mapper)
    {
        _messageRepository = messageRepository;
        _mapper = mapper;
    }

    public IEnumerable<MessageModel> GetUsers(FilterMessageModel? filter = null)
    {
        var users = _messageRepository.GetAll(user => 
            filter == null ||
            (filter.SendDate == null || filter.SendDate.Equals(user.CreationTime)) &&
            (filter.UserId == null || filter.UserId == user.UserId) &&
            (filter.TextPart == null || user.Text.Contains(filter.TextPart))
        );
        return _mapper.Map<IEnumerable<MessageModel>>(users);
    }

    public MessageModel GetUserInfo(int id)
    {
        var entity = _messageRepository.GetById(id);
        if (entity == null)
        {
            throw new Exception();
        }
        return _mapper.Map<MessageModel>(entity);
    }
}