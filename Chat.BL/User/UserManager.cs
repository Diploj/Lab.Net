using System.Globalization;
using AutoMapper;
using Chat.BL.User.Entities;
using Chat.DataAccess.Entities;
using Chat.Repository;

namespace Chat.BL.User;

public class UserManager : IUserManager
{
    private readonly IRepository<UserEntity> _userRepository;
    private readonly IMapper _mapper;
    
    public UserManager(IRepository<UserEntity> userRepository, IMapper mapper)
    {
        _userRepository = userRepository;
        _mapper = mapper;
    }
    
    public UserModel CreateUser(CreateUserModel model)
    {
        var entity = _mapper.Map<UserEntity>(model);

        _userRepository.Save(entity); 

        return _mapper.Map<UserModel>(entity);
    }

    public void DeleteUser(int id)
    {
        try
        {
            var entity = _userRepository.GetById(id);
            _userRepository.Delete(entity);
        }
        catch (Exception e)
        {
            throw new Exception(e.Message);
        }
    }

    public UserModel UpdateUser(int id, UpdateUserModel model)
    {
        var entity = _userRepository.GetById(id);
        if (entity == null)
            throw new KeyNotFoundException();
        
        entity = _mapper.Map<UserEntity>(model);
        entity = _userRepository.Save(entity);
        return _mapper.Map<UserModel>(entity);
    }
}