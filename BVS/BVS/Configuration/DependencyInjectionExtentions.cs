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
            collection.AddScoped<IATM_Repository, ATM_Repository>();
            collection.AddScoped<IJobRepository, JobRepository>();
            collection.AddScoped<IUserReportRepository, UserReportRepository>();
            collection.AddScoped<IMessageRepository, MessageRepository>();
            collection.AddScoped<ISubscriptionRepository, SubscriptionRepository>();
            collection.AddScoped<IPartRepository, PartRepository>();
            collection.AddScoped<IOrderRepository, OrderRepository>();
            return collection;
        }
    }
}