namespace Application.Common.AppMediator;

/// <summary>
/// Interface for a request handler.
/// </summary>
/// <typeparam name="TRequest">The type of the request.</typeparam>
/// <typeparam name="TResponse">The type of the response.</typeparam>
public interface IRequestHandler<TRequest, TResponse>
    where TRequest : IRequest<TResponse>
{
    /// <summary>
    /// Handles the request asynchronously and returns a response.
    /// </summary>
    /// <param name="request">The request.</param>
    /// <param name="cancellationToken">The cancellatiion token.</param>
    /// <returns></returns>
    Task<TResponse> HandleAsync(TRequest request, CancellationToken cancellationToken);
}