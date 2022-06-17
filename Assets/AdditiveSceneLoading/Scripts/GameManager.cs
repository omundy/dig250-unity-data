using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {
    public int objectsDestroyed = 0;


    void OnEnable ()
    {
        EventManager.StartListening ("ObjectDestroyed", ObjectDestroyed);
    }

    void OnDisable ()
    {
        EventManager.StopListening ("ObjectDestroyed", ObjectDestroyed);
    }

    void ObjectDestroyed ()
    {
        Debug.Log ("ObjectDestroyed");
        objectsDestroyed++;
    }



}
