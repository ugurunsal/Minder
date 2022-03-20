using Microsoft.AspNetCore.Mvc;
using Minder.Interface;
using Minder.Model;

[ApiController]
[Route("[controller]")]
public class LifeStyleController : ControllerBase
{
    private readonly ILifeStyleService _lifeStyleService;

    public LifeStyleController(ILifeStyleService lifeStyleService)
    {
        _lifeStyleService = lifeStyleService;
    }

    [HttpPost("create")]
    public void Create(LifeStyle lifeStyle)
    {
        _lifeStyleService.Create(lifeStyle);
    }

    [HttpPost("update")]
    public LifeStyle Update(LifeStyle lifeStyle)
    {
        return _lifeStyleService.Update(lifeStyle);
    }

    [HttpPost("delete")]
    public void Delete(LifeStyle lifeStyle)
    {
        _lifeStyleService.Delete(lifeStyle);
    }

    [HttpGet]
    public LifeStyle FindByUserId(int userId)
    {
        return _lifeStyleService.FindByUserId(userId);
    }
}