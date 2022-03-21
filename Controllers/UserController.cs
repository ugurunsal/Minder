using Microsoft.AspNetCore.Mvc;
using Minder.DTO;
using Minder.Helper;
using Minder.Interface;
using Minder.Model;

[ApiController]
[Route("[controller]")]
public class UserController : ControllerBase
{
    private readonly IUserService _userService;
    private readonly ResponseGeneratorHelper ResponseGeneratorHelper;

    public UserController(IUserService userService, ResponseGeneratorHelper _ResponseGeneratorHelper)
    {
        _userService = userService;
        ResponseGeneratorHelper = _ResponseGeneratorHelper;
    }

    [HttpPost("create")]
    public ActionResult<BaseResponse<User>> Create(User user)
    {
        return ResponseGeneratorHelper.ResponseGenerator(_userService.Create(user));
    }

    [HttpPost("update")]
    public ActionResult<BaseResponse<User>> Update(User user)
    {
        return ResponseGeneratorHelper.ResponseGenerator(_userService.Update(user));
    }

    [HttpPost("delete")]
    public ActionResult<BaseResponse<string>> Delete(User user)
    {
        return ResponseGeneratorHelper.ResponseGenerator(_userService.Delete(user));
    }

    [HttpGet("getall")]
    public ActionResult<BaseResponse<List<User>>> GetAll()
    {
        return ResponseGeneratorHelper.ResponseGenerator(_userService.GetAll());
    }

    [HttpGet]
    public ActionResult<BaseResponse<User>> FindById(int id)
    {
        return ResponseGeneratorHelper.ResponseGenerator(_userService.FindById(id));
    }
}