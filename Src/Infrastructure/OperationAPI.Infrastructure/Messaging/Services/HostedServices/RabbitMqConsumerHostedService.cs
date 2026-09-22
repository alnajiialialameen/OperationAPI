using OperationAPI.Infrastructure.Messaging.Interfaces;
using Microsoft.Extensions.Hosting;

namespace OperationAPI.Infrastructure.Messaging.Services.HostedServices
{

    // هو فقط مسؤول عن تشغيل الـ Consumer عند بدء التطبيق.
    public class RabbitMqConsumerHostedService : BackgroundService
    {
        private readonly IRabbitMqMessageConsumer _consumer;

        public RabbitMqConsumerHostedService(IRabbitMqMessageConsumer consumer)
        {
            _consumer = consumer;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            await _consumer.StartAsync(stoppingToken);

            await Task.Delay(Timeout.Infinite, stoppingToken);
        }
    }
}
