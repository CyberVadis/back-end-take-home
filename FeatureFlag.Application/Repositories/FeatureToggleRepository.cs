using FeatureFlag.Application.Models;

namespace FeatureFlag.Application.Repositories;

public class FeatureToggleRepository : IFeatureToggleRepository
{
    private List<FeatureToggle> featureToggles = new()
    {
        new FeatureToggle
        {
            Id = Guid.Parse("11111111-1111-1111-1111-111111111111"),
            Name = "DisabledFeature",
            Description = "Feature completely disabled in all environments",
            EnvironmentStates = new List<EnvironmentState>
            {
                new() { Environment = EnvironmentEnum.Development, IsActive = false, Percentage = 0 },
                new() { Environment = EnvironmentEnum.Staging, IsActive = false, Percentage = 0 },
                new() { Environment = EnvironmentEnum.Production, IsActive = false, Percentage = 0 }
            }
        },

        new FeatureToggle
        {
            Id = Guid.Parse("22222222-2222-2222-2222-222222222222"),
            Name = "EnabledFeature",
            Description = "Feature fully enabled in all environments",
            EnvironmentStates = new List<EnvironmentState>
            {
                new() { Environment = EnvironmentEnum.Development, IsActive = true, Percentage = 100 },
                new() { Environment = EnvironmentEnum.Staging, IsActive = true, Percentage = 100 },
                new() { Environment = EnvironmentEnum.Production, IsActive = true, Percentage = 100 }
            }
        }
    };

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

    public Task<bool> SetPartialActivation(Guid id, EnvironmentEnum environment, int percentage, bool isActive, CancellationToken token = default)
    {
        var featureIndex = featureToggles.FindIndex(x => x.Id == id);
        if (featureIndex == -1)
        {
            return Task.FromResult(false);
        }

        var environmentStates = featureToggles[featureIndex].EnvironmentStates;
        var envIndex = environmentStates.FindIndex(x => x.Environment == environment);
        var envToUpdate = environmentStates[envIndex];
        envToUpdate.Percentage = percentage;
        envToUpdate.IsActive = isActive;
        featureToggles[featureIndex].EnvironmentStates[envIndex] = envToUpdate;
        return Task.FromResult(true);
    }
}