using MediatR;
using Microsoft.AspNetCore.Mvc;
using StoresManagement.Application.Stores.Create;
using StoresManagement.Application.Stores.Delete;
using StoresManagement.Application.Stores.Get;
using StoresManagement.Application.Stores.GetAll;
using StoresManagement.Application.Stores.Update;

namespace StoresManagement.Api.Controllers;

[ApiController]
[Route("api/v1/stores")]
public class StoresController(IMediator mediator) : ControllerBase
{
    [HttpPost(Name = "Create store")]
    public async Task<IActionResult> Create([FromBody] CreateStoreRequest request)
    {
        var result = await mediator.Send(request);

        return result.IsSuccess
            ? Created($"api/v1/stores/{result.Value}", result.Value)
            : BadRequest(result.Errors);
    }

    [HttpGet(Name = "Get all stores")]
    public async Task<IEnumerable<GetStoreResponse>> GetAll()
        => await mediator.Send(new GetAllStoresQueryRequest());

    [HttpGet("{id}", Name = "Get store")]
    public async Task<IActionResult> Get([FromRoute] Guid id)
    {
        var result = await mediator.Send(new GetStoreQueryRequest(id));

        return result is not null
            ? Ok(result)
            : NotFound();
    }

    [HttpPut("{id}", Name = "Update store")]
    public async Task<IActionResult> Create([FromRoute] Guid id, [FromBody] UpdateStoreRequest request)
    {
        var result = await mediator.Send(request with { Id = id });

        return result.IsFailed
            ? result.HasError(e => e.Message == "NotFound")
                ? NotFound()
                : BadRequest(result.Errors)
            : Accepted();
    }

    [HttpDelete("{id}", Name = "Delete store")]
    public async Task<IActionResult> Delete([FromRoute] Guid id)
    {
        await mediator.Send(new DeleteStoreRequest(id));

        return NoContent();
    }
}