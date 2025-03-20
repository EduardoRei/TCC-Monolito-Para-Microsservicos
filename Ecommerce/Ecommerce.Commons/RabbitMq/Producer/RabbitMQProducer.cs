using Ecommerce.Commons.Enums;
using Newtonsoft.Json;
using RabbitMQ.Client;
using System.Text;

namespace Ecommerce.Commons.RabbitMq.Producer
{
    public class RabbitMQProducer : IMessageProducer
    {
        public async Task SendMessage<T>(T message, RabbitMqQueueEnum queue, RabbitMqRoutingKeyEnum routingKey)
        {
            var factory = new ConnectionFactory() { HostName = "rabbitmq", Port = 5672, UserName = "guest", Password = "guest" };
            using var connection = await factory.CreateConnectionAsync();
            using var channel = await connection.CreateChannelAsync();

            var exchangeName = "exchange " + routingKey.ToString();

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
    }
}
