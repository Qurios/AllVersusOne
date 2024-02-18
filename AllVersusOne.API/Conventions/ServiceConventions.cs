using AllVersusOne.Services;
using AllVersusOne.Services.GameService;

namespace AllVersusOne.API.Conventions;

public static class ServiceConventions
{

    public static IServiceCollection RegisterServiceConventions(this IServiceCollection serviceCollection, IConfiguration configuration)
    {
        serviceCollection.AddScoped<IUserService, UserService>();
        serviceCollection.AddScoped<IGameService, GameService>();
        serviceCollection.AddScoped<IAnswerService, AnswerService>();

        return serviceCollection;
    }
}