using Ecommerce.Commons.Enums;
using Newtonsoft.Json;
using RabbitMQ.Client;
using System.Text;

namespace Ecommerce.Commons.RabbitMq.Producer
{
    public class RabbitMQProducer : IMessageProducer, IAsyncDisposable
    {
        private readonly ConnectionFactory _factory = new()
        {
            HostName = "rabbitmq",
            Port = 5672,
            UserName = "guest",
            Password = "guest"
        };

        private readonly SemaphoreSlim _connectionLock = new(1, 1);
        private IConnection? _connection;

        private async Task<IConnection> GetConnectionAsync()
        {
            if (_connection is { IsOpen: true })
                return _connection;

            await _connectionLock.WaitAsync();
            try
            {
                if (_connection is { IsOpen: true })
                    return _connection;

                if (_connection != null)
                    await _connection.DisposeAsync();

                _connection = await _factory.CreateConnectionAsync();
                return _connection;
            }
            finally
            {
                _connectionLock.Release();
            }
        }

        public async Task SendMessage<T>(T message, RabbitMqQueueEnum queue, RabbitMqRoutingKeyEnum routingKey)
        {
            var connection = await GetConnectionAsync();
            using var channel = await connection.CreateChannelAsync();

            var exchangeName = "exchange" + routingKey.ToString();

            await channel.ExchangeDeclareAsync(exchange: exchangeName, type: ExchangeType.Direct);

            await channel.QueueDeclareAsync(queue: queue.ToString(),
                                    durable: false,
                                    exclusive: false,
                                    autoDelete: false,
                                    arguments: null);

            await channel.QueueBindAsync(queue: queue.ToString(), exchange: exchangeName, routingKey.ToString());

            var body = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(message));

            await channel.BasicPublishAsync(exchange: exchangeName, routingKey: routingKey.ToString(), body: body);
        }

        public async ValueTask DisposeAsync()
        {
            if (_connection != null)
                await _connection.DisposeAsync();

            _connectionLock.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}
