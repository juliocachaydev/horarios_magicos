using Alpaca;
using MediatR;

namespace Application.Tests.TestCommon;

public static class TestMediatorExtensions
{
    //Task<TResponse> Send<TResponse>(IRequest<TResponse> request, CancellationToken cancellationToken = default);
    public static async Task<TResponse> SendRequest<TResponse>(this CustomApplicationFactory application,
        IRequest<TResponse> request)
    {
        using var scope = application.GetService(out IMediator mediator);

        return await mediator.Send(request);
    }
    
    public static async Task SendRequest<TRequest>(this CustomApplicationFactory application,
        TRequest request) where TRequest : IRequest
    {
        using var scope = application.GetService(out IMediator mediator);

        await mediator.Send(request);
    }
}