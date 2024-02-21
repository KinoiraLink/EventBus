using Assets.Scripts.EventBus.Events;
using System;


namespace Assets.Scripts.EventBus.Interfaces
{
    public interface ISubscription
    {
        Guid Id { get; }
        void Publish(IntegrationEvent integrationEvent);
    }
}
