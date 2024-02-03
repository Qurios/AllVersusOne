﻿using AllVersusOne.DataModel.Entities;
using AllVersusOne.Infrastructure.DataAccess;
using AllVersusOne.Infrastructure.Database;
using Microsoft.EntityFrameworkCore;

namespace AllVersusOne.API.Conventions
{
    public static class DatabaseConventions
    {
        public static IServiceCollection RegisterDatabaseConventions(this IServiceCollection serviceCollection, IConfiguration configuration)
        {
            serviceCollection.AddEntityFrameworkSqlite().AddDbContext<DatabaseContext>(options => options.UseSqlite(configuration.GetConnectionString("Database")));
            serviceCollection.AddScoped<IUnitOfWork, UnitOfWork>();
            serviceCollection.AddScoped<IUnitOfWorkManager, UnitOfWorkManager>();

            serviceCollection.AddScoped<IRepository<GameRound>, DatabaseRepository<GameRound>>();
            serviceCollection.AddScoped<IRepository<Guess>, DatabaseRepository<Guess>>();
            serviceCollection.AddScoped<IRepository<Question>, DatabaseRepository<Question>>();
            serviceCollection.AddScoped<IRepository<User>, DatabaseRepository<User>>();

            return serviceCollection;
        }
    }
}