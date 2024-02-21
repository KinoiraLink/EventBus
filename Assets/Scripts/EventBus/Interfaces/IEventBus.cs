using Assets.Scripts.EventBus.Events;
using System;


namespace Assets.Scripts.EventBus.Interfaces
{
    public interface IEventBus
    {
        Guid Subscribe<TIntegrationEvent>(IntegrationEventHandler<TIntegrationEvent> eventHandler) where TIntegrationEvent : IntegrationEvent;

        void UnSubscribe<TIntegrationEvent>(Guid guid) where TIntegrationEvent : IntegrationEvent;

        void Publish<TIntegrationEvent>(TIntegrationEvent integrationEvent) where TIntegrationEvent : IntegrationEvent;

    }
}
