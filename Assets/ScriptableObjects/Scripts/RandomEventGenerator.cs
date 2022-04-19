using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomEventGenerator : MonoBehaviour {

    public List<RandomEventScriptableObject> randomEvents;


    public void SelectNewRandomEvent ()
    {
        int r = (int)Random.Range (0, randomEvents.Count);
        Debug.Log ("eventTitle: " + randomEvents [r].eventTitle + "; eventPolicy: " + randomEvents [r].eventPolicy);
    }



}
