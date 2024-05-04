using MediatR;
using Microsoft.AspNetCore.Mvc;
using StoresManagement.Application.CreateStore;

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

    //[HttpGet("{id}", Name = "Get")]
    //public async Task<IActionResult> Get([FromRoute] Guid id)
    //{
    //    var result = await mediator.Send(new GetCompanyQueryRequest(id));

    //    return result is not null
    //        ? Ok(result)
    //        : NotFound();
    //}

    //[HttpGet(Name = "List")]
    //public async Task<IEnumerable<GetCompanyResponse>> List()
    //    => await mediator.Send(new ListCompaniesQueryRequest());
}