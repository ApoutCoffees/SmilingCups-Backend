using System.Net.Mime;
using Microsoft.AspNetCore.Mvc;
using SmilingCup_Backend.Payment.Domain.Model.Queries;
using SmilingCup_Backend.Payment.Domain.Services;
using SmilingCup_Backend.Payment.Interfaces.Rest.Resources;
using SmilingCup_Backend.Payment.Interfaces.Rest.Transform;
using Swashbuckle.AspNetCore.Annotations;

namespace SmilingCup_Backend.Payment.Interfaces.Rest;

[ApiController]
[Route("api/v1/[controller]")]
[Produces(MediaTypeNames.Application.Json)]
[SwaggerTag("Available Order Endpoints.")]
public class OrdersController(
    IOrderCommandService orderCommandService,
    IOrderQueryService orderQueryService)
    : ControllerBase
{
     [HttpGet("{orderId:int}")]
    [SwaggerOperation("Get Order by Id", "Get a order by its unique identifier.", OperationId = "GetOrderById")]
    [SwaggerResponse(200, "The order was found and returned.", typeof(OrderResource))]
    [SwaggerResponse(404, "The order was not found.")]
    public async Task<IActionResult> GetOrderById(int orderId)
    {
        var getOrderByIdQuery = new GetOrderByIdQuery(orderId);
        var order = await orderQueryService.Handle(getOrderByIdQuery);
        if (order is null) return NotFound();
        var orderResource = OrderResourceFromEntityAssembler.ToResourceFromEntity(order);
        return Ok(orderResource);
    }

    [HttpPost]
    [SwaggerOperation("Create Order", "Create a new order.", OperationId = "CreateOrder")]
    [SwaggerResponse(201, "The order was created.", typeof(OrderResource))]
    [SwaggerResponse(400, "The order was not created.")]
    public async Task<IActionResult> CreateOrder(CreateOrderResource resource)
    {
        var createOrderCommand = CreateOrderCommandFromResourceAssembler.ToCommandFromResource(resource);
        var order = await orderCommandService.Handle(createOrderCommand);
        if (order is null) return BadRequest();
        var orderResource = OrderResourceFromEntityAssembler.ToResourceFromEntity(order);
        return CreatedAtAction(nameof(GetOrderById), new { orderId = order.Id }, orderResource);
    }

    [HttpGet]
    [SwaggerOperation("Get All Orders", "Get all orders.", OperationId = "GetAllOrders")]
    [SwaggerResponse(200, "The orders were found and returned.", typeof(IEnumerable<OrderResource>))]
    [SwaggerResponse(404, "The orders were not found.")]
    public async Task<IActionResult> GetAllOrders()
    {
        var getAllOrdersQuery = new GetAllOrdersQuery();
        var orders = await orderQueryService.Handle(getAllOrdersQuery);
        var orderResources = orders.Select(OrderResourceFromEntityAssembler.ToResourceFromEntity);
        return Ok(orderResources);
    }
    
}