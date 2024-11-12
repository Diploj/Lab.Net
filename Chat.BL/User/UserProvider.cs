using AutoMapper;
using Chat.BL.User.Entities;
using Chat.DataAccess.Entities;
using Chat.Repository;

namespace Chat.BL.User;

public class UserProvider: IUserProvider
{
    private readonly IRepository<UserEntity> _userRepository;
    private readonly IMapper _mapper;
    
    public UserProvider(IRepository<UserEntity> userRepository, IMapper mapper)
    {
        _userRepository = userRepository;
        _mapper = mapper;
    }

    public IEnumerable<UserModel> GetUsers(FilterUserModel? filter = null)
    {


        var users = _userRepository.GetAll(user => 
            filter == null ||
            (filter.CreationTime == null ||filter.CreationTime == user.CreationTime) &&
            (filter.ModificationTime == null || filter.ModificationTime == user.ModificationTime) &&
            (filter.Email == null || filter.Email == user.Email) &&
            (filter.Phone == null || filter.Phone == user.Phone)  &&
            (filter.IsAdmin != true || user.Role == Role.Admin)
        );
        return _mapper.Map<IEnumerable<UserModel>>(users);
    }

    public UserModel GetUserInfo(int id)
    {
        var entity = _userRepository.GetById(id);
        if (entity == null)
        {
            throw new Exception();
        }
        return _mapper.Map<UserModel>(entity);
    }
}