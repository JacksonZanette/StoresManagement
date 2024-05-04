using MediatR;
using Microsoft.AspNetCore.Mvc;
using StoresManagement.Application.CreateCompany;
using StoresManagement.Application.ListCompanies;

namespace StoresManagement.Api.Controllers;

[ApiController]
[Route("api/v1/companies")]
public class CompaniesController(IMediator mediator) : ControllerBase
{
    [HttpPost(Name = "Create")]
    public async Task<IActionResult> Create([FromBody] CreateCompanyRequest request)
    {
        var result = await mediator.Send(request);

        return result.IsSuccess
            ? Created($"api/v1/companies/{result.Value}", result.Value)
            : BadRequest(result.Errors);
    }

    //[HttpGet("{id}", Name = "Get")]
    //public async Task<IActionResult> Get([FromRoute] Guid id)
    //{
    //    var result = await mediator.Send(new GetProductQuery(id));

    //    return result is not null
    //        ? Ok(result)
    //        : NotFound();
    //}

    [HttpGet(Name = "List")]
    public async Task<IEnumerable<CompanyResponseDto>> List()
        => await mediator.Send(new ListCompaniesQueryRequest());

    //[HttpPut("{id}", Name = "Update")]
    //public async Task<IActionResult> Create([FromRoute] Guid id, [FromBody] UpdateProductCommand command)
    //{
    //    var result = await mediator.Send(command with { Id = id });

    //    return result.IsFailed
    //        ? result.HasError(e => e.Message == "NotFound")
    //            ? NotFound()
    //            : BadRequest(result.Errors)
    //        : Accepted();
    //}

    //[HttpDelete("{id}", Name = "Delete")]
    //public async Task<IActionResult> Delete([FromRoute] Guid id)
    //{
    //    await mediator.Send(new DeleteProductCommand(id));

    //    return NoContent();
    //}
}