using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour {

    public Vector3 origin;
    public Vector3 destination;
    public float speed = 1.0f;

    public void Init (Vector3 _origin, Vector3 _destination)
    {
        origin = _origin;
        destination = _destination;
        speed = Random.Range (0.5f, 1.5f);
    }

    void Update ()
    {
        MoveTowards (destination);
    }

    void MoveTowards (Vector3 targetPosition)
    {
        // calculate distance to move
        float step = speed * Time.deltaTime;
        // move our position a step closer to the target.
        transform.position = Vector3.MoveTowards (transform.position, targetPosition, step);

        // Check if we have reached the target
        if (Vector3.Distance (transform.position, targetPosition) < 0.001f) {
            // remove 
            Destroy (gameObject);
        }
    }


}
