using Ecommerce.Commons.Enums;

namespace Ecommerce.Commons.RabbitMq.Producer
{
    public interface IMessageProducer
    {
        Task SendMessage<T>(T message, RabbitMqQueueEnum queue, RabbitMqRoutingKeyEnum topic);
    }
}
