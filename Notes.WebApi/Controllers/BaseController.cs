using Microsoft.AspNetCore.Mvc;

namespace Notes.WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BaseController : ControllerBase
    {
        internal Guid userId => new Guid(User.FindFirst("userId").Value);
    }
}
