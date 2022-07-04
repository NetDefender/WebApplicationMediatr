namespace WebApplicationMediatr.Behaviours;

public sealed class CreateCustomerBehaviour : IPipelineBehavior<CreateCustomerCommand, ErrorOr<Customer>>
{
    public async Task<ErrorOr<Customer>> Handle(CreateCustomerCommand request, CancellationToken cancellationToken, RequestHandlerDelegate<ErrorOr<Customer>> next)
    {
        return await next();
    }
}
