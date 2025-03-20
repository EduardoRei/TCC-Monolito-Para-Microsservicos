using RabbitMQ.Client;

namespace RabbitMqConsumer
{
    class Program
    {
        static async Task Main(string[] args)
        {
            try
            {
                var factory = new ConnectionFactory()
                {
                    HostName = "rabbitmq",
                    Port = 5672,
                    UserName = "guest",
                    Password = "guest"
                };

                using var connection = await factory.CreateConnectionAsync();
                using var channel = await connection.CreateChannelAsync();

                var consumerService = new RabbitMqConsumerService(channel);
                await consumerService.SetupConsumers();

                await Task.Delay(Timeout.Infinite);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro: {ex.Message}");
            }
        }
    }
}