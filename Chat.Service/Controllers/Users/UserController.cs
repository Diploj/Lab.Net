using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using Chat.BL.User;
using Chat.BL.User.Entities;
using Chat.Service.Controllers.Users.Entities;
using Chat.Service.Validator;

namespace Chat.Service.Controllers.Users;

[ApiController]
[Route("[controller]")]
public class UserController : ControllerBase
{
    private readonly IMapper _mapper;
    private readonly ILogger _logger;
    private readonly IUserManager _userManager;
    private readonly IUserProvider _userProvider;

    public UserController(IMapper mapper, ILogger<UserController> logger, IUserManager userManager,
        IUserProvider userProvider)
    {
        _mapper = mapper;
        _logger = logger;
        _userManager = userManager;
        _userProvider = userProvider;
    }

    [HttpPost("register")]
    public IActionResult RegisterUser([FromBody] RegisterUserRequest request)
    {
        var validationResult = new RegisterUserRequestValidator().Validate(request);
        if (validationResult.IsValid)
        {
            try
            {
                var createUserModel = _mapper.Map<CreateUserModel>(request);
                var userModel = _userManager.CreateUser(createUserModel);
                return Ok(new UserListResponse
                {
                    Users = [userModel]
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
    public IActionResult UpdateUser([FromBody] UpdateUserRequest request)
    {
        var validationResult = new UpdateUserRequestValidator().Validate(request);
        if (validationResult.IsValid)
        {
            var updateUserModel = _mapper.Map<UpdateUserModel>(request);
            try
            {
                var userModel = _userManager.UpdateUser(updateUserModel);
                return Ok(new UserListResponse
                {
                    Users = [userModel]
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
            var users = _userProvider.GetUsers();
            return Ok(new UserListResponse
            {
                Users = users.ToList()
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
    public IActionResult GetFilteredUsers([FromQuery] UserFilter filter)
    {
        try
        {
            var userFilterModel = _mapper.Map<FilterUserModel>(filter);
            var users = _userProvider.GetUsers(userFilterModel);
            return Ok(new UserListResponse
            {
                Users = users.ToList()
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
            var userModel = _userProvider.GetUserInfo(id);
            return Ok(new UserListResponse()
            {
                Users = [userModel]
            });
        }

        catch (Exception e)
        {
            _logger.LogError(e.ToString());
            return BadRequest("ERROR");
        }
    }
}