using BitsPilani.CourseToCartPublisher.BL.Interfaces;
using BitsPilani.CourseToCartPublisher.Common.UnitOfWork;
using BitsPilani.CourseToCartPublisher.DB.Constant;
using BitsPilani.RabbitMQMessageBroker;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using RabbitMQ.Client;
using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.Text;

namespace BitsPilani.CourseToCartPublisher.DB
{
    public static class DIDB
    {
        public static IServiceCollection AddDB(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddSingleton<IConfigConstants, ConfigConstants>();
            services.AddTransient<IUnitOfWork>(uof => new UnitOfWork.UnitOfWork(ConnectionMultiplexer.Connect(ConfigurationOptions.Parse(uof.GetService<IConfigConstants>().RedisConnection, true)).GetDatabase()));
            services.AddSingleton<IRabbitMQConnectionProvider>(sp =>
            {
                var factory = new ConnectionFactory()
                {
                    HostName = configuration["EventBus:HostName"]
                };

                if (!string.IsNullOrEmpty(configuration["EventBus:UserName"]))
                {
                    factory.UserName = configuration["EventBus:UserName"];
                }

                if (!string.IsNullOrEmpty(configuration["EventBus:Password"]))
                {
                    factory.Password = configuration["EventBus:Password"];
                }

                return new RabbitMQConnectionProvider(factory);
            });

            services.AddSingleton<RabbitMQProducer>();
            return services;
        }
    }
}
