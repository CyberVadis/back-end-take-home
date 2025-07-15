namespace FeatureFlag.Application.Services;

public interface IFeatureFlagService
{
    Task<bool> CreateAsync(CancellationToken token = default);
    Task<IEnumerable<FeatureFlag>> GetAllAsync(CancellationToken token = default);
    Task<FeatureFlag?> GetByNameAsync(string name, CancellationToken token = default);
    Task<FeatureFlag?> ToggleActivationAsync(CancellationToken token = default);
    Task<bool> DeleteByIdAsync(Guid id, CancellationToken token = default);
    Task<bool> IsFeatureEnabled(Guid id, CancellationToken token = default);
    Task<bool> SetRolloutPercentage(int percentage, CancellationToken token = default);
}