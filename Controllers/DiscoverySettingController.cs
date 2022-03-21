using Microsoft.AspNetCore.Mvc;
using Minder.DTO;
using Minder.Helper;
using Minder.Interface;
using Minder.Model;

[ApiController]
[Route("[controller]")]
public class DiscoverySettingController : ControllerBase
{
    private readonly IDiscoverySettingService _discoverySettingService;
    private readonly ResponseGeneratorHelper ResponseGeneratorHelper;

    public DiscoverySettingController(IDiscoverySettingService discoverySettingService, ResponseGeneratorHelper _ResponseGeneratorHelper)
    {
        _discoverySettingService = discoverySettingService;
        ResponseGeneratorHelper = _ResponseGeneratorHelper;
    }

    [HttpPost("create")]
    public ActionResult<BaseResponse<DiscoverySetting>> Create(DiscoverySetting discoverySetting)
    {
        return ResponseGeneratorHelper.ResponseGenerator(_discoverySettingService.Create(discoverySetting));
    }

    [HttpPost("update")]
    public ActionResult<BaseResponse<DiscoverySetting>> Update(DiscoverySetting discoverySetting)
    {
        return ResponseGeneratorHelper.ResponseGenerator(_discoverySettingService.Update(discoverySetting));
    }

    [HttpPost("delete")]
    public ActionResult<BaseResponse<string>> Delete(DiscoverySetting discoverySetting)
    {
        return ResponseGeneratorHelper.ResponseGenerator(_discoverySettingService.Delete(discoverySetting));
    }

    [HttpGet]
    public ActionResult<BaseResponse<DiscoverySetting>> FindByUserId(int userId)
    {
        return ResponseGeneratorHelper.ResponseGenerator(_discoverySettingService.FindByUserId(userId));
    }
}