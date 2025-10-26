
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

/**
 *  Instantiates ball(s) and sets origin/destinations
 */
public class BallManager : MonoBehaviour
{
    public bool createFromSinglePoint;
    public bool createFromMultiplePoints;
    public bool createFromMultipleColliders;

    public float spawnInterval = 1.0f;

    public GameObject ballPrefab;
    public Transform[] spawnPoints;
    public BoxCollider2D[] spawnColliders;
    public int originIndex = 0;
    public int destIndex = 0;

    void Start()
    {
        // start the loop
        StartCoroutine(InitCreatorLoop());
    }

    IEnumerator InitCreatorLoop()
    {
        while (true)
        {
            // change the spawnInterval if you like
            // spawnInterval = Random.Range(1.0f, 3.0f);
            // after a moment
            yield return new WaitForSeconds(spawnInterval);

            if (createFromSinglePoint)
                CreateNewBallFromSinglePoint();
            if (createFromMultiplePoints)
                CreateNewBallFromMultiplePoints();
            if (createFromMultipleColliders)
                CreateNewBallFromMultipleBounds();
        }
    }

    void CreateNewBallFromSinglePoint()
    {
        // add ball to world
        AddGameObjectToWorld(ballPrefab, spawnPoints[2].position, spawnPoints[0].position, Color.red);
    }

    void CreateNewBallFromMultiplePoints()
    {
        // increase origin index (reset to zero if greater than num spawn locations)
        originIndex = originIndex + 1 >= spawnPoints.Length ? 0 : ++originIndex;
        // set destination index to opposite side (0=>2, 1=>3, 2=>0, 3=>1)
        destIndex = originIndex < 2 ? originIndex + 2 : originIndex - 2;
        // add ball to world
        AddGameObjectToWorld(ballPrefab, spawnPoints[originIndex].position, spawnPoints[destIndex].position, Color.green);
    }

    void CreateNewBallFromMultipleBounds()
    {
        // increase origin index (reset to zero if greater than num spawn locations)
        originIndex = originIndex + 1 >= spawnColliders.Length ? 0 : ++originIndex;
        // set destination index to opposite side (0=>2, 1=>3, 2=>0, 3=>1)
        destIndex = originIndex < 2 ? originIndex + 2 : originIndex - 2;
        // add ball to world
        AddGameObjectToWorld(
            ballPrefab,
            // a random position inside the collider bounds
            RandomPointInBounds(spawnColliders[originIndex].bounds),
            RandomPointInBounds(spawnColliders[destIndex].bounds),
            Color.blue
        );
    }

    // basic instantiate script
    void AddGameObjectToWorld(GameObject prefab, Vector3 spawnPosition, Vector3 destPosition, Color color)
    {
        // spawn rotation
        Quaternion spawnRotation = new Quaternion();
        // no random rotation
        spawnRotation.eulerAngles = new Vector3(0f, 0f, 0f);
        // instantiate prefab @ spawn position
        GameObject obj = (GameObject)Instantiate(ballPrefab, spawnPosition, spawnRotation);
        // reference to script (contains all the other references we need)
        Ball ballScript = obj.GetComponent<Ball>();
        // call Init() on script
        ballScript.Init(spawnPosition, destPosition, color);
        // parent under Manager
        obj.transform.parent = gameObject.transform;
    }

    /**
     *  Return random Vector3 position inside bounds
     */
    public static Vector3 RandomPointInBounds(Bounds bounds)
    {
        return new Vector3(
            Random.Range(bounds.min.x, bounds.max.x),
            Random.Range(bounds.min.y, bounds.max.y),
            0
        );
    }



}
