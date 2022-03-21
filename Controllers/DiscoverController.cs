using Microsoft.AspNetCore.Mvc;
using Minder.DTO;
using Minder.Helper;
using Minder.Interface;
using Minder.Model;

[ApiController]
[Route("[controller]")]
public class DiscoverController : ControllerBase
{
    private readonly IDiscoveryService _discoverService;
    private readonly ResponseGeneratorHelper ResponseGeneratorHelper;

    public DiscoverController(IDiscoveryService discoverService, ResponseGeneratorHelper ResponseGeneratorHelper)
    {
        _discoverService = discoverService;
        this.ResponseGeneratorHelper = ResponseGeneratorHelper;
    }

    [HttpPost]
    public ActionResult<BaseResponse<List<DiscoveryUserDTO>>> Discover([FromQuery]int userId)
    {
        return ResponseGeneratorHelper.ResponseGenerator(_discoverService.Discovery(userId));
    }

    [HttpPost("like")]
    public ActionResult<BaseResponse<DiscoveryUserDTO>> Like([FromQuery] int id,[FromQuery] int like)
    {
        return ResponseGeneratorHelper.ResponseGenerator(_discoverService.Like(id,like));
    }
}