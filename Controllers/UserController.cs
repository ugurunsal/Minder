using Microsoft.AspNetCore.Mvc;
using Minder.DTO;
using Minder.Interface;
using Minder.Model;

[ApiController]
[Route("[controller]")]
public class UserController : ControllerBase
{
    private readonly IUserService _userService;
    

    public UserController(IUserService userService)
    {
        _userService = userService;
    }

    [HttpPost("create")]
    public void Create(User user)
    {
        _userService.Create(user);
    }

    [HttpPost("update")]
    public User Update(User user)
    {
        return _userService.Update(user);
    }

    [HttpPost("delete")]
    public void Delete(User user)
    {
        _userService.Delete(user);
    }

    [HttpGet("getall")]
    public List<User> GetAll()
    {
        return _userService.GetAll();
    }

    [HttpGet]
    public User FindById(int id)
    {
        return _userService.FindById(id);
    }
}