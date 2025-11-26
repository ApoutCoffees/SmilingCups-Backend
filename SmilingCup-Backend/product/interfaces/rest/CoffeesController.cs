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
[SwaggerTag("Available Coffee Endpoints.")]
public class CoffeesController(
    ICoffeeCommandService coffeeCommandService,
    ICoffeeQueryService coffeeQueryService)
    : ControllerBase
{
     [HttpGet("{coffeeId:int}")]
    [SwaggerOperation("Get Coffee by Id", "Get a coffee by its unique identifier.", OperationId = "GetCoffeeById")]
    [SwaggerResponse(200, "The coffee was found and returned.", typeof(CoffeeResource))]
    [SwaggerResponse(404, "The coffee was not found.")]
    public async Task<IActionResult> GetCoffeeById(int coffeeId)
    {
        var getCoffeeByIdQuery = new GetCoffeeByIdQuery(coffeeId);
        var coffee = await coffeeQueryService.Handle(getCoffeeByIdQuery);
        if (coffee is null) return NotFound();
        var coffeeResource = CoffeeResourceFromEntityAssembler.ToResourceFromEntity(coffee);
        return Ok(coffeeResource);
    }

    [HttpPost]
    [SwaggerOperation("Create Coffee", "Create a new coffee.", OperationId = "CreateCoffee")]
    [SwaggerResponse(201, "The coffee was created.", typeof(CoffeeResource))]
    [SwaggerResponse(400, "The coffee was not created.")]
    public async Task<IActionResult> CreateCoffee(CreateCoffeeResource resource)
    {
        var createCoffeeCommand = CreateCoffeeCommandFromResourceAssembler.ToCommandFromResource(resource);
        var coffee = await coffeeCommandService.Handle(createCoffeeCommand);
        if (coffee is null) return BadRequest();
        var coffeeResource = CoffeeResourceFromEntityAssembler.ToResourceFromEntity(coffee);
        return CreatedAtAction(nameof(GetCoffeeById), new { coffeeId = coffee.id }, coffeeResource);
    }

    [HttpGet]
    [SwaggerOperation("Get All Coffees", "Get all coffees.", OperationId = "GetAllCoffees")]
    [SwaggerResponse(200, "The coffees were found and returned.", typeof(IEnumerable<CoffeeResource>))]
    [SwaggerResponse(404, "The coffees were not found.")]
    public async Task<IActionResult> GetAllCoffees()
    {
        var getAllCoffeesQuery = new GetAllCoffeesQuery();
        var coffees = await coffeeQueryService.Handle(getAllCoffeesQuery);
        var coffeeResources = coffees.Select(CoffeeResourceFromEntityAssembler.ToResourceFromEntity);
        return Ok(coffeeResources);
    }
    
}