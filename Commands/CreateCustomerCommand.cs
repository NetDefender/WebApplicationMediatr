using Microsoft.AspNetCore.Http.Features;

namespace WebApplicationMediatr.Commands;
public sealed class CreateCustomerCommand : IRequest<ErrorOr<Customer>>
{
    public Customer Customer
    {
        get;
        set;
    } = null!;
}

public sealed class CreateCustomerCommandHandler : IRequestHandler<CreateCustomerCommand, ErrorOr<Customer>>
{
    private static volatile int s_idCustomer = 0;
    private readonly IHttpContextAccessor _context;

    public CreateCustomerCommandHandler(IHttpContextAccessor context)
    {
        ArgumentNullException.ThrowIfNull(context, nameof(context));
        _context = context!;
    }

    public async Task<ErrorOr<Customer>> Handle(CreateCustomerCommand request, CancellationToken cancellationToken)
    {
        await Task.CompletedTask;
        //Add to Database
        IHttpRequestIdentifierFeature requestFeature = _context.HttpContext!.Features.Get<IHttpRequestIdentifierFeature>()!;
        request.Customer.TraceId = requestFeature.TraceIdentifier;
        request.Customer.Id = ++s_idCustomer;
        return request.Customer;
    }
}
