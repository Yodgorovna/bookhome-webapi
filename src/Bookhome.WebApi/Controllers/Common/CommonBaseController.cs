using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Bookhome.WebApi.Controllers.Common
{
    [AllowAnonymous]
    public class CommonBaseController : ControllerBase
    {
    }
}
