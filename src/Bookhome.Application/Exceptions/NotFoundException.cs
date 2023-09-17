using Bookhome.Application.Exceptions;
using System.Net;

namespace Bookhome.Application.Exceptions;

public class NotFoundException : ClientException
{
    public override HttpStatusCode StatusCode { get; } = HttpStatusCode.NotFound;

    public override string TitleMessage { get; protected set; } = String.Empty;
}

