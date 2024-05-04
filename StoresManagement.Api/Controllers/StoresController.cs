using MediatR;
using Microsoft.AspNetCore.Mvc;
using StoresManagement.Application.Stores.CreateStore;
using StoresManagement.Application.Stores.DeleteStore;
using StoresManagement.Application.Stores.GetStore;
using StoresManagement.Application.Stores.ListStores;
using StoresManagement.Application.Stores.UpdateStore;

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

    [HttpGet(Name = "List stores")]
    public async Task<IEnumerable<GetStoreResponse>> List()
        => await mediator.Send(new ListStoresQueryRequest());

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