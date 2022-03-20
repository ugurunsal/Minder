using Microsoft.AspNetCore.Mvc;
using Minder.DTO;
using Minder.Interface;
using Minder.Model;

[ApiController]
[Route("[controller]")]
public class AccountController : ControllerBase
{
    private readonly IAccountService _accountService;

    public AccountController(IAccountService accountService)
    {
        _accountService = accountService;
    }

    [HttpPost("create")]
    public void Create(Account account)
    {
        _accountService.Create(account);
    }

    [HttpPost("update")]
    public Account Update(Account account)
    {
        _accountService.Update(account);
        return account;
    }

    [HttpPost("updateemail")]
    public Account UpdateEmail(string oldEmail, string newEmail)
    {
        return _accountService.UpdateEmail(oldEmail,newEmail);
    }

    [HttpPost("updatepassword")]
    public Account UpdatePasswordByEmail(string email, string newPassword)
    {
        return _accountService.UpdatePasswordByEmail(email,newPassword);
    }

    [HttpPost("changeisblocked")]
    public Account ChangeIsBlockedByEmail(string email)
    {
        return _accountService.ChangeIsBlockedByEmail(email);
    }

    [HttpPost("changevisibility")]
    public Account ChangeVisibilityByEmail(string email)
    {
        return _accountService.ChangeVisibilityByEmail(email);
    }

    [HttpPost("delete")]
    public void DeleteByEmail(string email)
    {
        _accountService.DeleteByEmail(email);
    }

    [HttpGet("getall")]
    public List<Account> GetAll()
    {
        return _accountService.GetAll();
    }

    [HttpGet("getbyemail")]
    public Account GetByEmail(string email)
    {
        return _accountService.GetByEmail(email);
    }

    [HttpGet("getbyid")]
    public Account GetById(int id)
    {
        return _accountService.GetById(id);
    }
}