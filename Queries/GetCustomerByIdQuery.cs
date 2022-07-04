

namespace WebApplicationMediatr.Queries;

public sealed class GetCustomerByIdQuery : IRequest<ErrorOr<Customer>>
{
    public int Id
    {
        get;
        set;
    }
}

public sealed class GetCustomerByIdQueryHandler : IRequestHandler<GetCustomerByIdQuery, ErrorOr<Customer>>
{
    public GetCustomerByIdQueryHandler(IClock clock)
    {
        Clock = clock;
    }

    public IClock Clock
    {
        get;
    }

    public async Task<ErrorOr<Customer>> Handle(GetCustomerByIdQuery request, CancellationToken cancellationToken)
    {
        await Task.CompletedTask;

        return new Customer
        {
            Id = request.Id,
            Name = $"Invent-{Clock.Now}"
        };
    }
}
