using System.Net;

namespace TodoList.Services.Exceptions;

public abstract class CustomException : Exception
{
    public HttpStatusCode ResponseStatusCode { get; }

    protected CustomException(string message, HttpStatusCode responseStatusCode) : base(message)
    {
        ResponseStatusCode = responseStatusCode;
    }
}