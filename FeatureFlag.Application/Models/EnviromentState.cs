namespace FeatureFlag.Contracts.Models;

public class EnvironmentState
{
    public required string Environment { get; init; }
    public required string FlagName { get; init; }
    public required bool IsActive { get; init; } = true;
    public required int Percentage { get; init; } = 100;
}