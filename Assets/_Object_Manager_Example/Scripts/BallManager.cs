using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**
 *  Instantiates ball(s) and sets origin/destinations
 */
public class BallManager : MonoBehaviour {

    public BoxCollider2D [] spawnColliders;
    public int originIndex = 0;
    public int destIndex = 0;
    public GameObject ballPrefab;

    void Start ()
    {
        // start the loop
        StartCoroutine (InitCreatorLoop (1.0f));
    }

    IEnumerator InitCreatorLoop (float wait)
    {
        while (true) {
            // after a moment
            yield return new WaitForSeconds (wait);
            // create a new ball
            CreateNewBall ();
        }
    }

    void CreateNewBall ()
    {
        // update origin index
        originIndex++;
        // make sure it isn't > than array 
        if (originIndex >= spawnColliders.Length) originIndex = 0;
        // set destination index
        if (originIndex < 2) destIndex = originIndex + 2; // 0,2 or 1,3
        else destIndex = originIndex - 2; // 2,0 or 3,1

        // get a position that doesn't contain any other colliders
        Vector3 spawnPosition = RandomPointInBounds (spawnColliders [originIndex].bounds);
        // get the spawn rotation
        Quaternion spawnRotation = new Quaternion ();
        // no random rotation
        spawnRotation.eulerAngles = new Vector3 (0f, 0f, 0f);
        // instantiate prefab @ spawn position
        GameObject obj = (GameObject)Instantiate (ballPrefab, spawnPosition, spawnRotation);
        // reference to script (contains all the other references we need)
        Ball ballScript = obj.GetComponent<Ball> ();
        // call Init() on script
        ballScript.Init (spawnPosition, RandomPointInBounds (spawnColliders [destIndex].bounds));
        // parent under Manager
        obj.transform.parent = gameObject.transform;
    }


    /**
     *  Return random Vector3 position inside bounds
     */
    public static Vector3 RandomPointInBounds (Bounds bounds)
    {
        return new Vector3 (
            Random.Range (bounds.min.x, bounds.max.x),
            Random.Range (bounds.min.y, bounds.max.y),
            0
        );
    }



}
