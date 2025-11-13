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
[SwaggerTag("Available Producer Stat Endpoints.")]
public class ProducerStatsController(
    IProducerStatCommandService producerStatCommandService,
    IProducerStatQueryService producerStatQueryService)
    : ControllerBase
{
     [HttpGet("{producerStatId:int}")]
    [SwaggerOperation("Get ProducerStat by Id", "Get a producerStat by its unique identifier.", OperationId = "GetProducerStatById")]
    [SwaggerResponse(200, "The producerStat was found and returned.", typeof(ProducerStatResource))]
    [SwaggerResponse(404, "The producerStat was not found.")]
    public async Task<IActionResult> GetProducerStatById(int producerStatId)
    {
        var getProducerStatByIdQuery = new GetProducerStatByIdQuery(producerStatId);
        var producerStat = await producerStatQueryService.Handle(getProducerStatByIdQuery);
        if (producerStat is null) return NotFound();
        var producerStatResource = ProducerStatResourceFromEntityAssembler.ToResourceFromEntity(producerStat);
        return Ok(producerStatResource);
    }

    [HttpPost]
    [SwaggerOperation("Create ProducerStat", "Create a new producerStat.", OperationId = "CreateProducerStat")]
    [SwaggerResponse(201, "The producerStat was created.", typeof(ProducerStatResource))]
    [SwaggerResponse(400, "The producerStat was not created.")]
    public async Task<IActionResult> CreateProducerStat(CreateProducerStatResource resource)
    {
        var createProducerStatCommand = CreateProducerStatCommandFromResourceAssembler.ToCommandFromResource(resource);
        var producerStat = await producerStatCommandService.Handle(createProducerStatCommand);
        if (producerStat is null) return BadRequest();
        var producerStatResource = ProducerStatResourceFromEntityAssembler.ToResourceFromEntity(producerStat);
        return CreatedAtAction(nameof(GetProducerStatById), new { producerStatId = producerStat.id }, producerStatResource);
    }

    [HttpGet]
    [SwaggerOperation("Get All ProducerStats", "Get all producerStats.", OperationId = "GetAllProducerStats")]
    [SwaggerResponse(200, "The producerStats were found and returned.", typeof(IEnumerable<ProducerStatResource>))]
    [SwaggerResponse(404, "The producerStats were not found.")]
    public async Task<IActionResult> GetAllProducerStats()
    {
        var getAllProducerStatsQuery = new GetAllProducerStatsQuery();
        var producerStats = await producerStatQueryService.Handle(getAllProducerStatsQuery);
        var producerStatResources = producerStats.Select(ProducerStatResourceFromEntityAssembler.ToResourceFromEntity);
        return Ok(producerStatResources);
    }
    
}