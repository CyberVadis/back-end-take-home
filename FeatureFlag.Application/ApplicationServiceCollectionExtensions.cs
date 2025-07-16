using FeatureFlag.Application.Repositories;
using FeatureFlag.Application.Services;
using Microsoft.Extensions.DependencyInjection;

namespace FeatureFlag.Application;

public static class ApplicationServiceCollectionExtensions
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddSingleton<IFeatureFlagService, FeatureFlagService>();
        services.AddSingleton<IFeatureToggleRepository, FeatureToggleRepository>();
        return services;
    }
}