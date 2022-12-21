using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibTech.Applicatrion.IntegrationEvents
{
    public interface IEventBus
    {
        void Public(IntegrationEvent @event);

        void Subscripe<T, TH>()
            where T : IntegrationEvent
            where TH : IIntegrationEventHandler<T>;

        void UnSubscripe<T, TH>()
            where TH : IIntegrationEventHandler<T>
            where T : IntegrationEvent;

    }
}
