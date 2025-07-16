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
        throw new NotImplementedException();
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
        return featureFlag;
    }

    public Task<bool> IsFeatureEnabled(Guid id, CancellationToken token = default)
    {
        throw new NotImplementedException();
    }

    public Task<bool> SetPartialActivation(int percentage, CancellationToken token = default)
    {
        throw new NotImplementedException();
    }

    public Task<FeatureToggle?> ToggleActivationAsync(CancellationToken token = default)
    {
        throw new NotImplementedException();
    }
}