using Microsoft.AspNetCore.Mvc;
using Minder.DTO;
using Minder.Interface;
using Minder.Model;

[ApiController]
[Route("[controller]")]
public class PassionController : ControllerBase
{
    private IPassionService _passionService;

    public PassionController(IPassionService passionService)
    {
        _passionService = passionService;
    }

    [HttpPost("create")]
    public void Create(Passion passion)
    {
        _passionService.Create(passion);
    }

    [HttpPost("update")]
    public Passion Update(Passion passion)
    {
        return _passionService.Update(passion);
    }

    [HttpPost("delete")]
    public void Delete(Passion passion)
    {
        _passionService.Delete(passion);
    }

    [HttpGet("getall")]
    public List<Passion> GetAll()
    {
        return _passionService.GetAll();
    }
    
    [HttpGet]
    public Passion GetByName(string name)
    {
        return _passionService.GetByName(name);
    }
}