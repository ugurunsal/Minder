using Microsoft.AspNetCore.Mvc;
using Minder.DTO;
using Minder.Helper;
using Minder.Interface;
using Minder.Model;

[ApiController]
[Route("[controller]")]
public class AccountController : ControllerBase
{
    private readonly IAccountService _accountService;
    private readonly ResponseGeneratorHelper ResponseGeneratorHelper;

    public AccountController(IAccountService accountService, ResponseGeneratorHelper _ResponseGeneratorHelper)
    {
        _accountService = accountService;
        ResponseGeneratorHelper = _ResponseGeneratorHelper;
    }

    [HttpPost("create")]
    public ActionResult<BaseResponse<Account>> Create(Account account)
    {
        return ResponseGeneratorHelper.ResponseGenerator(_accountService.Create(account));
    }

    [HttpPost("update")]
    public ActionResult<BaseResponse<Account>> Update(Account account)
    {
        return ResponseGeneratorHelper.ResponseGenerator(_accountService.Update(account));
    }

    [HttpPost("updateemail")]
    public ActionResult<BaseResponse<Account>> UpdateEmail(string oldEmail, string newEmail)
    {
        return ResponseGeneratorHelper.ResponseGenerator(_accountService.UpdateEmail(oldEmail,newEmail));
    }

    [HttpPost("updatepassword")]
    public ActionResult<BaseResponse<Account>> UpdatePasswordByEmail(string email, string newPassword)
    {
        return ResponseGeneratorHelper.ResponseGenerator(_accountService.UpdatePasswordByEmail(email,newPassword));
    }

    [HttpPost("changeisblocked")]
    public ActionResult<BaseResponse<Account>> ChangeIsBlockedByEmail(string email)
    {
        return ResponseGeneratorHelper.ResponseGenerator(_accountService.ChangeIsBlockedByEmail(email));
    }

    [HttpPost("changevisibility")]
    public ActionResult<BaseResponse<Account>> ChangeVisibilityByEmail(string email)
    {
        return ResponseGeneratorHelper.ResponseGenerator(_accountService.ChangeVisibilityByEmail(email));
    }

    [HttpPost("delete")]
    public ActionResult<BaseResponse<string>> DeleteByEmail(string email)
    {
        return ResponseGeneratorHelper.ResponseGenerator(_accountService.DeleteByEmail(email));
    }

    [HttpGet("getall")]
    public ActionResult<BaseResponse<List<Account>>> GetAll()
    {
        return ResponseGeneratorHelper.ResponseGenerator(_accountService.GetAll());
    }

    [HttpGet("getbyemail")]
    public ActionResult<BaseResponse<Account>> GetByEmail(string email)
    {
        return ResponseGeneratorHelper.ResponseGenerator(_accountService.GetByEmail(email));
    }

    [HttpGet("getbyid")]
    public ActionResult<BaseResponse<Account>> GetById(int id)
    {
        return ResponseGeneratorHelper.ResponseGenerator(_accountService.GetById(id));
    }
}