using SmilingCup_Backend.Iam.Application.Internal.OutboundServices;

namespace SmilingCup_Backend.Iam.Infrastructure.Pipeline.Middleware.Components;

public class RequestAuthorizationMiddleware(RequestDelegate next)
{
    public async Task InvokeAsync(
        HttpContext context, 
        ITokenService tokenService) 
    {
        var allowAnonymous = context.GetEndpoint()?.Metadata
            .Any(m => m.GetType() == typeof(Attributes.AllowAnonymousAttribute));
        
        if (allowAnonymous.HasValue && allowAnonymous.Value)
        {
            await next(context);
            return;
        }

        var token = context.Request.Headers["Authorization"]
            .FirstOrDefault()?.Split(" ").Last();

        if (token == null)
        {
            context.Response.StatusCode = StatusCodes.Status401Unauthorized;
            return;
        }
        
        var userId = await tokenService.ValidateToken(token);

        if (userId == null)
        {
            context.Response.StatusCode = StatusCodes.Status401Unauthorized;
            return;
        }
        context.Items["User"] = userId.Value; 
        
        await next(context);
    }
}