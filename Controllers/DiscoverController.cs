using Microsoft.AspNetCore.Mvc;
using Minder.DTO;
using Minder.Interface;
using Minder.Model;

[ApiController]
[Route("[controller]")]
public class DiscoverController : ControllerBase
{
    private readonly IDiscoveryService _discoverService;

    public DiscoverController(IDiscoveryService discoverService)
    {
        _discoverService = discoverService;
    }

    [HttpPost]
    public List<DiscoveryUserDTO> Discover([FromQuery]int userId)
    {
        return _discoverService.Discovery(userId);
    }

    [HttpPost("like")]
    public DiscoveryUserDTO Like([FromQuery] int id,[FromQuery] int like)
    {
        return _discoverService.Like(id,like);
    }
}