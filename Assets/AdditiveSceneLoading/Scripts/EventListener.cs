using TMPro;
using UnityEngine;

public class EventListener : MonoBehaviour
{
    public TMP_Text textAsset;
    public int objectsDestroyed = 0;

    void OnEnable()
    {
        EventManager.StartListening("ObjectDestroyed", ObjectDestroyed);
    }

    void OnDisable()
    {
        EventManager.StopListening("ObjectDestroyed", ObjectDestroyed);
    }

    void ObjectDestroyed()
    {
        // Debug.Log("ObjectDestroyed");
        objectsDestroyed++;
        textAsset.text = $"Objects destroyed: {objectsDestroyed}";
    }
}
