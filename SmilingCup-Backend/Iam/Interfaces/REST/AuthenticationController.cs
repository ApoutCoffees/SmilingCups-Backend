using SmilingCup_Backend.Iam.Domain.Services;
using SmilingCup_Backend.Iam.Infrastructure.Pipeline.Middleware.Attributes; 
using SmilingCup_Backend.Iam.Interfaces.REST.Resources;
using SmilingCup_Backend.Iam.Interfaces.REST.Transform;
using Microsoft.AspNetCore.Mvc;
using System.Net.Mime;

namespace SmilingCup_Backend.Iam.Interfaces.REST;

[ApiController]
[Route("api/v1/authentication")]
[Produces(MediaTypeNames.Application.Json)]
public class AuthenticationController(IUserCommandService userCommandService) : ControllerBase
{
    [HttpPost("sign-up")]
    [AllowAnonymous]
    public async Task<IActionResult> SignUp([FromBody] SignUpResource resource)
    {
        var command = SignUpCommandFromResourceAssembler.ToCommandFromResource(resource);
        
        await userCommandService.Handle(command);
        
        return StatusCode(201, new { message = "User created successfully" });
    }
    
    [HttpPost("sign-in")]
    [AllowAnonymous]
    public async Task<IActionResult> SignIn([FromBody] SignInResource resource)
    {
        var command = SignInCommandFromResourceAssembler.ToCommandFromResource(resource);
        
        var (user, token) = await userCommandService.Handle(command);
        
        var responseResource = AuthenticatedUserResourceFromEntityAssembler.ToResourceFromEntity(user, token);
        
        return Ok(responseResource);
    }
}