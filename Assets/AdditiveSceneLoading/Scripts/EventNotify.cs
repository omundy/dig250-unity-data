using UnityEngine;

public class EventNotify : MonoBehaviour
{
    void OnDisable()
    {
        EventManager.TriggerEvent("ObjectDestroyed");
    }
}
