namespace SmilingCup_Backend.Iam.Interfaces.REST.Resources;

public record AuthenticatedUserResource(
    int Id,
    string FullName,
    string Email,
    string Token
);