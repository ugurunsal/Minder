using Microsoft.AspNetCore.Mvc;
using Minder.DTO;
using Minder.Interface;
using Minder.Model;

[ApiController]
[Route("[controller]")]
public class DiscoverySettingController : ControllerBase
{
    private IDiscoverySettingService _discoverySettingService;

    public DiscoverySettingController(IDiscoverySettingService discoverySettingService)
    {
        _discoverySettingService = discoverySettingService;
    }

    [HttpPost("create")]
    public void Create(DiscoverySetting discoverySetting)
    {
        _discoverySettingService.Create(discoverySetting);
    }

    [HttpPost("update")]
    public DiscoverySetting Update(DiscoverySetting discoverySetting)
    {
        _discoverySettingService.Update(discoverySetting);
        return discoverySetting;
    }

    [HttpPost("delete")]
    public void Delete(DiscoverySetting discoverySetting)
    {
        _discoverySettingService.Delete(discoverySetting);
    }

    [HttpGet]
    public DiscoverySetting FindByUserId(int userId)
    {
        return _discoverySettingService.FindByUserId(userId);
    }
}