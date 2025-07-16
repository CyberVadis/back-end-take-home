namespace FeatureFlag.Contracts.Requests;

public class UpdateFeatureFlagRequest
{
    public required string Name { get; init; }
    public required string Environment { get; init; }
    public required bool IsEnabled { get; init; }
}