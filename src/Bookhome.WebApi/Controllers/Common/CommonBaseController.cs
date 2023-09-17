using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Bookhome.WebApi.Controllers.Common;

[ApiController]
[AllowAnonymous]
public abstract class CommonBaseController : ControllerBase
{
}
