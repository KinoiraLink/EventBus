using Assets.Scripts.EventBus;
using Assets.Scripts.EventBus.Interfaces;
using UnityEngine;

public class EventBusHub : MonoBehaviour
{
    public IEventBus eventBus;
    // Start is called before the first frame update
    private void Awake()=>
        eventBus = new EventBus();
    
}
