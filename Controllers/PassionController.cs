using Microsoft.AspNetCore.Mvc;
using Minder.DTO;
using Minder.Helper;
using Minder.Interface;
using Minder.Model;

[ApiController]
[Route("[controller]")]
public class PassionController : ControllerBase
{
    private readonly IPassionService _passionService;
    private readonly ResponseGeneratorHelper ResponseGeneratorHelper;

    public PassionController(IPassionService passionService, ResponseGeneratorHelper _ResponseGeneratorHelper)
    {
        _passionService = passionService;
        ResponseGeneratorHelper = _ResponseGeneratorHelper;
    }

    [HttpPost("create")]
    public ActionResult<BaseResponse<Passion>> Create(Passion passion)
    {
        return ResponseGeneratorHelper.ResponseGenerator(_passionService.Create(passion));
    }

    [HttpPost("update")]
    public ActionResult<BaseResponse<Passion>> Update(Passion passion)
    {
        return ResponseGeneratorHelper.ResponseGenerator(_passionService.Update(passion));
    }

    [HttpPost("delete")]
    public ActionResult<BaseResponse<string>> Delete(Passion passion)
    {
        return ResponseGeneratorHelper.ResponseGenerator(_passionService.Delete(passion));
    }

    [HttpGet("getall")]
    public ActionResult<BaseResponse<List<Passion>>> GetAll()
    {
        return ResponseGeneratorHelper.ResponseGenerator(_passionService.GetAll());
    }
    
    [HttpGet]
    public ActionResult<BaseResponse<Passion>> GetByName(string name)
    {
        return ResponseGeneratorHelper.ResponseGenerator(_passionService.GetByName(name));
    }
}