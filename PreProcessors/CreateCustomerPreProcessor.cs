namespace WebApplicationMediatr.PreProcessors;

public class CreateCustomerPreProcessor : IRequestPreProcessor<CreateCustomerCommand>
{
    private readonly IHttpContextAccessor _context;
    private readonly ITenant _tenant;

    public CreateCustomerPreProcessor(IHttpContextAccessor context, ITenant tenant)
    {
        _context = context;
        _tenant = tenant;
    }

    public Task Process(CreateCustomerCommand request, CancellationToken cancellationToken)
    {
        _tenant.Set(Guid.NewGuid());//_context.HttpContext.Request.Query["Id"];
        Console.WriteLine(nameof(CreateCustomerPreProcessor));
        return Task.CompletedTask;
    }
}
