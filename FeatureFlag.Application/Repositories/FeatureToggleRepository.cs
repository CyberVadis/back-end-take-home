using FeatureFlag.Application.Models;

namespace FeatureFlag.Application.Repositories;

public class FeatureToggleRepository : IFeatureToggleRepository
{
    private List<FeatureToggle> featureToggles = new();
    public Task<bool> CreateAsync(FeatureToggle featureToggle, CancellationToken token = default)
    {
        featureToggles.Add(featureToggle);
        return Task.FromResult(true);
    }

    public Task<bool> DeleteByIdAsync(Guid id, CancellationToken token = default)
    {
        var removed = featureToggles.RemoveAll(f=>f.Id == id);
        return Task.FromResult(removed > 0);
    }

    public Task<IEnumerable<FeatureToggle>> GetAllAsync(CancellationToken token = default)
    {
        return Task.FromResult(featureToggles.AsEnumerable());
    }

    public Task<FeatureToggle?> GetByIdAsync(Guid id, CancellationToken token = default)
    {
        var toogle = featureToggles.SingleOrDefault(f => f.Id == id);
        return Task.FromResult(toogle);
    }

    public Task<FeatureToggle?> GetByNameAsync(string name, CancellationToken token = default)
    {
        var toogle = featureToggles.SingleOrDefault(f => f.Name == name);
        return Task.FromResult(toogle);
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