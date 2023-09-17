using System.Net;

namespace Bookhome.Application.Exceptions;

public class TooManyRequestException : ClientException
{
    public override HttpStatusCode StatusCode { get; } = HttpStatusCode.TooManyRequests;
    public override string TitleMessage { get; protected set; } = String.Empty;
}
