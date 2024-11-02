using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Notes.WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BaseController : ControllerBase
    {
        internal Guid userId => !User.Identity.IsAuthenticated 
                ? Guid.Empty
                : Guid.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));
    }
}
