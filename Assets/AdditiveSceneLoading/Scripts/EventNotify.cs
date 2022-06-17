using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventNotify : MonoBehaviour {


    void OnDisable ()
    {
        EventManager.TriggerEvent ("ObjectDestroyed");
    }



}
