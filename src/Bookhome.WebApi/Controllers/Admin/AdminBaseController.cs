using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace Bookhome.WebApi.Controllers.Admin;

//[Authorize(Roles = "Admin, SuperAdmin")]
[AllowAnonymous]
public class AdminBaseController : ControllerBase
{ 

}
