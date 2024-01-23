using Microsoft.AspNetCore.Mvc;

namespace CurrentTimeService.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CurrentTimeServiceController : ControllerBase
{
    [HttpGet]
    public ActionResult Get()
    {
        return Ok(new { CreatedDate = DateTime.Now });
    }
}