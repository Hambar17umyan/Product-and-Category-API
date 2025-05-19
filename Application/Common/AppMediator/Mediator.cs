namespace Application.Common.AppMediator;

using Microsoft.Extensions.DependencyInjection;

/// <summary>
/// Mediator class that implements the IMediator interface.
/// </summary>
public class Mediator : IMediator
{
    /// <summary>
    /// The service scope factory used to create a scope for resolving dependencies.
    /// </summary>
    private readonly IServiceScopeFactory _scopeFactory;

    /// <summary>
    /// Initializes a new instance of the <see cref="Mediator"/> class.
    /// </summary>
    /// <param name="scopeFactory">The scope factory.</param>
    public Mediator(IServiceScopeFactory scopeFactory)
    {
        this._scopeFactory = scopeFactory;
    }

    /// <summary>
    /// Sends a request and returns a response asynchronously.
    /// </summary>
    /// <typeparam name="TResponse">The type of response.</typeparam>
    /// <param name="request">The request.</param>
    /// <param name="cancellationToken">The cancellation token.</param>
    /// <returns>The response.</returns>
    /// <exception cref="InvalidOperationException"></exception>
    public async Task<TResponse> SendAsync<TResponse>(IRequest<TResponse> request, CancellationToken cancellationToken = default)
    {
        using var scope = this._scopeFactory.CreateScope();

        var handlerType = typeof(IRequestHandler<,>).MakeGenericType(request.GetType(), typeof(TResponse));
        var handler = scope.ServiceProvider.GetService(handlerType);

        if (handler == null)
            throw new InvalidOperationException($"Handler not registered for {request.GetType().Name}");

        var method = handlerType.GetMethod("HandleAsync");
        var resultTask = (Task<TResponse>)method!.Invoke(handler, new object[] { request, cancellationToken })!;
        return await resultTask;
    }
}
