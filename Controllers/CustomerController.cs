using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace WebApplicationMediatr.Controllers;

[ApiController]
[Route("[controller]")]
public class CustomerController : ControllerBase
{
    private readonly ILogger<CustomerController> _logger;
    private readonly IMediator _mediator;

    public CustomerController(ILogger<CustomerController> logger, IMediator mediator)
    {
        _logger = logger;
        _mediator = mediator;
    }

    [HttpGet("get-by-id")]
    public async Task<IActionResult> GetCustomerById([FromQuery] GetCustomerByIdQuery query)
    {
        return (await _mediator.Send(query))
            .MatchFirst(customer => Ok(customer),
            error => Problem(error.Description, statusCode: (int)HttpStatusCode.Conflict));
    }

    [HttpPost("create")]
    public async Task<IActionResult> CreateCustomer([FromBody] CreateCustomerCommand command)
    {
        return (await _mediator.Send(command))
            .MatchFirst(customer => Created(new Uri($"/customer/get-by-id/{customer.Id}", UriKind.Relative),customer),
            error => Problem(error.Description, statusCode: (int)HttpStatusCode.Conflict));
    }
}