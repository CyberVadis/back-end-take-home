using FeatureFlag.Application.Models;

namespace FeatureFlag.Application.Repositories;

public interface IFeatureToggleRepository
{
    Task<bool> CreateAsync(FeatureToggle featureTogle, CancellationToken token = default);
    Task<IEnumerable<FeatureToggle>> GetAllAsync(CancellationToken token = default);
    Task<FeatureToggle?> GetByNameAsync(string name, CancellationToken token = default);
    Task<bool> ToggleActivationAsync(Guid id, EnvironmentEnum environment, CancellationToken token = default);
    Task<FeatureToggle?> GetByIdAsync(Guid id, CancellationToken token = default);
    Task<bool> DeleteByIdAsync(Guid id, CancellationToken token = default);
    Task<bool> IsFeatureEnabled(Guid id, EnvironmentEnum environment, CancellationToken token = default);
    Task<bool> SetPartialActivation(int percentage, CancellationToken token = default);
}