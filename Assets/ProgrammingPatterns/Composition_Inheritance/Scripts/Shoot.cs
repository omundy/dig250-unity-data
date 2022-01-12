using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour {

    public float headingAngle;

    void Start ()
    {
    }

    void Update ()
    {
        // Get a copy of your forward vector
        Vector3 forward = transform.forward;
        // Zero out the y component of your forward vector to only get the direction in the X,Z plane
        forward.y = 0;
        headingAngle = Quaternion.LookRotation (forward).eulerAngles.y;
    }

}
