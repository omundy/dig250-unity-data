using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**
 *  Place on any object and enable / disable to send events
 */
public class EventManagerNotify : MonoBehaviour {
    void OnEnable ()
    {
        EventManager.TriggerEvent ("ObjectActive");
    }
    void OnDisable ()
    {
        EventManager.TriggerEvent ("ObjectNotActive");
    }
}
