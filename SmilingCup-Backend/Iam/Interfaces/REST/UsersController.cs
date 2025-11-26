using System.Net.Mime;
using Microsoft.AspNetCore.Mvc;
using SmilingCup_Backend.Iam.Domain.Services;
using SmilingCup_Backend.Iam.Infrastructure.Pipeline.Middleware.Attributes; // Para [Authorize]
using SmilingCup_Backend.Iam.Interfaces.REST.Transform;

namespace SmilingCup_Backend.Iam.Interfaces.REST;

[ApiController]
[Route("api/v1/users")]
[Produces(MediaTypeNames.Application.Json)]
[Authorize] 
public class UsersController(IUserQueryService userQueryService) : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> GetAllUsers()
    {
        var query = new Domain.Model.Queries.GetAllUsersQuery();
        var users = await userQueryService.Handle(query);
        var resources = users.Select(UserResourceFromEntityAssembler.ToResourceFromEntity);
        return Ok(resources);
    }
    [HttpGet("{id}")]
    public async Task<IActionResult> GetUserById(int id)
    {
        var query = new Domain.Model.Queries.GetUserByIdQuery(id);
        var user = await userQueryService.Handle(query);
        if (user == null) return NotFound();
        var resource = UserResourceFromEntityAssembler.ToResourceFromEntity(user);
        return Ok(resource);
    }
}