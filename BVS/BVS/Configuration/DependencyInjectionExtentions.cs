using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BVS.Data.Repositories;
using BVS.Data.Repositories.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace BVS.Configuration
{
    public static class DependencyInjectionExtensions 
    {
        public static IServiceCollection InjectRepositories(this IServiceCollection collection)
        {
            collection.AddScoped<IUserRepository, UserRepository>();
            collection.AddScoped<IWorkerRepository, WorkerRepository>();
            collection.AddScoped<IStorageWorkerRepository, StorageWorkerRepository>();
            return collection;
        }
    }
}
