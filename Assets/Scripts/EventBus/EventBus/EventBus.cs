using Assets.Scripts.EventBus.Events;
using Assets.Scripts.EventBus.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Assets.Scripts.EventBus
{
    public class EventBus : IEventBus
    {
        private readonly Dictionary<Type, List<ISubscription>> _subscriptions;

        public EventBus()
        {
            _subscriptions = new Dictionary<Type, List<ISubscription>>();
        }


        public Guid Subscribe<TIntegrationEvent>(IntegrationEventHandler<TIntegrationEvent> eventHandler) where TIntegrationEvent : IntegrationEvent
        {

            Type type = typeof(TIntegrationEvent);

            if (!_subscriptions.ContainsKey(type))
            {
                _subscriptions.Add(type, new List<ISubscription>());
            }
            _subscriptions[type].Add(new Subscription<TIntegrationEvent>(eventHandler, out var guid));

            return guid;

        }

        public void UnSubscribe<TIntegrationEvent>(Guid guid) where TIntegrationEvent : IntegrationEvent
        {
            Type type = typeof(TIntegrationEvent);
            if (_subscriptions.ContainsKey(type))
            {
                var subcriptionByType = _subscriptions[type];
                var subscritonToRemove = subcriptionByType.Where(p => p.Id == guid).FirstOrDefault();
                if (subscritonToRemove != null)
                {
                    _subscriptions[type].Remove(subscritonToRemove);
                }

            }
        }

        public void Publish<TIntegrationEvent>(TIntegrationEvent integrationEvent) where TIntegrationEvent : IntegrationEvent
        {
            var subcriptionByType = new List<ISubscription>();

            Type type = typeof(TIntegrationEvent);
            if (_subscriptions.ContainsKey(type))
            {
                subcriptionByType = _subscriptions[type];
            }
            foreach (var subscription in subcriptionByType)
            {
                subscription.Publish(integrationEvent);
            }
        }
    }
    
}
