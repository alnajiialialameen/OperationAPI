using OperationAPI.Domain;
using OperationAPI.Infrastructure.Messaging.Configurations;
using OperationAPI.Infrastructure.Messaging.Handlers;
using OperationAPI.Infrastructure.Messaging.Interfaces;
using OperationAPI.Infrastructure.Messaging.Services;
using OperationAPI.Infrastructure.Messaging.Services.HostedServices;
using Infrastructure.Messaging.Handlers;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace OperationAPI.Infrastructure
{
    public static class InfrastructureDI
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services,IConfiguration configuration)
        {
            // RabbitMQ Configuration
            services.Configure<MessageConfiguration>(configuration.GetSection("RabbitMQ"));

            // RabbitMQ Consumer Hosted Service(as Background Service)
            services.AddHostedService<RabbitMqConsumerHostedService>();

            // RabbitMQ Connection
            services.AddSingleton<IRabbitMqConnection, RabbitMqConnection>();

            // Routing Resolver
            services.AddSingleton<IRabbitMqRoutingResolver, RabbitMqMessageResolver>();

            // Message Handler Resolver
            services.AddScoped<IMessageHandlerResolver, MessageHandlerResolver>();

            // RabbitMQ Consumer
            services.AddSingleton<IRabbitMqMessageConsumer, RabbitMqMessageConsumer>();

            // RabbitMQ Topology
            services.AddSingleton<IRabbitMqTopologyInitializer, RabbitMqTopologyInitializer>();

            // Message Handlers
            services.AddScoped<IMessageHandler<AirPortDomain>,AirPortMessageHandler>();
            services.AddScoped<IMessageHandler<AirLineDomain>,AirlineMessageHandler>();

            return services;
        }
    }
}
