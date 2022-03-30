using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**
 *  Place on a 3D object to "listen" for events
 */
public class EventManagerTest : MonoBehaviour {

    void OnEnable ()
    {
        EventManager.StartListening ("ObjectActive", ObjectActive);
        EventManager.StartListening ("ObjectNotActive", ObjectNotActive);
    }

    void OnDisable ()
    {
        EventManager.StopListening ("ObjectActive", ObjectActive);
        EventManager.StopListening ("ObjectNotActive", ObjectNotActive);
    }

    void ObjectActive ()
    {
        gameObject.GetComponent<MeshRenderer> ().material.color = Color.green;
    }
    void ObjectNotActive ()
    {
        gameObject.GetComponent<MeshRenderer> ().material.color = Color.red;
    }

}
