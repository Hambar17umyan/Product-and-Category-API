namespace Application.Common.AppMediator;

/// <summary>
/// Interface for a mediator that handles requests and responses.
/// </summary>
public interface IMediator
{
    /// <summary>
    /// Sends a request and returns a response asynchronously.
    /// </summary>
    /// <typeparam name="TResponse">The response type.</typeparam>
    /// <param name="request">The request.</param>
    /// <param name="cancellationToken">The cancelation token.</param>
    /// <returns>The response.</returns>
    Task<TResponse> SendAsync<TResponse>(IRequest<TResponse> request, CancellationToken cancellationToken = default);
}
