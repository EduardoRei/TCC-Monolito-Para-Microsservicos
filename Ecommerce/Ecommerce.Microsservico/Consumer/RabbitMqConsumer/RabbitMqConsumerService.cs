using Ecommerce.Commons.Enums;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System.Text;

namespace RabbitMqConsumer
{
    record RabbitRoutingInfos(string QueueName, string Exchange, RabbitMqRoutingKeyEnum RoutingKey);

    public class RabbitMqConsumerService
    {
        private readonly IChannel _channel;
        private readonly IHttpClientService _httpClientService;
        private readonly List<RabbitRoutingInfos> _routingConfigs;

        public RabbitMqConsumerService(IChannel channel)
        {
            _channel = channel;
            _httpClientService = new HttpClientService();
            _routingConfigs = ObterConfiguracoes();
        }

        public async Task SetupConsumers()
        {
            foreach (var config in _routingConfigs)
            {
                await DeclararExchangeEFila(config);
                await ConfigurarConsumer(config);
            }
        }

        private List<RabbitRoutingInfos> ObterConfiguracoes()
        {
            return new List<RabbitRoutingInfos>
        {
            new(RabbitMqQueueEnum.PagamentoQueue.ToString(), "exchangePagamentoPedidoCriado", RabbitMqRoutingKeyEnum.PagamentoPedidoCriado),
            new(RabbitMqQueueEnum.PagamentoQueue.ToString(), "exchangePagamentoPedidoEvento", RabbitMqRoutingKeyEnum.PagamentoPedidoEvento),
            new(RabbitMqQueueEnum.PedidoQueue.ToString(), "exchangePedidoPagamento", RabbitMqRoutingKeyEnum.PedidoPagamento),
            new(RabbitMqQueueEnum.PedidoQueue.ToString(), "exchangePedidoProduto", RabbitMqRoutingKeyEnum.PedidoProduto),
        };
        }

        private async Task DeclararExchangeEFila(RabbitRoutingInfos config)
        {
            await _channel.ExchangeDeclareAsync(config.Exchange, ExchangeType.Direct, durable: false, autoDelete: false);
            await _channel.QueueDeclareAsync(config.QueueName, durable: false, exclusive: false, autoDelete: false);
            await _channel.QueueBindAsync(config.QueueName, config.Exchange, config.RoutingKey.ToString());
        }

        private async Task ConfigurarConsumer(RabbitRoutingInfos config)
        {
            var consumer = new AsyncEventingBasicConsumer(_channel);
            consumer.ReceivedAsync += async (model, ea) =>
            {
                var message = Encoding.UTF8.GetString(ea.Body.ToArray());
                await ProcessMessageAsync(config.RoutingKey, message);
            };

            await _channel.BasicConsumeAsync(config.QueueName, autoAck: true, consumer);
        }

        private async Task ProcessMessageAsync(RabbitMqRoutingKeyEnum routingKey, string message)
        {
            try
            {
                switch (routingKey)
                {
                    case RabbitMqRoutingKeyEnum.PagamentoPedidoCriado:
                        await _httpClientService.PutPedidoIdPagamentoAsync(message);
                        break;
                    case RabbitMqRoutingKeyEnum.PagamentoPedidoEvento:
                        await _httpClientService.PutStatusPagamentoAsync(message);
                        break;
                    case RabbitMqRoutingKeyEnum.PedidoPagamento:
                        await _httpClientService.PostCriarPagamentoAsync(message);
                        break;
                    case RabbitMqRoutingKeyEnum.PedidoProduto:
                        await _httpClientService.PutQuantidadeProdutoAsync(message);
                        break;
                    default:
                        Console.WriteLine($"Routing Key desconhecida: {routingKey}");
                        break;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro ao processar mensagem: {ex.Message}");
            }
        }
    }

}
