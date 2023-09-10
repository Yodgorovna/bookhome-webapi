using System.Net;

namespace Bookhome.Application.Exception;

public class NotFoundException
{
    public HttpStatusCode StatusCode { get; set; } = HttpStatusCode.NotFound;
    public string TitleMessage { get; protected set; } = string.Empty; 
}
