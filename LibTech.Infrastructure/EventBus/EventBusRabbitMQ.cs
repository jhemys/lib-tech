using LibTech.Applicatrion.IntegrationEvents;
using RabbitMQ.Client;

namespace LibTech.Infrastructure.EventBus
{
    public class EventBusRabbitMQ : IEventBus, IDisposable
    {
        private readonly string _connectionString = "localhost:5672";
        public void Public(IntegrationEvent @event)
        {
            var eventName = @event.GetType().Name;
            var factory = new ConnectionFactory() { HostName = _connectionString, Password = "123456", UserName = "User" };
        }

        public void Subscripe<T, TH>()
            where T : IntegrationEvent
            where TH : IIntegrationEventHandler<T>
        {
            throw new NotImplementedException();
        }

        public void UnSubscripe<T, TH>()
            where T : IntegrationEvent
            where TH : IIntegrationEventHandler<T>
        {
            throw new NotImplementedException();
        }
        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
