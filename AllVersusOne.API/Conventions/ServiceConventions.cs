using AllVersusOne.DataModel.Entities;
using AllVersusOne.Infrastructure.DataAccess;
using AllVersusOne.Infrastructure.Database;
using AllVersusOne.Services;
using AllVersusOne.Services.GameService;
using Microsoft.EntityFrameworkCore;

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