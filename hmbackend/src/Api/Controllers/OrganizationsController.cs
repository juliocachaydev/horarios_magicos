using Api.Features.Organizations;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers;

[ApiController]
[Route("/api/organizations")]
public class OrganizationsController : ControllerBase
{
    private readonly IMediator _mediator;

    public OrganizationsController(
        IMediator mediator)
    {
        _mediator = mediator;
    }
    
    [HttpGet("{organizationId:guid}")]
    public async Task<ActionResult<OrganizationViewModel>> Organization(Guid organizationId)
    {
        var query = new OrganizationsGet()
        {
            OrganizationId = organizationId
        };
        
        var result = await _mediator.Send(query);

        return Ok(result);
    }
}