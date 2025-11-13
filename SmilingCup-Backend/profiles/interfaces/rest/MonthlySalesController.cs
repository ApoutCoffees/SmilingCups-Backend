using System.Net.Mime;
using Microsoft.AspNetCore.Mvc;
using SmilingCup_Backend.profiles.domain.model.queries;
using SmilingCup_Backend.profiles.domain.services;
using SmilingCup_Backend.profiles.interfaces.rest.resources;
using SmilingCup_Backend.profiles.interfaces.rest.transform;
using Swashbuckle.AspNetCore.Annotations;

namespace SmilingCup_Backend.profiles.interfaces.rest;


[ApiController]
[Route("api/v1/[controller]")]
[Produces(MediaTypeNames.Application.Json)]
[SwaggerTag("Available Monthly Sale Endpoints.")]
public class MonthlySalesController(
    IMonthlySaleCommandService monthlySaleCommandService,
    IMonthlySaleQueryService monthlySaleQueryService)
    : ControllerBase
{
     [HttpGet("{monthlySaleId:int}")]
    [SwaggerOperation("Get MonthlySale by Id", "Get a monthlySale by its unique identifier.", OperationId = "GetMonthlySaleById")]
    [SwaggerResponse(200, "The monthlySale was found and returned.", typeof(MonthlySaleResource))]
    [SwaggerResponse(404, "The monthlySale was not found.")]
    public async Task<IActionResult> GetMonthlySaleById(int monthlySaleId)
    {
        var getMonthlySaleByIdQuery = new GetMonthlySaleByIdQuery(monthlySaleId);
        var monthlySale = await monthlySaleQueryService.Handle(getMonthlySaleByIdQuery);
        if (monthlySale is null) return NotFound();
        var monthlySaleResource = MonthlySaleResourceFromEntityAssembler.ToResourceFromEntity(monthlySale);
        return Ok(monthlySaleResource);
    }

    [HttpPost]
    [SwaggerOperation("Create MonthlySale", "Create a new monthlySale.", OperationId = "CreateMonthlySale")]
    [SwaggerResponse(201, "The monthlySale was created.", typeof(MonthlySaleResource))]
    [SwaggerResponse(400, "The monthlySale was not created.")]
    public async Task<IActionResult> CreateMonthlySale(CreateMonthlySaleResource resource)
    {
        var createMonthlySaleCommand = CreateMonthlySaleCommandFromResourceAssembler.ToCommandFromResource(resource);
        var monthlySale = await monthlySaleCommandService.Handle(createMonthlySaleCommand);
        if (monthlySale is null) return BadRequest();
        var monthlySaleResource = MonthlySaleResourceFromEntityAssembler.ToResourceFromEntity(monthlySale);
        return CreatedAtAction(nameof(GetMonthlySaleById), new { monthlySaleId = monthlySale.id }, monthlySaleResource);
    }

    [HttpGet]
    [SwaggerOperation("Get All MonthlySales", "Get all monthlySales.", OperationId = "GetAllMonthlySales")]
    [SwaggerResponse(200, "The monthlySales were found and returned.", typeof(IEnumerable<MonthlySaleResource>))]
    [SwaggerResponse(404, "The monthlySales were not found.")]
    public async Task<IActionResult> GetAllMonthlySales()
    {
        var getAllMonthlySalesQuery = new GetAllMonthlySalesQuery();
        var monthlySales = await monthlySaleQueryService.Handle(getAllMonthlySalesQuery);
        var monthlySaleResources = monthlySales.Select(MonthlySaleResourceFromEntityAssembler.ToResourceFromEntity);
        return Ok(monthlySaleResources);
    }
    
}