using FeatureFlag.Application.Models;
using FeatureFlag.Application.Repositories;

namespace FeatureFlag.Application.Services;

public class FeatureFlagService(IFeatureToggleRepository _featureToggleRepository) : IFeatureFlagService
{
    public Task<bool> CreateAsync(
        FeatureToggle featureToogle,
        CancellationToken token = default)
    {
        return _featureToggleRepository.CreateAsync(featureToogle, token);         
    }

    public Task<bool> DeleteByIdAsync(Guid id, CancellationToken token = default)
    {
        return _featureToggleRepository.DeleteByIdAsync(id, token);
    }

    public Task<IEnumerable<FeatureToggle>> GetAllAsync(CancellationToken token = default)
    {
        return _featureToggleRepository.GetAllAsync(token);
    }

    public async Task<FeatureToggle?> GetByIdOrNameAsync(string idOrName, CancellationToken token = default)
    {
        var featureFlag = Guid.TryParse(idOrName, out var id)
            ? await _featureToggleRepository.GetByIdAsync(id, token)
            : await _featureToggleRepository.GetByNameAsync(idOrName, token);
        if (featureFlag is not null)
        { 
            //TODO: Get data from the EnvRepository
            //featureFlag.EnvironmentStates = Repo;
        }
        return featureFlag;
    }

    public Task<FeatureToggle?> ToggleActivationAsync(Guid id, EnvironmentEnum environment, CancellationToken token = default)
    {
        var result = _featureToggleRepository.ToggleActivationAsync(id, environment, token);
        return _featureToggleRepository.GetByIdAsync(id);
    }

    public Task<bool> IsFeatureEnabled(Guid id, EnvironmentEnum environment, CancellationToken token = default)
    {
        return _featureToggleRepository.IsFeatureEnabled(id, environment, token);
    }

    public Task<bool> SetPartialActivation(Guid id, EnvironmentEnum environment, int percentage, CancellationToken token = default)
    {
        throw new NotImplementedException();
    }
}