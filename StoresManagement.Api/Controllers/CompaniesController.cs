using MediatR;
using Microsoft.AspNetCore.Mvc;
using StoresManagement.Application.CreateCompany;
using StoresManagement.Application.GetCompany;
using StoresManagement.Application.ListCompanies;

namespace StoresManagement.Api.Controllers;

[ApiController]
[Route("api/v1/companies")]
public class CompaniesController(IMediator mediator) : ControllerBase
{
    [HttpPost(Name = "Create company")]
    public async Task<IActionResult> Create([FromBody] CreateCompanyRequest request)
    {
        var result = await mediator.Send(request);

        return result.IsSuccess
            ? Created($"api/v1/companies/{result.Value}", result.Value)
            : BadRequest(result.Errors);
    }

    [HttpGet("{id}", Name = "Get company")]
    public async Task<IActionResult> Get([FromRoute] Guid id)
    {
        var result = await mediator.Send(new GetCompanyQueryRequest(id));

        return result is not null
            ? Ok(result)
            : NotFound();
    }

    [HttpGet(Name = "List companies")]
    public async Task<IEnumerable<GetCompanyResponse>> List()
        => await mediator.Send(new ListCompaniesQueryRequest());
}