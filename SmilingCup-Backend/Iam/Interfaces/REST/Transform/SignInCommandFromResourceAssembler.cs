using SmilingCup_Backend.Iam.Domain.Model.Commands;
using SmilingCup_Backend.Iam.Interfaces.REST.Resources;

namespace SmilingCup_Backend.Iam.Interfaces.REST.Transform;

public static class SignInCommandFromResourceAssembler
{
    public static SignInCommand ToCommandFromResource(SignInResource resource)
    {
        return new SignInCommand(resource.Email, resource.Password);
    }
}