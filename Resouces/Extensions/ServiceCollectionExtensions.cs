using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Polly;
using Resouces.Configuration;
using StackExchange.Redis;

namespace Resouces.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static void AddPolly(this IServiceCollection service)
        {
            service.AddHttpClient("GenericPolly").AddTransientHttpErrorPolicy(policy => policy.WaitAndRetryAsync(retryCount: 3, sleepDurationProvider: attempt => TimeSpan
            .FromSeconds(Math.Pow(2, attempt)),
            onRetry: (outcome, delay, attempt, context) =>
            {
                Console.WriteLine($"Tentativa {attempt} falhou. Retentando em {delay.TotalSeconds}s...");
            })).AddTransientHttpErrorPolicy(policy =>
                    policy.CircuitBreakerAsync(
                        handledEventsAllowedBeforeBreaking: 2,
                        durationOfBreak: TimeSpan.FromSeconds(30)
            ));
        }

        public static void AddRabbit(this IServiceCollection service, IConfiguration configuration)
        {
            service.Configure<RabbitMqConfig>(configuration.GetSection("RabbitMqSettings"));
            service.AddSingleton(r => 
            {
                var config = r.GetRequiredService<IOptions<RabbitMqConfig>>().Value;
                return new RabbitMQ.Client.ConnectionFactory
                {
                    Port = config.Port,
                    UserName = config.UserName,
                    Password = config.Password,
                    HostName = config.HostName
                };
            });
        }

        public static void AddRedis(this IServiceCollection service, IConfiguration configuration)
        {
            service.AddSingleton<IConnectionMultiplexer>(s => 
            { 
                string RedisConnection = configuration.GetSection("Redis;Connection").Value;
                return ConnectionMultiplexer.Connect(RedisConnection);
            });
        }
    }
}
