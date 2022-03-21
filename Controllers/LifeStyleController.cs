using Microsoft.AspNetCore.Mvc;
using Minder.DTO;
using Minder.Helper;
using Minder.Interface;
using Minder.Model;

[ApiController]
[Route("[controller]")]
public class LifeStyleController : ControllerBase
{
    private readonly ILifeStyleService _lifeStyleService;
    private readonly ResponseGeneratorHelper ResponseGeneratorHelper;

    public LifeStyleController(ILifeStyleService lifeStyleService, ResponseGeneratorHelper _ResponseGeneratorHelper)
    {
        _lifeStyleService = lifeStyleService;
        ResponseGeneratorHelper = _ResponseGeneratorHelper;
    }

    [HttpPost("create")]
    public ActionResult<BaseResponse<LifeStyle>> Create(LifeStyle lifeStyle)
    {
        return ResponseGeneratorHelper.ResponseGenerator(_lifeStyleService.Create(lifeStyle));
    }

    [HttpPost("update")]
    public ActionResult<BaseResponse<LifeStyle>> Update(LifeStyle lifeStyle)
    {
        return ResponseGeneratorHelper.ResponseGenerator(_lifeStyleService.Update(lifeStyle));
    }

    [HttpPost("delete")]
    public ActionResult<BaseResponse<string>> Delete(LifeStyle lifeStyle)
    {
        return ResponseGeneratorHelper.ResponseGenerator(_lifeStyleService.Delete(lifeStyle));
    }

    [HttpGet]
    public ActionResult<BaseResponse<LifeStyle>> FindByUserId(int userId)
    {
        return ResponseGeneratorHelper.ResponseGenerator(_lifeStyleService.FindByUserId(userId));
    }
}