using Assets.Scripts.EventBus.Events;
using Assets.Scripts.EventBus.Interfaces;
using System;

namespace Assets.Scripts.EventBus
{
    public class Subscription<TIntegrationEvent> : ISubscription where TIntegrationEvent : IntegrationEvent
    {
        private readonly IntegrationEventHandler<TIntegrationEvent> integrationEventHandler;
        public Guid Id { get; }

        public Subscription(IntegrationEventHandler<TIntegrationEvent> integrationEventHandler,out Guid Id)
        {
            this.integrationEventHandler = integrationEventHandler;
            
            Id = Guid.NewGuid();
            
        }

        public void Publish(IntegrationEvent integrationEvent)
        {
            
            integrationEventHandler.Invoke(integrationEvent as TIntegrationEvent);

        }
    }
}
