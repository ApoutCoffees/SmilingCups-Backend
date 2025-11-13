namespace SmilingCup_Backend.Iam.Interfaces.REST.Resources;

public record UserResource(
    int Id,
    int SubscriptionId,
    string FullName,
    string Email,
    long Phone,
    string Address,
    string City,
    string Country,
    bool IsVerified,
    string Type
);