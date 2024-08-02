using Microsoft.AspNetCore.Mvc;

namespace NSP.api.Controllers;
[ApiController]
[Route("[controller]")]
public class TestController : ControllerBase
{
    private readonly ILogger<TestController> _logger;

    public TestController(ILogger<TestController> logger)
    {
        _logger = logger;
    }

    [HttpGet(Name = "Get")]
    public async Task<IActionResult> Get()
    {
        return Ok("Ok");
    }
}
