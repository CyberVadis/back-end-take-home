namespace FeatureFlag.Application.Models;

public class FeatureToggle
{
    public Guid Id { get; init; }
    public required string Name { get; init; }
    public required string Description { get; init; }
    //public required string DeveloperOwner { get; set; }
    public DateTime CreatedAt { get; set; }
}