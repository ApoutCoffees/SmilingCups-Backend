using System.Net.Mime;
using Microsoft.AspNetCore.Mvc;
using SmilingCup_Backend.product.domain.model.queries;
using SmilingCup_Backend.product.domain.services;
using SmilingCup_Backend.product.interfaces.rest.resources;
using SmilingCup_Backend.product.interfaces.rest.transform;
using Swashbuckle.AspNetCore.Annotations;

namespace SmilingCup_Backend.product.interfaces.rest;

[ApiController]
[Route("api/v1/[controller]")]
[Produces(MediaTypeNames.Application.Json)]
[SwaggerTag("Available MysteryBox Endpoints.")]
public class MysteryBoxesController(
    IMysteryBoxCommandService mysteryBoxCommandService,
    IMysteryBoxQueryService mysteryBoxQueryService)
    : ControllerBase
{
     [HttpGet("{mysteryBoxId:int}")]
    [SwaggerOperation("Get MysteryBox by Id", "Get a mysteryBox by its unique identifier.", OperationId = "GetMysteryBoxById")]
    [SwaggerResponse(200, "The mysteryBox was found and returned.", typeof(MysteryBoxResource))]
    [SwaggerResponse(404, "The mysteryBox was not found.")]
    public async Task<IActionResult> GetMysteryBoxById(int mysteryBoxId)
    {
        var getMysteryBoxByIdQuery = new GetMysteryBoxByIdQuery(mysteryBoxId);
        var mysteryBox = await mysteryBoxQueryService.Handle(getMysteryBoxByIdQuery);
        if (mysteryBox is null) return NotFound();
        var mysteryBoxResource = MysteryBoxResourceFromEntityAssembler.ToResourceFromEntity(mysteryBox);
        return Ok(mysteryBoxResource);
    }

    [HttpPost]
    [SwaggerOperation("Create MysteryBox", "Create a new mysteryBox.", OperationId = "CreateMysteryBox")]
    [SwaggerResponse(201, "The mysteryBox was created.", typeof(MysteryBoxResource))]
    [SwaggerResponse(400, "The mysteryBox was not created.")]
    public async Task<IActionResult> CreateMysteryBox(CreateMysteryBoxResource resource)
    {
        var createMysteryBoxCommand = CreateMysteryBoxCommandFromResourceAssembler.ToCommandFromResource(resource);
        var mysteryBox = await mysteryBoxCommandService.Handle(createMysteryBoxCommand);
        if (mysteryBox is null) return BadRequest();
        var mysteryBoxResource = MysteryBoxResourceFromEntityAssembler.ToResourceFromEntity(mysteryBox);
        return CreatedAtAction(nameof(GetMysteryBoxById), new { mysteryBoxId = mysteryBox.id }, mysteryBoxResource);
    }

    [HttpGet]
    [SwaggerOperation("Get All MysteryBoxes", "Get all mysteryBoxes.", OperationId = "GetAllMysteryBoxes")]
    [SwaggerResponse(200, "The mysteryBoxes were found and returned.", typeof(IEnumerable<MysteryBoxResource>))]
    [SwaggerResponse(404, "The mysteryBoxes were not found.")]
    public async Task<IActionResult> GetAllMysteryBoxes()
    {
        var getAllMysteryBoxesQuery = new GetAllMysteryBoxesQuery();
        var mysteryBoxes = await mysteryBoxQueryService.Handle(getAllMysteryBoxesQuery);
        var mysteryBoxResources = mysteryBoxes.Select(MysteryBoxResourceFromEntityAssembler.ToResourceFromEntity);
        return Ok(mysteryBoxResources);
    }
    
}