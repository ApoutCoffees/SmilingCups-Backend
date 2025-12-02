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
[SwaggerTag("Available Subscription Endpoints.")]
public class SubscriptionsController(
    ISubscriptionCommandService subscriptionCommandService,
    ISubscriptionQueryService subscriptionQueryService)
    : ControllerBase
{
     [HttpGet("{subscriptionId:int}")]
    [SwaggerOperation("Get Subscription by Id", "Get a subscription by its unique identifier.", OperationId = "GetSubscriptionById")]
    [SwaggerResponse(200, "The subscription was found and returned.", typeof(SubscriptionResource))]
    [SwaggerResponse(404, "The subscription was not found.")]
    public async Task<IActionResult> GetSubscriptionById(int subscriptionId)
    {
        var getSubscriptionByIdQuery = new GetSubscriptionByIdQuery(subscriptionId);
        var subscription = await subscriptionQueryService.Handle(getSubscriptionByIdQuery);
        if (subscription is null) return NotFound();
        var subscriptionResource = SubscriptionResourceFromEntityAssembler.ToResourceFromEntity(subscription);
        return Ok(subscriptionResource);
    }

    [HttpPost]
    [SwaggerOperation("Create Subscription", "Create a new subscription.", OperationId = "CreateSubscription")]
    [SwaggerResponse(201, "The subscription was created.", typeof(SubscriptionResource))]
    [SwaggerResponse(400, "The subscription was not created.")]
    public async Task<IActionResult> CreateSubscription([FromBody] CreateSubscriptionResource resource)
    {
        var createSubscriptionCommand = CreateSubscriptionCommandFromResourceAssembler.ToCommandFromResource(resource);
        var subscription = await subscriptionCommandService.Handle(createSubscriptionCommand);
        if (subscription is null) return BadRequest();
        var subscriptionResource = SubscriptionResourceFromEntityAssembler.ToResourceFromEntity(subscription);
        return CreatedAtAction(nameof(GetSubscriptionById), new { subscriptionId = subscription.Id }, subscriptionResource);
    }

    [HttpGet]
    [SwaggerOperation("Get All Subscriptions", "Get all subscriptions.", OperationId = "GetAllSubscriptions")]
    [SwaggerResponse(200, "The subscriptions were found and returned.", typeof(IEnumerable<SubscriptionResource>))]
    [SwaggerResponse(404, "The subscriptions were not found.")]
    public async Task<IActionResult> GetAllSubscriptions()
    {
        var getAllSubscriptionsQuery = new GetAllSubscriptionsQuery();
        var subscriptions = await subscriptionQueryService.Handle(getAllSubscriptionsQuery);
        var subscriptionResources = subscriptions.Select(SubscriptionResourceFromEntityAssembler.ToResourceFromEntity);
        return Ok(subscriptionResources);
    }
    
}