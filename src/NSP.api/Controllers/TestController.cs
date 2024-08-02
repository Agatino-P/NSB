using Microsoft.AspNetCore.Mvc;

namespace NSP.api.Controllers;
[ApiController]
[Route("[controller]")]
public class TestController : ControllerBase
{
    private readonly IMessageSession messageSession;
    private readonly ILogger<TestController> logger;

    public TestController(IMessageSession messageSession, ILogger<TestController> logger)
    {
        this.messageSession = messageSession;
        this.logger = logger;
    }

    [HttpGet(Name = "Get")]
    public async Task<IActionResult> Get(string text)
    {
        await messageSession.SendLocal(new ApiCommand(  text));
        return Ok("Ok");
    }
}
