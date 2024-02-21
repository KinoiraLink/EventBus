

namespace Assets.Scripts.EventBus.Interfaces
{
    public delegate void IntegrationEventHandler<in T>(T obj);
}
