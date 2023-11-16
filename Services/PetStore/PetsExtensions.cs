using PetStore;

namespace PetsSample.Services.PetStore;

public static class PetsExtensions
{
    public static IServiceCollection AddPetStoreApiClient(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddOptions<Options.PetStore>()
            .Bind(configuration.GetSection(nameof(Options.PetStore)))
            .ValidateDataAnnotations()
            .ValidateOnStart();

        var config = configuration.GetSection(nameof(Options.PetStore)).Get<Options.PetStore>();

        services.AddHttpClient<PetStoreApiClient>(client =>
        {
            client.BaseAddress = new Uri(config.BaseAddress);
        })
        .SetHandlerLifetime(TimeSpan.FromMinutes(5));

        return services;

    }

}
